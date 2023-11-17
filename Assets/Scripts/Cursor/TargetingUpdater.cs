using GameModelDir;
using GameViewDir;
using UnityEngine;

namespace Cursor
{
    public class TargetingUpdater : IUpdater
    {
        private readonly GameModel _gameModel;
        private readonly GameView _gameView;

        public TargetingUpdater(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }
        
        public void Update()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out var hit, Mathf.Infinity, ~LayerMask.GetMask($"IgnoreObject"));
            GameObject target = _gameModel.CursorModel.TargetAtGunPoint;
            if(hit.collider.gameObject == target) return;
            _gameModel.CursorModel.SetTargetAtGunPoint(hit.collider.gameObject);
        }
    }
}