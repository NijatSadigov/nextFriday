using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static IntroController;

public class FINAL : MonoBehaviour
{
    [SerializeField]
    List<string> texts = new List<string>();
    int currentD = -1;
    [SerializeField] TextMeshProUGUI textField;
    [SerializeField]
    GameObject Canvas;
    [SerializeField]
    GameObject buttons;
    bool gameFinished = false;

    [SerializeField] List<GameObject> reactions = new List<GameObject>();
    private void Start()
    {
        ChangeText();
        for (int i = 0; i < reactions.Count; i++) { 
        reactions[i].SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) &&!gameFinished)
        {
            ChangeText();
        }
        if (gameFinished) {
        

        
        }

    }
    public void ButtonReactions(int i)
    {
        buttons.gameObject.SetActive(false);
        reactions[i].SetActive(true);
        if (i==0)
        {
            textField.text = "YEYYYYY\n(Game ended to exit click alt+f4)";
        }
        else if (i == 1)
        {
            textField.text = "YEYEYEYEYEYEYEYEYEYEYEYEYYEEYYEYEYEYEYEYEYEY\n(Game ended to exit click alt+f4)";

        }
        else if (i == 2)
        {
            textField.text = "EYEYEYEYEYEYYEYEYEYEYEYEYEYEYEYEYEYEYEYEYEYEYEYE\n from now on I will believe in GOD\nEYYEYEYEYEYEYEY\n(Game ended to exit click alt+f4)";

        }
    }

    private void ChangeText()
    {
        currentD++;
        if (currentD >= texts.Count)
        {
            //Canvas.gameObject.SetActive(false);
            gameFinished = true;

        }

        if (currentD == texts.Count-1)
        {
            textField.text = texts[currentD];

            buttons.gameObject.SetActive(true);
            gameFinished = true;

        }
        else if(currentD< texts.Count - 1) 
            {
                textField.text = texts[currentD];
            }

    }
}
