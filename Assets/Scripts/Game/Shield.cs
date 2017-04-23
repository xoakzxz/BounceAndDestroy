using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BounceAndDestroy
{
    public class Shield : MonoBehaviour
    {
        [SerializeField]
        private float velocity;

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Ball")
            {
                Renderer color = collision.gameObject.GetComponent<Renderer>();

                if (color.material.color == Color.green)
                {
                    collision.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                }
                else if (color.material.color == Color.yellow)
                {

                    collision.gameObject.GetComponent<Renderer>().material.color = Color.red;
                }
                else
                {
                    PoolBolas1.Instance.ReleaseBolas(collision.gameObject.GetComponent<Rigidbody>());
                }

            }
            else if (collision.gameObject.tag == "BallMedium")
            {
                PoolBolas2.Instance.ReleaseBolas(collision.gameObject.GetComponent<Rigidbody>());
                Rigidbody bola = PoolBolas1.Instance.GetBolas();
                bola.transform.position = collision.gameObject.transform.position;
                Rigidbody bola2 = PoolBolas1.Instance.GetBolas();
                bola2.transform.position = collision.gameObject.transform.position;

                StartCoroutine(desactivarColisiones(bola.gameObject,bola2.gameObject,collision.gameObject));
                

            }
            else if (collision.gameObject.tag == "BallBig")
            {
                PoolBolas3.Instance.ReleaseBolas(collision.gameObject.GetComponent<Rigidbody>());
                Rigidbody bola = PoolBolas2.Instance.GetBolas();
                bola.transform.position = collision.gameObject.transform.position;
                Rigidbody bola2 = PoolBolas2.Instance.GetBolas();
                bola2.transform.position = collision.gameObject.transform.position;
               
                StartCoroutine(desactivarColisiones(bola.gameObject,bola2.gameObject,collision.gameObject));
            }
        }

        IEnumerator desactivarColisiones(GameObject a, GameObject b,GameObject c)
        {
            if (c.tag == "BallBig")
            {
                a.tag = "Default01";
                b.tag = "Default01";

                yield return new WaitForSeconds(0.3f);

                a.tag = "BallMedium";
                b.tag = "BallMedium";

            }
            else if (c.tag == "BolaMediana")
            {
                a.tag = "Default02";
                b.tag = "Default02";

                yield return new WaitForSeconds(0.3f);

                a.tag = "Bolas";
                b.tag = "Bolas";
            }
           
            yield return new WaitForSeconds(0.01f);
        }
    }
}