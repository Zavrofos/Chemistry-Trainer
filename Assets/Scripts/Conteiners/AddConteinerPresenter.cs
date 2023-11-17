using System.Collections.Generic;
using CapacityDir;
using Description_Objects;
using GameModelDir;
using GameViewDir;
using UnityEngine;

namespace Conteiners
{
    public class AddConteinerPresenter : IPresenter
    {
        private readonly GameModel _gameModel;
        private readonly GameView _gameView;
        private readonly Dictionary<Conteiner, List<IPresenter>> _conteinersPresenter;

        public AddConteinerPresenter(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
            _conteinersPresenter = new Dictionary<Conteiner, List<IPresenter>>();
        }
        
        public void Subscribe()
        {
            _gameModel.CollectionOfConteiners.AddedConteiner += OnAddConteiner;
        }

        public void UnSubscribe()
        {
            _gameModel.CollectionOfConteiners.AddedConteiner += OnAddConteiner;
        }

        private void OnAddConteiner(ConteinerView conteinerView)
        {
            conteinerView.Id = _gameModel.CollectionOfConteiners.IdCount;
            List<ElementDescr> elements = new List<ElementDescr>();
            foreach (var element in conteinerView.InitialElements)
            {
                elements.Add(element);
            }

            Conteiner newConteiner = new Conteiner(_gameModel.CollectionOfConteiners.IdCount, elements, conteinerView.transform.position,
                conteinerView.transform.rotation, conteinerView.gameObject.layer, new Vector3(-130, 0, 0),
                conteinerView.PointPositionTilt.position);
            _gameModel.CollectionOfConteiners.ConteinersMap.Add(_gameModel.CollectionOfConteiners.IdCount, newConteiner);
            _gameView.CurrentCapacityes.Add(_gameModel.CollectionOfConteiners.IdCount, conteinerView);
            _gameModel.CollectionOfConteiners.IdCount++;

            List<IPresenter> presenters = new()
            {
                new OpenCloseInfoWindowPresenter(newConteiner, conteinerView),
                new DisplayTextInfoPresenter(newConteiner, conteinerView), 
                new AddingElementsToConteinerPresenter(newConteiner, conteinerView, _gameModel),
                new EmptyConteinerPresenter(newConteiner, conteinerView),
                new ReturnToInitialPositionConteinerPresenter(newConteiner, conteinerView, _gameModel),
                new AddingFillerToConteinerPresenter(newConteiner, conteinerView, _gameModel),
                new RemoveFillerPresenter(newConteiner, conteinerView)
            };
                
            _conteinersPresenter.Add(newConteiner, presenters);
                
            foreach (var presenter in presenters)
            {
                presenter.Subscribe();
            }
        }
    }
}