using UnityEngine;
using System.Collections;


namespace BounceAndDestroy { 

        public class desactivarbola : MonoBehaviour {
            [SerializeField]
            private Transform puntoreaparicion;
            [SerializeField]
            private float Velocidad;
            // Use this for initialization
            void Start () {
	
	        }
	
	        // Update is called once per frame
	        void Update () {
	
	        }

            void OnTriggerExit(Collider other)
            {
                Desactivado(other.gameObject);

            }

            IEnumerator reaparecerBola(GameObject a) {
                yield return new WaitForSeconds(2f);
                a.SetActive(true);
                a.GetComponent<Renderer>().material.color = Color.green;
                a.GetComponent<Rigidbody>().AddForce(transform.right * Velocidad);
                yield return new WaitForSeconds(0.1f);

            }

            public void Desactivado(GameObject other) {
                other.gameObject.SetActive(false);
                other.GetComponent<Rigidbody>().velocity = Vector3.zero;
                other.GetComponent<Transform>().position = puntoreaparicion.position;
                StartCoroutine(reaparecerBola(other.gameObject));
            }
        }
}