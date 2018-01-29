using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfLifeRepository;
using Moq;
using GameOfLife.Controllers;
using GameOfLifePresentation;

namespace GameOfLife.Tests
{
    [TestClass]
    public class GameControllerTest
    {

        [TestMethod]
        public void GetRandomLifeMatrixViewTest()
        {
            //Arrange
            var repository = new Mock<IGenerationRepository>(MockBehavior.Strict);

            repository.Setup(x => x.GetRandomPopulationDistribution(It.IsAny<int>())).Returns(PopulationDistributionMocks.Get8X8FirstGenerationPopulationDistribution);
            var target = new GameController(repository.Object);

            //Act
            var result = target.Index();

            //Assert
            Assert.IsInstanceOfType(((ViewResultBase)result).Model,typeof(PopulationDistribution));
        }

        [TestMethod]
        public void NewGenerationViewTest()
        {
            //Arrange
            var repository = new Mock<IGenerationRepository>(MockBehavior.Strict);

            repository.Setup(x => x.GetNextGeneration(It.IsAny<PopulationDistribution>())).Returns(PopulationDistributionMocks.Get8X8SecondGenerationPopulationDistribution);
            var target = new GameController(repository.Object);
            var tempDataMock = new TempDataDictionary
            {
                ["PreviousGeneration"] = PopulationDistributionMocks.Get8X8FirstGenerationPopulationDistribution()
            };
            target.TempData = tempDataMock;
            //Act
            var result = target.NewGeneration();

            //Assert
            Assert.IsInstanceOfType(((ViewResultBase)result).Model, typeof(PopulationDistribution));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void NewGenerationViewTest_WhenTempDataIsNull_ThrowsException()
        {
            //Arrange
            var repository = new Mock<IGenerationRepository>(MockBehavior.Strict);

            repository.Setup(x => x.GetNextGeneration(It.IsAny<PopulationDistribution>())).Returns(PopulationDistributionMocks.Get8X8SecondGenerationPopulationDistribution);
            var target = new GameController(repository.Object);
           
            //Act
            target.NewGeneration();
        }
    }
}
