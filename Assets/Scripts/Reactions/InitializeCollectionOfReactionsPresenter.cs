using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Effects;
using GameModelDir;
using GameViewDir;

namespace Reactions
{
    public class InitializeCollectionOfReactionsPresenter : IPresenter
    {
        private readonly GameModel _gameModel;
        private readonly GameView _gameView;
        private readonly Dictionary<Reaction, List<IPresenter>> _reactionsPresenters;

        public InitializeCollectionOfReactionsPresenter(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
            _reactionsPresenters = new Dictionary<Reaction, List<IPresenter>>();
        }
        
        public void Subscribe()
        {
            _gameModel.CollectionsOfReactions.Initialized += OnInitialize;
        }

        public void UnSubscribe()
        {
            _gameModel.CollectionsOfReactions.Initialized += OnInitialize;
        }

        private void OnInitialize()
        {
            foreach (var reactionDesc in _gameView.ReactionsInfo)
            {
                Reaction newReaction = new Reaction(reactionDesc.Elements, reactionDesc.ResultElements,
                    CreateEffects(reactionDesc.Effects));

                _gameModel.CollectionsOfReactions.ReactionsMap.Add(CreateKey(reactionDesc.Elements), newReaction);

                List<IPresenter> presenters = new()
                {
                    new StartReactionsPresenter(newReaction, _gameModel)
                };

                foreach (var presenter in presenters)
                {
                    presenter.Subscribe();
                }
                
                _reactionsPresenters.Add(newReaction, presenters);
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