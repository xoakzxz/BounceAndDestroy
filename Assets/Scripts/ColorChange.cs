using UnityEngine;
using System.Collections;

public class ColorChange : MonoBehaviour {

    #region Properties

    [SerializeField]
    private float velocity;
    [SerializeField]
    private Transform spawnPoint;

    #endregion

    #region Functions

    void OnCollisionEnter(Collision colision)
    {
        if (colision.gameObject.name == "Sphere 1")
        {
            Renderer color = colision.gameObject.GetComponent<Renderer>();

            if (color.material.color == Color.green)
            {
                colision.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            }
            else if (color.material.color == Color.yellow)
            {

                colision.gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
            else
            {
                colision.gameObject.SetActive(false);
                colision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                colision.gameObject.GetComponent<Transform>().position = spawnPoint.position;
                StartCoroutine(SpawnBall(colision.gameObject));
            }
        }
    }

    #endregion

    #region Coroutines

    IEnumerator SpawnBall(GameObject ball)
    {
        yield return new WaitForSeconds(2f);

        ball.SetActive(true);
        ball.GetComponent<Renderer>().material.color = Color.green;
        ball.GetComponent<Rigidbody>().AddForce(transform.right * -velocity);

        yield return new WaitForSeconds(0.1f);
    }

    #endregion
}
