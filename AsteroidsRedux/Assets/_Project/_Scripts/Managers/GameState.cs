using System;

namespace MangledMonster.Managers
{
    [Serializable]
    public enum GameState
    {
        Starting = 0,
        SpawningHeroes = 1,
        SpawningEnemies = 2,
        Win = 3,
        Lose = 4,
    }
}   


