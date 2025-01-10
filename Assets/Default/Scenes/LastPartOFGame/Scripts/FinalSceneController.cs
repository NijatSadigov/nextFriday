using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

 public struct Dialogues
{
    public int speaker;//0-storyteller, 1 Maddy , 2 Nijat
    public string text;


}
    public class FinalSceneController : MonoBehaviour
{
  
    public List<Dialogues> dialogues = new List<Dialogues>();
    [SerializeField] List<Sprite> sprites = new List<Sprite>();
    [SerializeField] TextMeshProUGUI dialogueField;
    [SerializeField] TextMeshProUGUI narratorNameField;
    [SerializeField] GameObject dialoguePictureField;

    [SerializeField] GameObject firstCanvas;
    private bool gameEnded = false;
    private int currentD = -1;

    void Start()
    {
        firstCanvas.gameObject.SetActive(true);
        dialogues.Add(new Dialogues { speaker = 0, text = "Maddy was surprised to see Nijat standing there, a faint look of concern on his face." });
        dialogues.Add(new Dialogues { speaker = 1, text = "Hey… what are you doing here?" });
        dialogues.Add(new Dialogues { speaker = 2, text = "Hey there, beautiful. My gut told me something was wrong, so I had to come check on you." });
        dialogues.Add(new Dialogues { speaker = 2, text = "How are you holding up?" });
        dialogues.Add(new Dialogues { speaker = 1, text = "I'm fine, really. Don’t worry about me." });
        dialogues.Add(new Dialogues { speaker = 0, text = "Anyone could see through that. Maddy wasn’t the type to easily share her feelings, even with those close to her." });
        dialogues.Add(new Dialogues { speaker = 2, text = "Are you sure about that?" });
        dialogues.Add(new Dialogues { speaker = 1, text = "Yes, I don’t need help." });
        dialogues.Add(new Dialogues { speaker = 0, text = "Someone needed to remind Maddy that it’s okay to open up, to lean on someone. And who better than Nijat, the one who would never give up on her?" });
        dialogues.Add(new Dialogues { speaker = 0, text = "She didn’t trust Nijat fully yet, but trust needs a chance to grow. How could Nijat prove himself if she never let him in?" });
        dialogues.Add(new Dialogues { speaker = 0, text = "It seemed, somehow, that Maddy heard me." });
        dialogues.Add(new Dialogues { speaker = 1, text = "Since you’re already here… why not come into my treehouse? I’ll make us some hot chocolate." });
        dialogues.Add(new Dialogues { speaker = 0, text = "And so, they climbed into the cozy treehouse, where laughter replaced awkward silences, and stories were shared over steaming mugs of hot chocolate. Maybe, just maybe, the real Maddy learned something from this little adventure. Right, Maddy?" });
        currentD++;
        SetDiaologue();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && !gameEnded)
        {
            currentD++;

            if (currentD >= dialogues.Count)
            {
                EndGame();
            }
            else
            {
                SetDiaologue();
            }
        }
    }
    private void SetDiaologue()
    {
        dialogueField.text = dialogues[currentD].text;
        if (dialogues[currentD].speaker == 0) {
            //narrator
            narratorNameField.text = "Narrator";
            var rawImage = dialoguePictureField.GetComponent<RawImage>();
            rawImage.texture = sprites[0].texture;
        }
        if (dialogues[currentD].speaker == 1) {
            //Maddy
            narratorNameField.text = "Maddy";
            var rawImage = dialoguePictureField.GetComponent<RawImage>();
            rawImage.texture = sprites[1].texture;
        }
        if (dialogues[currentD].speaker == 2) {
            //Nijat
            narratorNameField.text = "Nijat";
            var rawImage = dialoguePictureField.GetComponent<RawImage>();
            rawImage.texture = sprites[2].texture;

        }

    }

    private void EndGame()
    {
        gameEnded = true;
        firstCanvas.gameObject.SetActive(false);
        LoadNextScene();
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

}
