﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capacity;
using Effects;
using GameViewDir;

namespace GameModelDir
{
    public class StartGameInitializePresenter : IPresenter
    {
        private readonly GameModel _gameModel;
        private readonly GameView _gameView;
        private Dictionary<Capacity.Capacity, List<IPresenter>> _elementsPresenters;

        public StartGameInitializePresenter(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
            _elementsPresenters = new Dictionary<Capacity.Capacity, List<IPresenter>>();
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
            var elementsDescription = _gameView.Elements;
            var reactionDescription = _gameView.Reactions;

            foreach (var elementDescr in elementsDescription)
            {
                Capacity.Capacity newCapacity = new Capacity.Capacity(elementDescr.InitialElement.Name, elementDescr.InitialElement.Formula, elementDescr.InitialElement.EnvironmentType);

                List<IPresenter> Presenters = new()
                {
                    new OpenCloseInfoWindowPresenter(newCapacity, elementDescr),
                    new ChangeTextInfoPresenter(newCapacity, elementDescr)
                };
                
                _elementsPresenters.Add(newCapacity, Presenters);
                
                _gameModel.ElementsMap.Add(elementDescr.InitialElement.Name, newCapacity);
                _gameView.CurrentElements.Add(elementDescr.InitialElement.Name, elementDescr);
            }

            foreach (var reactionDesc in reactionDescription)
            {
                _gameModel.ReactionsMap.Add(CreateKey(reactionDesc.Elements), new Reaction(reactionDesc.Elements, reactionDesc.ResultElements, CreateEffects(reactionDesc.Effects)));
            }
            
            foreach (var presenters in _elementsPresenters.Values)
            {
                foreach (var presenter in presenters)
                {
                    presenter.Subscribe();
                }
            }

            InitializeTextInfo();
        }


        private void InitializeTextInfo()
        {
            foreach (var value in _gameModel.ElementsMap.Values)
            {
                value.ChangeText(value.Formula);
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