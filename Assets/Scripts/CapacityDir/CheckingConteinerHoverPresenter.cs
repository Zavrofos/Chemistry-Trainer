using GameModelDir;
using GameViewDir;
using UnityEngine;

namespace CapacityDir
{
    public class CheckingConteinerHoverPresenter : IPresenter
    {
        private readonly GameModel _gameModel;
        private readonly GameView _gameView;

        public CheckingConteinerHoverPresenter(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }
        
        public void Subscribe()
        {
            _gameModel.CursorModel.AimedAtTheTarget += OnCheckElementTarget;
        }

        public void UnSubscribe()
        {
            _gameModel.CursorModel.AimedAtTheTarget += OnCheckElementTarget;
        }

        private void OnCheckElementTarget(GameObject target)
        {
            foreach (var capacityView in _gameView.CurrentCapacityes.Values)
            {
                if (capacityView.gameObject == target)
                {
                    _gameModel.CapacityesMap[capacityView.Id].OpenInformationWindow();
                }
                else if (_gameModel.CapacityesMap[capacityView.Id].IsOpenInformationWindow)
                {
                    _gameModel.CapacityesMap[capacityView.Id].CloseInformationWindow();
                }
            }
        }
    }
}