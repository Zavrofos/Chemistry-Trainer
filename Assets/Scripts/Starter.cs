using System.Collections.Generic;
using CapacityDir;
using Conteiners;
using Cursor;
using GameModelDir;
using GameViewDir;
using Reactions;
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
            new InitializeCollectionOfReactionsPresenter(GameModel, GameView),
            new InitializeCollectionOfConteinersPresenter(GameModel, GameView),
            new AddConteinerPresenter(GameModel, GameView),
            
            new CheckingConteinerHoverPresenter(GameModel, GameView),
            new TiltingConteinerPresenter(GameModel, GameView),
            new CancelTiltPresenter(GameModel, GameView),
            new ClickPresenter(GameModel, GameView),
            new TakeConteinerPresenter(GameModel, GameView),
            new MixElementsPresenter(GameModel, GameView)
        };
        Updaters = new List<IUpdater>()
        {
            new TargetingUpdater(GameModel, GameView),
            new ClickMouse0Updater(GameModel, GameView),
            new MoveSelectedConteinerToMouseUpdater(GameModel, GameView),
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
