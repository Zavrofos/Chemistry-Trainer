using UnityEngine;

namespace Description_Scripts
{
    [CreateAssetMenu(fileName = "ChangeColorEffect", menuName = "Create Description/Effects/ChangeColorEffect")]
    public class ChangeColorEffect : EffectDescr
    {
        public Color Color;
        public override void SetEffect(GameModel model)
        {
            model.ChangeColor(Color);
        }
    }
}