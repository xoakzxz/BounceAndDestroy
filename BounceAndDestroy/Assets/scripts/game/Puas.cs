using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace BounceAndDestroy
{
    public class Puas : MonoBehaviour
    {
        private int timer;
        private float tiempo;
        private Transform canvas;
        private Transform text;
   

        // Use this for initialization
        void Awake() {
            timer = 0;
            tiempo = 5f;
            canvas = gameObject.transform.FindChild("Canvas");
            text = canvas.transform.Find("Timer");
            
        }



        void Start()
        {
            text.localPosition = text.parent.localPosition;
            StartCoroutine(Explotar());
            
        }

        // Update is called once per frame
        void Update()
        {
            if (timer == 1)
            {
                text.GetComponent<Text>().text = tiempo.ToString("N0");
                tiempo -= Time.deltaTime;
            }
        }

        IEnumerator Explotar()
        {
            yield return new WaitForSeconds(0.1f);
            timer = 1;
            yield return new WaitForSeconds(5f);
            float a = Random.Range(4f, 6f);

            for (int i = 0; i < a; i++)
            {
                Rigidbody bola = PoolBolas1.Instance.GetBolas();
                bola.transform.position = gameObject.transform.position;
            }
            PoolBolas4.Instance.ReleaseBolas(gameObject.GetComponent<Rigidbody>());
            yield return new WaitForSeconds(0.1f);
            timer = 0;


        }
    }
}