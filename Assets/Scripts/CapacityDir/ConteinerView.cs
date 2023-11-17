using System;
using System.Collections.Generic;
using Description_Objects;
using GameModelDir;
using TMPro;
using UnityEngine;

namespace CapacityDir
{
    public class ConteinerView : MonoBehaviour
    {
        [HideInInspector] public int Id;
        public List<ElementDescr> InitialElements;
        public GameObject InfoWindow;
        public TMP_Text InfoText;
        public Transform PointPositionTilt;

        public Renderer Filler;
    }
}