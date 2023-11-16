using System;

namespace CapacityDir
{
    public class DisplayTextInfoPresenter : IPresenter
    {
        private readonly Conteiner _conteinerModel;
        private readonly ConteinerView _conteinerView;

        public DisplayTextInfoPresenter(CapacityDir.Conteiner conteinerModel, ConteinerView conteinerView)
        {
            _conteinerModel = conteinerModel;
            _conteinerView = conteinerView;
        }

        public void Subscribe()
        {
            _conteinerModel.ChangedTextInfo += OnChangeTextInfo;
        }

        public void UnSubscribe()
        {
            _conteinerModel.ChangedTextInfo += OnChangeTextInfo;
        }

        private void OnChangeTextInfo()
        {
            string newText = String.Empty;
            if (_conteinerModel.CurrentElements.Count == 0)
            {
                newText = "Empty";
            }

            for (int i = 0; i < _conteinerModel.CurrentElements.Count; i++)
            {
                if (i == _conteinerModel.CurrentElements.Count - 1)
                {
                    newText += _conteinerModel.CurrentElements[i].Formula;
                }
                else
                {
                    newText += _conteinerModel.CurrentElements[i].Formula + " + ";
                }
            }

            _conteinerView.InfoText.text = newText;
        }
    }
}