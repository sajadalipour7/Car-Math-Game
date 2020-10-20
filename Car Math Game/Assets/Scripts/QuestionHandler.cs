using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionHandler : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI questionText,optionsText;
    [SerializeField] Button buttonA,buttonB,buttonC,buttonD;
    [SerializeField] Movement speedChanger;

    private Question activeQuestion;
    
    // Start is called before the first frame update
    void Start()
    {
        buttonA.onClick.AddListener(()=> { Answer("A"); });
        buttonB.onClick.AddListener(() => { Answer("B"); });
        buttonC.onClick.AddListener(() => { Answer("C"); });
        buttonD.onClick.AddListener(() => { Answer("D"); });
        GenerateNewQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Answer(string option)
    {
        int index = 0;
        switch (option)
        {
            case "A":
                index = 0;
                break;
            case "B":
                index = 1;
                break;
            case "C":
                index = 2;
                break;
            case "D":
                index = 3;
                break;
            default:
                break;
        }

        bool isCorrect=activeQuestion.AnswerQuestion(index);
        if (isCorrect)
        {
            print("correct");
            speedChanger.ChangeSpeed(5f);
        }
        else
        {
            print("wrong!");
            speedChanger.ChangeSpeed(-5f);
        }

        GenerateNewQuestion();
    }

    void GenerateNewQuestion()
    {
        Question question = new Question();
        questionText.text = question.GetQuestionString();
        optionsText.text=question.GetOptionsString();
        activeQuestion = question;
    }






}
