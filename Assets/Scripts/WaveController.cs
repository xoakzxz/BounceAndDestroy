using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace BounceAndDestroy
{
    public class WaveController : MonoBehaviour
    {
        #region Properties

        private float time;
        private int actualWave = 0;

        [SerializeField]
        private GameObject[] waves = new GameObject[6];

        [Space(10f)]

        [SerializeField]
        private Text wave;
        [SerializeField]
        private Text timeCounter;

        //Static elements
        public static int waveEnd = 0;

        //Singleton
        public static WaveController Instance
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
            time = 5f;
        }

        private void Update()
        {
            if (actualWave == 0 && waveEnd == 0)
            {
                wave.gameObject.SetActive(true);
                timeCounter.gameObject.SetActive(true);
                wave.text = "La primera ronda comienza en:";

                if (time < 0)
                {
                    wave.gameObject.SetActive(false);
                    timeCounter.gameObject.SetActive(false);
                    actualWave = 1;
                    time = 5f;

                    PoolManager.Instance.GetBall(0, waves[0].transform.FindChild("1").position);
                    PoolManager.Instance.GetBall(0, waves[0].transform.FindChild("2").position);
                    PoolManager.Instance.GetBall(0, waves[0].transform.FindChild("3").position);
                    PoolManager.Instance.GetBall(0, waves[0].transform.FindChild("4").position);
                }
                else
                {
                    timeCounter.text = time.ToString("N0");
                    time -= Time.deltaTime;
                }
            }
            else if (actualWave == 1 && waveEnd == 0)
            {
                wave.gameObject.SetActive(true);
                timeCounter.gameObject.SetActive(true);
                wave.text = "La siguiente ronda comienza en:";

                if (time < 0)
                {
                    int a = Random.Range(1, 3);
                    Debug.Log(a.ToString());
                    wave.gameObject.SetActive(false);
                    timeCounter.gameObject.SetActive(false);
                    actualWave = 2;
                    time = 5f;

                    if (a == 1)
                    {
                        PoolManager.Instance.GetBall(2, waves[1].transform.FindChild("1").position);
                        PoolManager.Instance.GetBall(2, waves[1].transform.FindChild("2").position);
                    }
                    else
                    {
                        PoolManager.Instance.GetBall(3, waves[2].transform.FindChild("1").position);
                        PoolManager.Instance.GetBall(2, waves[2].transform.FindChild("2").position);
                    }
                }
                else
                {
                    timeCounter.text = time.ToString("N0");
                    time -= Time.deltaTime;
                }

            }
            else if (actualWave == 2 && waveEnd == 0)
            {
                wave.gameObject.SetActive(true);
                timeCounter.gameObject.SetActive(true);
                wave.text = "La última ronda comienza en:";

                if (time < 0)
                {
                    int a = Random.Range(1, 4);

                    Debug.Log(a.ToString());

                    wave.gameObject.SetActive(false);
                    timeCounter.gameObject.SetActive(false);
                    actualWave = 3;
                    time = 5f;

                    if (a == 1)
                    {
                        PoolManager.Instance.GetBall(2, waves[3].transform.FindChild("1").position);
                        PoolManager.Instance.GetBall(2, waves[3].transform.FindChild("2").position);
                        PoolManager.Instance.GetBall(2, waves[3].transform.FindChild("3").position);
                    }
                    else if (a == 2)
                    {
                        PoolManager.Instance.GetBall(3, waves[4].transform.FindChild("1").position);
                        PoolManager.Instance.GetBall(3, waves[4].transform.FindChild("2").position);
                    }
                    else
                    {
                        PoolManager.Instance.GetBall(3, waves[5].transform.FindChild("1").position);
                        PoolManager.Instance.GetBall(2, waves[5].transform.FindChild("2").position);
                        PoolManager.Instance.GetBall(2, waves[5].transform.FindChild("3").position);
                    }
                }
                else
                {
                    timeCounter.text = time.ToString("N0");
                    time -= Time.deltaTime;
                }
            }
        }

        #endregion

        #region Class functions

        public void SetActualWave(int a)
        {
            actualWave = a;
        }

        public int GetActualWave()
        {
            return actualWave;
        }

        public void GameOver()
        {
            StartCoroutine(EndGame());
        }

        #endregion

        #region Coroutines

        private IEnumerator EndGame()
        {
            if (PauseManager.Instance.GetPause())
            {
                PauseManager.Instance.SetPause(false);
            }

            yield return new WaitForEndOfFrame();

            SceneLoader.Instance.LoadNextScene();
        }

        #endregion
    }
}