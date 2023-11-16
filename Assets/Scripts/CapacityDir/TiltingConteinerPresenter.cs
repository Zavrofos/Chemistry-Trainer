using Cursor;
using GameModelDir;
using GameViewDir;
using Unity.VisualScripting;
using UnityEngine;

namespace CapacityDir
{
    public class TiltingConteinerPresenter : IPresenter
    {
        private readonly GameModel _gameModel;
        private readonly GameView _gameView;

        public TiltingConteinerPresenter(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }

        public void Subscribe()
        {
            _gameModel.CursorModel.AimedAtTheTarget += OnTiltCapacity;
        }

        public void UnSubscribe()
        {
            _gameModel.CursorModel.AimedAtTheTarget -= OnTiltCapacity;
        }

        private void OnTiltCapacity(GameObject target)
        {
            CursorModel cursorModel = _gameModel.CursorModel;
            if (cursorModel.CurrentState != CursorState.CapacitySelected) return;
            ConteinerView selectedConteiner = cursorModel.SelectedTarget.GetComponent<ConteinerView>();
            if (cursorModel.TargetAtGunPoint.TryGetComponent(out ConteinerView capacity))
            {
                selectedConteiner.transform.rotation = Quaternion.Euler(_gameModel.CapacityesMap[capacity.Id].RotationTilt);
                selectedConteiner.transform.position =
                    _gameModel.CapacityesMap[capacity.Id].PointPositionTilt;
                cursorModel.CurrentState = CursorState.CapacityTilt;
            }
        }
    }
}