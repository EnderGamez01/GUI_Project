using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockPaperScissors : MonoBehaviour
{
    public Text Result;
    public Image AIChoice;

    public string[] Choices;
    public Sprite Rock, Paper, Scissors;

    public void Play(string myChoice)
    {
        string randomChoice = Choices[Random.Range(0, Choices.Length)];

        switch(randomChoice)
        {
            case "Rock":
                switch (myChoice)
                {
                    case "Rock":
                        Result.text = "Tie";
                        break;

                    case "Paper":
                        Result.text = "Paper covers the rock, You Win!";
                        break;

                    case "Scissors":
                        Result.text = "Rock beats scissors, You Lose.";
                        break;
                }

                AIChoice.sprite = Rock;
                break;
               
            case "Paper":
                switch (myChoice)
                {
                    case "Rock":
                        Result.text = "Paper covers rock, You Lose.";
                        break;

                    case "Paper":
                        Result.text = "Tie";
                        break;

                    case "Scissors":
                        Result.text = "Scissors cut paper, You Win!";
                        break;
                }

                AIChoice.sprite = Paper;
                break;

            case "Scissors":
                switch (myChoice)
                {
                    case "Rock":
                        Result.text = "Rock beats scissors, You Win!";
                        break;

                    case "Paper":
                        Result.text = "Scissors cuts paper, You Lose.";
                        break;

                    case "Scissors":
                        Result.text = "Tie";
                        break;
                }

                AIChoice.sprite = Scissors;
                break;
        }
    }
}
