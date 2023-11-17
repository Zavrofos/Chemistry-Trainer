using System;
using System.Collections.Generic;

namespace Reactions
{
    public class CollectionsOfReactions
    {
        public Dictionary<string, Reaction> ReactionsMap;
        public event Action Initialized;

        public CollectionsOfReactions()
        {
            ReactionsMap = new Dictionary<string, Reaction>();
        }

        public void Initialize()
        {
            Initialized?.Invoke();
        }
    }
}