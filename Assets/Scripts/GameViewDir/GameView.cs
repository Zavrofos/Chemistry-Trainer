using System.Collections.Generic;
using Description_Objects;
using Description_Scripts;
using Elements;
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