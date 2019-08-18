using UnityEngine;

namespace Scripts.Managers
{
    interface IAudioManager
    {
        float CurrentAudioVolume { get; }

        void SetVolume(float volume);
    }

    public class AudioManager : MonoBehaviour, IAudioManager
    {
        #region VARIABLES

        [SerializeField] private AudioSource mainAudioSource = null;

        #endregion // VARIABLES

        #region PROPERTIES

        public float CurrentAudioVolume => mainAudioSource.volume;

        #endregion // PROPERTIES

        #region CONSTRUCTOR & INITS

        #endregion // CONSTRUCTOR & INITS

        #region PUBLIC METHODS

        public void SetVolume(float volume)
        {
            mainAudioSource.volume = volume;
        }

        #endregion // PUBLIC METHODS

        #region PRIVATE METHODS

        #endregion // PRIVATE METHODS
    }
}