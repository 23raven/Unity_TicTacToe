using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isXTurn = true;
    public Cell[] cells;
    private bool isGameOver = false;
    private int moveCount = 0;
    public GameObject restartButton;

    public TMP_Text turnText;
    public TMP_Text resultText;

    int[,] winPatterns = new int[,]
{
    {0,1,2}, {3,4,5}, {6,7,8},
    {0,3,6}, {1,4,7}, {2,5,8},
    {0,4,8}, {2,4,6}
};

    private void Start()
    {
        restartButton.SetActive(false);
        resultText.gameObject.SetActive(false);
    }

    void UpdateTurnText()
    {
        string player = isXTurn ? "X" : "O";
        turnText.text = player;
    }

    public void MakeMove(Cell cell)
    {
        if (isGameOver) return;

        if (isXTurn)
            cell.SetX();
        else
            cell.SetO();

        moveCount++;

        if (CheckWin())
        {
            isGameOver = true;

            string winner = isXTurn ? "X" : "O";
            Debug.Log("Winner: " + winner);
            resultText.gameObject.SetActive(true);
            resultText.text = "Winner: " + winner;
            restartButton.SetActive(true);
            return;
        }

        if (moveCount >= 9)
        {
            isGameOver = true;
            Debug.Log("DRAW");
            resultText.text = "Draw!";
            restartButton.SetActive(true);
            return;
        }

        isXTurn = !isXTurn;
        UpdateTurnText();

    }

    bool CheckWin()
    {
        for (int i = 0; i < 8; i++)
        {
            Cell a = cells[winPatterns[i, 0]];
            Cell b = cells[winPatterns[i, 1]];
            Cell c = cells[winPatterns[i, 2]];

            if (a.IsSame(b) && b.IsSame(c))
            {
                HighlightWin(a, b, c);
                return true;
            }
        }

        return false;
    }

    void HighlightWin(Cell a, Cell b, Cell c)
    {
        foreach (Cell cell in cells)
        {
            if (cell != a && cell != b && cell != c)
            {
                cell.Fade();
            }
        }
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public void ResetGame()
    {
        isGameOver = false;
        isXTurn = true;
        moveCount = 0;
        restartButton.SetActive(false);

        foreach (Cell cell in cells)
        {
            cell.ResetCell();
        }

    }
}