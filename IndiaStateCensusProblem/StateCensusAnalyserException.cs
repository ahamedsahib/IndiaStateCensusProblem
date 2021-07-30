using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaStateCensusProblem
{
    public class StateCensusAnalyserException : Exception
    {
        public ExceptionType exception;
     
        public enum ExceptionType
        {
            FILE_NOT_FOUND, INVALID_FILE_TYPE, INVALID_HEADER, INVALID_DELIMITER, NO_SUCH_COUNTRY
        }

     
        public StateCensusAnalyserException(ExceptionType exception, string message) : base(message)
        {
            this.exception = exception;
        }
    }

}
