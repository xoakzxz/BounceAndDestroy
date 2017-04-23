using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace BounceAndDestroy
{
    public class Pause : MonoBehaviour
    {
        #region Properties

        private GameObject canvas;
        private Transform pauseText;
        private Transform continueButton;
        private Transform menuButton;
        private Transform resetButton;
        private Transform winText;

        [SerializeField]
        private GameObject handheld_vida;

        private float vida;

        #endregion

        #region Unity Functions

        void Awake()
        {
            canvas = GameObject.Find("CanvasPowerUps");
            pauseText = canvas.transform.FindChild("PausaText");
            continueButton = canvas.transform.FindChild("Continuar");
            menuButton = canvas.transform.FindChild("MenuPrincipal");
            resetButton = canvas.transform.FindChild("Reintentar");
            winText = canvas.transform.FindChild("TextoGanar");
        }

        void Update()
        {
            Debug.Log(WaveController.waveEnd);
            vida= GameObject.Find("GameMaster").GetComponent<Life>().GetVida();

            if (vida <= 0)
            {
                Time.timeScale = 0;
                pauseText.gameObject.SetActive(true);
                pauseText.GetComponent<Text>().text = "GameOver";
                resetButton.gameObject.SetActive(true);
                menuButton.gameObject.SetActive(true);
            }

            if (GameObject.Find("GameMaster").GetComponent<ControlOleadas>().GetOleadaActual()==3 && WaveController.waveEnd == 0) {
                Time.timeScale = 0;
                menuButton.gameObject.SetActive(true);
                winText.gameObject.SetActive(true);

            }
        }

        #endregion

        #region Buttons Functions

        public void OnPausa()
        {
            Time.timeScale = 0;
            pauseText.gameObject.SetActive(true);
            pauseText.GetComponent<Text>().text = "Pausa";
            continueButton.gameObject.SetActive(true);
            menuButton.gameObject.SetActive(true);

        }

       public  void OnContinuar()
        {
            Time.timeScale = 1;

            pauseText.gameObject.SetActive(false);
            continueButton.gameObject.SetActive(false);
            menuButton.gameObject.SetActive(false);
        }

        public void OnMenuPrincipal()
        {
            Time.timeScale = 1;
            
            SceneLoader.Instance.LoadNextScene();
        }

        public void OnReintentar()
        {
            foreach (GameObject gameObject in FindObjectsOfType(typeof(GameObject)))
            {
                switch (gameObject.name)
                {
                    case "Sphere(Clone)":
                        break;

                    case "Mediana(Clone)":
                        break;

                    case "grande(Clone)":
                        break;

                    case "Pua(Clone)":
                        break;
                }

                if (gameObject.name == "Sphere(Clone)")
                {
                    PoolBolas1.Instance.ReleaseBolas(gameObject.gameObject.GetComponent<Rigidbody>());
                }
                else if (gameObject.name == "Mediana(Clone)")
                {
                    PoolBolas2.Instance.ReleaseBolas(gameObject.gameObject.GetComponent<Rigidbody>());
                }
                else if (gameObject.name == "grande(Clone)")
                {
                    PoolBolas3.Instance.ReleaseBolas(gameObject.gameObject.GetComponent<Rigidbody>());
                }
                else if (gameObject.name == "Pua(Clone)")
                {
                    PoolBolas4.Instance.ReleaseBolas(gameObject.gameObject.GetComponent<Rigidbody>());
                }

            }

            handheld_vida.SetActive(true);

            GameObject.Find("GameMaster").GetComponent<ControlOleadas>().SetOleadaActual(0);
            WaveController.waveEnd = 0;
            GameObject.Find("GameMaster").GetComponent<Life>().SetVida(100);

            Time.timeScale = 1;

            pauseText.gameObject.SetActive(false);
            resetButton.gameObject.SetActive(false);
            menuButton.gameObject.SetActive(false);
        }

        #endregion
    }
}