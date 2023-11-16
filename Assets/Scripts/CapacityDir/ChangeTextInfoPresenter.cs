namespace CapacityDir
{
    public class ChangeTextInfoPresenter : IPresenter
    {
        private readonly Capacity _capacityModel;
        private readonly CapacityView _capacityView;

        public ChangeTextInfoPresenter(CapacityDir.Capacity capacityModel, CapacityView capacityView)
        {
            _capacityModel = capacityModel;
            _capacityView = capacityView;
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
            _capacityView.InfoText.text = newText;
        }
    }
}