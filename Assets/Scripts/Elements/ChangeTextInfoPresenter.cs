namespace Elements
{
    public class ChangeTextInfoPresenter : IPresenter
    {
        private readonly Element _elementModel;
        private readonly ElementView _elementView;

        public ChangeTextInfoPresenter(Element elementModel, ElementView elementView)
        {
            _elementModel = elementModel;
            _elementView = elementView;
        }

        public void Subscribe()
        {
            _elementModel.ChangedTextInfo += OnChangeTextInfo;
        }

        public void UnSubscribe()
        {
            _elementModel.ChangedTextInfo += OnChangeTextInfo;
        }

        private void OnChangeTextInfo(string newText)
        {
            _elementView.InfoText.text = newText;
        }
    }
}