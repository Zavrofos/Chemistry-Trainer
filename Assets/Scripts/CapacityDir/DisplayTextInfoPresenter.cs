using System;

namespace CapacityDir
{
    public class DisplayTextInfoPresenter : IPresenter
    {
        private readonly Capacity _capacityModel;
        private readonly CapacityView _capacityView;

        public DisplayTextInfoPresenter(CapacityDir.Capacity capacityModel, CapacityView capacityView)
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

        private void OnChangeTextInfo()
        {
            string newText = String.Empty;
            if (_capacityModel.CurrentElements.Count == 0)
            {
                newText = "Empty";
            }

            for (int i = 0; i < _capacityModel.CurrentElements.Count; i++)
            {
                if (i == _capacityModel.CurrentElements.Count - 1)
                {
                    newText += _capacityModel.CurrentElements[i].Formula;
                }
                else
                {
                    newText += _capacityModel.CurrentElements[i].Formula + " + ";
                }
            }

            _capacityView.InfoText.text = newText;
        }
    }
}