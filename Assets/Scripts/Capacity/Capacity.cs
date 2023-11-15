using System;
using Description_Scripts;

namespace Capacity
{
    public class Capacity
    {
        public string Name;
        public string Formula;
        public EnvironmentType EnvironmentType;
        public bool IsOpenInformationWindow;

        public event Action OpenedInfoWindow;
        public event Action CloseInfoWindow;
        public event Action<string> ChangedTextInfo;

        public Capacity(string name, string formula, EnvironmentType environmentType)
        {
            Name = name;
            Formula = formula;
            EnvironmentType = environmentType;
        }

        public void OpenInformationWindow()
        {
            IsOpenInformationWindow = true;
            OpenedInfoWindow?.Invoke();
        }

        public void CloseInformationWindow()
        {
            IsOpenInformationWindow = false;
            CloseInfoWindow?.Invoke();
        }

        public void ChangeText(string newText)
        {
            ChangedTextInfo?.Invoke(newText);
        }
    }
}