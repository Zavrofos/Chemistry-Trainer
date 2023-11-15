using System;
using Description_Objects;
using TMPro;
using UnityEngine;

namespace Capacity
{
    [Serializable]
    public class ElementView : MonoBehaviour
    {
        public ElementDescr Description;
        public GameObject InfoWindow;
        public TMP_Text InfoText;
    }
}