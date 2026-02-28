using UnityEngine;
using TMPro;
using System.Collections;

public class InstructionFade : MonoBehaviour
{
    [SerializeField] private float fadeDuration = 2f;

    private TextMeshProUGUI instructionText;

    private void Awake()
    {
        instructionText = GetComponent<TextMeshProUGUI>();
    }

    public void BeginFade()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float timer = 0f;
        Color originalColor = instructionText.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);

            instructionText.color = new Color(
                originalColor.r,
                originalColor.g,
                originalColor.b,
                alpha
            );

            yield return null;
        }

        gameObject.SetActive(false);
    }
}