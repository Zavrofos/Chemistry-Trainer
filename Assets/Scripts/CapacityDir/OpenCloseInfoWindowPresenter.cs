namespace CapacityDir
{
    public class OpenCloseInfoWindowPresenter : IPresenter
    {
        private readonly Capacity _capacityModel;
        private readonly CapacityView _capacityView;

        public OpenCloseInfoWindowPresenter(Capacity capacityModel, CapacityView capacityView)
        {
            _capacityModel = capacityModel;
            _capacityView = capacityView;
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
            _capacityView.InfoWindow.SetActive(true);
        }
        
        private void OnCloseInfoWindow()
        {
            _capacityView.InfoWindow.SetActive(false);
        }
    }
}