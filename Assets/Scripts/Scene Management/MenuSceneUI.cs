using UnityEngine;

namespace Scene_Management
{
    // ReSharper disable once InconsistentNaming
    public class MenuSceneUI : MonoBehaviour
    {
        public void PlayMethod()
        {
            Loader.LoadScene(Loader.Scenes.Tutorial);
        }

        public void QuitMethod()
        {
            Application.Quit();
        }
    }
}