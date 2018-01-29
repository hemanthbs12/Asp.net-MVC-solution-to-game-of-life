using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeRepository.Tests
{
    [TestClass]
    public class NextGenerationRepositoryTest
    {

        [TestMethod]
        public void GetRandomPopulationDistribution_WhenZeroSize_ReturnsEmptyModel()
        {
            //Arrange
            var target = new GenerationRepository();

            //Act
            var result = target.GetRandomPopulationDistribution(0);

            //Assert
            Assert.IsTrue(result.LifeMatrix.Length == 0);
        }

        [TestMethod]
        public void GetRandomPopulationDistribution_WhenFiniteSize_ReturnsFiniteModel()
        {
            //Arrange
            var target = new GenerationRepository();

            //Act
            var result = target.GetRandomPopulationDistribution(10);

            //Assert
            Assert.IsTrue(result.LifeMatrix.Length == 100);
        }

        [TestMethod]
        public void GetNextGeneration_When8X8Matrix_Returns8X8NextGeneration()
        {
            //Arrange
            var target = new GenerationRepository();

            //Act
            var result = target.GetNextGeneration(PopulationDistributionMocks.Get8X8FirstGenerationPopulationDistribution());

            var expectedResult = PopulationDistributionMocks.Get8X8SecondGenerationPopulationDistribution();
            //Assert
            for (int i = 0; i < expectedResult.Size-1; i++)
            {
                for (int j = 0; j < expectedResult.Size - 1; j++)
                {
                    Assert.AreEqual(result.LifeMatrix[i,j],expectedResult.LifeMatrix[i,j] );
                }
            }
        }
    }
}
