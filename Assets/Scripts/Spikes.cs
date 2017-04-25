using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace BounceAndDestroy
{
    public class Spikes : MonoBehaviour
    {
        #region Properties

        private int timer;
        private float time;

        private Transform canvas;
        private Transform text;

        #endregion

        #region Unity functions

        void Awake()
        {
            timer = 0;
            time = 5f;
            canvas = gameObject.transform.FindChild("Canvas");
            text = canvas.transform.Find("Timer");
        }

        void Start()
        {
            text.localPosition = text.parent.localPosition;
            StartCoroutine(Exploit());
        }

        void Update()
        {
            if (timer == 1)
            {
                text.GetComponent<Text>().text = time.ToString("N0");
                time -= Time.deltaTime;
            }
        }

        #endregion

        #region Coroutines

        IEnumerator Exploit()
        {
            yield return new WaitForSeconds(0.1f);

            timer = 1;

            yield return new WaitForSeconds(5f);

            float a = Random.Range(4f, 6f);

            for (int i = 0; i < a; i++)
            {
                PoolManager.Instance.GetBall(0, gameObject.transform.position);
            }

            PoolManager.Instance.ReleaseBall(gameObject.GetComponent<Rigidbody>(), 3);

            yield return new WaitForSeconds(0.1f);

            timer = 0;
        }

        #endregion
    }
}