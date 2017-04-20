using UnityEngine;
using System.Collections;

namespace BounceAndDestroy
{ 
    public class DisableBall : MonoBehaviour {

        #region Properties

        [SerializeField]
        private Transform spawnPoint;
        [SerializeField]
        private float velocity;

        #endregion

        #region Functions

        void OnTriggerExit(Collider other)
        {
            Disable(other.gameObject);
        }

        public void Disable(GameObject other)
        {
            other.gameObject.SetActive(false);
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.GetComponent<Transform>().position = spawnPoint.position;

            StartCoroutine(SpawnBall(other.gameObject));
        }

        #endregion

        #region Coroutines

        IEnumerator SpawnBall(GameObject ball)
        {
            yield return new WaitForSeconds(2f);

            ball.SetActive(true);
            ball.GetComponent<Renderer>().material.color = Color.green;
            ball.GetComponent<Rigidbody>().AddForce(transform.right * velocity);

            yield return new WaitForSeconds(0.1f);

        }

        #endregion
    }
}