using System;
using Description_Scripts;
using UnityEngine;

namespace CapacityDir
{
    public class Element
    {
        public readonly string Name;
        public readonly string Formula;
        public readonly EnvironmentType EnvironmentType;

        public Element(string name, string formula, EnvironmentType environmentType)
        {
            Name = name;
            Formula = formula;
            EnvironmentType = environmentType;
        }
    }
}