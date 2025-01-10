using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstPartStoryManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI MaddysPart; // Reference to TextMeshPro UI element
    [SerializeField] GameObject answerButton;

    string first ="Maddy texted you\n" +
    "She is sad...";
    string askFist = "ask what is going on?";
    string second = "She just told that she was expecting something special to happen today, \nbut it did not.  she has anxiety because of that.";
    string secondAnswer = "It is only up to you to make her today special\nmaybe get some flowers?";
    int stage=0;
    private void Start()
    {
        MaddysPart.text = first;
        answerButton.GetComponentInChildren<TextMeshProUGUI>().text = (askFist);

    }


    public void onClickNextButton()
    {
        stage++;
        Debug.Log(stage);
        if (stage == 1) {
            MaddysPart.text = second;
            answerButton.GetComponentInChildren<TextMeshProUGUI>().text = (secondAnswer);

        }
        if (stage == 2) {
            LoadNextScene();
        }
    }

    public void LoadNextScene()
    {
        Debug.Log("Loading next scene...");

        // Get the current scene's index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Calculate the next scene index
        int nextSceneIndex = currentSceneIndex + 1;

        // Check if the next scene index is valid
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex); // Load the next scene
        }
        else
        {
            Debug.LogWarning("No more scenes to load.");
        }
    }




}
