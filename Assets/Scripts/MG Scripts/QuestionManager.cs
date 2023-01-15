using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuestionManager : MonoBehaviour
{
    public GameObject[] Levels;
    int currentLevel;
    public float percentage;
    float AnsweredCorrectly;   
    string percentageConverted;
    public Text TMPscore;
   


    private void Start()
    {

    

    }

   


    public void canceled() 
    {
        Levels[currentLevel].SetActive(false);
    }    public void correctAnswer() 

    {        
        if (currentLevel != Levels.Length) 
        {
            Levels[currentLevel].SetActive(false);
            AnsweredCorrectly++;
            Debug.Log("correct" + AnsweredCorrectly);
            if (currentLevel == 0)
            {
                currentLevel = 1;
                Levels[currentLevel].SetActive(true);

            }
            else if (currentLevel == 1)
            {
                currentLevel = 3;
                Levels[currentLevel].SetActive(true);
            }
            else if (currentLevel == 2) 
            {
                currentLevel = 4;
                Levels[currentLevel].SetActive(true);
            }
            else if (currentLevel == 3)
            {
                currentLevel = 2;
                Levels[currentLevel].SetActive(true);
            }
            else if (currentLevel == 4)
            {
                currentLevel = 5;
                Levels[currentLevel].SetActive(true);
            }
            else if (currentLevel == 5)
            {
                currentLevel = 6;
                Levels[currentLevel].SetActive(true);
            }
            else if (currentLevel == 6)
            {
                currentLevel = 7;
                Levels[currentLevel].SetActive(true);
            }
            else if (currentLevel == 7)
            {
                currentLevel = 8;
                Levels[currentLevel].SetActive(true);
            }
            else if (currentLevel == 8)
            {
                currentLevel = 9;
                Levels[currentLevel].SetActive(true);
                percentage = (AnsweredCorrectly / 8) * 100;
                Debug.Log("Convert " + percentage);                
            }
        }
    }
    public void incorrectAnswer()
    {
        if (currentLevel != Levels.Length)
        {
            Levels[currentLevel].SetActive(false);
            if (currentLevel == 0)
            {
                currentLevel = 1;
                Levels[currentLevel].SetActive(true);
            }
            else if (currentLevel == 1)
            {
                currentLevel = 2;
                Levels[currentLevel].SetActive(true);
            }
            else if (currentLevel == 2)
            {
                currentLevel = 5;
                Levels[currentLevel].SetActive(true);
            }
            else if (currentLevel == 3)
            {
                currentLevel = 2;
                Levels[currentLevel].SetActive(true);
            }
            else if (currentLevel == 4)
            {
                currentLevel = 5;
                Levels[currentLevel].SetActive(true);
            }
            else if (currentLevel == 5)
            {
                currentLevel = 8;
                Levels[currentLevel].SetActive(true);
            }
            else if (currentLevel == 6)
            {
                currentLevel = 8;
                Levels[currentLevel].SetActive(true);
            }
            else if (currentLevel == 7)
            {
                currentLevel = 8;
                Levels[currentLevel].SetActive(true);
            }
            else if (currentLevel == 8)
            {
                currentLevel = 9;
                Levels[currentLevel].SetActive(true);
                percentage = (AnsweredCorrectly / 8) * 100;                
                Debug.Log("RAW" + percentage);
            }
        }
    }   
    private void Update()
    {          
        TMPscore.text = ("You managed to get " + percentage + "% Well done");
    }
}