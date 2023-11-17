using System.Collections.Generic;
using CapacityDir;
using Description_Objects;
using GameModelDir;
using GameViewDir;
using UnityEngine;

namespace Conteiners
{
    public class AddContainerPresenter : IPresenter
    {
        private readonly GameModel _gameModel;
        private readonly GameView _gameView;
        private readonly Dictionary<Container, List<IPresenter>> _containersPresenter;

        public AddContainerPresenter(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
            _containersPresenter = new Dictionary<Container, List<IPresenter>>();
        }
        
        public void Subscribe()
        {
            _gameModel.CollectionOfContainers.AddedContainer += OnAddContainer;
        }

        public void UnSubscribe()
        {
            _gameModel.CollectionOfContainers.AddedContainer += OnAddContainer;
        }

        private void OnAddContainer(ConteinerView containerView)
        {
            containerView.Id = _gameModel.CollectionOfContainers.IdCount;
            List<ElementDescr> elements = new List<ElementDescr>();
            foreach (var element in containerView.InitialElements)
            {
                elements.Add(element);
            }

            Container newContainer = new Container(_gameModel.CollectionOfContainers.IdCount, elements, containerView.transform.position,
                containerView.transform.rotation, containerView.gameObject.layer, new Vector3(-130, 0, 0),
                containerView.PointPositionTilt.position);
            _gameModel.CollectionOfContainers.ConteinersMap.Add(_gameModel.CollectionOfContainers.IdCount, newContainer);
            _gameView.CurrentCapacityes.Add(_gameModel.CollectionOfContainers.IdCount, containerView);
            _gameModel.CollectionOfContainers.IdCount++;

            List<IPresenter> presenters = new()
            {
                new OpenCloseInfoWindowPresenter(newContainer, containerView),
                new DisplayTextInfoPresenter(newContainer, containerView), 
                new AddingElementsToConteinerPresenter(newContainer, containerView, _gameModel),
                new EmptyConteinerPresenter(newContainer, containerView),
                new ReturnToInitialPositionConteinerPresenter(newContainer, containerView, _gameModel),
                new AddingFillerToConteinerPresenter(newContainer, containerView, _gameModel),
                new RemoveFillerPresenter(newContainer, containerView)
            };
                
            _containersPresenter.Add(newContainer, presenters);
                
            foreach (var presenter in presenters)
            {
                presenter.Subscribe();
            }
        }
    }
}