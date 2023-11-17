using CapacityDir;

namespace Conteiners
{
    public class RemoveFillerPresenter : IPresenter
    {
        private Container _model;
        private readonly ConteinerView _view;

        public RemoveFillerPresenter(Container model, ConteinerView view)
        {
            _model = model;
            _view = view;
        }

        public void Subscribe()
        {
            _model.RemovedFiller += OnRemoveFiller;
        }

        public void UnSubscribe()
        {
            _model.RemovedFiller += OnRemoveFiller;
        }

        private void OnRemoveFiller()
        {
            _view.Filler.gameObject.SetActive(false);
        }
    }
}