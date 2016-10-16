using UnityEngine;
using System.Collections;
namespace BounceAndDestroy
{
    public class enemigos : MonoBehaviour
    {

        [SerializeField]
        private float Velocidad;

        [SerializeField]
        private float VelocidadMax;

       

        private float smoothingFactor;

        private Rigidbody rb;

        // Use this for initialization
        void Awake()
        {
            smoothingFactor = 1.0f;
            transform.Rotate(0, 0, Random.Range(0f, 360f));
        }

        void Start()
        {
            if (gameObject.tag == "Bolas" || gameObject.tag == "Default2") {
                gameObject.GetComponent<Renderer>().material.color = Color.green;
            }
           
            rb = gameObject.GetComponent<Rigidbody>();
            rb.AddForce(transform.right * Velocidad);

        }

        // Update is called once per frame
        void Update()
        {
            if (gameObject.GetComponent<Rigidbody>().velocity.magnitude > Velocidad)
            {
                gameObject.GetComponent<Rigidbody>().velocity = Vector3.ClampMagnitude(gameObject.GetComponent<Rigidbody>().velocity, VelocidadMax);
            }


            
        }
        void FixedUpdate()
        {
            Vector3 cvel = gameObject.GetComponent<Rigidbody>().velocity;
            Vector3 tvel = cvel.normalized * VelocidadMax;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.Lerp(cvel, tvel, Time.deltaTime * smoothingFactor);

        }

        void OnCollisionEnter(Collision nucleo)
        {
            if (nucleo.gameObject.CompareTag("Nucleo"))
            {
                GameObject.Find("GameMaster").GetComponent<Vida>().Vida_nucleo();
            }

        }



    }
}