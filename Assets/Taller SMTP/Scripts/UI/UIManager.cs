using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI milestoneText;
    [SerializeField] private TextMeshProUGUI emailStatusText;
    [SerializeField] private GameObject endGamePanel;

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void ShowMilestone(string message)
    {
        milestoneText.text = message;
    }

    public void ShowEmailStatus(string message)
    {
        emailStatusText.text = message;
    }

    public void ShowEndGame()
    {
        endGamePanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}