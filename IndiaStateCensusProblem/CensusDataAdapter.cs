using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IndiaStateCensusProblem
{
    public class CensusDataAdapter
    {
        public string[] GetData(string filePath, string csvHeaders)
        {
            try
            {
                string[] data;
                //Check for file exists or not
                if (!File.Exists(filePath))
                {
                    throw new StateCensusAnalyserException(StateCensusAnalyserException.ExceptionType.FILE_NOT_FOUND, "File not found");
                }
                //CHeck for correct file extension
                if (!Path.GetExtension(filePath).Equals(".csv"))
                {
                    throw new StateCensusAnalyserException(StateCensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, "Invalid file extension");
                }
                //read data from files
                data = File.ReadAllLines(filePath);
                //check for headers are valid
                if (!data[0].Equals(csvHeaders))
                {
                    throw new StateCensusAnalyserException(StateCensusAnalyserException.ExceptionType.INVALID_HEADER, "Invalid file headers");
                }
                return data;
            }
            catch (StateCensusAnalyserException ex)
            {
                throw ex;
            }
        }
    }
}