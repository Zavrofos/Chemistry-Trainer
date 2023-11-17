using GameModelDir;
using GameViewDir;

namespace Conteiners
{
    public class InitializeCollectionOfConteinersPresenter : IPresenter
    {
        private readonly GameModel _gameModel;
        private readonly GameView _gameView;

        public InitializeCollectionOfConteinersPresenter(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }
        
        public void Subscribe()
        {
            _gameModel.CollectionOfConteiners.Initialized += OnInitialize;
        }

        public void UnSubscribe()
        {
            _gameModel.CollectionOfConteiners.Initialized -= OnInitialize;
        }

        private void OnInitialize()
        {
            foreach (var conteinerView in _gameView.InitialConteiners)
            {
                _gameModel.CollectionOfConteiners.AddConteiner(conteinerView);
            }

            InitializeTextInfo();
        }
        
        private void InitializeTextInfo()
        {
            foreach (var value in _gameModel.CollectionOfConteiners.ConteinersMap.Values)
            {
                value.DisplayInfoText();
            }
        }
    }
}