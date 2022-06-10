using Quest;
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
        _panelWin.SetActive(true);
    }

    public void Lose()
    {
        _panelLose.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    private void OnDestroy()
    {
        Hero.WinDelegate -= Win;
        Hero.LoseDelegate -= Lose;
    }
}
