using GameModelDir;
using GameViewDir;
using UnityEngine;

namespace Cursor
{
    public class MoveSelectedCapacityToMouseUpdater : IUpdater
    {
        private readonly GameModel _gameModel;
        private readonly GameView _gameView;

        public MoveSelectedCapacityToMouseUpdater(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }

        public void Update()
        {
            if (_gameModel.CursorModel.CurrentState != CursorState.CapacitySelected) return;
            _gameModel.CursorModel.SelectedTarget.transform.position = _gameModel.CursorModel.CursorPosition;
        }
    }
}