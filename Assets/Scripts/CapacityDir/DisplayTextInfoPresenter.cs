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
            if (_conteinerModel.CurrentElements.Count == 0)
            {
                _conteinerView.InfoText.text =  "Empty";
                return;
            }
            
            string newText = string.Empty;

            if (_conteinerModel.PreviousElements.Count != 0)
            {
                for (int i = 0; i < _conteinerModel.PreviousElements.Count; i++)
                {
                    if (i == _conteinerModel.PreviousElements.Count - 1)
                    {
                        newText += _conteinerModel.PreviousElements[i].Formula;
                    }
                    else
                    {
                        newText += _conteinerModel.PreviousElements[i].Formula + " + ";
                    }
                }
            }
            
            if (newText != string.Empty)
            {
                newText += " -> ";
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