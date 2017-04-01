using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace BounceAndDestroy
{
    public class pausa : MonoBehaviour
    {

        private GameObject canvas;
        private Transform PausaTexto;
        private Transform botonContinuar;
        private Transform botonMenu;
        private Transform botonReiniciar;
        private Transform ganarTexto;

        [SerializeField]
        private GameObject handheld_vida;

        private float vida;

        void Awake() {
            canvas = GameObject.Find("CanvasPowerUps");
            PausaTexto = canvas.transform.FindChild("PausaText");
            botonContinuar = canvas.transform.FindChild("Continuar");
            botonMenu = canvas.transform.FindChild("MenuPrincipal");
            botonReiniciar = canvas.transform.FindChild("Reintentar");
            ganarTexto = canvas.transform.FindChild("TextoGanar");
        }
        
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Debug.Log(ControladorWaves.WaveEnd);
            vida= GameObject.Find("GameMaster").GetComponent<Vida>().GetVida();

            if (vida <= 0)
            {
                Time.timeScale = 0;
                PausaTexto.gameObject.SetActive(true);
                PausaTexto.GetComponent<Text>().text = "GameOver";
                botonReiniciar.gameObject.SetActive(true);
                botonMenu.gameObject.SetActive(true);
            }

            if (GameObject.Find("GameMaster").GetComponent<ControlOleadas>().GetOleadaActual()==3 && ControladorWaves.WaveEnd == 0) {
                Time.timeScale = 0;
                botonMenu.gameObject.SetActive(true);
                ganarTexto.gameObject.SetActive(true);

            }
        }

        public void OnPausa() {
            Time.timeScale = 0;
            PausaTexto.gameObject.SetActive(true);
            PausaTexto.GetComponent<Text>().text = "Pausa";
            botonContinuar.gameObject.SetActive(true);
            botonMenu.gameObject.SetActive(true);

        }

       public  void OnContinuar() {
            Time.timeScale = 1;
            PausaTexto.gameObject.SetActive(false);
            botonContinuar.gameObject.SetActive(false);
            botonMenu.gameObject.SetActive(false);
        }

        public void OnMenuPrincipal() {
            Time.timeScale = 1;
            SceneManager.LoadScene("Menu");
        }

        public void OnReintentar() {

            foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
            {
                if (go.name == "Sphere(Clone)")
                {
                    PoolBolas1.Instance.ReleaseBolas(go.gameObject.GetComponent<Rigidbody>());
                }
                else if (go.name == "Mediana(Clone)")
                {
                    PoolBolas2.Instance.ReleaseBolas(go.gameObject.GetComponent<Rigidbody>());
                }
                else if (go.name == "grande(Clone)")
                {
                    PoolBolas3.Instance.ReleaseBolas(go.gameObject.GetComponent<Rigidbody>());
                }
                else if (go.name == "Pua(Clone)")
                {
                    PoolBolas4.Instance.ReleaseBolas(go.gameObject.GetComponent<Rigidbody>());
                }

            }
            handheld_vida.SetActive(true);
            GameObject.Find("GameMaster").GetComponent<ControlOleadas>().SetOleadaActual(0);
            ControladorWaves.WaveEnd = 0;
            GameObject.Find("GameMaster").GetComponent<Vida>().SetVida(100);
            Time.timeScale = 1;
            PausaTexto.gameObject.SetActive(false);
            botonReiniciar.gameObject.SetActive(false);
            botonMenu.gameObject.SetActive(false);
        }


    }
}