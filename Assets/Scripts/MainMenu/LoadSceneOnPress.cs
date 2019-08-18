using Scripts.Managers;
using UnityEngine;

namespace Scripts.MainMenu
{
    public class LoadSceneOnPress : MonoBehaviour
    {
        #region VARIABLES

        [SerializeField] private string sceneToLoad = "MainMenu";
        [Zenject.Inject] private IScenesManager sceneManager;

        #endregion //VARIABLES

        #region PRIVATE METHODS

        private void Update()
        {
            if (IsAnyInputDetected())
            {
                sceneManager.LoadScene(sceneToLoad);
                enabled = false;
            }
        }

        private bool IsAnyInputDetected()
        {
            return Input.anyKeyDown || Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1);
        }

        #endregion //PRIVATE METHODS
    }
}