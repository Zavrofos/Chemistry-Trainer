using System;
using System.Collections;
using System.Collections.Generic;
using Description_Objects;
using Description_Scripts;
using UnityEngine;

public class Starter : MonoBehaviour
{
    [HideInInspector] public GameModel GameModel;
    public GameView GameView;
    public List<ElementDescr> Elements;
    public List<ReactionDesc> Reactions;

    public List<IPresenter> Presenters;

    private void Awake()
    {
        GameModel = new GameModel();
        Presenters = new List<IPresenter>()
        {

        };
    }

    private void Start()
    {
        GameModel.Initialize();
    }

    private void OnEnable()
    {
        foreach (var presenter in Presenters)
        {
            presenter.Subscribe();
        }
    }

    private void OnDisable()
    {
        foreach (var presenter in Presenters)
        {
            presenter.UnSubscribe();
        }
    }
}
