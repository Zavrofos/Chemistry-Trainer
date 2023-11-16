namespace CapacityDir
{
    public class OpenCloseInfoWindowPresenter : IPresenter
    {
        private readonly Conteiner _conteinerModel;
        private readonly ConteinerView _conteinerView;

        public OpenCloseInfoWindowPresenter(Conteiner conteinerModel, ConteinerView conteinerView)
        {
            _conteinerModel = conteinerModel;
            _conteinerView = conteinerView;
        }
        
        public void Subscribe()
        {
            _conteinerModel.OpenedInfoWindow += OnOpenInfoWindow;
            _conteinerModel.CloseInfoWindow += OnCloseInfoWindow;
        }

        public void UnSubscribe()
        {
            _conteinerModel.OpenedInfoWindow -= OnOpenInfoWindow;
            _conteinerModel.CloseInfoWindow -= OnCloseInfoWindow;
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