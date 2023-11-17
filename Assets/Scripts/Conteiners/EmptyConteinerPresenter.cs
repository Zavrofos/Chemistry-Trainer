using GameModelDir;

namespace CapacityDir
{
    public class EmptyConteinerPresenter : IPresenter
    {
        private readonly Container _model;
        private readonly ConteinerView _view;

        public EmptyConteinerPresenter(Container model, ConteinerView view)
        {
            _model = model;
            _view = view;
        }
        
        public void Subscribe()
        {
            _model.EmptiedCapacity += OnClearCapacity;
        }

        public void UnSubscribe()
        {
            _model.EmptiedCapacity -= OnClearCapacity;
        }

        private void OnClearCapacity()
        {
            _model.CurrentElements.Clear();
            _model.RemoveFiller();
        }
    }
}