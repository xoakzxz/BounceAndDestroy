using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace BounceAndDestroy
{
    public enum GameStates {main,reglas};
    public class menu : MonoBehaviour
    {
        private GameStates currentstate;

        [SerializeField]
        private GameObject mainmenu;
        [SerializeField]
        private GameObject reglasmenu;

        [SerializeField]
        private GameObject bola1;
        [SerializeField]
        private GameObject bGrande;
        [SerializeField]
        private GameObject bMediana;
        [SerializeField]
        private GameObject pua;
        [SerializeField]
        private GameObject perder;
        [SerializeField]
        private GameObject Poder1;
        [SerializeField]
        private GameObject Poder2;
        [SerializeField]
        private GameObject controles;
        [SerializeField]
        private Text descripcion;

        [SerializeField]
        private Text reglaactual;



        private int controlMenuReglas;
        // Use this for initialization

        void Awake() {
            controlMenuReglas = 1;

        }



        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            switch (currentstate)
            {
                case GameStates.main:
                    mainmenu.SetActive(true);
                    reglasmenu.SetActive(false);
                    break;
                case GameStates.reglas:
                    mainmenu.SetActive(false);
                    reglasmenu.SetActive(true);
                    break;
                    
            }

            if (controlMenuReglas < 1)
            {
                controlMenuReglas = 1;
            }

            if (controlMenuReglas > 8)
            {
                controlMenuReglas = 8;
            }

            switch (controlMenuReglas)
            {
                case 1:
                    reglaactual.text = "1/8";
                    descripcion.text = "Las bolas normales comenzaran en color verde, al colisionar con el escudo pasan a color amarillo y rojo y luego se destruiran";
                    bola1.SetActive(true);
                    bMediana.SetActive(false);
                    bGrande.SetActive(false);
                    pua.SetActive(false);
                    perder.SetActive(false);
                    Poder1.SetActive(false);
                    Poder2.SetActive(false);
                    controles.SetActive(false);
                    break;

                case 2:
                    reglaactual.text = "2/8";
                    descripcion.text = "las bolas grandes al colisionar con el escudo se separaran en dos bolas medianas ";
                    bola1.SetActive(false);
                    bMediana.SetActive(false);
                    bGrande.SetActive(true);
                    pua.SetActive(false);
                    perder.SetActive(false);
                    Poder1.SetActive(false);
                    Poder2.SetActive(false);
                    controles.SetActive(false);
                    break;
                case 3:
                    reglaactual.text = "3/8";
                    descripcion.text = "las bolas medianas al colisionar con el escudo se separaran en dos bolas normales verdes";
                    bola1.SetActive(false);
                    bMediana.SetActive(true);
                    bGrande.SetActive(false);
                    pua.SetActive(false);
                    perder.SetActive(false);
                    Poder1.SetActive(false);
                    Poder2.SetActive(false);
                    controles.SetActive(false);
                    break;
                case 4:
                    reglaactual.text = "4/8";
                    descripcion.text = "las puas a los 5 segundos explotaran separandose en 4-6 bolas normales verdes ";
                    bola1.SetActive(false);
                    bMediana.SetActive(false);
                    bGrande.SetActive(false);
                    pua.SetActive(true);
                    perder.SetActive(false);
                    Poder1.SetActive(false);
                    Poder2.SetActive(false);
                    controles.SetActive(false);
                    break;
                case 5:
                    reglaactual.text = "5/8";
                    descripcion.text = "el jugador perdera si la vida del nucleo llega a 0";
                    bola1.SetActive(false);
                    bMediana.SetActive(false);
                    bGrande.SetActive(false);
                    pua.SetActive(false);
                    perder.SetActive(true);
                    Poder1.SetActive(false);
                    Poder2.SetActive(false);
                    controles.SetActive(false);
                    break;
                case 6:
                    reglaactual.text = "6/8";
                    descripcion.text = "al activar MaxShield el nucleo sera rodeado 10 segundos por una defensa perfecta de escudos, usalo en situaciones peligrosas, este se usa con click izquierdo";
                    bola1.SetActive(false);
                    bMediana.SetActive(false);
                    bGrande.SetActive(false);
                    pua.SetActive(false);
                    perder.SetActive(false);
                    Poder1.SetActive(true);
                    Poder2.SetActive(false);
                    controles.SetActive(false);
                    break;
                case 7:
                    reglaactual.text = "7/8";
                    descripcion.text = "Al activar HPUP el nucleo recuperara 20 puntos de vida, este se usa con click izquierdo ";
                    bola1.SetActive(false);
                    bMediana.SetActive(false);
                    bGrande.SetActive(false);
                    pua.SetActive(false);
                    perder.SetActive(false);
                    Poder1.SetActive(false);
                    Poder2.SetActive(true);
                    controles.SetActive(false);
                    break;

                case 8:
                    reglaactual.text = "8/8";
                    descripcion.text = "El personaje se mueve presionando click izquierdo, y seguira la posicion del mouse ";
                    bola1.SetActive(false);
                    bMediana.SetActive(false);
                    bGrande.SetActive(false);
                    pua.SetActive(false);
                    perder.SetActive(false);
                    Poder1.SetActive(false);
                    Poder2.SetActive(false);
                    controles.SetActive(true);

                    break;
            }
        }
        public void OnSalir() {
            Application.Quit();
        }


        public void OnJugar() {
            SceneManager.LoadScene("Game");
        }

        public void OnReglas() {
            currentstate = GameStates.reglas;
        }


        public void OnAtras() {
            controlMenuReglas = 1;
            currentstate = GameStates.main;
        }


        public void SiguienteRegla() {
            controlMenuReglas = controlMenuReglas + 1;
        }
        public void anteriorRegla()
        {
            controlMenuReglas = controlMenuReglas - 1;
        }
    }
}