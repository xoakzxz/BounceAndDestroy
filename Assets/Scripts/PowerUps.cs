using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace BounceAndDestroy
{
    public class PowerUps : MonoBehaviour
    {
        #region Properties

        private int backupMaxShield;
        private int backupHPUP;

        [SerializeField]
        private int maxShieldAmount;
        [SerializeField]
        private int HPUPAmount;

        [Space(10f)]

        [SerializeField]
        GameObject[] shields = new GameObject[4];

        [SerializeField]
        private Text textMaxShield;
        [SerializeField]
        private Text textMaxHp;

        [SerializeField]
        private Transform CantidadMS;
        [SerializeField]
        private Transform Cantidadhp;

        //int que controla si se ha usado el max shield
        private int timerMS;
        private int timerHP;
        //float que mostrara un timer de cuanto queda para usar nueva,ente hp
        private float tiempoMS;
        private float tiempoHp;

        //cotrolador max shield para que el jugador no pueda usarlo dos veces seguidas
        private bool controladorMS;
        private bool controladorHP;

        //cast del script Vida
        private GameObject vida;
        private int actualWave;

        #endregion

        void Awake()
        {
            vida = GameObject.Find("GameMaster");
            controladorMS = false;
            controladorHP = false;
            timerMS = 0;
            tiempoMS = 10f;
            tiempoHp = 20f;

            backupMaxShield = maxShieldAmount;
            backupHPUP = HPUPAmount;
        }

        void Start()
        {
            CantidadMS.GetComponent<Text>().text = "X" + maxShieldAmount;
            Cantidadhp.GetComponent<Text>().text = "X" + HPUPAmount;
        }

        void Update()
        {
            actualWave = GameObject.FindGameObjectWithTag("GameController").GetComponent<WaveController>().GetActualWave();

            if (actualWave == 0 && WaveController.waveEnd == 0)
            {
                maxShieldAmount= backupMaxShield;
                HPUPAmount = backupHPUP ;
                CantidadMS.GetComponent<Text>().text = "X" + maxShieldAmount;
                Cantidadhp.GetComponent<Text>().text = "X" + HPUPAmount;
            }

            if (timerMS == 1)
            {
                textMaxShield.text = tiempoMS.ToString("N0");
                tiempoMS -= Time.deltaTime;
            }
            if (timerHP == 1)
            {
                textMaxHp.text = tiempoHp.ToString("N0");
                tiempoHp -= Time.deltaTime;
            }
        }

        public void OnMaxShield()
        {
            if (controladorMS == false)
            {
                StartCoroutine(MaxShield());
            }
        }

        public void OnHPUP()
        {
            if (controladorHP==false)
            {
                vida.GetComponent<Core>().IncreaseHealth(20f);
                StartCoroutine(HPUP());
            }
        }

        private IEnumerator MaxShield()
        {
            if (maxShieldAmount > 0 )
            {
                yield return new WaitForSeconds(0.1f);

                controladorMS = true;
                timerMS = 1;
                maxShieldAmount--;
                CantidadMS.GetComponent<Text>().text = "X" + maxShieldAmount;

                foreach (GameObject shield in shields)
                {
                    shield.SetActive(true);
                }

                yield return new WaitForSeconds(10f);

                foreach (GameObject shield in shields)
                {
                    shield.SetActive(false);
                }

                yield return new WaitForSeconds(0.1f);

                controladorMS = false;
                timerMS = 0;
                tiempoMS = 10f;
                textMaxShield.text = "MaxShield";

                yield return new WaitForSeconds(0.1f);
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
            }
        }

        private IEnumerator HPUP()
        {
            if (HPUPAmount>0)
            { 
                yield return new WaitForSeconds(0.1f);
                
                timerHP = 1;
                controladorHP = true;
                HPUPAmount--;
                Cantidadhp.GetComponent<Text>().text = "X" + HPUPAmount;

                yield return new WaitForSeconds(20f);

                controladorHP = false;
                tiempoHp = 20f;
                timerHP = 0;
                textMaxHp.text = "HPUP";

                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
