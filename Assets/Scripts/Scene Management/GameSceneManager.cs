using System.Collections;
using UnityEngine;

namespace Scene_Management
{
    public class GameSceneManager : MonoBehaviour
    {

        private void Start()
        {
            GameEventSystem.current.OnPlayerWinGame += OnPlayerWinGame;
        }

        private void OnPlayerWinGame()
        {
            Loader.LoadScene(Loader.Scenes.GameOver);
        }
    }
}