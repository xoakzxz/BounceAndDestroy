using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BounceAndDestroy
{
    public enum GameStates { main, reglas };

    public class Menu : MonoBehaviour
    {
        #region Properties

        private GameStates currentState;

        [Header("Menu elements")]

        [SerializeField]
        private GameObject mainMenu;
        [SerializeField]
        private GameObject rulesMenu;

        [Space(10f)]

        [SerializeField]
        private GameObject bola1;
        [SerializeField]
        private GameObject ballBig;
        [SerializeField]
        private GameObject ballMedium;
        [SerializeField]
        private GameObject pua;
        [SerializeField]
        private GameObject perder;
        [SerializeField]
        private GameObject powerUp1;
        [SerializeField]
        private GameObject powerUp2;
        [SerializeField]
        private GameObject controls;
        [SerializeField]
        private Text description;

        [Header("UI elements")]

        [SerializeField]
        private Text actualRule;

        private int rulesMenuControl;

        #endregion

        #region Unity Functions

        void Awake()
        {
            rulesMenuControl = 1;
        }

        void Update()
        {
            switch (currentState)
            {
                case GameStates.main:
                    mainMenu.SetActive(true);
                    rulesMenu.SetActive(false);
                    break;

                case GameStates.reglas:
                    mainMenu.SetActive(false);
                    rulesMenu.SetActive(true);
                    break;
            }

            if (rulesMenuControl < 1)
            {
                rulesMenuControl = 1;
            }

            if (rulesMenuControl > 8)
            {
                rulesMenuControl = 8;
            }

            switch (rulesMenuControl)
            {
                case 1:
                    actualRule.text = "1/8";
                    description.text = "Las bolas normales comenzaran en color verde, al colisionar con el escudo pasan a color amarillo y rojo y luego se destruiran";
                    bola1.SetActive(true);
                    ballMedium.SetActive(false);
                    ballBig.SetActive(false);
                    pua.SetActive(false);
                    perder.SetActive(false);
                    powerUp1.SetActive(false);
                    powerUp2.SetActive(false);
                    controls.SetActive(false);
                    break;

                case 2:
                    actualRule.text = "2/8";
                    description.text = "las bolas grandes al colisionar con el escudo se separaran en dos bolas medianas ";
                    bola1.SetActive(false);
                    ballMedium.SetActive(false);
                    ballBig.SetActive(true);
                    pua.SetActive(false);
                    perder.SetActive(false);
                    powerUp1.SetActive(false);
                    powerUp2.SetActive(false);
                    controls.SetActive(false);
                    break;

                case 3:
                    actualRule.text = "3/8";
                    description.text = "las bolas medianas al colisionar con el escudo se separaran en dos bolas normales verdes";
                    bola1.SetActive(false);
                    ballMedium.SetActive(true);
                    ballBig.SetActive(false);
                    pua.SetActive(false);
                    perder.SetActive(false);
                    powerUp1.SetActive(false);
                    powerUp2.SetActive(false);
                    controls.SetActive(false);
                    break;

                case 4:
                    actualRule.text = "4/8";
                    description.text = "las puas a los 5 segundos explotaran separandose en 4-6 bolas normales verdes ";
                    bola1.SetActive(false);
                    ballMedium.SetActive(false);
                    ballBig.SetActive(false);
                    pua.SetActive(true);
                    perder.SetActive(false);
                    powerUp1.SetActive(false);
                    powerUp2.SetActive(false);
                    controls.SetActive(false);
                    break;

                case 5:
                    actualRule.text = "5/8";
                    description.text = "el jugador perdera si la vida del nucleo llega a 0";
                    bola1.SetActive(false);
                    ballMedium.SetActive(false);
                    ballBig.SetActive(false);
                    pua.SetActive(false);
                    perder.SetActive(true);
                    powerUp1.SetActive(false);
                    powerUp2.SetActive(false);
                    controls.SetActive(false);
                    break;

                case 6:
                    actualRule.text = "6/8";
                    description.text = "al activar MaxShield el nucleo sera rodeado 10 segundos por una defensa perfecta de escudos, usalo en situaciones peligrosas, este se usa con click izquierdo";
                    bola1.SetActive(false);
                    ballMedium.SetActive(false);
                    ballBig.SetActive(false);
                    pua.SetActive(false);
                    perder.SetActive(false);
                    powerUp1.SetActive(true);
                    powerUp2.SetActive(false);
                    controls.SetActive(false);
                    break;

                case 7:
                    actualRule.text = "7/8";
                    description.text = "Al activar HPUP el nucleo recuperara 20 puntos de vida, este se usa con click izquierdo ";
                    bola1.SetActive(false);
                    ballMedium.SetActive(false);
                    ballBig.SetActive(false);
                    pua.SetActive(false);
                    perder.SetActive(false);
                    powerUp1.SetActive(false);
                    powerUp2.SetActive(true);
                    controls.SetActive(false);
                    break;

                case 8:
                    actualRule.text = "8/8";
                    description.text = "El personaje se mueve presionando click izquierdo, y seguira la posicion del mouse ";
                    bola1.SetActive(false);
                    ballMedium.SetActive(false);
                    ballBig.SetActive(false);
                    pua.SetActive(false);
                    perder.SetActive(false);
                    powerUp1.SetActive(false);
                    powerUp2.SetActive(false);
                    controls.SetActive(true);
                    break;
            }
        }

        #endregion

        #region Buttons Functions

        public void OnExit()
        {
            Application.Quit();
        }

        public void OnPlay()
        {
            SceneLoader.Instance.LoadNextScene();
        }

        public void OnRules()
        {
            currentState = GameStates.reglas;
        }

        public void OnBack()
        {
            currentState = GameStates.main;

            rulesMenuControl = 1;
        }

        public void NextRule()
        {
            rulesMenuControl++;
        }

        public void LastRule()
        {
            rulesMenuControl--;
        }

        #endregion
    }
}