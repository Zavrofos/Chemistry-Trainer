using System;
using System.Collections.Generic;
using CapacityDir;

namespace Conteiners
{
    public class CollectionOfConteiners
    {
        public Dictionary<int, Container> ConteinersMap;
        public event Action Initialized;
        public event Action<ConteinerView> AddedContainer;
        public int IdCount = 0;

        public CollectionOfConteiners()
        {
            ConteinersMap = new Dictionary<int, Container>();
        }

        public void Initialize()
        {
            Initialized?.Invoke();
        }

        public void AddConteiner(ConteinerView conteiner)
        {
            AddedContainer?.Invoke(conteiner);
        }
    }
}