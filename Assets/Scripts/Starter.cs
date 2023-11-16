using System;
using System.Collections;
using System.Collections.Generic;
using CapacityDir;
using Cursor;
using Description_Objects;
using Description_Scripts;
using GameModelDir;
using GameViewDir;
using UnityEngine;

public class Starter : MonoBehaviour
{
    [HideInInspector] public GameModel GameModel;
    public GameView GameView;
    public List<IPresenter> Presenters;
    public List<IUpdater> Updaters;

    private void Awake()
    {
        GameModel = new GameModel();
        Presenters = new List<IPresenter>()
        {
            new StartGameInitializePresenter(GameModel, GameView),
            new CheckingCapacityHoverPresenter(GameModel, GameView),
            new TakingCapacityPresenter(GameModel, GameView),
            new TiltingCapacityPresenter(GameModel, GameView)
        };
        Updaters = new List<IUpdater>()
        {
            new TargetingUpdater(GameModel, GameView),
            new ClickMouse0Updater(GameModel, GameView),
            new MoveSelectedCapacityToMouseUpdater(GameModel, GameView),
            new CursorPositionUpdater(GameModel, GameView)
        };
    }

    private void Start()
    {
        GameModel.Initialize();
    }

    private void Update()
    {
        foreach (var updater in Updaters)
        {
            updater.Update();
        }
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
