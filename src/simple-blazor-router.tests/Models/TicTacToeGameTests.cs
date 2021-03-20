using System;
using Xunit;
using Shouldly;
using Moq;
using simple_blazor_router.Models;
using simple_blazor_router.Services.TicTakToeApplicationServices;

namespace simple_blazor_router.tests.Models
{
    public class TicTacToeGamesTests
    {
        [Fact]
        public void It_Should_Create_A_New_Game()
        {
            var ticTacToeHorizontalChecker = new Mock<ITicTacToeHorizontalChecker>();
            var ticTacToeVerticalChecker = new Mock<ITicTacToeVerticalChecker>();
            var ticTacToeDiagonalChecker = new Mock<ITicTacToeDiagonalChecker>();

            var game = new TicTacToeGame(ticTacToeHorizontalChecker.Object,
                ticTacToeVerticalChecker.Object,
                ticTacToeDiagonalChecker.Object);

            game.ShouldNotBeNull();
            game.CurrentTicTacToeTurn.ShouldBe(TicTacToeEnum.O);
        } 

        [Fact]
        public void It_Should_Select_First_Cell()
        {
            var ticTacToeHorizontalChecker = new Mock<ITicTacToeHorizontalChecker>();
            var ticTacToeVerticalChecker = new Mock<ITicTacToeVerticalChecker>();
            var ticTacToeDiagonalChecker = new Mock<ITicTacToeDiagonalChecker>();

            var game = new TicTacToeGame(ticTacToeHorizontalChecker.Object,
                ticTacToeVerticalChecker.Object,
                ticTacToeDiagonalChecker.Object);

            var selected = game.SelectSpace(1,1);

            game.SpaceValue(1,1).ShouldBe(TicTacToeEnum.O);
            selected.ShouldBe(true);
            game.CurrentTicTacToeTurn.ShouldBe(TicTacToeEnum.X);
        }

        [Fact]
        public void It_Should_Select_Second_Cell()
        {
            var ticTacToeHorizontalChecker = new Mock<ITicTacToeHorizontalChecker>();
            var ticTacToeVerticalChecker = new Mock<ITicTacToeVerticalChecker>();
            var ticTacToeDiagonalChecker = new Mock<ITicTacToeDiagonalChecker>();

            var game = new TicTacToeGame(ticTacToeHorizontalChecker.Object,
                ticTacToeVerticalChecker.Object,
                ticTacToeDiagonalChecker.Object);

            game.SelectSpace(1,1);

            var selected = game.SelectSpace(0,2);

            game.SpaceValue(1,1).ShouldBe(TicTacToeEnum.O);
            game.SpaceValue(0, 2).ShouldBe(TicTacToeEnum.X);
            game.CurrentTicTacToeTurn.ShouldBe(TicTacToeEnum.O);
            selected.ShouldBe(true);
        }

        [Fact]
        public void It_Should_Not_Select_First_Cell()
        {
            var ticTacToeHorizontalChecker = new Mock<ITicTacToeHorizontalChecker>();
            var ticTacToeVerticalChecker = new Mock<ITicTacToeVerticalChecker>();
            var ticTacToeDiagonalChecker = new Mock<ITicTacToeDiagonalChecker>();

            var game = new TicTacToeGame(ticTacToeHorizontalChecker.Object,
                ticTacToeVerticalChecker.Object,
                ticTacToeDiagonalChecker.Object);

            game.SelectSpace(1,1);

            var selected = game.SelectSpace(1,1);

            game.SpaceValue(1,1).ShouldBe(TicTacToeEnum.O);
            game.CurrentTicTacToeTurn.ShouldBe(TicTacToeEnum.X);
            selected.ShouldBe(false);
        }

        [Fact]
        public void O_Should_Be_Horizontal_Winner()
        {
            var ticTacToeHorizontalChecker = new Mock<ITicTacToeHorizontalChecker>();
            var ticTacToeVerticalChecker = new Mock<ITicTacToeVerticalChecker>();
            var ticTacToeDiagonalChecker = new Mock<ITicTacToeDiagonalChecker>();

            ticTacToeHorizontalChecker
                .Setup(x => x.CheckWinner(It.IsAny<TicTacToeEnum>(), It.IsAny<GameSpace[,]>()))
                .Returns(true);

            ticTacToeDiagonalChecker 
                .Setup(x => x.CheckWinner(It.IsAny<TicTacToeEnum>(), It.IsAny<GameSpace[,]>()))
                .Returns(false);

            ticTacToeVerticalChecker
                .Setup(x => x.CheckWinner(It.IsAny<TicTacToeEnum>(), It.IsAny<GameSpace[,]>()))
                .Returns(false);

            var game = new TicTacToeGame(ticTacToeHorizontalChecker.Object,
                ticTacToeVerticalChecker.Object,
                ticTacToeDiagonalChecker.Object);

            game.SelectSpace(1,0);

            var gameStatus = game.CurrentTicTacToeGameStatus;

            gameStatus.ShouldBe(TicTakToeGameStatusEnum.OWins);
        }

        [Fact]
        public void O_Should_Be_Vertical_Winner()
        {
            var ticTacToeHorizontalChecker = new Mock<ITicTacToeHorizontalChecker>();
            var ticTacToeVerticalChecker = new Mock<ITicTacToeVerticalChecker>();
            var ticTacToeDiagonalChecker = new Mock<ITicTacToeDiagonalChecker>();

            ticTacToeHorizontalChecker
                .Setup(x => x.CheckWinner(It.IsAny<TicTacToeEnum>(), It.IsAny<GameSpace[,]>()))
                .Returns(false);

            ticTacToeDiagonalChecker 
                .Setup(x => x.CheckWinner(It.IsAny<TicTacToeEnum>(), It.IsAny<GameSpace[,]>()))
                .Returns(false);

            ticTacToeVerticalChecker
                .Setup(x => x.CheckWinner(It.IsAny<TicTacToeEnum>(), It.IsAny<GameSpace[,]>()))
                .Returns(true);

            var game = new TicTacToeGame(ticTacToeHorizontalChecker.Object,
                ticTacToeVerticalChecker.Object,
                ticTacToeDiagonalChecker.Object);

            game.SelectSpace(1,0);

            var gameStatus = game.CurrentTicTacToeGameStatus;

            gameStatus.ShouldBe(TicTakToeGameStatusEnum.OWins);
        }

        [Fact]
        public void O_Should_Be_Diagonal_Winner()
        {
            var ticTacToeHorizontalChecker = new Mock<ITicTacToeHorizontalChecker>();
            var ticTacToeVerticalChecker = new Mock<ITicTacToeVerticalChecker>();
            var ticTacToeDiagonalChecker = new Mock<ITicTacToeDiagonalChecker>();

            ticTacToeHorizontalChecker
                .Setup(x => x.CheckWinner(It.IsAny<TicTacToeEnum>(), It.IsAny<GameSpace[,]>()))
                .Returns(false);

            ticTacToeDiagonalChecker 
                .Setup(x => x.CheckWinner(It.IsAny<TicTacToeEnum>(), It.IsAny<GameSpace[,]>()))
                .Returns(true);

            ticTacToeVerticalChecker
                .Setup(x => x.CheckWinner(It.IsAny<TicTacToeEnum>(), It.IsAny<GameSpace[,]>()))
                .Returns(false);

            var game = new TicTacToeGame(ticTacToeHorizontalChecker.Object,
                ticTacToeVerticalChecker.Object,
                ticTacToeDiagonalChecker.Object);

            game.SelectSpace(1,0);

            var gameStatus = game.CurrentTicTacToeGameStatus;

            gameStatus.ShouldBe(TicTakToeGameStatusEnum.OWins);
        }

        [Fact]
        public void Should_Be_A_Draw()
        {
            var ticTacToeHorizontalChecker = new Mock<ITicTacToeHorizontalChecker>();
            var ticTacToeVerticalChecker = new Mock<ITicTacToeVerticalChecker>();
            var ticTacToeDiagonalChecker = new Mock<ITicTacToeDiagonalChecker>();

            ticTacToeHorizontalChecker
                .Setup(x => x.CheckWinner(It.IsAny<TicTacToeEnum>(), It.IsAny<GameSpace[,]>()))
                .Returns(false);

            ticTacToeDiagonalChecker 
                .Setup(x => x.CheckWinner(It.IsAny<TicTacToeEnum>(), It.IsAny<GameSpace[,]>()))
                .Returns(false);

            ticTacToeVerticalChecker
                .Setup(x => x.CheckWinner(It.IsAny<TicTacToeEnum>(), It.IsAny<GameSpace[,]>()))
                .Returns(false);

            var game = new TicTacToeGame(ticTacToeHorizontalChecker.Object,
                ticTacToeVerticalChecker.Object,
                ticTacToeDiagonalChecker.Object);

            game.SelectSpace(1,0);
            game.SelectSpace(1,1);
            game.SelectSpace(1,2);
            game.SelectSpace(2,0);
            game.SelectSpace(2,1);
            game.SelectSpace(2,2);
            game.SelectSpace(0,0);
            game.SelectSpace(0,1);
            game.SelectSpace(0,2);

            var gameStatus = game.CurrentTicTacToeGameStatus;

            gameStatus.ShouldBe(TicTakToeGameStatusEnum.Draw);
        }
    }
}