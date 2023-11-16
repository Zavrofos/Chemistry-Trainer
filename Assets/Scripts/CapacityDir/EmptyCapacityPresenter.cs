using GameModelDir;

namespace CapacityDir
{
    public class EmptyCapacityPresenter : IPresenter
    {
        private readonly Capacity _model;
        private readonly CapacityView _view;

        public EmptyCapacityPresenter(Capacity model, CapacityView view)
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
        }
    }
}