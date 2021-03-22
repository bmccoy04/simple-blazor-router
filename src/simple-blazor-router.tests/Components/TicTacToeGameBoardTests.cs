using System;
using Xunit;
using Shouldly;
using Bunit;
using Moq;
using simple_blazor_router.Models;
using simple_blazor_router.Components;
using simple_blazor_router.Services.TicTakToeApplicationServices;

namespace simple_blazor_router.tests.Components
{
    public class TicTacToeGameBoardTests
    {
        [Fact]
        public void It_Should_Create_A_New_GameBoard()
        {
            var mockHorizontalChecker = new Mock<ITicTacToeHorizontalChecker>();
            var mockVerticalChecker = new Mock<ITicTacToeVerticalChecker>();
            var mockDiagonalChecker = new Mock<ITicTacToeDiagonalChecker>();

            mockDiagonalChecker 
                .Setup(x => x.CheckWinner(It.IsAny<TicTacToeEnum>(), It.IsAny<GameSpace[,]>()))
                .Returns(false);

            mockHorizontalChecker.Setup(x => x.CheckWinner(It.IsAny<TicTacToeEnum>(), It.IsAny<GameSpace[,]>())).Returns(false);
            mockVerticalChecker.Setup(x => x.CheckWinner(It.IsAny<TicTacToeEnum>(), It.IsAny<GameSpace[,]>())).Returns(false);

            var ticTacToeGame = new TicTacToeGame(mockHorizontalChecker.Object, mockVerticalChecker.Object, mockDiagonalChecker.Object);

            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<TicTacToeGameBoard>(
                ("TicTacToeGame", ticTacToeGame)
            );

            var tdCount = cut.FindAll("td").Count;
            tdCount.ShouldBe(9);

            var trCount = cut.FindAll("tr").Count;
            trCount.ShouldBe(3);
        }
    }
}