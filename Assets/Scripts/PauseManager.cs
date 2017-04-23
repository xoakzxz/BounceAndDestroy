using UnityEngine;

namespace BounceAndDestroy
{
    public class PauseManager : MonoBehaviour
    {
        #region Properties

        private bool isPause;

        //Singleton
        public static PauseManager Instance
        {
            get; private set;
        }

        #endregion

        #region Unity functions

        private void Awake()
        {
            if (Instance != null)
            {
                DestroyImmediate(gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        #endregion

        #region Class functions

        public bool GetPause()
        {
            return isPause;
        }

        public void SetPause(bool isPause)
        {
            this.isPause = isPause;

            switch (this.isPause)
            {
                case true:
                    Time.timeScale = 0;
                    break;

                case false:
                    Time.timeScale = 1;
                    break;
            }
        }

        #endregion
    }
}
