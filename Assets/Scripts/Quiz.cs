using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] List<QuestionSO> questionSOs= new List<QuestionSO>();
    private int currentQuestionSOIndex=-1;
    private bool gameEnded=false;
    int numberOfQuestions = 6, 
        rightAnswers = 0;

    [SerializeField] GameObject questionText;
    [SerializeField] GameObject[] answerButtons=new GameObject[4];
    [SerializeField] GameObject ReactionGroup;
    [SerializeField] GameObject questionGroup;
    [SerializeField] GameObject nextButton;
    [SerializeField] int correctAnswerIndex;
    [SerializeField] Sprite defaultSprite;
    [SerializeField] Sprite ChosenSprite;
    void Start()
    {
        // ShowQuestion();
        ChangeStatusOfQuestionCanvas(false);
        ChangeStatusOfReactionCanvas(true);
        questionText.GetComponentInChildren<TextMeshProUGUI>().text = ("THIS GAME IS MADEN ONLY AND ONLY FOR MADDIE. YOU HAVE TO PASS MADDIE TEST!");

        ReactionGroup.GetComponentInChildren<TextMeshProUGUI>().text= "HEY NICE LOOKING GIRL \n (if you are Maddie ofc)";

    }
    private void Update()
    {
        if (gameEnded)
        {
            if (Input.GetKey(KeyCode.Space)) {
                LoadNextScene();

            }
        }
    }
    private void LoadNextScene()
    {
        // Get the current scene index and load the next one.
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Check if the next scene index is valid.
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("No more scenes to load.");
        }
    }
    void ShowQuestion()
    {
        questionText.GetComponentInChildren<TextMeshProUGUI>().text = questionSOs[currentQuestionSOIndex].GetQuestion();
        string[] answerButtonTexts = questionSOs[currentQuestionSOIndex].GetAnswers();
        for (int i = 0; i < answerButtonTexts.Length; i++)
        {
            if (!string.IsNullOrEmpty(answerButtonTexts[i]))
            {
                TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();

                answerButtons[i].SetActive(true);
                buttonText.text = answerButtonTexts[i];
            }
            else
            {
                answerButtons[i].SetActive(false);

            }
        }
    }

    void ShowReaction(int indexOfButton)
    {
        ChangeStatusOfQuestionCanvas(false);
        ChangeStatusOfReactionCanvas(true);
        ReactionGroup.GetComponentInChildren<TextMeshProUGUI>().text = questionSOs[currentQuestionSOIndex].GetAnswerReactionText(indexOfButton);
        if ( questionSOs[currentQuestionSOIndex].GetSprite(indexOfButton) != null)
        {
            Image image = ReactionGroup.GetComponentInChildren<Image>();
            image.gameObject.SetActive(true);

            ReactionGroup.GetComponentInChildren<Image>().sprite = questionSOs[currentQuestionSOIndex].GetSprite(indexOfButton);

        }
        else
        {
            Image image = ReactionGroup.GetComponentInChildren<Image>();
            image.gameObject.SetActive(false);
        }
    }
    public void OnNextButtonSelected()
    {
        ChangeStatusOfQuestionCanvas(true);
        ChangeStatusOfReactionCanvas(false);

        currentQuestionSOIndex++;
        if (currentQuestionSOIndex < questionSOs.Count)
        { 
            ShowQuestion();

        }
    
        else
        {
            ShowFinalScene();

        }
    }
    
    void ShowFinalScene()
    {
        ChangeStatusOfQuestionCanvas(false);
        ChangeStatusOfReactionCanvas(false);
        nextButton.gameObject.SetActive(false);
        gameEnded = true;
        if (rightAnswers > numberOfQuestions / 2)
        {
            questionText.GetComponentInChildren<TextMeshProUGUI>().text =rightAnswers+ " Out of 6 NICEE girl"+"\nWell you look like Maddie, Lets start the game\n Click Space to go";
        }
        else {
            questionText.GetComponentInChildren<TextMeshProUGUI>().text = rightAnswers+ " Out of 6, mmmm" + "\nI dont think you are Maddie\n Please exit the game. \n if you are REEEAAALLLLLLYYYYY MADDIEEEEE: Click Space to go";

        }
    }

    void ChangeStatusOfQuestionCanvas(bool b)
    {
        questionGroup.SetActive(b);
    }
    void ChangeStatusOfReactionCanvas(bool b)
    {
        ReactionGroup.SetActive(b);
        nextButton.SetActive(b);
    }
    public void OnAnswerSelected(int index)
    {
        int[] rightAnswerIndexes= questionSOs[currentQuestionSOIndex].GetCorrectAnswerIndex();

        if (Array.Exists(rightAnswerIndexes, element => element == index)) {
            rightAnswers++;
        }
        ShowReaction(index);
    }
}
