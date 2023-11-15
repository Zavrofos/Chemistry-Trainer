using GameModelDir;
using GameViewDir;
using UnityEngine;

namespace Elements
{
    public class CheckingElementHoverPresenter : IPresenter
    {
        private readonly GameModel _gameModel;
        private readonly GameView _gameView;

        public CheckingElementHoverPresenter(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }
        
        public void Subscribe()
        {
            _gameModel.CursorModel.ChangedTarget += OnCheckElementTarget;
        }

        public void UnSubscribe()
        {
            _gameModel.CursorModel.ChangedTarget += OnCheckElementTarget;
        }

        private void OnCheckElementTarget(GameObject target)
        {
            foreach (var element in _gameView.CurrentElements.Values)
            {
                if (element.gameObject == target)
                {
                    _gameModel.ElementsMap[element.Description.Name].OpenInformationWindow();
                }
                else if (_gameModel.ElementsMap[element.Description.Name].IsOpenInformationWindow)
                {
                    _gameModel.ElementsMap[element.Description.Name].CloseInformationWindow();
                }
            }
        }
    }
}