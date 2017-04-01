using UnityEngine;
using System.Collections;

public class cambiocolor : MonoBehaviour {

    [SerializeField]
    private float Velocidad;
    [SerializeField]
    private Transform puntoreaparicion;

    // Use this for initialization

    void Awake() {
        

    }
	void Start () {
	
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Sphere 1")
        {
            Renderer color = col.gameObject.GetComponent<Renderer>();

            if (color.material.color == Color.green)
            {
                col.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            }
            else if (color.material.color == Color.yellow)
            {

                col.gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
            else
            {
                col.gameObject.SetActive(false);
                col.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                col.gameObject.GetComponent<Transform>().position = puntoreaparicion.position;
                StartCoroutine(reaparecerBola(col.gameObject));

            }
        }


    }

    IEnumerator reaparecerBola(GameObject ob)
    {
        yield return new WaitForSeconds(2f);
        ob.SetActive(true);
        ob.GetComponent<Renderer>().material.color = Color.green;
        ob.GetComponent<Rigidbody>().AddForce(-transform.right * Velocidad);
        yield return new WaitForSeconds(0.1f);

    }
}
