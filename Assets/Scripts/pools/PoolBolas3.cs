using UnityEngine;
using System.Collections.Generic;
namespace BounceAndDestroy
{
    public class PoolBolas3 : MonoBehaviour
    {

        private static PoolBolas3 instance;

        public static PoolBolas3 Instance
        {
            get
            {
                return instance;
            }
        }

        [SerializeField]
        private Rigidbody BolasPrefab;

        [SerializeField]
        private int size;

        private List<Rigidbody> Bolas;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                PrepareBolas();
            }
            else
                Destroy(gameObject);
        }

        private void PrepareBolas()
        {
            Bolas = new List<Rigidbody>();
            for (int i = 0; i < size; i++)
                AddBolas();
        }

        public Rigidbody GetBolas()
        {
            ControladorWaves.WaveEnd++;
            if (Bolas.Count == 0)
                AddBolas();
            return Allocatebolas();
        }

        public void ReleaseBolas(Rigidbody bola)
        {
            ControladorWaves.WaveEnd--;
            bola.gameObject.SetActive(false);
            bola.GetComponent<Renderer>().material.color = Color.green;
            Bolas.Add(bola);
        }

        private void AddBolas()
        {
            Rigidbody instance = Instantiate(BolasPrefab);
            instance.gameObject.SetActive(false);
            Bolas.Add(instance);
        }

        private Rigidbody Allocatebolas()
        {
            Rigidbody bolas = Bolas[Bolas.Count - 1];
            Bolas.RemoveAt(Bolas.Count - 1);
            bolas.gameObject.SetActive(true);
            return bolas;
        }
    }
}