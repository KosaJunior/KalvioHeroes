using Scripts.Common;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Managers
{
    interface IScenesManager
    {
        void LoadScene(string sceneName);
    }

    public class ScenesManager : MonoBehaviour, IScenesManager
    {
        #region VARIABLES

        [SerializeField] private Fader fader = null;

        private string sceneToLoad = string.Empty;

        #endregion // VARIABLES

        #region PROPERTIES

        #endregion // PROPERTIES

        #region CONSTRUCTOR & INITS

        #endregion // CONSTRUCTOR & INITS

        #region PUBLIC METHODS

        public void LoadScene(string sceneToLoad)
        {
            this.sceneToLoad = sceneToLoad;
            
            fader.onFadeInEnd += OnFadeInEnd;
            fader.StartFade();
        }

        #endregion // PUBLIC METHODS

        #region PRIVATE METHODS

        private void OnEnable()
        {
            SceneManager.activeSceneChanged += OnSceneChanged;
        }

        private void OnDisable()
        {
            SceneManager.activeSceneChanged -= OnSceneChanged;
        }
                
        private void OnSceneChanged(Scene arg0, Scene arg1)
        {
            fader.EndFade();
        }

        private void OnFadeInEnd()
        {
            SceneManager.LoadScene(sceneToLoad);
            fader.onFadeInEnd -= OnFadeInEnd;
        }

        #endregion // PRIVATE METHODS
    }
}