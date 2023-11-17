using System.Collections.Generic;
using CapacityDir;
using Description_Objects;
using Description_Scripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameViewDir
{
    public class GameView : MonoBehaviour
    {
        public List<ReactionDesc> ReactionsInfo;
        public List<ElementDescr> ElementsInfo;
        [FormerlySerializedAs("InitialCapacityes")] public List<ConteinerView> InitialConteiners;
        
        public Dictionary<int, ConteinerView> CurrentCapacityes = new();
    }
}