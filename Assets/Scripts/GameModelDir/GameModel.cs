using System;
using System.Collections.Generic;
using Capacity;
using Cursor;

namespace GameModelDir
{
    public class GameModel
    {
        public Dictionary<string, Capacity.Capacity> ElementsMap;
        public Dictionary<string, Reaction> ReactionsMap;
        public CursorModel CursorModel;
        public event Action Initialized;

        public GameModel()
        {
            ElementsMap = new Dictionary<string, Capacity.Capacity>();
            ReactionsMap = new Dictionary<string, Reaction>();
            CursorModel = new CursorModel();
        }
    
        public void Initialize()
        {
            Initialized?.Invoke();
        }
    }
}