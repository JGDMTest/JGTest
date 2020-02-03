using System;
using FluentAssertions;
using NUnit.Framework;

namespace JG.FinTechTest.Tests
{
    public class GiftAidCalculatorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SetUpCalculatorWithTaxRateBelowZero_ShouldThrowException()
        {
            Action construct = () =>
            {
                var unused = new GiftAidCalculator(-1);
            };
            construct.Should().Throw<ArgumentException>();
        }

        [Test]
        public void SetUpCalculatorWithTaxRateAbove100_ShouldThrowException()
        {
            Action construct = () =>
            {
                var unused = new GiftAidCalculator(100.1m);
            };
            construct.Should().Throw<ArgumentException>();
        }

        [Test]
        public void CalculatingGiftAidFor100WithTaxRate20_ShouldReturn25()
        {
            var giftAidCalculator = new GiftAidCalculator(20);
            giftAidCalculator.CalculateGiftAid(100).Should().Be(25);

        }
    }
}