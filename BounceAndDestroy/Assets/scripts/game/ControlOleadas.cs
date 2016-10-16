using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace BounceAndDestroy
{
    public class ControlOleadas : MonoBehaviour
    {


        private GameObject wave1;
        private GameObject wave2;
        private GameObject wave3;
        private GameObject wave4;
        private GameObject wave5;
        private GameObject wave6;

        

        

        //int usado para saber en que oleada estamos en todo momento
        private int OleadaActual;

      

        private float Tiempo;

        [SerializeField]
        private Text Oleada;
        [SerializeField]
        private Text tiempoTexto;


        // Use this for initialization
        void Awake() {
            wave1 = GameObject.Find("Wave1");
            wave2 = GameObject.Find("Wave2");
            wave3 = GameObject.Find("Wave3");
            wave4 = GameObject.Find("Wave4");
            wave5 = GameObject.Find("Wave5");
            wave6 = GameObject.Find("Wave6");
           
            OleadaActual = 0;
            Tiempo = 5f;
            ControladorWaves.WaveEnd = 0;
        }

        void Start()
        {
            

        }

        // Update is called once per frame
        void Update()
        {
            

            if (OleadaActual == 0 && ControladorWaves.WaveEnd == 0)
            {
                Oleada.gameObject.SetActive(true);
                tiempoTexto.gameObject.SetActive(true);
                Oleada.text = "La Primer Oleada comienza en ";
                if (Tiempo < 0)
                {
                    Oleada.gameObject.SetActive(false);
                    tiempoTexto.gameObject.SetActive(false);
                    OleadaActual = 1;
                    Tiempo = 5f;
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
                    tiempoTexto.text = Tiempo.ToString("N0");
                    Tiempo -= Time.deltaTime;
                }


            }
            else if (OleadaActual == 1 && ControladorWaves.WaveEnd == 0)
            {
                Oleada.gameObject.SetActive(true);
                tiempoTexto.gameObject.SetActive(true);
                Oleada.text = "La siguiente Oleada comienza en ";

                if (Tiempo < 0)
                {
                    int a = Random.Range(1, 3);
                    Debug.Log(a.ToString());
                    Oleada.gameObject.SetActive(false);
                    tiempoTexto.gameObject.SetActive(false);
                    OleadaActual = 2;
                    Tiempo = 5f;
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
                    tiempoTexto.text = Tiempo.ToString("N0");
                    Tiempo -= Time.deltaTime;
                }

            } else if (OleadaActual == 2 && ControladorWaves.WaveEnd == 0) {
                Oleada.gameObject.SetActive(true);
                tiempoTexto.gameObject.SetActive(true);
                Oleada.text = "La Ultima Oleada comienza en ";

                if (Tiempo < 0)
                {
                    int a = Random.Range(1, 4);
                    Debug.Log(a.ToString());
                    Oleada.gameObject.SetActive(false);
                    tiempoTexto.gameObject.SetActive(false);
                    OleadaActual = 3;
                    Tiempo = 5f;
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
                    else {
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
                    tiempoTexto.text = Tiempo.ToString("N0");
                    Tiempo -= Time.deltaTime;
                }

            }
        }

        public void SetOleadaActual(int a) {
            OleadaActual = a;
        }
        public int GetOleadaActual()
        {
            return OleadaActual;
        }

    }
}