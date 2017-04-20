using UnityEngine;
using System.Collections;
namespace BounceAndDestroy
{
    public class cambiocolor2 : MonoBehaviour
    {
        [SerializeField]
        private float Velocidad;

        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.tag == "Bolas")
            {
                Renderer color = col.gameObject.GetComponent<Renderer>();

                if (color.material.color == Color.green)
                {
                    col.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                }
                else if (color.material.color == Color.yellow)
                {

                    col.gameObject.GetComponent<Renderer>().material.color = Color.red;
                }
                else
                {

                    // col.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    PoolBolas1.Instance.ReleaseBolas(col.gameObject.GetComponent<Rigidbody>());
                   
                }
            } else if (col.gameObject.tag == "BolaMediana") {
                PoolBolas2.Instance.ReleaseBolas(col.gameObject.GetComponent<Rigidbody>());
                Rigidbody bola = PoolBolas1.Instance.GetBolas();
                bola.transform.position = col.gameObject.transform.position;
                Rigidbody bola2 = PoolBolas1.Instance.GetBolas();
                bola2.transform.position = col.gameObject.transform.position;

                StartCoroutine(desactivarColisiones(bola.gameObject,bola2.gameObject,col.gameObject));
                

            } else if (col.gameObject.tag == "BolaGrande") {
                PoolBolas3.Instance.ReleaseBolas(col.gameObject.GetComponent<Rigidbody>());
                Rigidbody bola = PoolBolas2.Instance.GetBolas();
                bola.transform.position = col.gameObject.transform.position;
                Rigidbody bola2 = PoolBolas2.Instance.GetBolas();
                bola2.transform.position = col.gameObject.transform.position;
               
                StartCoroutine(desactivarColisiones(bola.gameObject,bola2.gameObject,col.gameObject));
               

            }


        }

       

        IEnumerator desactivarColisiones(GameObject a, GameObject b,GameObject c)
        {
            if (c.tag == "BolaGrande")
            {
                a.tag = "Default";
                b.tag = "Default";
                yield return new WaitForSeconds(0.3f);
                a.tag = "BolaMediana";
                b.tag = "BolaMediana";

            }
            else if (c.tag == "BolaMediana") {
                a.tag = "Default2";
                b.tag = "Default2";
                yield return new WaitForSeconds(0.3f);
                a.tag = "Bolas";
                b.tag = "Bolas";
            }
           
            yield return new WaitForSeconds(0.01f);
        }


    }
}