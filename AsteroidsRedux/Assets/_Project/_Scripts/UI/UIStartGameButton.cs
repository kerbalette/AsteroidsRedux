using UnityEngine;
using UnityEngine.SceneManagement;

namespace MangledMonster.UI
{
    public class UIStartGameButton : MonoBehaviour
    {
        [SerializeField] private string _levelName;

        public string LevelName => _levelName;

        public void LoadLevel()
        {
            SceneManager.LoadScene(_levelName);
        }
    }
}