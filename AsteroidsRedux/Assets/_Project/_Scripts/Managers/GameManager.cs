using System;
using MangledMonster.Utilities;
using UnityEngine;

namespace MangledMonster.Managers
{
    public class GameManager : StaticInstance<GameManager>
    {
        public static event Action<GameState> OnBeforeStateChanged;
        public static event Action<GameState> OnAfterStateChanged;
        
        public GameState State { get; private set; }

        private void Start()
        {
            ChangeState(GameState.Starting);
        }

        private void ChangeState(GameState newState)
        {
            OnBeforeStateChanged?.Invoke(newState);
            Debug.Log($"Old state: {State}");
            
            State = newState;
            switch (newState)
            {
                case GameState.Starting:
                    HandleStarting();
                    break;
                case GameState.SpawningHeroes:
                    HandleSpawningHeroes();
                    break;
                case GameState.SpawningEnemies:
                    break;
                case GameState.Win:
                    break;
                case GameState.Lose:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
            }
            OnAfterStateChanged?.Invoke(newState);
            Debug.Log($"New state: {newState}");
        }

        private void HandleSpawningHeroes()
        {
            ChangeState(GameState.SpawningEnemies);
        }
        
        private void HandleStarting()
        {
            ChangeState(GameState.SpawningHeroes);
        }
    }
}