using simple_blazor_router.Models;

namespace simple_blazor_router.Services.TicTakToeApplicationServices
{
    public interface ITicTacToeHorizontalChecker
    {
        bool CheckWinner(TicTacToeEnum currentTurn, GameSpace[,] spaces);
    }
}