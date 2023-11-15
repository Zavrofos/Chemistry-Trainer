using System;
using Description_Objects;
using TMPro;
using UnityEngine;

namespace CapacityDir
{
    [Serializable]
    public class CapacityView : MonoBehaviour
    {
        public ElementDescr InitialElement;
        public GameObject InfoWindow;
        public TMP_Text InfoText;
    }
}