using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chess : MonoBehaviour
{
    //Skeleton for Chess Game
    //Board Layout 
    //will change to whatever measurements we need
    private const int SQUARE_SIZE = 64;
    private const int BOARD_SIZE = 8 * SQUARE_SIZE; 
    private const int MARGIN = 30;  
    
    //Objects <-----INCOMPLETE
    //need to define moves that each piece can make
    //private Board board;
    //private Piece selectedPiece;
    //private Select selectedSquare;
    private bool playerTurn; //true = player 1 turn, false = player 2 turn

    void Start()
    {
        //InitializeBoard();
    }

    private void InitializeBoard() {
    //    board = new Board();
    }

    private bool TurnFlipper() {
        //something to swap whose turn it is
        return true;
    }

    void Update()
    {
        
    }
}
