using System;
using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace Scripts.Common
{
    public enum FadeState
    {
        None,
        FadeIn,
        FadeOut,
    }

    public class Fader : MonoBehaviour
    {
        #region VARIABLES

        public Action onFadeInEnd;

        [Header("FadeSettings")] [SerializeField]
        private Image fadeImage = null;

        [SerializeField] private float fadeSpeed = 0.5f;

        private float alpha = 0f;
        private FadeState fadeState = FadeState.None;

        #endregion // VARIABLES

        #region PROPERTIES

        #endregion // PROPERTIES

        #region CONSTRUCTOR & INITS

        #endregion // CONSTRUCTOR & INITS

        #region PUBLIC METHODS

        #endregion // PUBLIC METHODS

        public void StartFade()
        {
            fadeState = FadeState.FadeIn;
            gameObject.SetActive(true);
        }

        public void EndFade()
        {
            fadeState = FadeState.FadeOut;
        }

        #region PRIVATE METHODS

        private void Update()
        {
            if (fadeState == FadeState.FadeIn)
                FadeIn();
            else if(fadeState == FadeState.FadeOut)
                FadeOut();
        }

        private void FadeIn()
        {
            if (alpha <= 1)
            {
                alpha += fadeSpeed * Time.deltaTime;
                SetAlphaColor(alpha);
            }
            else
            {
                onFadeInEnd();
                ResetFadeState();
            }
        }

        private void FadeOut()
        {
            if (alpha > 0)
            {
                alpha -= fadeSpeed * Time.deltaTime;
                SetAlphaColor(alpha);
            }
            else
            {
                ResetFadeState();
                gameObject.SetActive(false);
            }
        }

        private void SetAlphaColor(float alpha)
        {
            fadeImage.color = new Color(0, 0, 0, alpha);
        }
        
        private void ResetFadeState()
        {
            fadeState = FadeState.None;
        }

        #endregion // PRIVATE METHODS
    }
}