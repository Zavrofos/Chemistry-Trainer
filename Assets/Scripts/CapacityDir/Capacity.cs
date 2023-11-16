using System;
using Description_Scripts;
using UnityEngine;

namespace CapacityDir
{
    public class Capacity
    {
        public string Name;
        public string Formula;
        public EnvironmentType EnvironmentType;
        public Vector3 InitialPositin;
        public Vector3 RotationTilt;
        public Quaternion InitialRotation;
        public LayerMask InitialLayer;
        public bool IsOpenInformationWindow;

        public event Action OpenedInfoWindow;
        public event Action CloseInfoWindow;
        public event Action<string> ChangedTextInfo;

        public Capacity(string name, string formula, EnvironmentType environmentType, Vector3 initialPosition, 
            Quaternion initialRotation, Vector3 rotationTilt, LayerMask initialLayer)
        {
            Name = name;
            Formula = formula;
            EnvironmentType = environmentType;
            InitialPositin = initialPosition;
            InitialRotation = initialRotation;
            RotationTilt = rotationTilt;
            InitialLayer = initialLayer;
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