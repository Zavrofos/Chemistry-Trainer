using System.Collections.Generic;
using CapacityDir;
using Description_Objects;
using Description_Scripts;
using UnityEngine;

namespace GameViewDir
{
    public class GameView : MonoBehaviour
    {
        public List<ReactionDesc> Reactions;
        public List<CapacityView> Elements;
        public Dictionary<string, CapacityView> CurrentElements = new();
    }
}