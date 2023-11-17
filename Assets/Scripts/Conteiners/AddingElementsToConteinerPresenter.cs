using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Description_Objects;
using GameModelDir;
using UnityEngine;

namespace CapacityDir
{
    public class AddingElementsToConteinerPresenter : IPresenter
    {
        private readonly Conteiner _model;
        private readonly ConteinerView _view;
        private readonly GameModel _gameModel;

        public AddingElementsToConteinerPresenter(Conteiner model, ConteinerView view, GameModel gameModel)
        {
            _model = model;
            _view = view;
            _gameModel = gameModel;
        }
        
        public void Subscribe()
        {
            _model.AddedElement += OnAddNewElements;
        }

        public void UnSubscribe()
        {
            _model.AddedElement -= OnAddNewElements;
        }

        private void OnAddNewElements(List<ElementDescr> elements)
        {
            _model.PreviousElements.Clear();
            
            if (_model.CurrentElements.Count == 0)
            {
                ConteinerView selectedConteiner = _gameModel.CursorModel.SelectedTarget.GetComponent<ConteinerView>();
                _gameModel.CollectionOfConteiners.ConteinersMap[_view.Id].AddFiller(selectedConteiner.Filler);
            }

            foreach (var element in elements)
            {
                if (!_model.CurrentElements.Contains(element))
                {
                    _model.CurrentElements.Add(element);
                }
            }
            
            var currentElements = _model.CurrentElements;
            
            string key = CreateKey(_model.CurrentElements);
            bool changed = false;
            
            if(_gameModel.CollectionsOfReactions.ReactionsMap.ContainsKey(key))
            {
                List<ElementDescr> newElements = new List<ElementDescr>();
                foreach (var element in _gameModel.CollectionsOfReactions.ReactionsMap[key].ResultElements)
                {
                    ElementDescr descriptionEl = _gameModel.ElementsInfoMap[element];
                    newElements.Add(descriptionEl);

                    changed = true;
                }
                
                _model.CurrentElements = newElements;
                _gameModel.CollectionsOfReactions.ReactionsMap[key].StartReaction();
            }

            if (changed)
            {
                _model.PreviousElements.AddRange(currentElements);
            }
            
            _model.DisplayInfoText();
        }
        
        private string CreateKey(List<ElementDescr> elements)
        {
            string[] names = new string[elements.Count];

            for (int i = 0; i < names.Length; i++)
            {
                names[i] = elements[i].Name;
            }
            Array.Sort(names);
            StringBuilder key = new StringBuilder();
            foreach (var s in names)
            {
                key.Append(s);
            }
            return key.ToString();
        }
    }
}