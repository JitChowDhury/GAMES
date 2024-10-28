 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]float timeToCompleteQuestion = 30f;
    [SerializeField] float timetoShowCorrectAnswer = 10f;
    public bool loadNextQuestion=true;
    float timerValue;
    public bool isAnsweringQuestions;
    public float fillfraction;

    private void Update()
    {
        updateTimer();
    }

    public void CancelTimer()
    {
        timerValue = 0; 
    }

    void updateTimer()
    {
        timerValue -= Time.deltaTime;
        if (isAnsweringQuestions)
        {   if(timerValue > 0)
            {
                fillfraction = timerValue / (float)timeToCompleteQuestion;
            }
            else
            {
                isAnsweringQuestions = false;
                timerValue = timetoShowCorrectAnswer;
            }
        }
        else
        {
            if (timerValue > 0)
            {
                fillfraction = timerValue / (float)timetoShowCorrectAnswer;
            }

            else 
            {
                isAnsweringQuestions = true;
                timerValue = timeToCompleteQuestion;
                loadNextQuestion=true ;
            }
        }
        
        

    }
}
     
