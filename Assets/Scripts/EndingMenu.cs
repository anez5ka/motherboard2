using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingMenu : MonoBehaviour
{
    [SerializeField] GameObject endingMenu;
    [SerializeField] GameObject winner;
    [SerializeField] GameObject loser;
    private void Awake()
    {
        endingMenu.SetActive(false);
    }
    public void Win()
    {
        endingMenu.SetActive(true);
        winner.SetActive(true);
        loser.SetActive(false);
        Time.timeScale = 0;
    }
    public void Lose()
    {
        endingMenu.SetActive(true);
        winner.SetActive(false);
        loser.SetActive(true);
        Time.timeScale = 0;
    }

    public void Next()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(3);
        endingMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Home()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        endingMenu.SetActive(false);
    }
}
