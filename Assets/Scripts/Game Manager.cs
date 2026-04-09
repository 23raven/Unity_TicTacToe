using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isXTurn = true;
    public Cell[] cells;

    int[,] winPatterns = new int[,]
{
    {0,1,2}, {3,4,5}, {6,7,8},
    {0,3,6}, {1,4,7}, {2,5,8},
    {0,4,8}, {2,4,6}
};

    public void MakeMove(Cell cell)
    {
        if (isXTurn)
            cell.SetX();
        else
            cell.SetO();

        if (CheckWin())
        {
            Debug.Log("WIN!");
            return;
        }

        isXTurn = !isXTurn;
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
                return true;
            }
        }

        return false;
    }
}