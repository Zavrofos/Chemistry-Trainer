namespace CapacityDir
{
    public class OpenCloseInfoWindowPresenter : IPresenter
    {
        private readonly Container _containerModel;
        private readonly ConteinerView _conteinerView;

        public OpenCloseInfoWindowPresenter(Container containerModel, ConteinerView conteinerView)
        {
            _containerModel = containerModel;
            _conteinerView = conteinerView;
        }
        
        public void Subscribe()
        {
            _containerModel.OpenedInfoWindow += OnOpenInfoWindow;
            _containerModel.CloseInfoWindow += OnCloseInfoWindow;
        }

        public void UnSubscribe()
        {
            _containerModel.OpenedInfoWindow -= OnOpenInfoWindow;
            _containerModel.CloseInfoWindow -= OnCloseInfoWindow;
        }

        private void OnOpenInfoWindow()
        {
            _conteinerView.InfoWindow.SetActive(true);
        }
        
        private void OnCloseInfoWindow()
        {
            _conteinerView.InfoWindow.SetActive(false);
        }
    }
}