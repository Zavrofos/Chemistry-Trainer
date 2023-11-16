using Cursor;
using GameModelDir;

namespace CapacityDir
{
    public class ReturnToInitialPositionCapacityPresenter : IPresenter
    {
        private readonly Capacity _model;
        private readonly CapacityView _view;
        private readonly GameModel _gameModel;

        public ReturnToInitialPositionCapacityPresenter(Capacity model, CapacityView view, GameModel gameModel)
        {
            _model = model;
            _view = view;
            _gameModel = gameModel;
        }
        
        public void Subscribe()
        {
            _model.ReturnedToInitialPosition += OnReturnCapacity;
        }

        public void UnSubscribe()
        {
            _model.ReturnedToInitialPosition += OnReturnCapacity;
        }

        private void OnReturnCapacity()
        {
            _view.transform.position = _model.InitialPositin;
            _view.transform.rotation = _model.InitialRotation;
            _view.gameObject.layer = _model.InitialLayer;
            _gameModel.CursorModel.CurrentState = CursorState.Idle;
            _gameModel.CursorModel.SelectedTarget = null;
        }
    }
}