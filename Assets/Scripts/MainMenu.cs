using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;

    private void Start()
    {
        DisplayFinalScore();
    }

    private void DisplayFinalScore()
    {
        if (finalScoreText != null)
        {
            int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
            finalScoreText.text = $"Final Score: {finalScore}";
        }
    }

    // also used for restarting
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
