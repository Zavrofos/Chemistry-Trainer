using Description_Scripts;
using UnityEngine;

namespace CapacityDir
{
    public class NewElement
    {
        public readonly string Name;
        public readonly string Formula;
        public readonly EnvironmentType EnvironmentType;
        public readonly Color Color;

        public NewElement(string name, string formula, EnvironmentType environmentType, Color color)
        {
            Name = name;
            Formula = formula;
            EnvironmentType = environmentType;
            Color = color;
        }
    }
}