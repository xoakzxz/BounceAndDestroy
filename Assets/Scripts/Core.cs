using UnityEngine;
using UnityEngine.UI;

namespace BounceAndDestroy
{
    public class Core : MonoBehaviour
    {
        #region Properties

        [Range(0, 100)]
        public float healthPoints;
        [SerializeField]
        private Scrollbar health;

        //Hidden
        private float initialHealth;

        #endregion

        #region Unity functions

        private void Start()
        {
            initialHealth = healthPoints;
        }

        #endregion

        #region Class functions

        public void IncreaseHealth(float amount)
        {
            healthPoints += amount;

            UpdateHealthBar();
        }

        public void DecreaseHealth(float amount)
        {
            healthPoints -= amount;

            UpdateHealthBar();

            if (healthPoints <= 0)
            {
                WaveController.Instance.GameOver();
            }
        }

        private void UpdateHealthBar()
        {
            health.size = healthPoints / initialHealth;
        }

        #endregion
    }
}
