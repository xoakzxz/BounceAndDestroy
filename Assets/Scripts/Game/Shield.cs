using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BounceAndDestroy
{
    public class Shield : MonoBehaviour
    {
        #region Properties

        [SerializeField]
        private float velocity;

        #endregion

        #region Unity functions

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
                    PoolManager.Instance.ReleaseBall(collision.gameObject.GetComponent<Rigidbody>(), 0);
                }
            }
            else if (collision.gameObject.tag == "BallMedium")
            {
                PoolManager.Instance.ReleaseBall(collision.gameObject.GetComponent<Rigidbody>(), 1);

                Rigidbody bola1 = PoolManager.Instance.GetBall(0, collision.gameObject.transform.position);
                Rigidbody bola2 = PoolManager.Instance.GetBall(0, collision.gameObject.transform.position);

                StartCoroutine(DisableColitions(bola1.gameObject,bola2.gameObject,collision.gameObject));
            }
            else if (collision.gameObject.tag == "BallBig")
            {
                PoolManager.Instance.ReleaseBall(collision.gameObject.GetComponent<Rigidbody>(), 2);

                Rigidbody bola1 = PoolManager.Instance.GetBall(1, collision.gameObject.transform.position);
                Rigidbody bola2 = PoolManager.Instance.GetBall(1, collision.gameObject.transform.position);
               
                StartCoroutine(DisableColitions(bola1.gameObject, bola2.gameObject, collision.gameObject));
            }
        }

        #endregion

        #region Coroutines

        private IEnumerator DisableColitions(GameObject newBall01, GameObject newBall02, GameObject hittedBall)
        {
            if (hittedBall.tag == "BallBig")
            {
                newBall01.tag = "Default01";
                newBall02.tag = "Default01";

                yield return new WaitForSeconds(0.3f);

                newBall01.tag = "BallMedium";
                newBall02.tag = "BallMedium";

            }
            else if (hittedBall.tag == "BallMedium")
            {
                newBall01.tag = "Default02";
                newBall02.tag = "Default02";

                yield return new WaitForSeconds(0.3f);

                newBall01.tag = "Ball";
                newBall02.tag = "Ball";
            }
           
            yield return new WaitForSeconds(0.01f);
        }

        #endregion
    }
}