using System;
using System.Collections;
using System.Collections.Generic;
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
            ChangeState(GameState.TitleScreen);
        }

        private void ChangeState(GameState newState)
        {
            OnBeforeStateChanged?.Invoke(newState);
            Debug.Log($"Old state: {State}");
            
            State = newState;
            switch (newState)
            {
                case GameState.TitleScreen:
                    HandleTitleScreen();
                    break;
                case GameState.InGame:
                    break;
                case GameState.Win:
                    break;
                case GameState.Loose:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
            }
            
            OnAfterStateChanged?.Invoke(newState);
            Debug.Log($"New state: {newState}");
        }

        private void HandleTitleScreen()
        {
            
        }
    }
}