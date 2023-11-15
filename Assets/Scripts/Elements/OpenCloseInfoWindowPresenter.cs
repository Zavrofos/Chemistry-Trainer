using GameModelDir;
using GameViewDir;

namespace Elements
{
    public class OpenCloseInfoWindowPresenter : IPresenter
    {
        private readonly Element _elementModel;
        private readonly ElementView _elementView;

        public OpenCloseInfoWindowPresenter(Element elementModel, ElementView elementView)
        {
            _elementModel = elementModel;
            _elementView = elementView;
        }
        
        public void Subscribe()
        {
            _elementModel.OpenedInfoWindow += OnOpenInfoWindow;
            _elementModel.CloseInfoWindow += OnCloseInfoWindow;
        }

        public void UnSubscribe()
        {
            _elementModel.OpenedInfoWindow -= OnOpenInfoWindow;
            _elementModel.CloseInfoWindow -= OnCloseInfoWindow;
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