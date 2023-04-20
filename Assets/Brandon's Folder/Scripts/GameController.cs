//AUTHOR: BRANDON RUSSELL

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//class used in tandem with PlayerColor to manipulate buttons and text UI
[System.Serializable]
public class Player {
    public Image panel;
    public Text text;
    public Button button;
}

//class used to manipulate player buttons and text UI
[System.Serializable]
public class PlayerColor {
    public Color panelColor;
    public Color textColor;
}

public class GameController : MonoBehaviour {
    //array of all 9 gridspace buttons
    public Text[] buttonList;
    
    //player vs. cpu variables
    private string playerSide;
    private string cpuSide;
    public bool playerMove;
    public float delay;
    private int value;

    //panel and text for gameover
    public GameObject gameOverPanel;
    public Text gameOverText;

    //game count and conditions
    private int moveCount;
    private bool winner = false;

    //panel buttons for info boxes
    public GameObject restartButton;
    public GameObject startInfo;

    //UI player colored boxes
    public Player playerX;
    public Player playerO;
    public PlayerColor activePlayerColor;
    public PlayerColor inactivePlayerColor;

    //on start awake
    private void Awake() {
        gameOverPanel.SetActive(false);
        SetGameControllerReferenceOnButtons();
        moveCount = 0;
        playerMove = true;
    }

    void Update() {
        if (playerMove == false) {
            delay+= delay * Time.deltaTime;
            if (delay >= 50) {
                value = Random.Range(0,8);
                if (buttonList[value].GetComponentInParent<Button>().interactable == true) {
                    buttonList[value].text = GetCpuSide();
                    buttonList[value].GetComponentInParent<Button>().interactable = false;
                    EndTurn();
                }
            }
        }
    }

    void SetGameControllerReferenceOnButtons() {
        for (int i = 0; i < buttonList.Length; i++) {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    //sets starting side based off input string startingSide
    public void SetStartingSide(string startingSide) {
        playerSide = startingSide;
        if (playerSide == "X") {
            SetPlayerColors(playerX, playerO);
            cpuSide = "O";
        }
        else {
            SetPlayerColors(playerO, playerX);
            cpuSide = "X";
        }

        StartGame();
    }

    //starts the game and sets UI to make sense when the game is started
    void StartGame() {
        SetBoardInteractable(true);
        SetPlayerButtons(false);
        startInfo.SetActive(false);
    }

    //gets the player side
    public string GetPlayerSide() {
        return playerSide;
    }
    public string GetCpuSide() {
        return cpuSide;
    }

    //ends turn, checks win conditions, moves to the next turn if its not the last
    public void EndTurn() {
        //Horizontal
        moveCount++;
        if(buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide) {
            winner = true;
            GameOver();
        }
        else if(buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide) {
            winner = true;
            GameOver();
        }
        else if(buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide) {
            winner = true;
            GameOver();
        }

        //Vertical
        else if(buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide) {
            winner = true;
            GameOver();
        }
        else if(buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide) {
            winner = true;
            GameOver();
        }
        else if(buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide) {
            winner = true;
            GameOver();
        }

        //Diagonal
        else if(buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide) {
            winner = true;
            GameOver();
        }
        else if(buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide) {
            winner = true;
            GameOver();
        }
        else if (moveCount >= 9) {
            SetGameOverText("Draw");
            SetPlayerColorsInactive();
        }
        else {
            ChangeSides();
            delay = 10;
        }
    }

    //sets panel colors depending on whose turn it is
    void SetPlayerColors(Player newPlayer, Player oldPlayer) {
        newPlayer.panel.color = activePlayerColor.panelColor;
        newPlayer.text.color = activePlayerColor.textColor;
        oldPlayer.panel.color = inactivePlayerColor.textColor;
        oldPlayer.text.color = inactivePlayerColor.textColor;
    }

    //ends the game and shows winner/draw
    void GameOver() {
        SetBoardInteractable(false);

        if (winner == true) {
            SetGameOverText(playerSide + " Wins!");
        }
    }

    //flips the turn
    void ChangeSides() {
        playerMove = (playerMove == true) ? false : true;

        if (playerSide == "X") {
            SetPlayerColors(playerX, playerO);
        }
        else {
            SetPlayerColors(playerO, playerX);
        }
    }

    //sets the text of the game over box(needed to switch between draw and winner)
    void SetGameOverText(string value) {
        gameOverPanel.SetActive(true);
        gameOverText.text = value;
    }

    //restart button
    public void Restart() {
        moveCount = 0;
        gameOverPanel.SetActive(false);
        SetPlayerButtons(true);
        SetPlayerColorsInactive();
        startInfo.SetActive(true);
        playerMove = true;
        delay = 10;

        for(int i = 0; i < buttonList.Length; i++) {
            buttonList[i].text = "";
        }
    }

    //makes the gridspaces interactable
    void SetBoardInteractable(bool toggle) {
        for(int i = 0; i < buttonList.Length; i++) {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }   

    //makes the choose player buttons interactable
    void SetPlayerButtons(bool toggle) {
        playerX.button.interactable = toggle;
        playerO.button.interactable = toggle;
    }

    //sets the player colors to inactive
    void SetPlayerColorsInactive() {
        playerX.panel.color = inactivePlayerColor.panelColor;
        playerX.text.color = inactivePlayerColor.textColor;
        playerO.panel.color = inactivePlayerColor.panelColor;
        playerO.text.color = inactivePlayerColor.textColor;
    }
}
