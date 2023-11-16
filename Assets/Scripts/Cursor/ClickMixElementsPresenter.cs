using System.Collections.Generic;
using CapacityDir;
using GameModelDir;
using GameViewDir;

namespace Cursor
{
    public class ClickMixElementsPresenter : IPresenter
    {
        private readonly GameModel _gameModel;
        private readonly GameView _gameView;

        public ClickMixElementsPresenter(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }

        public void Subscribe()
        {
            _gameModel.CursorModel.ClickedMouse0 += OnMixElements;
        }

        public void UnSubscribe()
        {
            _gameModel.CursorModel.ClickedMouse0 -= OnMixElements;
        }

        private void OnMixElements()
        {
            if (_gameModel.CursorModel.CurrentState != CursorState.CapacityTilt) return;
            CapacityView capacityViewTarget = _gameModel.CursorModel.TargetAtGunPoint.GetComponent<CapacityView>();
            CapacityView capacityViewSelected = _gameModel.CursorModel.SelectedTarget.GetComponent<CapacityView>();
            
            _gameModel.CapacityesMap[capacityViewTarget.Id].AddElement(_gameModel.CapacityesMap[capacityViewSelected.Id].CurrentElements);
            _gameModel.CapacityesMap[capacityViewSelected.Id].EmptyCapacity();
            _gameModel.CapacityesMap[capacityViewSelected.Id].ReturnToInitialPosition();
            
        }
    }
}