using System;
using System.Collections.Generic;
using Description_Objects;
using UnityEngine;

namespace CapacityDir
{
    public class Container
    {
        public List<ElementDescr> PreviousElements = new();
        public List<ElementDescr> CurrentElements;
        public readonly int Id;
        public readonly Vector3 InitialPositin;
        public readonly Quaternion InitialRotation;
        public readonly LayerMask InitialLayer;
        public readonly Vector3 RotationTilt;
        public readonly Vector3 PointPositionTilt;
        
        public bool IsOpenInformationWindow;
        
        public event Action OpenedInfoWindow;
        public event Action CloseInfoWindow;
        public event Action ChangedTextInfo;
        public event Action<List<ElementDescr>> AddedElement;
        public event Action EmptiedCapacity;
        public event Action ReturnedToInitialPosition;

        public event Action<Renderer> AddedFiller;
        public event Action RemovedFiller;

        public Container(int id, List<ElementDescr> currentElement, Vector3 initialPositin, Quaternion initialRotation,
            LayerMask initialLayer, Vector3 rotationTilt, Vector3 pointPositionTilt)
        {
            Id = id;
            CurrentElements = currentElement;
            InitialPositin = initialPositin;
            InitialRotation = initialRotation;
            InitialLayer = initialLayer;
            RotationTilt = rotationTilt;
            PointPositionTilt = pointPositionTilt;
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

        public void DisplayInfoText()
        {
            ChangedTextInfo?.Invoke();
        }

        public void AddElement(List<ElementDescr> newElement)
        {
            AddedElement?.Invoke(newElement);
        }

        public void EmptyCapacity()
        {
            EmptiedCapacity?.Invoke();
        }

        public void ReturnToInitialPosition()
        {
            ReturnedToInitialPosition?.Invoke();
        }

        public void AddFiller(Renderer filler)
        {
            AddedFiller?.Invoke(filler);
        }

        public void RemoveFiller()
        {
            RemovedFiller?.Invoke();
        }
    }
}