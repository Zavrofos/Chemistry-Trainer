using Description_Scripts;
using UnityEngine;

namespace Description_Objects
{
    [CreateAssetMenu(fileName = "Element", menuName = "Create Description/Element")]
    public class ElementDescr : ScriptableObject
    {
        public string Name;
        public string Formula;
        public EnvironmentType EnvironmentType;
    }
}
