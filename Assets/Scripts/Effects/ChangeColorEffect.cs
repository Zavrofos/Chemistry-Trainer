using CapacityDir;
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
            if(model.CursorModel.TargetAtGunPoint.TryGetComponent(out ConteinerView conteiner))
            {
                conteiner.Filler.material.color = Color;
            }
        }
    }
}