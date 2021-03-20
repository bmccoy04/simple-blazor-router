using System;
using Xunit;
using Shouldly;
using Moq;
using simple_blazor_router.Models;

namespace simple_blazor_router.tests.Services
{
    public class TicTacToeHorizontalCheckerTests
    {
        [Fact]
        public void It_Should_Create_A_New_Checker()
        {
            var actual = new TicTacToeHorizontalChecker();

            actual.ShouldNotBeNull();
        }

        [Fact]
        public void There_Should_Be_No_Winner_O_Turn()
        {
            var checker = new TicTacToeHorizontalChecker();
            var spaces = GetGameSpaces();

            var actual = checker.CheckWinner(TicTacToeEnum.O, spaces);

            actual.ShouldBeFalse();
        }

        [Fact]
        public void There_Should_Be_No_Winner_X_Turn()
        {
            var checker = new TicTacToeHorizontalChecker();
            var spaces = GetGameSpaces();

            var actual = checker.CheckWinner(TicTacToeEnum.X, spaces);
            actual.ShouldBeFalse();
        }

        [Fact]
        public void There_Should_Be_No_Winner__Turn()
        {
            var checker = new TicTacToeHorizontalChecker();
            var spaces = GetGameSpaces();

            var actual = checker.CheckWinner(TicTacToeEnum._, spaces);
            actual.ShouldBeFalse();
        }

        [Fact]
        public void There_Should_Be_Winner_O_Top_Turn()
        {
            var checker = new TicTacToeHorizontalChecker();
            var spaces = GetGameSpaces();

            spaces[0,0].Select(TicTacToeEnum.O);
            spaces[0,1].Select(TicTacToeEnum.O);
            spaces[0,2].Select(TicTacToeEnum.O);

            var actual = checker.CheckWinner(TicTacToeEnum.O, spaces);
            actual.ShouldBeTrue();
        }

        [Fact]
        public void There_Should_Be_Winner_O_Middle_Turn()
        {
            var checker = new TicTacToeHorizontalChecker();
            var spaces = GetGameSpaces();

            spaces[1,0].Select(TicTacToeEnum.O);
            spaces[1,1].Select(TicTacToeEnum.O);
            spaces[1,2].Select(TicTacToeEnum.O);

            var actual = checker.CheckWinner(TicTacToeEnum.O, spaces);
            actual.ShouldBeTrue();
        }

        [Fact]
        public void There_Should_Be_Winner_O_Bottom()
        {
            var checker = new TicTacToeHorizontalChecker();
            var spaces = GetGameSpaces();

            spaces[2,0].Select(TicTacToeEnum.O);
            spaces[2,1].Select(TicTacToeEnum.O);
            spaces[2,2].Select(TicTacToeEnum.O);

            var actual = checker.CheckWinner(TicTacToeEnum.O, spaces);
            actual.ShouldBeTrue();
        }

        public GameSpace[,] GetGameSpaces()
        {
            var spaces = new GameSpace[3,3];

            for (int x = 0; x < 3; x++)
            {
                for(int y = 0; y < 3; y++)
                {
                    spaces[x, y] = new GameSpace();
                }
            }
            return spaces;
        }

    }
}