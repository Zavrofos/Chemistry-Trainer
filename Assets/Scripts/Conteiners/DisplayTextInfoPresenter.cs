using System;

namespace CapacityDir
{
    public class DisplayTextInfoPresenter : IPresenter
    {
        private readonly Container _containerModel;
        private readonly ConteinerView _conteinerView;

        public DisplayTextInfoPresenter(CapacityDir.Container containerModel, ConteinerView conteinerView)
        {
            _containerModel = containerModel;
            _conteinerView = conteinerView;
        }

        public void Subscribe()
        {
            _containerModel.ChangedTextInfo += OnChangeTextInfo;
        }

        public void UnSubscribe()
        {
            _containerModel.ChangedTextInfo += OnChangeTextInfo;
        }

        private void OnChangeTextInfo()
        {
            if (_containerModel.CurrentElements.Count == 0)
            {
                _conteinerView.InfoText.text =  "Empty";
                return;
            }
            
            string newText = string.Empty;

            if (_containerModel.PreviousElements.Count != 0)
            {
                for (int i = 0; i < _containerModel.PreviousElements.Count; i++)
                {
                    if (i == _containerModel.PreviousElements.Count - 1)
                    {
                        newText += _containerModel.PreviousElements[i].Formula;
                    }
                    else
                    {
                        newText += _containerModel.PreviousElements[i].Formula + " + ";
                    }
                }
            }
            
            if (newText != string.Empty)
            {
                newText += " -> ";
            }

            for (int i = 0; i < _containerModel.CurrentElements.Count; i++)
            {
                if (i == _containerModel.CurrentElements.Count - 1)
                {
                    newText += _containerModel.CurrentElements[i].Formula;
                }
                else
                {
                    newText += _containerModel.CurrentElements[i].Formula + " + ";
                }
            }

            _conteinerView.InfoText.text = newText;
        }
    }
}