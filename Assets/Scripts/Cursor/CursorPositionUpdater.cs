using GameModelDir;
using GameViewDir;
using UnityEngine;

namespace Cursor
{
    public class CursorPositionUpdater : IUpdater
    {
        private readonly GameModel _gameModel;
        private readonly GameView _gameView;

        public CursorPositionUpdater(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }
        
        public void Update()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit,Mathf.Infinity, ~LayerMask.GetMask($"IgnoreObject"));
            
            float x;
            float y;
            float z;

            if (hit.point.x > 2f) x = 2f;
            else x = hit.point.x;

            if (hit.point.y < 0.4f) y = 0.4f;
            else if (hit.point.y > 1.5f) y = 1.5f;
            else y = hit.point.y;

            if (hit.point.z > 0.8f) z = 0.8f;
            else if (hit.point.z < -2.5f) z = -2.5f;
            else z = hit.point.z;

            _gameModel.CursorModel.CursorPosition = new Vector3(x, y, z);
        }
    }
}