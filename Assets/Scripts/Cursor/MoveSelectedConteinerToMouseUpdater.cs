using GameModelDir;
using GameViewDir;
using UnityEngine;

namespace Cursor
{
    public class MoveSelectedConteinerToMouseUpdater : IUpdater
    {
        private readonly GameModel _gameModel;
        private readonly GameView _gameView;

        public MoveSelectedConteinerToMouseUpdater(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }

        public void Update()
        {
            if (_gameModel.CurrentState != GameState.CapacitySelected) return;
            _gameModel.CursorModel.SelectedTarget.transform.position = _gameModel.CursorModel.CursorPosition;
        }
    }
}