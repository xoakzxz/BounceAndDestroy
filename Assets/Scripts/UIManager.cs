using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace BounceAndDestroy
{
    public class UIManager : MonoBehaviour
    {
        #region Properties

        [Header("HUD elements")]

        [SerializeField]
        private GameObject[] menus = new GameObject[2];

        [Space(10f)]

        [SerializeField]
        private GameObject waveSet;
        [SerializeField]
        private Text wave;
        [SerializeField]
        private Text waveTime;

        [Space(10f)]

        [SerializeField]
        private Text maxShieldAmount;
        [SerializeField]
        private Text HPUPAmount;

        [Space(10f)]

        [SerializeField]
        private GameObject lifeHandler;
        [SerializeField]
        private GameObject youWin;

        //Hidden
        private bool isWaveTime = true;
        private float waveCount = 5.0f;

        //Singleton
        public static UIManager Instance
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

        private void Start()
        {
            if (PauseManager.Instance.GetPause())
            {
                PauseManager.Instance.SetPause(false);
            }

            menus[0].SetActive(true);
            menus[1].SetActive(false);

            waveSet.SetActive(true);
        }

        private void Update()
        {
            if (isWaveTime)
            {
                StartCoroutine(UpdateWaveTime());
            }
        }

        #endregion

        #region Buttons functions

        public void OnPause()
        {
            PauseManager.Instance.SetPause(true);

            menus[0].SetActive(false);
            menus[1].SetActive(true);
        }

        public void OnContinue()
        {
            PauseManager.Instance.SetPause(false);

            menus[1].SetActive(false);
            menus[0].SetActive(true);
        }

        public void OnRetry()
        {
            if (PauseManager.Instance.GetPause())
            {
                PauseManager.Instance.SetPause(false);
            }

            SceneLoader.Instance.ReloadScene();
        }

        public void OnMenu()
        {
            if (PauseManager.Instance.GetPause())
            {
                PauseManager.Instance.SetPause(false);
            }

            SceneLoader.Instance.LoadNextScene();
        }

        #endregion

        #region Coroutines

        private IEnumerator UpdateWaveTime()
        {
            isWaveTime = false;

            if (waveCount == 0)
            {
                waveCount = 5.0f;
                waveSet.SetActive(false);

                yield return null;
            }

            waveCount--;

            yield return new WaitForSeconds(1.0f);

            waveTime.text = waveCount.ToString();
        }

        #endregion
    }
}
