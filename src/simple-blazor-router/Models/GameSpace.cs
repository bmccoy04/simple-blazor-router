namespace simple_blazor_router.Models
{
    public class GameSpace
    {
        public TicTacToeEnum CurrentValue {get; private set;}
        public GameSpace()
        {
            CurrentValue = TicTacToeEnum._;
        }

        public bool Select(TicTacToeEnum ticTacToeEnum)
        {
            if(CurrentValue != TicTacToeEnum._)
                return false;

            CurrentValue = ticTacToeEnum;
            return true;
        }
    }
}