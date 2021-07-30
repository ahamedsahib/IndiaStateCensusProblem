using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaStateCensusProblem.DataDAO
{
    public class CensusDataDAO
    {
        public string state;
        public long population;
        public long area;
        public long density;

        /// <summary>
        /// Parameterized constructor for census data
        /// </summary>
        /// <param name="state"></param>
        /// <param name="population"></param>
        /// <param name="area"></param>
        /// <param name="density"></param>
        public CensusDataDAO(string state, string population, string area, string density)
        {
            this.state = state;
            this.population = Convert.ToInt64(population);
            this.area = Convert.ToInt64(area);
            this.density = Convert.ToInt32(density);
        }
    }
}
