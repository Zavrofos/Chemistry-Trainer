
using System;
using System.Linq;
using System.Text;
using Effects;
using GameViewDir;

namespace GameModelDir
{
    public class StartGameInitializePresenter : IPresenter
    {
        private readonly GameModel _gameModel;
        private readonly GameView _gameView;

        public StartGameInitializePresenter(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }
        
        public void Subscribe()
        {
            _gameModel.Initialized += OnInitializeStartGame;
        }

        public void UnSubscribe()
        {
            _gameModel.Initialized += OnInitializeStartGame;
        }

        private void OnInitializeStartGame()
        {
            var elementsDescription = _gameView.Elements;
            var reactionDescription = _gameView.Reactions;

            foreach (var elementDescr in elementsDescription)
            {
                _gameModel.ElementsMap.Add(elementDescr.Name, new Element(elementDescr.Name, elementDescr.Formula, elementDescr.EnvironmentType));
            }

            foreach (var reactionDesc in reactionDescription)
            {
                _gameModel.ReactionsMap.Add(CreateKey(reactionDesc.Elements), new Reaction(reactionDesc.Elements, reactionDesc.ResultElements, CreateEffects(reactionDesc.Effects)));
            }
        }

        private string CreateKey(string[] elements)
        {
            string[] elementsNew = elements.ToArray();
            Array.Sort(elementsNew);
            StringBuilder key = new StringBuilder();
            foreach (var s in elementsNew)
            {
                key.Append(s);
            }

            return key.ToString();
        }

        private IEffect[] CreateEffects(EffectDescr[] effectsDescrs)
        {
            IEffect[] effects = new IEffect[effectsDescrs.Length];
            for (int i = 0; i < effectsDescrs.Length; i++)
            {
                effects[i] = effectsDescrs[i].SetEffect();
            }

            return effects;
        }
    }
}