using simple_blazor_router.Services.TicTakToeApplicationServices;

namespace simple_blazor_router.Models
{
    public interface ITicTacToeGame
    {
        TicTacToeEnum CurrentTicTacToeTurn { get; }
        TicTakToeGameStatusEnum CurrentTicTacToeGameStatus { get; }
        GameSpace[,] Spaces { get; set; }
        int TurnCount { get; }
        bool IsValidSpace(int x, int y);
        bool SelectSpace(int x, int y);
        TicTacToeEnum SpaceValue(int x, int y);
    }

    public class TicTacToeGame : ITicTacToeGame
    {
        private readonly ITicTacToeHorizontalChecker _ticTacToeHorizontalChecker;
        private readonly ITicTacToeVerticalChecker _ticTacToeVertcalChecker;
        private readonly ITicTacToeDiagonalChecker _ticTacToeDiagonalChecker;
        public TicTacToeEnum CurrentTicTacToeTurn { get; private set; }
        public TicTakToeGameStatusEnum CurrentTicTacToeGameStatus { get; private set; }
        public GameSpace[,] Spaces { get;  set; }
        public int TurnCount { get; private set; }
        public TicTacToeGame(ITicTacToeHorizontalChecker ticTacToeHorizontalChecker,
        ITicTacToeVerticalChecker ticTacToeVertcalChecker,
        ITicTacToeDiagonalChecker ticTacToeDiagonalChecker)
        {
            _ticTacToeHorizontalChecker = ticTacToeHorizontalChecker;
            _ticTacToeVertcalChecker = ticTacToeVertcalChecker;
            _ticTacToeDiagonalChecker = ticTacToeDiagonalChecker;
            CurrentTicTacToeTurn = TicTacToeEnum.O;
            Spaces = new GameSpace[3, 3];
            CurrentTicTacToeGameStatus = TicTakToeGameStatusEnum.InProgress;
            TurnCount = 0;

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    Spaces[x, y] = new GameSpace();
                }
            }
        }
        public bool SelectSpace(int x, int y)
        {
            if (!IsValidSpace(x, y) || !(CurrentTicTacToeGameStatus == TicTakToeGameStatusEnum.InProgress))
                return false;

            var gameSpace = Spaces[x, y];

            var wasSelected = gameSpace.Select(CurrentTicTacToeTurn);

            if (wasSelected)
            {
                CheckForWinner(CurrentTicTacToeTurn);
                SwitchTurn();
            }

            return wasSelected;
        }
        public TicTacToeEnum SpaceValue(int x, int y)
        {
            if (!IsValidSpace(x, y))
                return TicTacToeEnum._;

            var space = Spaces[x, y];

            return space.CurrentValue;
        }
        public bool IsValidSpace(int x, int y)
        {
            if (x < 0 || x > 2)
            {
                return false;
            }

            if (y < 0 || y > 2)
            {
                return false;
            }

            return true;
        }
        private void SwitchTurn()
        {
            if (CurrentTicTacToeTurn == TicTacToeEnum.O)
                CurrentTicTacToeTurn = TicTacToeEnum.X;
            else if (CurrentTicTacToeTurn == TicTacToeEnum.X)
                CurrentTicTacToeTurn = TicTacToeEnum.O;
        }
        private void CheckForWinner(TicTacToeEnum currentTurn)
        {
            var horizontalWinner = _ticTacToeHorizontalChecker.CheckWinner(currentTurn, Spaces);
            var verticalWinner = _ticTacToeVertcalChecker.CheckWinner(currentTurn, Spaces);
            var crossWinner = _ticTacToeDiagonalChecker.CheckWinner(currentTurn, Spaces);

            if (horizontalWinner || verticalWinner || crossWinner)
            {
                if (CurrentTicTacToeTurn == TicTacToeEnum.O)
                    CurrentTicTacToeGameStatus = TicTakToeGameStatusEnum.OWins;
                else
                    CurrentTicTacToeGameStatus = TicTakToeGameStatusEnum.XWins;
            }

            TurnCount++;
            if (TurnCount == 9)
                CurrentTicTacToeGameStatus = TicTakToeGameStatusEnum.Draw;
        }
    }
}