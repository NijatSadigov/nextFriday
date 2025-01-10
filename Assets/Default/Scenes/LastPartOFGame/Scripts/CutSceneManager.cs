using UnityEngine;
using UnityEngine.Playables;

public class CutSceneManager : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public GameObject playerController;

    void Start()
    {
        if (playableDirector != null)
        {
            playableDirector.stopped += OnCutsceneEnd;
        }

        // Optionally, disable player controls during the cutscene
        if (playerController != null)
        {
            playerController.gameObject.SetActive(false); // Disable controls during cutscene
        }
    }

    private void OnCutsceneEnd(PlayableDirector director)
    {
        Debug.Log("CutScene ended");
        if (playerController != null)
        {
            playerController.gameObject.SetActive(true); // Enable controls after cutscene
        }
    }

    void OnDestroy()
    {
        if (playableDirector != null)
        {
            playableDirector.stopped -= OnCutsceneEnd;
        }
    }
}
