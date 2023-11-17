using System;
using System.Collections.Generic;
using CapacityDir;
using Conteiners;
using Cursor;
using Description_Objects;
using Reactions;

namespace GameModelDir
{
    public class GameModel
    {
        public CollectionsOfReactions CollectionsOfReactions;
        public CollectionOfConteiners CollectionOfConteiners;
        public Dictionary<string, ElementDescr> ElementsInfoMap;
        public CursorModel CursorModel;
        public GameState CurrentState = GameState.Idle;
        public event Action Initialized;

        public GameModel()
        {
            CollectionsOfReactions = new CollectionsOfReactions();
            CollectionOfConteiners = new CollectionOfConteiners();
            ElementsInfoMap = new Dictionary<string, ElementDescr>();
            CursorModel = new CursorModel();
        }
    
        public void Initialize()
        {
            Initialized?.Invoke();
        }
    }
}