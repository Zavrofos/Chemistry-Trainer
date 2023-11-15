using GameModelDir;
using GameViewDir;
using UnityEngine;

namespace CapacityDir
{
    public class CheckingCapacityHoverPresenter : IPresenter
    {
        private readonly GameModel _gameModel;
        private readonly GameView _gameView;

        public CheckingCapacityHoverPresenter(GameModel gameModel, GameView gameView)
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
            foreach (var capacityView in _gameView.CurrentElements.Values)
            {
                if (capacityView.gameObject == target)
                {
                    _gameModel.ElementsMap[capacityView.InitialElement.Name].OpenInformationWindow();
                }
                else if (_gameModel.ElementsMap[capacityView.InitialElement.Name].IsOpenInformationWindow)
                {
                    _gameModel.ElementsMap[capacityView.InitialElement.Name].CloseInformationWindow();
                }
            }
        }
    }
}