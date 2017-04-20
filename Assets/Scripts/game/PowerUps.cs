using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace BounceAndDestroy
{
    public class PowerUps : MonoBehaviour
    {
        [SerializeField]
        private int cantidadMaxShield;
        [SerializeField]
        private int cantidadHpup;

        private int backupCMS;
        private int backupCHP;

        [SerializeField]
        GameObject Shield1;
        [SerializeField]
        GameObject Shield2;
        [SerializeField]
        GameObject Shield3;
        [SerializeField]
        GameObject Shield4;

        private GameObject canvas;
        [SerializeField]
        private Text textMaxShield;
        [SerializeField]
        private Text textMaxHp;

        private Transform CantidadMS;
        private Transform Cantidadhp;

        //int que controla si se ha usado el max shield
        private int timerMS;
        //int que controla si se ha usado hp
        private int timerHP;
        //float que mostrara un timer de cuanto queda del power up
        private float tiempoMS;
        //float que mostrara un timer de cuanto queda para usar nueva,ente hp
        private float tiempoHp;
        // Use this for initialization

        //cotrolador max shield para que el jugador no pueda usarlo dos veces seguidas

        private bool controladorMS;
        private bool controladorHP;

        //cast del script Vida
        private GameObject vida;
        private int OleadaActual;
        
        void Awake() {
            vida = GameObject.Find("GameMaster");
            controladorMS = false;
            controladorHP = false;
            timerMS = 0;
            tiempoMS = 10f;
            tiempoHp = 20f;
            canvas = GameObject.Find("CanvasPowerUps");
            
            CantidadMS= canvas.transform.FindChild("CantidadesMaxShield");
            Cantidadhp= canvas.transform.FindChild("CantidadesHPup");
            backupCMS=cantidadMaxShield;
            backupCHP=cantidadHpup;

    }


        void Start()
        {
            CantidadMS.GetComponent<Text>().text = "X" + cantidadMaxShield;
            Cantidadhp.GetComponent<Text>().text = "X" + cantidadHpup;
        }

        // Update is called once per frame
        void Update()
        {
            OleadaActual = GameObject.Find("GameMaster").GetComponent<ControlOleadas>().GetOleadaActual();
            if (OleadaActual == 0 && ControladorWaves.WaveEnd == 0)
            {
                cantidadMaxShield= backupCMS;
                cantidadHpup = backupCHP ;
                CantidadMS.GetComponent<Text>().text = "X" + cantidadMaxShield;
                Cantidadhp.GetComponent<Text>().text = "X" + cantidadHpup;
            }

            if (timerMS == 1) {
                textMaxShield.text = tiempoMS.ToString("N0");
                tiempoMS -= Time.deltaTime;
            }
            if (timerHP == 1)
            {
                textMaxHp.text = tiempoHp.ToString("N0");
                tiempoHp -= Time.deltaTime;
            }
        }

        public void OnMaxShield() {

            if (controladorMS == false)
            {
                StartCoroutine(MaxShield());
            }

        }

        public void OnHpup() {

            if (controladorHP==false) {
                vida.GetComponent<Life>().AumentarVida();
                StartCoroutine(HpUp());
            }
        }


        IEnumerator MaxShield() {

            if (cantidadMaxShield > 0 )
            {
                yield return new WaitForSeconds(0.1f);
                controladorMS = true;
                timerMS = 1;
                cantidadMaxShield--;
                CantidadMS.GetComponent<Text>().text = "X" + cantidadMaxShield;
                Shield1.SetActive(true);
                Shield2.SetActive(true);
                Shield3.SetActive(true);
                Shield4.SetActive(true);
                yield return new WaitForSeconds(10f);
                Shield1.SetActive(false);
                Shield2.SetActive(false);
                Shield3.SetActive(false);
                Shield4.SetActive(false);
                yield return new WaitForSeconds(0.1f);
                controladorMS = false;
                timerMS = 0;
                tiempoMS = 10f;
                textMaxShield.text = "MaxShield";
                yield return new WaitForSeconds(0.1f);
            }
            else {
                yield return new WaitForSeconds(0.1f);
            }
        }

        IEnumerator HpUp() {
            if (cantidadHpup>0) { 
                yield return new WaitForSeconds(0.1f);
                
                timerHP = 1;
                controladorHP = true;
                cantidadHpup--;
                Cantidadhp.GetComponent<Text>().text = "X" + cantidadHpup;
                yield return new WaitForSeconds(20f);
                controladorHP = false;
                tiempoHp = 20f;
                timerHP = 0;
                textMaxHp.text = "HpUp";
                yield return new WaitForSeconds(0.1f);
            }

        }

        

    }
}
