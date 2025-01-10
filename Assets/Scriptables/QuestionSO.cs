using UnityEngine;

[CreateAssetMenu(menuName ="Question",fileName="New question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField]string question = "Enter New Question";
    [SerializeField] string[] answers= new string[4];
    [SerializeField] int[] correctAnswerIndexes = new int[2];
    [SerializeField] string[] answerReactionText = new string[4];
    [SerializeField] Sprite[] answerReactionSprite = new Sprite[4];

    public string GetQuestion()
    {
        return question;
    }
    public string[] GetAnswers()
    {
        return answers;
    }
    public string GetAnswer(int i)
    {
        return answers[i];
    }
    public int[] GetCorrectAnswerIndex()
    {
        return correctAnswerIndexes;
    }
    public string[] GetAnswerReactionTexts()
    {
        return answerReactionText;
    }
    public string GetAnswerReactionText(int i)
    {
        return answerReactionText[i];
    }
    public Sprite GetSprite(int i)
    {
        return (answerReactionSprite[i]);
    }


}
