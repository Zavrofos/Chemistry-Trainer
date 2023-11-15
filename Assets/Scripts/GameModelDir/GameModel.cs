using System;
using System.Collections.Generic;
using Cursor;

namespace GameModelDir
{
    public class GameModel
    {
        public Dictionary<string, CapacityDir.Capacity> ElementsMap;
        public Dictionary<string, Reaction> ReactionsMap;
        public CursorModel CursorModel;
        public event Action Initialized;

        public GameModel()
        {
            ElementsMap = new Dictionary<string, CapacityDir.Capacity>();
            ReactionsMap = new Dictionary<string, Reaction>();
            CursorModel = new CursorModel();
        }
    
        public void Initialize()
        {
            Initialized?.Invoke();
        }
    }
}