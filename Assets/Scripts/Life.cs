using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour {

    #region Properties

    [SerializeField]
    private Scrollbar scroll_vida;
    [SerializeField]
    private GameObject handheld_vida;

    private float vida;

    #endregion

    #region Unity functions

    void Start()
    {
        vida = 100;

        scroll_vida.size = vida;
    }

    void Update()
    {
        scroll_vida.size = vida / 100;

        if (vida <= 0)
        {
            vida = 0;
            handheld_vida.SetActive(false);
        }

        if (vida >= 100)
        {
            vida = 100;
        }
    }

    #endregion

    #region Class functions

    public void CoreLife()
    { 
        if (vida > 0)
        {
            vida = vida - 5 ;
            scroll_vida.size = vida / 100;
        }
    }

    public void IncreaseLife()
    {
        vida = vida + 20;
    }

    public float GetLife()
    {
        return vida;
    }

    public void SetLife(float a)
    {
        vida = a;
    }

    #endregion
}
