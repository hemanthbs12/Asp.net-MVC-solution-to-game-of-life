using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using GameOfLifePresentation;

namespace GameOfLifeRepository.Tests
{
    public static class PopulationDistributionMocks
    {
        public static PopulationDistribution Get8X8FirstGenerationPopulationDistribution()
        {
            var populationDistribution = new PopulationDistribution()
            {
                //This life matrix covers all possible life combination for next generation rules
                LifeMatrix = new[,]
                {
                    {true, true, true, false,true, true, false,false},
                    {true, true, false,false,false,true, false,false},
                    {true, false,false,true, false,true, false,false},
                    {false,true, true, false,false,false,true, false},
                    {false,false,false,false,false,false,true, false},
                    {false,false,true, false,false,true, false,false},
                    {false,false,false,true, false,false,true, false},
                    {false,false,false,false,false,false,false,false}
                },
                Size = 8
            };
            return populationDistribution;
        }

        public static PopulationDistribution Get8X8SecondGenerationPopulationDistribution()
        {
            var populationDistribution = new PopulationDistribution()
            {
                LifeMatrix = new[,]
                {
                    {true, false,true, false,true, true, false,false},
                    {false,false,false,true, false,true, true, false},
                    {true, false,false,false,true, true, true, false},
                    {false,true, true, false,false,true, true, false},
                    {false,true, true, false,false,true, true, false},
                    {false,false,false,false,false,true, true, false},
                    {false,false,false,false,false,false,false,false},
                    {false,false,false,false,false,false,false,false}
                },
                Size = 8
            };
            return populationDistribution;
        }
    }
}
