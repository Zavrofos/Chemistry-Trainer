using System;
using System.Collections.Generic;
using CapacityDir;
using Cursor;
using Description_Objects;

namespace GameModelDir
{
    public class GameModel
    {
        public Dictionary<int, Conteiner> CapacityesMap;
        public Dictionary<string, ElementDescr> ElementsInfoMap;
        public Dictionary<string, Reaction> ReactionsMap;
        public CursorModel CursorModel;
        public event Action Initialized;

        public GameModel()
        {
            CapacityesMap = new Dictionary<int, Conteiner>();
            ElementsInfoMap = new Dictionary<string, ElementDescr>();
            ReactionsMap = new Dictionary<string, Reaction>();
            CursorModel = new CursorModel();
        }
    
        public void Initialize()
        {
            Initialized?.Invoke();
        }
    }
}