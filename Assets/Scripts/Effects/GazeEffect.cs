using CapacityDir;
using GameModelDir;

namespace Effects
{
    public class GazeEffect : IEffect
    {
        public void SetEffect(GameModel model)
        {
            if(model.CursorModel.TargetAtGunPoint.TryGetComponent(out ConteinerView container))
            {
                container.GazeEffectParticle.Play();
            }
        }
    }
}