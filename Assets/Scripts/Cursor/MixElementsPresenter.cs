using CapacityDir;
using GameModelDir;
using GameViewDir;

namespace Cursor
{
    public class MixElementsPresenter : IPresenter
    {
        private readonly GameModel _gameModel;
        private readonly GameView _gameView;

        public MixElementsPresenter(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }

        public void Subscribe()
        {
            _gameModel.CursorModel.MixedElements += OnMixElements;
        }

        public void UnSubscribe()
        {
            _gameModel.CursorModel.MixedElements -= OnMixElements;
        }

        private void OnMixElements()
        {
            ConteinerView conteinerViewTarget = _gameModel.CursorModel.TargetAtGunPoint.GetComponent<ConteinerView>();
            ConteinerView conteinerViewSelected = _gameModel.CursorModel.SelectedTarget.GetComponent<ConteinerView>();

            var conteiners = _gameModel.CollectionOfContainers.ConteinersMap[conteinerViewSelected.Id];
            _gameModel.CollectionOfContainers.ConteinersMap[conteinerViewTarget.Id].AddElement(conteiners.CurrentElements);
            conteiners.EmptyCapacity();
            conteiners.ReturnToInitialPosition();
        }
    }
}