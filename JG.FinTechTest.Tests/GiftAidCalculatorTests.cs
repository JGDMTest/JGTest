using System;
using FluentAssertions;
using JG.FinTechTest;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;

namespace Tests
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
            Action construct = () => new GiftAidCalculator(-1);
            construct.Should().Throw<ArgumentException>();
        }

        [Test]
        public void SetUpCalculatorWithTaxRateAbove100_ShouldThrowException()
        {
            Action construct = () => new GiftAidCalculator(100.1m);
            construct.Should().Throw<ArgumentException>();
        }

        [Test]
        public void CalculatingGiftAidFor100WithTaxRate20_ShouldReturn25()
        {
            var GiftAidCalculator = new GiftAidCalculator(20);
            GiftAidCalculator.CalculateGiftAid(100).Should().Be(25);

        }
    }
}