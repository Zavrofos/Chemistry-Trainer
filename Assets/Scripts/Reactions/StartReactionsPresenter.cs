using CapacityDir;
using GameModelDir;
using GameViewDir;
using UnityEngine.UIElements;

namespace Reactions
{
    public class StartReactionsPresenter : IPresenter
    {
        private readonly Reaction _model;
        private readonly GameModel _gameModel;

        public StartReactionsPresenter(Reaction model, GameModel gameModel)
        {
            _model = model;
            _gameModel = gameModel;
        }
        
        public void Subscribe()
        {
            _model.StartedReaction += OnStartReaction;
        }

        public void UnSubscribe()
        {
            _model.StartedReaction -= OnStartReaction;
        }

        private void OnStartReaction()
        {
            foreach (var effect in _model.Effects)
            {
                effect.SetEffect(_gameModel);
            }
        }
    }
}