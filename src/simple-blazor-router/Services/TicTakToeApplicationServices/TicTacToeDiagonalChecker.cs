using simple_blazor_router.Models;
using simple_blazor_router.Services.TicTakToeApplicationServices;

namespace simple_blazor_router.Models
{
    public class TicTacToeDiagonalChecker : ITicTacToeDiagonalChecker
    {
        public TicTacToeDiagonalChecker()
        {
        }

        public bool CheckWinner(TicTacToeEnum currentTurn, GameSpace[,] spaces)
        {
            if(currentTurn == TicTacToeEnum._)
                return false;

            if(spaces[0,0].CurrentValue == currentTurn && spaces[1,1].CurrentValue == currentTurn && spaces[2,2].CurrentValue == currentTurn)
                return true;

            if(spaces[0,2].CurrentValue == currentTurn && spaces[1,1].CurrentValue == currentTurn && spaces[2,0].CurrentValue == currentTurn)
                return true;

            return false;
        }
    }
}