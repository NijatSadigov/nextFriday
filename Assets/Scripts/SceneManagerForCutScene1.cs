using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerForCutScene1 : MonoBehaviour
{
    public float changeTime;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Update()
    {
        changeTime-= Time.deltaTime;
        if(changeTime < 0)
        {
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
