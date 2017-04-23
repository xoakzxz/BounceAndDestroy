using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BounceAndDestroy
{
    public class PoolManager : MonoBehaviour
    {
        #region Properties

        [Header("Pool settings")]

        public int[] ballsPoolSize = new int[4];
        public Rigidbody[] ballsPrefabs = new Rigidbody[4];
        public List<Rigidbody>[] balls = new List<Rigidbody>[4];

        //Singleton
        public static PoolManager Instance
        {
            get; private set;
        }

        #endregion

        #region Unity functions

        private void Awake()
        {
            if (Instance != null)
            {
                DestroyImmediate(gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        private void Start()
        {
            for (int i = 0; i < balls.Length; i++)
            {
                balls[i] = new List<Rigidbody>();
            }

            PreparePool();
        }

        #endregion

        #region Pool functions

        private void PreparePool()
        {
            for (int listIndex = 0; listIndex < balls.Length; listIndex++)
            {
                for (int i = 0; i < ballsPoolSize[listIndex]; i++)
                {
                    AddBall(ballsPrefabs[listIndex], listIndex);
                }
            }
        }

        public Rigidbody GetBall(int index, Vector3 position)
        {
            WaveController.waveEnd++;

            if (balls[index].Count == 0)
            {
                AddBall(ballsPrefabs[index], index);
            }

            return ObtainBall(index, position);
        }

        public void ReleaseBall(Rigidbody ball, int index)
        {
            WaveController.waveEnd--;

            ball.gameObject.SetActive(false);
            ball.GetComponent<Renderer>().material.color = Color.green;
            balls[index].Add(ball);
        }

        private void AddBall(Rigidbody ball, int index)
        {
            Rigidbody instance = Instantiate(ball);
            instance.gameObject.SetActive(false);
            balls[index].Add(ball);
        }

        private Rigidbody ObtainBall(int index, Vector3 position)
        {
            List<Rigidbody> ballList = balls[index];

            Rigidbody ball = ballList[ballList.Count - 1];
            ballList.RemoveAt(balls[index].Count - 1);
            ball.gameObject.SetActive(true);

            return ball;
        }

        #endregion
    }

}