using IndiaStateCensusProblem.DataDAO;
using IndiaStateCensusProblem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace IndiaStateCensusProblem
{
   public class IndiaStateCensusAdapter:CensusDataAdapter
    {
        string[] censusdata;
        Dictionary<string, CensusDTO> dataDict;
        /// <summary>
        /// Method for load data and add into dictionary
        /// </summary>
        
        public Dictionary<string, CensusDTO> LoadCensusData(string filePath, string csvHeaders)
        {
            try
            {
                dataDict = new Dictionary<string, CensusDTO>();
                censusdata = GetData(filePath, csvHeaders);
                foreach (string i in censusdata.Skip(1))
                {
                    //Check for valid delimiters
                    if (!i.Contains(","))
                    {
                        throw new StateCensusAnalyserException(StateCensusAnalyserException.ExceptionType.INVALID_DELIMITER, "Invalid Delimiter");
                    }
                    string[] lines = i.Split(",");
                    //Check for correct file and call respective constructor and add into dictionary
                    if (filePath.Contains("CensusData.csv"))
                    {
                        dataDict.Add(lines[1], new CensusDTO(new CensusDataDAO(lines[0], lines[1], lines[2], lines[3])));
                    }
                    if (filePath.Contains("StateCodes.csv"))
                    {
                        dataDict.Add(lines[1], new CensusDTO(new StateCodesDAO(lines[0], lines[1], lines[2], lines[3])));
                    }
                }
                return dataDict;
            }
            catch (StateCensusAnalyserException ex)
            {
                throw ex;
            }

        }
    }
}
