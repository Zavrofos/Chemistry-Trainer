using System.Collections.Generic;
using Capacity;
using Description_Objects;
using Description_Scripts;
using UnityEngine;

namespace GameViewDir
{
    public class GameView : MonoBehaviour
    {
        public List<ReactionDesc> Reactions;
        public List<ElementView> Elements;
        public Dictionary<string, ElementView> CurrentElements = new();
    }
}