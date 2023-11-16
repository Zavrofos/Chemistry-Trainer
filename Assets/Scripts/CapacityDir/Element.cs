using Description_Scripts;
using UnityEngine;

namespace CapacityDir
{
    public class Element
    {
        public readonly string Name;
        public readonly string Formula;
        public readonly EnvironmentType EnvironmentType;
        public readonly Color Color;

        public Element(string name, string formula, EnvironmentType environmentType, Color color)
        {
            Name = name;
            Formula = formula;
            EnvironmentType = environmentType;
            Color = color;
        }
    }
}