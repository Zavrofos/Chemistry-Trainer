using GameModelDir;
using GameViewDir;
using UnityEngine;

namespace Cursor
{
    public class HoverUpdater : IUpdater
    {
        private readonly GameModel _gameModel;
        private readonly GameView _gameView;

        public HoverUpdater(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }
        
        public void Update()
        {
            GameObject target = _gameModel.CursorModel.TargetAtGunPoint;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit))
            {
                if(hit.collider.gameObject == target) return;
                _gameModel.CursorModel.ChangeTarget(hit.collider.gameObject);
            }
        }
    }
}