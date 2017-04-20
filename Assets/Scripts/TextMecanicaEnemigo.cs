using UnityEngine;
using System.Collections;
namespace BounceAndDestroy
{
    public class TextMecanicaEnemigo : MonoBehaviour
    {
        [SerializeField]
        private float velocity;

        private new Rigidbody rigidbody;

        private DisableBall a;

        void Awake()
        {
            rigidbody = gameObject.GetComponent<Rigidbody>();

            gameObject.SetActive(true);
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }

        void Start()
        {
            rigidbody.AddForce(transform.right * velocity);
        }
    }
}