using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    private int nextMilestone = 10;
    private bool gameCompleted = false;

    public bool GameStarted { get; private set; } = false;

    [Header("References")]
    [SerializeField] private HexSpawner spawner;
    [SerializeField] private EmailManager emailManager;
    [SerializeField] private UIManager uiManager;

    private void Start()
    {
        uiManager.UpdateScore(score);
        uiManager.ShowMilestone("");
        uiManager.ShowEmailStatus("");
    }

    public void StartGame()
    {
        GameStarted = true;
        gameCompleted = false;
    }

    public void ConfigureEmail(string email)
    {
        if (emailManager != null)
            emailManager.SetDestinationEmail(email);
    }

    public void AddScore()
    {
        if (!GameStarted || gameCompleted)
            return;

        score++;
        uiManager.UpdateScore(score);

        if (score >= nextMilestone && score < 100)
        {
            HandleMilestone(score);
            nextMilestone += 10;
        }

        if (score >= 100)
        {
            CompleteGame();
        }
    }

    private async void HandleMilestone(int milestoneScore)
    {
        uiManager.ShowMilestone("You reached " + milestoneScore + " points!");
        uiManager.ShowEmailStatus("Sending email...");

        if (emailManager == null)
        {
            uiManager.ShowEmailStatus("Email system not configured.");
            return;
        }

        var emailContent = EmailContentBuilder.BuildMilestoneEmail(milestoneScore);

        var result = await emailManager.SendEmailAsync(
            emailContent.subject,
            emailContent.body
        );

        uiManager.ShowEmailStatus(result.message);
    }

    private async void CompleteGame()
    {
        if (gameCompleted)
            return;

        gameCompleted = true;
        GameStarted = false;

        if (spawner != null)
            spawner.StopSpawning();

        uiManager.ShowMilestone("You reached 100 points!");
        uiManager.ShowEndGame();
        uiManager.ShowEmailStatus("Sending final score...");

        Time.timeScale = 0f;

        if (emailManager == null)
        {
            uiManager.ShowEmailStatus("Email system not configured.");
            return;
        }

        var emailContent = EmailContentBuilder.BuildCompletionEmail();

        var result = await emailManager.SendEmailAsync(
            emailContent.subject,
            emailContent.body
        );

        uiManager.ShowEmailStatus(result.message);
    }
}