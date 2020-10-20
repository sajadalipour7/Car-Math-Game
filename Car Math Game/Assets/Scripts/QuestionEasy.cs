using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question
{
    private string questionString;
    private string optionsString;

    private int[] optionsArray = new int[4];
    private int correctOptionIndex;

    public Question()
    {
        CreateQuestion();
    }
    public void CreateQuestion()
    {
        int x = Random.Range(0, 100);
        int y = Random.Range(0, 100);

        questionString = x.ToString() + " + " + y.ToString();
        int answer = x + y;
        optionsArray[0] = answer;



        for (int i = 1; i < 4; i++)
        {
            int randNum = Random.Range(0, 200);
            while (randNum == answer)
            {
                randNum = Random.Range(0, 200);
            }
            optionsArray[i] = randNum;
        }

        int changeIndex = Random.Range(0, 4);

        int tmp = optionsArray[changeIndex];
        optionsArray[changeIndex] = answer;
        optionsArray[0] = tmp;
        correctOptionIndex = changeIndex;

        optionsString = "A) " + optionsArray[0].ToString() + "\n\n" +
            "B) " + optionsArray[1].ToString() + "\n\n" +
            "C) " + optionsArray[2].ToString() + "\n\n" +
            "D) " + optionsArray[3].ToString();
    }

    public string GetQuestionString()
    {
        return questionString;
    }

    public string GetOptionsString()
    {
        return optionsString;
    }

    public bool AnswerQuestion(int option)
    {
        if (optionsArray[option] == optionsArray[correctOptionIndex])
        {
            return true;
        }
        return false;
    }
}
