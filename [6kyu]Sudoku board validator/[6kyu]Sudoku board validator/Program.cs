public class SudokuValidator
{
    public static bool Validate(int[][] board)
    {
        return !ContainsZeros(board) && IsRowsValid(board) && IsColumnsValid(board) && IsBoxesValid(board);
    }

    private static bool ContainsZeros(int[][] board)
    {
        for (var i = 0; i < board.Length; i++)
        {
            for (var j = 0; j < board[i].Length; j++)
            {
                if (board[i][j] == 0)
                {
                    return true;
                }
            }
        }

        return false;
    }

    private static bool IsRowsValid(int[][] board)
    {
        for (var i = 0; i < board.Length; i++)
        {
            List<int> foundDigits = new List<int>();

            for (var j = 0; j < board[i].Length; j++)
            {
                if (foundDigits.Contains(board[i][j]))
                {
                    return false;
                }
                else
                {
                    foundDigits.Add(board[i][j]);
                }
            }
        }

        return true;
    }

    private static bool IsColumnsValid(int[][] board)
    {
        for (var i = 0; i < board[0].Length; i++)
        {
            List<int> foundDigits = new List<int>();

            for (var j = 0; j < board.Length; j++)
            {
                if (foundDigits.Contains(board[j][i]))
                {
                    return false;
                }
                else
                {
                    foundDigits.Add(board[j][i]);
                }
            }
        }

        return true;
    }

    private static bool IsBoxesValid(int[][] board)
    {
        for (var i = 0; i <= 6; i += 3)
        {
            for (var j = 0; j <= 6; j += 3)
            {
                if (!IsBoxValid(i, j))
                {
                    return false;
                }
            }
        }

        return true;

        bool IsBoxValid(int rowIndex, int columnIndex)
        {
            List<int> foundDigits = new List<int>();

            for (var i = rowIndex; i <= rowIndex + 2; i++)
            {
                for (var j = columnIndex; j <= columnIndex + 2; j++)
                {
                    if (foundDigits.Contains(board[i][j]))
                    {
                        return false;
                    }
                    else
                    {
                        foundDigits.Add(board[i][j]);
                    }
                }
            }

            return true;
        }
    }
}