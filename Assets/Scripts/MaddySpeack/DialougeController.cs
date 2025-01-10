using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using UnityEngine.Rendering;

struct Dialogue
{
    public bool person; //0 Maddie, 1 Nijat
    public string text;
    public Dialogue(bool person, string text)
    {
        this.person = person;
        this.text = text;
    }
}

public class DialougeController : MonoBehaviour
{
    [SerializeField] PlayableDirector cutScene;
    [SerializeField] GameObject dialougeBackground;
    [SerializeField] GameObject pic;

    [SerializeField ]GameObject maddyFace;
    [SerializeField ]GameObject nijatFace;
    [SerializeField ]TextMeshProUGUI dialogueField;
    [SerializeField] List<Dialogue> dialogues = new List<Dialogue> ();
    [SerializeField] GameObject spaceText;
    int currentDialogue = -1;

    void Start()
    {
        Dialogue d1 = new Dialogue(false, "Hey, why u get these flowers?");
        Dialogue d2 = new Dialogue(true, "Well, you told that you are sad.\nBecause you were expecting something special but it did not happened.");
        Dialogue d3 = new Dialogue(false, "mmmmhm");
        Dialogue d4 = new Dialogue(true, "I really like you so I just thought maybe I can do something special for u.");
        Dialogue d5 = new Dialogue(false, "mmmmhm");
        dialogues.Add(d1);
        dialogues.Add(d2);
        dialogues.Add(d3);
        dialogues.Add(d4);    
        dialogues.Add(d5);
        changeNextDialogue();
        if (cutScene != null)
        {
            // Subscribe to the 'stopped' event
            cutScene.stopped += OnCutsceneFinished;
        }


        Debug.Log(cutScene != null ? "cutScene is assigned." : "cutScene is not assigned.");
    }
    private void OnCutsceneFinished(PlayableDirector director)
    {
        if (director == cutScene)
        {
            // Load the next scene
            LoadNextScene();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(currentDialogue);

          changeNextDialogue();
        }
    }
    void changeNextDialogue()
    {
        currentDialogue++;
        if ( currentDialogue>= dialogues.Count ) {
            Debug.Log("err"+dialogues.Count);
            maddyFace.gameObject.SetActive(false);
            nijatFace.gameObject.SetActive(false);
            dialogueField.gameObject.SetActive(false);
            dialougeBackground.gameObject.SetActive(false);
            pic.gameObject.SetActive(false);
            spaceText.SetActive(false);
            cutScene.Play();
            // LoadNextScene();
        }
        else
        {

            if (dialogues[currentDialogue].person == false)
            {
                maddyFace.gameObject.SetActive(true);
                nijatFace.gameObject.SetActive(false);
            }
            else
            {
                maddyFace.gameObject.SetActive(false);
                nijatFace.gameObject.SetActive(true);
            }
            dialogueField.text= dialogues[currentDialogue].text;
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
