using System;
using UnityEngine;

namespace Description_Scripts
{
    [CreateAssetMenu(fileName = "Reaction", menuName = "Create Description/Reaction")]
    public class ReactionDesc : ScriptableObject
    {
        public string[] Elements;
        public string[] ResultElements;
        public EffectDescr[] Effects;
    }
}