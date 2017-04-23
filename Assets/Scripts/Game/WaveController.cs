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

        #endregion

        #region Unity functions

        void Awake()
        {
            wave1 = GameObject.Find("Wave1");
            wave2 = GameObject.Find("Wave2");
            wave3 = GameObject.Find("Wave3");
            wave4 = GameObject.Find("Wave4");
            wave5 = GameObject.Find("Wave5");
            wave6 = GameObject.Find("Wave6");
           
            actualWave = 0;
            time = 5f;

            WaveController.waveEnd = 0;
        }

        void Update()
        {
            if (actualWave == 0 && WaveController.waveEnd == 0)
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
                    Rigidbody bullet = PoolBolas1.Instance.GetBolas();
                    bullet.transform.position = wave1.transform.FindChild("1").position;
                    Rigidbody bullet2 = PoolBolas1.Instance.GetBolas();
                    bullet2.transform.position = wave1.transform.FindChild("2").position;
                    Rigidbody bullet3 = PoolBolas1.Instance.GetBolas();
                    bullet3.transform.position = wave1.transform.FindChild("3").position;
                    Rigidbody bullet4 = PoolBolas1.Instance.GetBolas();
                    bullet4.transform.position = wave1.transform.FindChild("4").position;
                }
                else {
                    timeCounter.text = time.ToString("N0");
                    time -= Time.deltaTime;
                }


            }
            else if (actualWave == 1 && WaveController.waveEnd == 0)
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
                        Rigidbody bullet = PoolBolas3.Instance.GetBolas();
                        bullet.transform.position = wave2.transform.FindChild("1").position;
                        Rigidbody bullet2 = PoolBolas3.Instance.GetBolas();
                        bullet2.transform.position = wave2.transform.FindChild("2").position;

                    }
                    else {
                        Rigidbody bullet = PoolBolas4.Instance.GetBolas();
                        bullet.transform.position = wave3.transform.FindChild("1").position;
                        Rigidbody bullet2 = PoolBolas3.Instance.GetBolas();
                        bullet2.transform.position = wave3.transform.FindChild("2").position;
                    }


                }
                else
                {
                    timeCounter.text = time.ToString("N0");
                    time -= Time.deltaTime;
                }

            } else if (actualWave == 2 && WaveController.waveEnd == 0) {
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
                        Rigidbody bullet = PoolBolas3.Instance.GetBolas();
                        bullet.transform.position = wave4.transform.FindChild("1").position;
                        Rigidbody bullet2 = PoolBolas3.Instance.GetBolas();
                        bullet2.transform.position = wave4.transform.FindChild("2").position;
                        Rigidbody bullet3 = PoolBolas3.Instance.GetBolas();
                        bullet3.transform.position = wave4.transform.FindChild("3").position;

                    }
                    else if (a == 2)
                    {
                        Rigidbody bullet = PoolBolas4.Instance.GetBolas();
                        bullet.transform.position = wave5.transform.FindChild("1").position;
                        Rigidbody bullet2 = PoolBolas4.Instance.GetBolas();
                        bullet2.transform.position = wave5.transform.FindChild("2").position;
                    }
                    else
                    {
                        Rigidbody bullet = PoolBolas4.Instance.GetBolas();
                        bullet.transform.position = wave6.transform.FindChild("1").position;
                        Rigidbody bullet2 = PoolBolas3.Instance.GetBolas();
                        bullet2.transform.position = wave6.transform.FindChild("2").position;
                        Rigidbody bullet3 = PoolBolas3.Instance.GetBolas();
                        bullet3.transform.position = wave6.transform.FindChild("3").position;
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