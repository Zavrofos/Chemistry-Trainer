using System;
using Description_Objects;
using TMPro;
using UnityEngine;

namespace Elements
{
    [Serializable]
    public class ElementView : MonoBehaviour
    {
        public ElementDescr Description;
        public GameObject InfoWindow;
        public TMP_Text InfoText;
    }
}