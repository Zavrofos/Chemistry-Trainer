using System;
using UnityEngine;

namespace Cursor
{
    public class CursorModel
    {
        public GameObject TargetAtGunPoint;
        public GameObject SelectedTarget;
        public Vector3 CursorPosition;
        
        public event Action<GameObject> AimedAtTheTarget;
        public event Action ClickedMouse0;
        public event Action TakedCapacity;
        public event Action MixedElements;

        public void SetTargetAtGunPoint(GameObject newTarget)
        {
            TargetAtGunPoint = newTarget;
            AimedAtTheTarget?.Invoke(newTarget);
        }

        public void ClickMouse0()
        {
            ClickedMouse0?.Invoke();
        }

        public void TakeContainer()
        {
            TakedCapacity?.Invoke();
        }

        public void MixElements()
        {
            MixedElements?.Invoke();
        }
    }
}