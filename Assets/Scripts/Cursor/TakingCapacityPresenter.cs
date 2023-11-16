using CapacityDir;
using GameModelDir;
using GameViewDir;
using Unity.VisualScripting;
using UnityEngine;

namespace Cursor
{
    public class TakingCapacityPresenter : IPresenter
    {
        private readonly GameModel _gameModel;
        private readonly GameView _gameView;

        public TakingCapacityPresenter(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }
        
        public void Subscribe()
        {
            _gameModel.CursorModel.ClickedMouse0 += OnChooseCapacity;
        }

        public void UnSubscribe()
        {
            _gameModel.CursorModel.ClickedMouse0 -= OnChooseCapacity;
        }

        private void OnChooseCapacity()
        {
            if (_gameModel.CursorModel.CurrentState == CursorState.CapacitySelected) return;
            
            if (_gameModel.CursorModel.TargetAtGunPoint.TryGetComponent(out CapacityView capacity))
            {
                _gameModel.ElementsMap[capacity.InitialElement.Name].CloseInformationWindow();
                
                _gameModel.CursorModel.CurrentState = CursorState.CapacitySelected;
                _gameModel.CursorModel.SelectedTarget = _gameModel.CursorModel.TargetAtGunPoint;
                _gameModel.CursorModel.SelectedTarget.layer = LayerMask.NameToLayer($"IgnoreObject");
            }
        }
    }
}