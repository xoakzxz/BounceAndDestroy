using UnityEngine;
using System.Collections;
namespace BounceAndDestroy
{
    public class TextMecanicaEnemigo : MonoBehaviour
    {
        [SerializeField]
        private float Velocidad;

        private Rigidbody rb;

        private desactivarbola a;


        void Awake()
        {
            rb = gameObject.GetComponent<Rigidbody>();
            gameObject.SetActive(true);
            gameObject.GetComponent<Renderer>().material.color = Color.green;


        }

        // Use this for initialization
        void Start()
        {
            rb.AddForce(transform.right * Velocidad);
        }

        // Update is called once per frame
        void Update()
        {
            /*
            if (rb.velocity.magnitude > Velocidad || rb.velocity.magnitude < 2f)
            {

                rb.velocity = rb.velocity.normalized * Velocidad;
            }
            */
        }



        void OnEnable()
        {


        }



    }
}