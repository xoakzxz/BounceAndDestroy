using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Life : MonoBehaviour {

    [SerializeField]
    private Scrollbar scroll_vida;
    [SerializeField]
    private GameObject handheld_vida;

    private float vida;


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

    public void Vida_nucleo()
    { 
        if (vida > 0)
        {
            vida = vida - 5 ;
            scroll_vida.size = vida / 100;
        }
    }

    public void AumentarVida()
    {
        vida = vida + 20;
    }

    public float GetVida()
    {
        return vida;
    }

    public void SetVida(float a)
    {
        vida = a;
    }
}
