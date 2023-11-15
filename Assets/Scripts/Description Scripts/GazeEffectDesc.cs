using Effects;
using GameModelDir;
using UnityEngine;

namespace Description_Scripts
{
    [CreateAssetMenu(fileName = "GazeEffect", menuName = "Create Description/Effects/GazeEffect")]
    public class GazeEffectDesc : EffectDescr
    {
        public override IEffect GetEffect()
        {
            return new GazeEffect();
        }
    }
}