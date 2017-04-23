using UnityEngine;

namespace BounceAndDestroy
{
    public class MenuEnemies : MonoBehaviour
    {
        #region Properties

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

        void Awake()
        {
            rigidbody = gameObject.GetComponent<Rigidbody>();

            transform.Rotate(0, 0, Random.Range(0f, 360f));
        }

        void Start()
        {
            rigidbody.AddForce(transform.right * velocity);
        }

        void Update()
        {
            if (gameObject.GetComponent<Rigidbody>().velocity.magnitude > velocity)
            {
                gameObject.GetComponent<Rigidbody>().velocity = Vector3.ClampMagnitude(gameObject.GetComponent<Rigidbody>().velocity, maxVelocity);
            }
        }

        void FixedUpdate()
        {
            Vector3 cVelocity = gameObject.GetComponent<Rigidbody>().velocity;
            Vector3 tVelocity = cVelocity.normalized * maxVelocity;

            gameObject.GetComponent<Rigidbody>().velocity = Vector3.Lerp(cVelocity, tVelocity, Time.deltaTime * smoothingFactor);
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Nucleo"))
            {
                GameObject.Find("GameMaster").GetComponent<Life>().Vida_nucleo();
            }
        }

        #endregion
    }
}