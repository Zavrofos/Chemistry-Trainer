using System;
using System.Collections.Generic;
using CapacityDir;

namespace Conteiners
{
    public class CollectionOfConteiners
    {
        public Dictionary<int, Conteiner> ConteinersMap;
        public event Action Initialized;
        public event Action<ConteinerView> AddedConteiner;
        public int IdCount = 0;

        public CollectionOfConteiners()
        {
            ConteinersMap = new Dictionary<int, Conteiner>();
        }

        public void Initialize()
        {
            Initialized?.Invoke();
        }

        public void AddConteiner(ConteinerView conteiner)
        {
            AddedConteiner?.Invoke(conteiner);
        }
    }
}