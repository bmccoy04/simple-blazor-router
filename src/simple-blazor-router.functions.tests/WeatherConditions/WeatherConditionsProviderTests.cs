using System;
using Xunit;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using simple_blazor_router.application.WeatherConditions;

namespace simple_blazor_router.functions.tests
{
    public class WeatherConditionsProviderTests
    {
        [Fact]
        public void It_Should_Create_Weather_Conditions_Provider()
        {
            var conditionsProvider = new WeatherConditionsProvider();
            conditionsProvider.ShouldNotBeNull();
        }

        [Fact]
        public void It_Should_Return_Six_Conditions()
        {
            var conditionsProvider = new WeatherConditionsProvider();

            var actual = conditionsProvider.Get();

            actual.ToList().Count.ShouldBe(6);
        }

        [Fact]
        public void It_Should_Return_A_Single_Condition()
        {
            var conditionsProvider = new WeatherConditionsProvider();

            var actual = conditionsProvider.Get(2);

            actual.Id.ShouldBe(2);
        }
    }
}
