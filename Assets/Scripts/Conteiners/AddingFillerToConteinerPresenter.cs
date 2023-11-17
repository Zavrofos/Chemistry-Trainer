using CapacityDir;
using GameModelDir;
using UnityEngine;

namespace Conteiners
{
    public class AddingFillerToConteinerPresenter : IPresenter
    {
        private readonly Container _model;
        private readonly ConteinerView _view;
        private readonly GameModel _gameModel;

        public AddingFillerToConteinerPresenter(Container model, ConteinerView view, GameModel gameModel)
        {
            _model = model;
            _view = view;
        }
        
        public void Subscribe()
        {
            _model.AddedFiller += OnAddFiller;
        }

        public void UnSubscribe()
        {
            _model.AddedFiller += OnAddFiller;
        }

        private void OnAddFiller(Renderer filler)
        {
            _view.Filler.gameObject.SetActive(true);
            _view.Filler.material.color = filler.material.color;
        }
    }
}