using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public Text[] buttonList;
    public string playerSide;

    public GameObject gameOverPanel;
    public Text gameOverText;

    private int moveCount;
    private bool winner = false;

    public GameObject restartButton;

    private void Awake() {
        gameOverPanel.SetActive(false);
        SetGameControllerReferenceOnButtons();
        playerSide = "X";
        moveCount = 0;
    }

    void SetGameControllerReferenceOnButtons() {
        for (int i = 0; i < buttonList.Length; i++) {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    public string GetPlayerSide() {
        return playerSide;
    }

    public void EndTurn() {
        //Horizontal
        moveCount++;
        if(buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide) {
            winner = true;
            GameOver();
        }
        if(buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide) {
            winner = true;
            GameOver();
        }
        if(buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide) {
            winner = true;
            GameOver();
        }

        //Vertical
        if(buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide) {
            winner = true;
            GameOver();
        }
        if(buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide) {
            winner = true;
            GameOver();
        }
        if(buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide) {
            winner = true;
            GameOver();
        }

        //Diagonal
        if(buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide) {
            winner = true;
            GameOver();
        }
        if(buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide) {
            winner = true;
            GameOver();
        }
        else if (moveCount >= 9) {
            SetGameOverText("Draw");
        }

        ChangeSides();
    }

    void GameOver() {
        SetBoardInteractable(false);
        if (winner == true) {
            SetGameOverText(playerSide + " Wins!");
        }
    }

    void ChangeSides() {
        playerSide = (playerSide == "X") ? "O" : "X";
    }

    void SetGameOverText(string value) {
        gameOverPanel.SetActive(true);
        gameOverText.text = value;
    }

    public void Restart() {
        playerSide = "X";
        moveCount = 0;
        gameOverPanel.SetActive(false);
        SetBoardInteractable(true);

        for(int i = 0; i < buttonList.Length; i++) {
            buttonList[i].text = "";
        }
    }

    void SetBoardInteractable(bool toggle) {
        for(int i = 0; i < buttonList.Length; i++) {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }   
}
