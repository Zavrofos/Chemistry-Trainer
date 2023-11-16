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
            CursorModel cursorModel = _gameModel.CursorModel;
            if (cursorModel.CurrentState != CursorState.CapacityTilt) return;
            ConteinerView selectedConteiner = cursorModel.SelectedTarget.GetComponent<ConteinerView>();
            if (!cursorModel.TargetAtGunPoint.GetComponent<ConteinerView>())
            {
                selectedConteiner.transform.rotation = _gameModel.CapacityesMap[selectedConteiner.Id].InitialRotation;
                cursorModel.CurrentState = CursorState.CapacitySelected;
            }
        }
    }
}