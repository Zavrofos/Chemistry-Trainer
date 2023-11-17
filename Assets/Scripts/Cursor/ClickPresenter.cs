using GameModelDir;
using GameViewDir;

namespace Cursor
{
    public class ClickPresenter : IPresenter
    {
        private readonly GameModel _gameModel;
        private readonly GameView _gameView;

        public ClickPresenter(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }
        
        public void Subscribe()
        {
            _gameModel.CursorModel.ClickedMouse0 += OnClick;
        }

        public void UnSubscribe()
        {
            _gameModel.CursorModel.ClickedMouse0 -= OnClick;
        }

        private void OnClick()
        {
            if (_gameModel.CurrentState == GameState.Idle)
            {
                _gameModel.CursorModel.TakeContainer();
            }

            if (_gameModel.CurrentState == GameState.CapacityTilt)
            {
                _gameModel.CursorModel.MixElements();
            }
        }
    }
}