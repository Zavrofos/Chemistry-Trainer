using GameViewDir;

namespace GameModelDir
{
    public class StartGameInitializePresenter : IPresenter
    {
        private readonly GameModel _gameModel;
        private readonly GameView _gameView;
        
        public StartGameInitializePresenter(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }
        
        public void Subscribe()
        {
            _gameModel.Initialized += OnInitializeStartGame;
        }

        public void UnSubscribe()
        {
            _gameModel.Initialized += OnInitializeStartGame;
        }

        private void OnInitializeStartGame()
        {
            foreach (var elementDescr in _gameView.ElementsInfo)
            {
                _gameModel.ElementsInfoMap.Add(elementDescr.Name, elementDescr);
            }
            
            _gameModel.CollectionsOfReactions.Initialize();
            _gameModel.CollectionOfContainers.Initialize();
        }
    }
}