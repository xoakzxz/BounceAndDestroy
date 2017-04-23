using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace BounceAndDestroy
{
    public class WaveController : MonoBehaviour
    {
        #region Properties

        private float time;
        private int actualWave;

        private GameObject wave1;
        private GameObject wave2;
        private GameObject wave3;
        private GameObject wave4;
        private GameObject wave5;
        private GameObject wave6;

        [SerializeField]
        private Text wave;
        [SerializeField]
        private Text timeCounter;

        //Static elements
        public static int waveEnd;

        //Singleton
        public static WaveController Instance
        {
            get; private set;
        }

        #endregion

        #region Unity functions

        void Awake()
        {
            if (Instance != null)
            {
                DestroyImmediate(gameObject);
            }
            else
            {
                Instance = this;
            }

            wave1 = GameObject.Find("Wave1");
            wave2 = GameObject.Find("Wave2");
            wave3 = GameObject.Find("Wave3");
            wave4 = GameObject.Find("Wave4");
            wave5 = GameObject.Find("Wave5");
            wave6 = GameObject.Find("Wave6");
           
            actualWave = 0;
            time = 5f;

            waveEnd = 0;
        }

        void Update()
        {
            if (actualWave == 0 && waveEnd == 0)
            {
                wave.gameObject.SetActive(true);
                timeCounter.gameObject.SetActive(true);
                wave.text = "La Primer Oleada comienza en ";

                if (time < 0)
                {
                    wave.gameObject.SetActive(false);
                    timeCounter.gameObject.SetActive(false);
                    actualWave = 1;
                    time = 5f;

                    PoolManager.Instance.GetBall(0, wave1.transform.FindChild("1").position);
                    PoolManager.Instance.GetBall(0, wave1.transform.FindChild("2").position);
                    PoolManager.Instance.GetBall(0, wave1.transform.FindChild("3").position);
                    PoolManager.Instance.GetBall(0, wave1.transform.FindChild("4").position);
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
                wave.text = "La siguiente Oleada comienza en ";

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
                        PoolManager.Instance.GetBall(2, wave2.transform.FindChild("1").position);
                        PoolManager.Instance.GetBall(2, wave2.transform.FindChild("2").position);
                    }
                    else
                    {
                        PoolManager.Instance.GetBall(3, wave3.transform.FindChild("1").position);
                        PoolManager.Instance.GetBall(2, wave3.transform.FindChild("2").position);
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
                wave.text = "La Ultima Oleada comienza en ";

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
                        PoolManager.Instance.GetBall(2, wave4.transform.FindChild("1").position);
                        PoolManager.Instance.GetBall(2, wave4.transform.FindChild("2").position);
                        PoolManager.Instance.GetBall(2, wave4.transform.FindChild("3").position);
                    }
                    else if (a == 2)
                    {
                        PoolManager.Instance.GetBall(3, wave5.transform.FindChild("1").position);
                        PoolManager.Instance.GetBall(3, wave5.transform.FindChild("2").position);
                    }
                    else
                    {
                        PoolManager.Instance.GetBall(3, wave6.transform.FindChild("1").position);
                        PoolManager.Instance.GetBall(2, wave6.transform.FindChild("2").position);
                        PoolManager.Instance.GetBall(2, wave6.transform.FindChild("3").position);
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

        public void SetActualWave(int a)
        {
            actualWave = a;
        }

        public int GetActualWave()
        {
            return actualWave;
        }
    }
}