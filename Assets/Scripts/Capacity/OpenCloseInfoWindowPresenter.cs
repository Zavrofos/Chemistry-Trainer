namespace Capacity
{
    public class OpenCloseInfoWindowPresenter : IPresenter
    {
        private readonly Capacity _capacityModel;
        private readonly ElementView _elementView;

        public OpenCloseInfoWindowPresenter(Capacity capacityModel, ElementView elementView)
        {
            _capacityModel = capacityModel;
            _elementView = elementView;
        }
        
        public void Subscribe()
        {
            _capacityModel.OpenedInfoWindow += OnOpenInfoWindow;
            _capacityModel.CloseInfoWindow += OnCloseInfoWindow;
        }

        public void UnSubscribe()
        {
            _capacityModel.OpenedInfoWindow -= OnOpenInfoWindow;
            _capacityModel.CloseInfoWindow -= OnCloseInfoWindow;
        }

        private void OnOpenInfoWindow()
        {
            _elementView.InfoWindow.SetActive(true);
        }
        
        private void OnCloseInfoWindow()
        {
            _elementView.InfoWindow.SetActive(false);
        }
    }
}