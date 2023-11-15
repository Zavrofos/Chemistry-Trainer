using GameModelDir;
using UnityEngine;

namespace Effects
{
    public class ChangeColorEffect : IEffect
    {
        public readonly Color Color;

        public ChangeColorEffect(Color color)
        {
            Color = color;
        }
        
        public void SetEffect(GameModel model)
        {
            
        }
    }
}