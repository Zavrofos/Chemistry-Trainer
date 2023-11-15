using System;
using System.Collections.Generic;
using Cursor;

namespace GameModelDir
{
    public class GameModel
    {
        public Dictionary<string, Element> ElementsMap;
        public Dictionary<string, Reaction> ReactionsMap;
        public CursorModel CursorModel;
        public event Action Initialized;

        public GameModel()
        {
            ElementsMap = new Dictionary<string, Element>();
            ReactionsMap = new Dictionary<string, Reaction>();
            CursorModel = new CursorModel();
        }
    
        public void Initialize()
        {
            Initialized?.Invoke();
        }
    }
}