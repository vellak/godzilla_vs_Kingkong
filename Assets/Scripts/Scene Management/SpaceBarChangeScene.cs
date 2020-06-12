using System;
using UnityEngine;

namespace Scene_Management
{
    public class SpaceBarChangeScene : MonoBehaviour
    {
        public KeyCode keyToPressNextScene;
        public KeyCode keyToPressReloadScene;
        public Loader.Scenes sceneSwitchTo;
        public Loader.Scenes sceneReload;
        

        private void Update()
        {
            if (Input.GetKeyDown(keyToPressNextScene))
            {
                Loader.LoadScene(sceneSwitchTo);
            }

            if (Input.GetKeyDown(keyToPressReloadScene))
            {
                Loader.LoadScene(sceneReload);
            }
        }
    }
}