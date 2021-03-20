using simple_blazor_router.Models;

namespace simple_blazor_router.Services.TicTakToeApplicationServices
{
    public interface ITicTacToeVerticalChecker
    {
        bool CheckWinner(TicTacToeEnum currentTurn, GameSpace[,] spaces);
    }
}