using System.Collections.Generic;
using CapacityDir;
using Description_Objects;
using Description_Scripts;
using UnityEngine;

namespace GameViewDir
{
    public class GameView : MonoBehaviour
    {
        public List<ReactionDesc> ReactionsInfo;
        public List<ElementDescr> ElementsInfo;
        public List<CapacityView> InitialCapacityes;
        
        public Dictionary<int, CapacityView> CurrentCapacityes = new();
    }
}