using Effects;
using GameModelDir;
using UnityEngine;

namespace Description_Scripts
{
    [CreateAssetMenu(fileName = "ChangeColorEffect", menuName = "Create Description/Effects/ChangeColorEffect")]
    public class ChangeColorEffectDescr : EffectDescr
    {
        public Color Color;
        public override IEffect SetEffect()
        {
            return new ChangeColorEffect(Color);
        }
    }
}