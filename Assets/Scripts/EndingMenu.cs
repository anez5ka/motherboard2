using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingMenu : MonoBehaviour
{
    [SerializeField] private GameObject endingMenu;
    [SerializeField] private GameObject winner;
    [SerializeField] private GameObject loser;
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

    public void Home()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        endingMenu.SetActive(false);
    }
}
