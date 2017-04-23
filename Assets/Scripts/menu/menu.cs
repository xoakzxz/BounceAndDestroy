using UnityEngine;
using UnityEngine.UI;

namespace BounceAndDestroy
{
    public class Menu : MonoBehaviour
    {
        #region Properties

        [Header("Menu elements")]

        [SerializeField]
        private GameObject[] menus = new GameObject[2];

        [Space(10f)]

        [SerializeField]
        private GameObject[] ruleElements = new GameObject[8];

        [Space(10f)]

        [SerializeField]
        private Text actualRule;
        [SerializeField]
        private Text description;

        [Space(10f)]

        [SerializeField]
        private string[] rules = new string[8];

        //Hidden
        private int rulesControl;

        #endregion

        #region Unity functions

        void Start()
        {
            menus[0].SetActive(true);
            menus[1].SetActive(false);
        }

        #endregion

        #region Buttons functions

        public void OnPlay()
        {
            SceneLoader.Instance.LoadNextScene();
        }

        public void OnRules()
        {
            rulesControl = 1;

            menus[0].SetActive(false);
            menus[1].SetActive(true);

            UpdateRules();
        }

        public void OnExit()
        {
            Application.Quit();
        }

        public void OnBack()
        {
            rulesControl = 1;

            menus[1].SetActive(false);
            menus[0].SetActive(true);

            UpdateRules();
        }

        public void NextRule()
        {
            rulesControl++;

            UpdateRules();
        }

        public void LastRule()
        {
            rulesControl--;

            UpdateRules();
        }

        private void UpdateRules()
        {
            actualRule.text = string.Format("{0}/8", rulesControl);

            switch (rulesControl)
            {
                case 0:
                    OnBack();
                    break;

                case 1:
                    description.text = rules[0];
                    ruleElements[7].SetActive(false);
                    ruleElements[0].SetActive(true);
                    ruleElements[1].SetActive(false);
                    break;

                case 2:
                    description.text = rules[1];
                    ruleElements[0].SetActive(false);
                    ruleElements[1].SetActive(true);
                    ruleElements[2].SetActive(false);
                    break;

                case 3:
                    description.text = rules[2];
                    ruleElements[1].SetActive(false);
                    ruleElements[2].SetActive(true);
                    ruleElements[3].SetActive(false);
                    break;

                case 4:
                    description.text = rules[3];
                    ruleElements[2].SetActive(false);
                    ruleElements[3].SetActive(true);
                    ruleElements[4].SetActive(false);
                    break;

                case 5:
                    description.text = rules[4];
                    ruleElements[3].SetActive(false);
                    ruleElements[4].SetActive(true);
                    ruleElements[5].SetActive(false);
                    break;

                case 6:
                    description.text = rules[5];
                    ruleElements[4].SetActive(false);
                    ruleElements[5].SetActive(true);
                    ruleElements[6].SetActive(false);
                    break;

                case 7:
                    description.text = rules[6];
                    ruleElements[5].SetActive(false);
                    ruleElements[6].SetActive(true);
                    ruleElements[7].SetActive(false);
                    break;

                case 8:
                    description.text = rules[7];
                    ruleElements[6].SetActive(false);
                    ruleElements[7].SetActive(true);
                    break;

                case 9:
                    OnBack();
                    break;

                default:
                    break;
            }
        }

        #endregion
    }
}
