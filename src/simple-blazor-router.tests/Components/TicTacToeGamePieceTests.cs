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
    public class TcTacToeGamePieceTests
    {
        [Fact]
        public void It_Should_Create_A_New_GamePiece()
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
            var cut = ctx.RenderComponent<TicTacToeGamePiece>(
                ("TicTacToeGame", ticTacToeGame),
                ("SpaceX", 1),
                ("SpaceY", 1)
            );

            cut.Find("span").MarkupMatches("<span>_</span>");
        }

        [Fact]
        public void It_Should_Mark_The_Piece_As_O()
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
            var cut = ctx.RenderComponent<TicTacToeGamePiece>(
                ("TicTacToeGame", ticTacToeGame),
                ("SpaceX", 1),
                ("SpaceY", 1)
            );

            cut.Find("span").Click();

            cut.Find("span").MarkupMatches("<span>O</span>");
        }

        [Fact]
        public void It_Should_Stay_Marked_As_O()
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
            var cut = ctx.RenderComponent<TicTacToeGamePiece>(
                ("TicTacToeGame", ticTacToeGame),
                ("SpaceX", 1),
                ("SpaceY", 1)
            );

            cut.Find("span").Click();

            cut.Find("span").Click();

            cut.Find("span").MarkupMatches("<span>O</span>");
        }
    }
}