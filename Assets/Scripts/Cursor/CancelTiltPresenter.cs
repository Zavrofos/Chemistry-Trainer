using CapacityDir;
using GameModelDir;
using GameViewDir;
using UnityEngine;

namespace Cursor
{
    public class CancelTiltPresenter : IPresenter
    {
        private readonly GameModel _gameModel;
        private readonly GameView _gameView;

        public CancelTiltPresenter(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }
        
        public void Subscribe()
        {
            _gameModel.CursorModel.AimedAtTheTarget += OnCancelTilt;
        }

        public void UnSubscribe()
        {
            _gameModel.CursorModel.AimedAtTheTarget -= OnCancelTilt;
        }

        private void OnCancelTilt(GameObject obj)
        {
            if (_gameModel.CurrentState != GameState.CapacityTilt) return;
            CursorModel cursorModel = _gameModel.CursorModel;
            ConteinerView selectedConteiner = cursorModel.SelectedTarget.GetComponent<ConteinerView>();
            if (!cursorModel.TargetAtGunPoint.TryGetComponent<ConteinerView>(out _))
            {
                selectedConteiner.transform.rotation = _gameModel.CollectionOfContainers.ConteinersMap[selectedConteiner.Id].InitialRotation;
                _gameModel.CurrentState = GameState.CapacitySelected;
            }
        }
    }
}