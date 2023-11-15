
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Effects;
using Elements;
using GameViewDir;

namespace GameModelDir
{
    public class StartGameInitializePresenter : IPresenter
    {
        private readonly GameModel _gameModel;
        private readonly GameView _gameView;
        private Dictionary<Element, List<IPresenter>> _elementsPresenters;

        public StartGameInitializePresenter(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
            _elementsPresenters = new Dictionary<Element, List<IPresenter>>();
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
                Element newElement = new Element(elementDescr.Description.Name, elementDescr.Description.Formula, elementDescr.Description.EnvironmentType);

                List<IPresenter> Presenters = new()
                {
                    new OpenCloseInfoWindowPresenter(newElement, elementDescr)
                };
                
                _elementsPresenters.Add(newElement, Presenters);
                
                _gameModel.ElementsMap.Add(elementDescr.Description.Name, newElement);
                _gameView.CurrentElements.Add(elementDescr.Description.Name, elementDescr);
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