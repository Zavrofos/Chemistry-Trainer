using CapacityDir;
using GameModelDir;
using GameViewDir;
using UnityEngine;

namespace Cursor
{
    public class TakeConteinerPresenter : IPresenter
    {
        private readonly GameModel _gameModel;
        private readonly GameView _gameView;

        public TakeConteinerPresenter(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }
        
        public void Subscribe()
        {
            _gameModel.CursorModel.TakedCapacity += OnTakeCapacity;
        }

        public void UnSubscribe()
        {
            _gameModel.CursorModel.TakedCapacity -= OnTakeCapacity;
        }

        private void OnTakeCapacity()
        {
            if (_gameModel.CursorModel.TargetAtGunPoint.TryGetComponent(out ConteinerView capacity))
            {
                _gameModel.CapacityesMap[capacity.Id].CloseInformationWindow();
                _gameModel.CursorModel.CurrentState = CursorState.CapacitySelected;
                _gameModel.CursorModel.SelectedTarget = _gameModel.CursorModel.TargetAtGunPoint;
                _gameModel.CursorModel.SelectedTarget.layer = LayerMask.NameToLayer($"IgnoreObject");
            }
        }
    }
}