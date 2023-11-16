using Cursor;
using GameModelDir;
using GameViewDir;
using Unity.VisualScripting;
using UnityEngine;

namespace CapacityDir
{
    public class TiltingCapacityPresenter : IPresenter
    {
        private readonly GameModel _gameModel;
        private readonly GameView _gameView;

        public TiltingCapacityPresenter(GameModel gameModel, GameView gameView)
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
            
            if (cursorModel.CurrentState == CursorState.Idle) return;
            CapacityView selectedCapacity = cursorModel.SelectedTarget.GetComponent<CapacityView>();
            if (cursorModel.TargetAtGunPoint.TryGetComponent(out CapacityView capacity))
            {
                selectedCapacity.transform.rotation = Quaternion.Euler(_gameModel.CapacityesMap[capacity.Id].RotationTilt);
                selectedCapacity.transform.position =
                    _gameModel.CapacityesMap[capacity.Id].PointPositionTilt;
                cursorModel.CurrentState = CursorState.CapacityTilt;
            }
            else
            {
                selectedCapacity.transform.rotation =
                    _gameModel.CapacityesMap[selectedCapacity.Id].InitialRotation;
                cursorModel.CurrentState = CursorState.CapacitySelected;
            }
        }
    }
}