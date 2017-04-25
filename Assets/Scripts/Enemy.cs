using UnityEngine;

namespace BounceAndDestroy
{
    public class Enemy : MonoBehaviour
    {
        #region Properties

        [SerializeField]
        private bool isInMenu;

        [Space(10f)]

        [SerializeField]
        private float velocity;
        [SerializeField]
        private float maxVelocity;

        [Space(10f)]

        [SerializeField] [Range(0, 1)]
        private float smoothingFactor = 1.0f;        

        //Cached components
        private new Rigidbody rigidbody;

        #endregion

        #region Unity functions

        private void Awake()
        {
            rigidbody = gameObject.GetComponent<Rigidbody>();
        }

        private void Start()
        {
            transform.Rotate(0, 0, Random.Range(0f, 360f));

            if (!isInMenu)
            {
                if (gameObject.tag == "Ball" || gameObject.tag == "Default02")
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.green;
                }
            }

            rigidbody.AddForce(transform.right * velocity);
        }

        private void Update()
        {
            if (gameObject.GetComponent<Rigidbody>().velocity.magnitude > velocity)
            {
                gameObject.GetComponent<Rigidbody>().velocity = Vector3.ClampMagnitude(gameObject.GetComponent<Rigidbody>().velocity, maxVelocity);
            }
        }

        private void FixedUpdate()
        {
            Vector3 cVelocity = gameObject.GetComponent<Rigidbody>().velocity;
            Vector3 tVelocity = cVelocity.normalized * maxVelocity;

            gameObject.GetComponent<Rigidbody>().velocity = Vector3.Lerp(cVelocity, tVelocity, Time.deltaTime * smoothingFactor);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Core"))
            {
                collision.gameObject.GetComponent<Core>().DecreaseHealth(5);
            }
        }

        #endregion
    }
}
