using System;
using UnityEngine;

namespace Cursor
{
    public class CursorModel
    {
        public GameObject TargetAtGunPoint { get; private set; }
        public GameObject SelectedTarget;
        public Vector3 CursorPosition;
        public CursorState CurrentState = CursorState.Idle;
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

        public void TakeCapacity()
        {
            TakedCapacity?.Invoke();
        }

        public void MixElements()
        {
            MixedElements?.Invoke();
        }
    }
}