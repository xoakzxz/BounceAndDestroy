using UnityEngine;

public class Player : MonoBehaviour {

    #region Properties

    [SerializeField]
    private float speed;

    #endregion

    #region Unity functions

    private void Update()
    {
        if (Input.GetMouseButton(0)) transform.Translate(-speed * Time.deltaTime, 0, 0);

        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mouseOnScreen = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    #endregion

    #region Class functions

    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    #endregion
}
