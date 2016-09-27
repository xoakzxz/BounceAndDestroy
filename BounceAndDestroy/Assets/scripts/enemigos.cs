using UnityEngine;
using System.Collections;

public class enemigos : MonoBehaviour {

    [SerializeField]
    private float Velocidad;

    private Rigidbody rb;

    // Use this for initialization
    void Awake() {
        transform.Rotate(0, 0, Random.Range(0f, 360f));
    }

    void Start () {
       
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(transform.right * Velocidad );
      

        
    }
	
	// Update is called once per frame
	void Update () {
        
    }

  
}
