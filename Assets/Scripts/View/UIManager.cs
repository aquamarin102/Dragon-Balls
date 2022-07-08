using UnityEngine;
using UnityEngine.SceneManagement;

    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject _panelWin;
        [SerializeField] private GameObject _panelLose;

        private void Start()
        {
            Hero.WinDelegate += Win;
            Hero.LoseDelegate += Lose;
        }

        public void Win()
        {
            Time.timeScale = 0;
            _panelWin.SetActive(true);
        }

        public void Lose()
        {
            Time.timeScale = 0;
            _panelLose.SetActive(true);
        }

        public void Restart()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

        private void OnDestroy()
        {
            Hero.WinDelegate -= Win;
            Hero.LoseDelegate -= Lose;
        }
    }
