using System;
using UnityEngine;

namespace Cursor
{
    public class CursorModel
    {
        public GameObject TargetAtGunPoint { get; private set; }
        public event Action ChangedTarget;
        
        public void ChangeTarget(GameObject newTarget)
        {
            TargetAtGunPoint = newTarget;
            ChangedTarget?.Invoke();
        }
    }
}