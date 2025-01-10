using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
    public enum GameState
    {
        Intro,
        GamePlay
    }

    [SerializeField] List<string> dialogues = new List<string>();
    [SerializeField] TextMeshProUGUI dialogueField;
    [SerializeField] GameObject Canvas;
    public GameState currentState;
    [SerializeField] TextMeshProUGUI countdown;
    [SerializeField] GameObject[] points = new GameObject[3];
    [SerializeField] GameObject spawner;

    private int currentD = 0;
    private int currentPos = 1;

    private float gameTimer = 20f; // Timer for the gameplay

    void Start()
    {
        dialogueField.text = dialogues[0];
        currentState = GameState.Intro;
        spawner.SetActive(false); // Disable spawner initially
    }

    void Update()
    {
        if (currentState == GameState.Intro)
        {
            HandleIntroState();
        }
        else if (currentState == GameState.GamePlay)
        {
            HandleGamePlayState();
        }
    }

    private void HandleIntroState()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentD++;
            if (currentD >= dialogues.Count)
            {
                Canvas.gameObject.SetActive(false);
                currentState = GameState.GamePlay;
                countdown.gameObject.SetActive(true);
                spawner.SetActive(true); // Enable spawner
            }
            else
            {
                dialogueField.text = dialogues[currentD];
            }
        }
    }

    private void HandleGamePlayState()
    {
        gameTimer -= Time.deltaTime;
        countdown.text = Mathf.FloorToInt(gameTimer).ToString();
        if (gameTimer <= 0)
        {
            // Move to the next scene when timer reaches 0
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        // Player movement
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (currentPos > 0)
            {
                currentPos--;
            }
            ChangePosition();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (currentPos < 2)
            {
                currentPos++;
            }
            ChangePosition();
        }
    }

    private void ChangePosition()
    {
        transform.position = new Vector3(transform.position.x, points[currentPos].transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Restart the game
            RestartGame();
        }
    }

    private void RestartGame()
    {
        // Clear trains using the spawner's public method
        spawner.GetComponent<SpawnerScript>().ClearSpawnedTrains();

        // Reset timer
        gameTimer = 15f;

        // Reset player's position
        currentPos = 1;
        ChangePosition();
    }

}
