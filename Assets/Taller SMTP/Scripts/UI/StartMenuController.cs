using System.Net.Mail;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class StartMenuController : MonoBehaviour
{
    [SerializeField] private TMP_InputField emailInputField;
    [SerializeField] private Button startButton;
    [SerializeField] private GameObject startMenuPanel;
    [SerializeField] private InstructionFade instructionFade;
    [SerializeField] private HexSpawner spawner;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private GameManager gameManager;

    private void Start()
    {
        startButton.interactable = false;
        emailInputField.onValueChanged.AddListener(ValidateEmail);
    }

    private void ValidateEmail(string email)
    {
        email = email.Trim();

        if (IsValidEmail(email))
        {
            startButton.interactable = true;
            uiManager.ShowEmailStatus("");
        }
        else
        {
            startButton.interactable = false;
            uiManager.ShowEmailStatus("Enter a valid email address.");
        }
    }

    public void StartGame()
    {
        string email = emailInputField.text.Trim();

        if (gameManager != null)
            gameManager.ConfigureEmail(email);

        startMenuPanel.SetActive(false);

        StartCoroutine(BeginGameSequence());
    }

    private IEnumerator BeginGameSequence()
    {
        yield return new WaitForSeconds(2f);

        if (gameManager != null)
            gameManager.StartGame();

        if (spawner != null)
            spawner.StartSpawning();

        if (instructionFade != null)
            instructionFade.BeginFade();
    }

    private bool IsValidEmail(string email)
    {
        try
        {
            MailAddress addr = new MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}