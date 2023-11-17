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
        public CollectionOfConteiners CollectionOfContainers;
        public Dictionary<string, ElementDescr> ElementsInfoMap;
        public CursorModel CursorModel;
        public GameState CurrentState = GameState.Idle;
        public event Action Initialized;

        public GameModel()
        {
            CollectionsOfReactions = new CollectionsOfReactions();
            CollectionOfContainers = new CollectionOfConteiners();
            ElementsInfoMap = new Dictionary<string, ElementDescr>();
            CursorModel = new CursorModel();
        }
    
        public void Initialize()
        {
            Initialized?.Invoke();
        }
    }
}