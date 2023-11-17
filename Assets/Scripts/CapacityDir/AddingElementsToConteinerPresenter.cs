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

        private void OnAddNewElements(List<Element> elements)
        {
            _model.PreviousElements.Clear();
            _model.CurrentElements.AddRange(elements);
            var currentElements = _model.CurrentElements;
            
            string key = CreateKey(_model.CurrentElements);
            bool changed = false;
            
            if(_gameModel.CollectionsOfReactions.ReactionsMap.ContainsKey(key))
            {
                List<Element> newElements = new List<Element>();
                foreach (var element in _gameModel.CollectionsOfReactions.ReactionsMap[key].ResultElements)
                {
                    ElementDescr descriptionEl = _gameModel.ElementsInfoMap[element];
                    Element newElement = new Element(descriptionEl.Name, descriptionEl.Formula,
                        descriptionEl.EnvironmentType);
                    newElements.Add(newElement);

                    changed = true;
                }
                
                _model.CurrentElements = newElements;
                _gameModel.CollectionsOfReactions.ReactionsMap[key].StartReaction(_view);
            }

            if (changed)
            {
                _model.PreviousElements.AddRange(currentElements);
            }
            
            _model.DisplayInfoText();
        }
        
        private string CreateKey(List<Element> elements)
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