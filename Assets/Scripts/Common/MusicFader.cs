using Scripts.Managers;
using UnityEngine;

namespace Scripts.Common

{
    public class MusicFader : MonoBehaviour
    {
        #region VARIABLES

        [SerializeField] private float fadeLengthInSeconds = 5f;

        private IAudioManager audioManager = null;
        private FadeState fadeState = FadeState.None;

        #endregion // VARIABLES

        #region PROPERTIES

        #endregion // PROPERTIES

        #region CONSTRUCTOR & INITS

        private void Awake()
        {
            audioManager = GetComponent<AudioManager>();
            StartFadeIn();
        }

        #endregion // CONSTRUCTOR & INITS

        #region PUBLIC METHODS

        public void StartFadeIn()
        {
            enabled = true;
            fadeState = FadeState.FadeIn;
        }

        public void StartFadeOut()
        {
            enabled = true;
            fadeState = FadeState.FadeOut;
        }

        #endregion // PUBLIC METHODS

        #region PRIVATE METHODS

        private void Update()
        {
            if (fadeState == FadeState.FadeIn)
                MusicFadeIn();
            else if (fadeState == FadeState.FadeOut)
                MusicFadeOut();
        }

        private void MusicFadeIn()
        {
            if (audioManager.CurrentAudioVolume < 1)
            {
                audioManager.SetVolume(audioManager.CurrentAudioVolume + Time.deltaTime / fadeLengthInSeconds);
            }
            else
            {
                DisableFader();
            }
        }

        private void MusicFadeOut()
        {
            if (audioManager.CurrentAudioVolume > 0)
            {
                audioManager.SetVolume(audioManager.CurrentAudioVolume - Time.deltaTime / fadeLengthInSeconds);
            }
            else
            {
                DisableFader();
            }
        }

        private void DisableFader()
        {
            fadeState = FadeState.None;
            enabled = false;
        }

        #endregion // PRIVATE METHODS
    }
}