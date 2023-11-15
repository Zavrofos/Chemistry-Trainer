namespace Capacity
{
    public class ChangeTextInfoPresenter : IPresenter
    {
        private readonly Capacity _capacityModel;
        private readonly ElementView _elementView;

        public ChangeTextInfoPresenter(Capacity capacityModel, ElementView elementView)
        {
            _capacityModel = capacityModel;
            _elementView = elementView;
        }

        public void Subscribe()
        {
            _capacityModel.ChangedTextInfo += OnChangeTextInfo;
        }

        public void UnSubscribe()
        {
            _capacityModel.ChangedTextInfo += OnChangeTextInfo;
        }

        private void OnChangeTextInfo(string newText)
        {
            _elementView.InfoText.text = newText;
        }
    }
}