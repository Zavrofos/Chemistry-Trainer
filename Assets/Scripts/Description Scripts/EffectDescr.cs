using System;
using Description_Scripts;
using Effects;
using GameModelDir;
using UnityEngine;

public abstract class EffectDescr : ScriptableObject
{
    public abstract IEffect GetEffect();
}