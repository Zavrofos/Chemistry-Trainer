using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapacityDir;
using Cursor;
using Effects;
using GameViewDir;
using UnityEngine;

namespace GameModelDir
{
    public class StartGameInitializePresenter : IPresenter
    {
        private readonly GameModel _gameModel;
        private readonly GameView _gameView;
        private Dictionary<Capacity, List<IPresenter>> _elementsPresenters;
        private int numberId = 0;

        public StartGameInitializePresenter(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
            _elementsPresenters = new Dictionary<Capacity, List<IPresenter>>();
        }
        
        public void Subscribe()
        {
            _gameModel.Initialized += OnInitializeStartGame;
        }

        public void UnSubscribe()
        {
            _gameModel.Initialized += OnInitializeStartGame;
            
            foreach (var presenters in _elementsPresenters.Values)
            {
                foreach (var presenter in presenters)
                {
                    presenter.UnSubscribe();
                }
            }
        }

        private void OnInitializeStartGame()
        {
            var elementsDescription = _gameView.ElementsInfo;
            var reactionDescription = _gameView.ReactionsInfo;
            var capacityesInitial = _gameView.InitialCapacityes;

            foreach (var elementDescr in elementsDescription)
            {
                _gameModel.ElementsInfoMap.Add(elementDescr.Name, elementDescr);
            }

            foreach (var reactionDesc in reactionDescription)
            {
                _gameModel.ReactionsMap.Add(CreateKey(reactionDesc.Elements), 
                    new Reaction(reactionDesc.Elements, reactionDesc.ResultElements, CreateEffects(reactionDesc.Effects)));
            }

            foreach (var capacityView in capacityesInitial)
            {
                capacityView.Id = numberId;
                
                List<Element> elements = new List<Element>();
                foreach (var element in capacityView.InitialElements)
                {
                    Element newElement = new Element(element.Name, element.Formula, element.EnvironmentType, Color.white);
                    elements.Add(newElement);
                }

                Capacity newCapacity = new Capacity(numberId, elements, capacityView.transform.position,
                    capacityView.transform.rotation, capacityView.gameObject.layer, new Vector3(-130, 0, 0),
                    capacityView.PointPositionTilt.position);
                _gameModel.CapacityesMap.Add(numberId, newCapacity);
                _gameView.CurrentCapacityes.Add(numberId, capacityView);
                numberId++;

                List<IPresenter> presenters = new()
                {
                    new OpenCloseInfoWindowPresenter(newCapacity, capacityView),
                    new DisplayTextInfoPresenter(newCapacity, capacityView), 
                    new AddingElementsToCapacityPresenter(newCapacity, capacityView, _gameModel),
                    new EmptyCapacityPresenter(newCapacity, capacityView)
                };
                
                _elementsPresenters.Add(newCapacity, presenters);

                foreach (var presentersValue in _elementsPresenters.Values)
                {
                    foreach (var presenter in presentersValue)
                    {
                        presenter.Subscribe();
                    }
                }
            }
            
            InitializeTextInfo();
        }


        private void InitializeTextInfo()
        {
            foreach (var value in _gameModel.CapacityesMap.Values)
            {
                value.DisplayInfoText();
            }
        }

        private string CreateKey(string[] elements)
        {
            string[] elementsNew = elements.ToArray();
            Array.Sort(elementsNew);
            StringBuilder key = new StringBuilder();
            foreach (var s in elementsNew)
            {
                key.Append(s);
            }

            return key.ToString();
        }

        private IEffect[] CreateEffects(EffectDescr[] effectsDescrs)
        {
            IEffect[] effects = new IEffect[effectsDescrs.Length];
            for (int i = 0; i < effectsDescrs.Length; i++)
            {
                effects[i] = effectsDescrs[i].GetEffect();
            }
            return effects;
        }
    }
}