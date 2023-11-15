using System;
using Description_Scripts;

public class Element
{
    public string Name;
    public string Formula;
    public EnvironmentType EnvironmentType;
    public bool IsOpenInformationWindow;

    public event Action OpenedInfoWindow;
    public event Action CloseInfoWindow;

    public Element(string name, string formula, EnvironmentType environmentType)
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
}