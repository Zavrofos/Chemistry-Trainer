using System;
using System.Collections.Generic;
using Description_Objects;
using UnityEngine;

public class GameModel
{
    public Dictionary<string, Element> ElementsMap;
    public Dictionary<string[], Reaction> ReactionsMap;
    public event Action Initialized;

    public GameModel()
    {
        ElementsMap = new Dictionary<string, Element>();
        ReactionsMap = new Dictionary<string[], Reaction>();
    }
    
    public void Initialize()
    {
        Initialized?.Invoke();
    }
}