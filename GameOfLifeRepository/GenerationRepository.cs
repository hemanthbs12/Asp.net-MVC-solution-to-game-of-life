using System;
using GameOfLifePresentation;


namespace GameOfLifeRepository
{
    public class GenerationRepository : IGenerationRepository
    {
        public PopulationDistribution GetRandomPopulationDistribution(int size)
        {
            
            var populationDistribution = new PopulationDistribution
            {
                LifeMatrix = new bool[size, size],
                Size = size
            };

            //fill random values for live and dead
            Random r = new Random();
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = 0; j < size - 1; j++)
                {
                    populationDistribution.LifeMatrix[i, j] = r.Next(2) > 0;
                }
            }

            return populationDistribution;
        }

        public PopulationDistribution GetNextGeneration(PopulationDistribution previousGeneration)
        {
            var nextGeneration = new PopulationDistribution
            {
                LifeMatrix = new bool[previousGeneration.Size, previousGeneration.Size],
                Size = previousGeneration.Size
            };

            for (int i = 0; i < previousGeneration.Size - 1; i++)
            {
                for (int j = 0; j < previousGeneration.Size - 1; j++)
                {
                    var neighboursCount = GetNeighboursCount(i, j, previousGeneration.LifeMatrix, previousGeneration.Size);
                    nextGeneration.LifeMatrix[i, j] = GetNewStatus(previousGeneration.LifeMatrix[i, j], neighboursCount);
                }
            }

            return nextGeneration;
        }

        private static bool GetNewStatus(bool previousGenerationStatus, int neighboursCount)
        {
            if ((neighboursCount < 2 || neighboursCount > 3) && previousGenerationStatus)
                return false;
            if ((neighboursCount == 2 || neighboursCount == 3) && previousGenerationStatus)
                return true;
            if (neighboursCount == 3 && !previousGenerationStatus)
                return true;

            return previousGenerationStatus;
        }

      
        private static int GetNeighboursCount(int row, int column, bool[,] previousGeneration, int size)
        {
            //=======================================================>=========
            //[row - 1, column - 1][row - 1, column][row - 1, column + 1]     ||
            //[row, column - 1]    [row,column]     [row, column + 1]         ||
            //[row + 1, column - 1][row + 1, column][row + 1, column + 1]     ||
            //=================================================================

            var neighboursCount = 0;
            if (row > 0 && column > 0 && previousGeneration[row - 1, column - 1])
            {
                neighboursCount++;
            }
            if (row > 0 && previousGeneration[row - 1, column])
            {
                neighboursCount++;
            }
            if (row > 0 && column < size - 1 && previousGeneration[row - 1, column + 1])
            {
                neighboursCount++;
            }
            if (column < size - 1 && previousGeneration[row, column + 1])
            {
                neighboursCount++;
            }
            if (column < size - 1 && row < size && previousGeneration[row + 1, column + 1])
            {
                neighboursCount++;
            }
            if (row < size && previousGeneration[row + 1, column])
            {
                neighboursCount++;
            }
            if (column > 0 && row < size && previousGeneration[row + 1, column - 1])
            {
                neighboursCount++;
            }
            if (column > 0 && previousGeneration[row, column - 1])
            {
                neighboursCount++;
            }
            return neighboursCount;
        }
    }
}
