using Assignment.Domain;
using Assignment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Assignment.Test
{
    public class CalculationServicesTests
    {
        [Theory]
        [InlineData(10, 100, 50000)]
        [InlineData(50, 641.25, 10280039.0625)]
        public void CalculateKineticEnergy_SmallNumber_ReturnsCorrectEnergy(decimal mass, decimal velocity, decimal energy)
        {
            // arange
            ICalculator calculator = new Calculator();

            // act
            var actualEnergy = calculator.CalculateKineticEnergy(mass, velocity);

            // assert
            Assert.Equal(energy, actualEnergy, 10);
        }

        [Theory]
        [InlineData(-100, 568)]
        public void CalculateKineticEnergy_MassLessThanZero_ArgumentException(decimal mass, decimal velocity)
        {
            // arange
            ICalculator calculator = new Calculator();

            // act
            void act() => calculator.CalculateKineticEnergy(mass, velocity);

            // assert
            Assert.Throws<ArgumentException>(act);
        }

        [Theory]
        [InlineData(234, "Nothing happens")]
        public void GetComment_SmallNumber_ReturnsNothingHappens(decimal energy, string comment)
        {
            // arange
            ICommentsMapper commentsMapper = new CommentsMapper();

            // act
            var actualComment = commentsMapper.GetComment(energy);

            // assert
            Assert.Equal(comment, actualComment);
        }

        [Theory]
        [InlineData(2344894889165235, "Earth explodes")]
        public void GetComment_LargeNumber_ReturnsEarthExplodes(decimal energy, string comment)
        {
            // arange
            ICommentsMapper commentsMapper = new CommentsMapper();

            // act
            var actualComment = commentsMapper.GetComment(energy);

            // assert
            Assert.Equal(comment, actualComment);
        }
    }
}