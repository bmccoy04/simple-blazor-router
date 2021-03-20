using simple_blazor_router.Models;

namespace simple_blazor_router.Services.TicTakToeApplicationServices
{
    public interface ITicTacToeDiagonalChecker
    {
        bool CheckWinner(TicTacToeEnum currentTurn, GameSpace[,] spaces);
    }
}