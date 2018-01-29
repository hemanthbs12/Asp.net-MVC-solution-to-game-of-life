using GameOfLifePresentation;

namespace GameOfLifeRepository
{
    public interface IGenerationRepository
    {
        PopulationDistribution GetRandomPopulationDistribution(int size);

        PopulationDistribution GetNextGeneration(PopulationDistribution currentGeneration);
    }
}
