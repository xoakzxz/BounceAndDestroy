using UnityEngine;
using System.Collections;

public class Movimiento : MonoBehaviour {


    [SerializeField]
    private float speed;

    
    
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        /*
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(-Vector3.back * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(0,  speed*Time.deltaTime,0);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(0,speed* Time.deltaTime,0);
        */
       

        
        if(Input.GetMouseButton(0))
            transform.Translate(-speed * Time.deltaTime, 0, 0);
    }
}
