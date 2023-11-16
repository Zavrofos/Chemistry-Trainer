using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Description_Objects;
using GameModelDir;
using UnityEngine;

namespace CapacityDir
{
    public class AddingElementsToCapacityPresenter : IPresenter
    {
        private readonly Capacity _model;
        private readonly CapacityView _view;
        private readonly GameModel _gameModel;

        public AddingElementsToCapacityPresenter(Capacity model, CapacityView view, GameModel gameModel)
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
            _model.CurrentElements.AddRange(elements);
            string key = CreateKey(_model.CurrentElements);
            if(_gameModel.ReactionsMap.ContainsKey(key))
            {
                List<Element> newElements = new List<Element>();
                foreach (var element in _gameModel.ReactionsMap[key].ResultElements)
                {
                    ElementDescr descriptionEl = _gameModel.ElementsInfoMap[element];
                    Element newElement = new Element(descriptionEl.Name, descriptionEl.Formula,
                        descriptionEl.EnvironmentType, Color.white);
                    newElements.Add(newElement);
                }
                _model.CurrentElements = newElements;
                _model.DisplayInfoText();
                _gameModel.ReactionsMap[key].StartReaction(_view);
            }
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