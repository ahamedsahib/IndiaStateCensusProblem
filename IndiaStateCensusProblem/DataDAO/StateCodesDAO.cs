using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaStateCensusProblem.DataDAO
{
    public class StateCodesDAO
    {
        public int serialNumber;
        public int tin;
        public string stateName;
        public string stateCode;

        /// <summary>
        /// Parameterized contructor for state codes
        /// </summary>
        /// <param name="serialNumber"></param>
        /// <param name="stateName"></param>
        /// <param name="stateCode"></param>
        public StateCodesDAO(string serialNumber, string tin, string stateName, string stateCode)
        {
            this.serialNumber = Convert.ToInt32(serialNumber);
            this.tin = Convert.ToInt32(tin);
            this.stateName = stateName;
            this.stateCode = stateCode;
        }
    }
}
