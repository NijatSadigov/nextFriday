using TMPro;
using UnityEngine;

public class ComplimentManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI complimentText; // Reference to TextMeshPro UI element
    [SerializeField] private GameObject complimentTextBG; // Reference to TextMeshPro UI element

    [SerializeField] private string[] compliments; // Array of compliments
    [SerializeField] private float complimentDuration = 2f; // Time to show the compliment

    private void Start()
    {
        complimentText.gameObject.SetActive(false); // Hide compliment text at the start
        complimentTextBG.gameObject.SetActive(false);

    }

    public void ShowCompliment()
    {
        // Pick a random compliment
        string compliment = compliments[Random.Range(0, compliments.Length)];

        // Display it
        complimentText.text = compliment;
        complimentText.gameObject.SetActive(true);
        complimentTextBG.gameObject.SetActive(true);

        // Hide after a duration
        Invoke(nameof(HideCompliment), complimentDuration);
    }

    private void HideCompliment()
    {
        complimentText.gameObject.SetActive(false);
        complimentTextBG.gameObject.SetActive(false);
    }

}
