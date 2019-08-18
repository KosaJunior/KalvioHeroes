using Scripts.Managers;
using UnityEngine;
using Zenject;

namespace Scripts.Installers
{
    public class ManagersInstaller : MonoInstaller
    {
        #region VARIABLES

        [SerializeField] private GameObject scenesManager = null;
        [SerializeField] private GameObject audioManager = null;

        #endregion

        #region PROPERTIES

        #endregion

        public override void InstallBindings()
        {
            InstantiatePrefabs();
            InstallInterfaces();
        }

        private void InstantiatePrefabs()
        {
            Container.InstantiatePrefab(audioManager);
        }

        private void InstallInterfaces()
        {
            Container.Bind<IScenesManager>().FromComponentInNewPrefab(scenesManager).AsSingle();
        }
    }
}