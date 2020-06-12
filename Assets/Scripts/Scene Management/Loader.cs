using UnityEngine.SceneManagement;
namespace Scene_Management
{
    public static class Loader
    {
        public enum Scenes
        {
            MainMenu,
            GameOver,
            Tutorial,
            Battle
        }

        public static void LoadScene(Scenes scene)
        {
            SceneManager.LoadScene(scene.ToString());
        }
        
    }
}