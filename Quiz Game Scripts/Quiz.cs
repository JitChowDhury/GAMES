using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;



public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField]TextMeshProUGUI questionText;
    [SerializeField] List<QuestionSO> questions=new List<QuestionSO>();
    QuestionSO currentquestion;
    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    bool hasAnsweredEarly=true;
    [Header("Buttons")]

    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    [Header("Timer")]

    [SerializeField] Image timerImage;
    Timer timer;
    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;
    [Header("ProgressBar")]
    [SerializeField] Slider progressBar;
    public bool isComplete;
    private void Awake()
    {   
        timer=FindObjectOfType<Timer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        progressBar.maxValue = questions.Count;
        progressBar.value = 0; ;
        
    }
    private void Update()
    {
        timerImage.fillAmount = timer.fillfraction;
        if (timer.loadNextQuestion)
        {
            if (progressBar.value == progressBar.maxValue)
            {
                isComplete = true;
                return;
            }
            hasAnsweredEarly = false;
            getNextQuestion();
            timer.loadNextQuestion = false;
        }
        else if (!hasAnsweredEarly && !timer.isAnsweringQuestions)
        {
            DisplayAnswer(-1);
            setButtonState(false);
        }
    }
    public void OnAnswerSelected(int index)
    {
        hasAnsweredEarly = true;
        DisplayAnswer(index);
        setButtonState(false);
        timer.CancelTimer();
        scoreText.text = "Score: " + scoreKeeper.CalculateScore() + "%";
       
    }

    private void DisplayAnswer(int index)
    {
        Image buttonImage;
        if (index == currentquestion.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
            scoreKeeper.IncrementCorrectAnswers();
        }
        else
        {
            correctAnswerIndex = currentquestion.GetCorrectAnswerIndex();
            string correctAnswer = currentquestion.GetAnswer(correctAnswerIndex);
            questionText.text = "Sorry , the correct answer was: \n" + correctAnswer;
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }

    }

    void getNextQuestion()
    {  if(questions.Count > 0) { 
        setButtonState(true);
        setDefaultButtonSprites();
        GetRandomQuestion();
        displayQuestions();
            progressBar.value++;
            scoreKeeper.IncrementQuestionSeen();
        }
    }

    private void GetRandomQuestion()
    {
        int index = Random.Range(0,questions.Count);
        currentquestion=questions[index];
        if (questions.Contains(currentquestion))
        {

            questions.Remove(currentquestion);
        }
    }

    void setDefaultButtonSprites()
    {
        Image buttonImage;
        for (int i = 0; i < answerButtons.Length; i++) { 
        
            buttonImage=answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        
        }
    }

    void displayQuestions()
    {
        questionText.text = currentquestion.GetQuestion();
        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentquestion.GetAnswer(i);
        }

    }
    void setButtonState(bool state)
    {
        for (int i = 0; i < answerButtons.Length; i++) { 
        
        Button button= answerButtons[i].GetComponent<Button>();
            button.interactable=state;
        }
    }
    

}
