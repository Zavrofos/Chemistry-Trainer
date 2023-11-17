using CapacityDir;
using GameModelDir;
using GameViewDir;
using UnityEngine;

namespace Cursor
{
    public class ClickMouse0Updater : IUpdater
    {
        private readonly GameModel _gameModel;
        private readonly GameView _gameView;

        public ClickMouse0Updater(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }

        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _gameModel.CursorModel.ClickMouse0();
            }
        }
    }
}