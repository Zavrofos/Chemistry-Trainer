﻿using Cursor;
using GameModelDir;

namespace CapacityDir
{
    public class ReturnToInitialPositionConteinerPresenter : IPresenter
    {
        private readonly Container _model;
        private readonly ConteinerView _view;
        private readonly GameModel _gameModel;

        public ReturnToInitialPositionConteinerPresenter(Container model, ConteinerView view, GameModel gameModel)
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
            _gameModel.CurrentState = GameState.Idle;
            _model.DisplayInfoText();
            _gameModel.CursorModel.SelectedTarget = null;
        }
    }
}