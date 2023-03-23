using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeGrid : MonoBehaviour {
    
    public GameObject matrixPrefab;

    private TicTacToeButton[] matrix = new TicTacToeButton[9];
    
    // Start is called before the first frame update
    void Start() {
        
    }

    public void Build() {
        for(int i = 0; i<=8; i++) {
            GameObject newCell = Instantiate(matrixPrefab, transform);

            matrix[i] = newCell.GetComponent<TicTacToeButton>();
        }
    }
}
