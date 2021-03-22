using System;
using Xunit;
using Shouldly;
using Bunit;
using Moq;
using simple_blazor_router.Models;
using simple_blazor_router.Pages;
using simple_blazor_router.Services.TicTakToeApplicationServices;
using Microsoft.Extensions.DependencyInjection;

namespace simple_blazor_router.tests.Pages
{
    public class TicTacToeGamePageTests
    {
        [Fact]
        public void It_Should_Create_A_New_GamePage()
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

            ctx.Services.AddSingleton<ITicTacToeGame>(ticTacToeGame);

            var cut = ctx.RenderComponent<TicTacToe>();

            var tdCount = cut.FindAll("td").Count;
            tdCount.ShouldBe(9);

            var trCount = cut.FindAll("tr").Count;
            trCount.ShouldBe(3);
        }


        [Fact]
        public void O_Should_Win()
        {

            var ticTacToeGame = new TicTacToeGame(new TicTacToeHorizontalChecker(), new TicTacToeVerticalChecker(), new TicTacToeDiagonalChecker());

            using var ctx = new TestContext();

            ctx.Services.AddSingleton<ITicTacToeGame>(ticTacToeGame);

            var cut = ctx.RenderComponent<TicTacToe>();

            var spans = cut.FindAll("span");

            spans[0].Click();
            spans[8].Click();
            spans[1].Click();
            spans[7].Click();
            spans[2].Click();
            spans[3].Click();
            spans[4].Click();
            spans[5].Click();

            var h3 = cut.Find("h3");
            h3.MarkupMatches("<h3>Game state: OWins</h3>");
        }
    }
}