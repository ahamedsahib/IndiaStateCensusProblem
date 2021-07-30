using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using IndiaStateCensusProblem.DataDAO;
using IndiaStateCensusProblem.DTO;
using IndiaStateCensusProblem;

namespace IndiaStateCensusTestProject
{
    [TestClass]
    public class UnitTest1
    {

        string stateCensusFilePath = @"C:\Users\ahamedsahib.m\source\repos\IndiaStateCensusProblem\IndiaStateCensusProblem\CSVFiles\CensusData.csv";
        string wrongExtensionFilePath = @"C:\Users\ahamedsahib.m\source\repos\IndiaStateCensusProblem\IndiaStateCensusProblem\CSVFiles\CensusData.c";
        string wrongFilePath = @"C:\Users\ahamedsahib.m\source\repos\IndiaStateCensusProblem\IndiaStateCensusProblem\CSVFiles\Data.csv";
        string wrongheadersFilePath = @"C:\Users\ahamedsahib.m\source\repos\IndiaStateCensusProblem\IndiaStateCensusProblem\CSVFiles\WrongHeaders.csv";
        string wrongDelimitersFilePath = @"C:\Users\ahamedsahib.m\source\repos\IndiaStateCensusProblem\IndiaStateCensusProblem\CSVFiles\WrongDelimiters.csv";

        string stateCodesFilePath = @"C:\Users\ahamedsahib.m\source\repos\IndiaStateCensusProblem\IndiaStateCensusProblem\CSVFiles\StateCodeData.csv";
        string stateCodeswrongExtensionFilePath = @"C:\Users\ahamedsahib.m\source\repos\IndiaStateCensusProblem\IndiaStateCensusProblem\CSVFiles\State.cs";
        string stateCodeswrongFilePath = @"C:\Users\ahamedsahib.m\source\repos\IndiaStateCensusProblem\IndiaStateCensusProblem\CSVFiles\Data.csv";
        string stateCodesWrongHeadersFilePath = @"C:\Users\ahamedsahib.m\source\repos\IndiaStateCensusProblem\IndiaStateCensusProblem\CSVFiles\StateCodeWrongHeaders.csv";
        string stateCodesWrongDelimitersFilePath = @"C:\Users\ahamedsahib.m\source\repos\IndiaStateCensusProblem\IndiaStateCensusProblem\CSVFiles\StateCodeWrongDelemiters.csv";

        //Object for csv adapter class
        CSVAdapterFactory csvAdapter = default;
        Dictionary<string,CensusDTO> Records;

        [TestInitialize]
        public void Setup()
        {
            Records = new Dictionary<string, CensusDTO>();
            csvAdapter = new CSVAdapterFactory();
           
        }
        /// <summary>
        /// Uc1 - Tc-1.1 - Test for number of records matches
        /// </summary>
        [TestMethod]
        public void TestNumberOfRecordMatches()
        {
            Records = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, stateCensusFilePath, "State,Population,Area,Density");
            int expected = 6, actual = Records.Count;
            Assert.AreEqual(actual, expected);
        }
        /// <summary>
        ///  Uc1 - Tc-1.2 - Test for Wrong File Extension
        /// </summary>
        [TestMethod]
        public void TestForWrongFileExtension()
        {
            try
            {
                Records = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongExtensionFilePath, "State,Population,Area,Density");


            }
            catch (StateCensusAnalyserException ex)
            {
                string expected = "Invalid file extension";

                Assert.AreEqual(ex.Message, expected);
            }

        }
        /// <summary>
        /// Uc1 - Tc-1.3 - Test for File not found exception
        /// </summary>
        [TestMethod]
        public void TestForFileNotFound()
        {
            try
            {
                Records = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongFilePath, "State,Population,Area,Density");


            }
            catch (StateCensusAnalyserException ex)
            {
                string expected = "File not found";

                Assert.AreEqual(ex.Message, expected);
            }

        }
        /// <summary>
        ///  Tc-1.4 - Test for wrong headers exception
        /// </summary>
        [TestMethod]
        public void TestForWrongHeaders()
        {
            try
            {
                Records = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongheadersFilePath, "State,Population,Area,Density");


            }
            catch (StateCensusAnalyserException ex)
            {
                string expected = "Invalid file headers";

                Assert.AreEqual(ex.Message, expected);
            }

        }
        /// <summary>
        /// Tc-1.4 - Test for wrong delemiters exception
        /// </summary>
        [TestMethod]
        public void TestForWrongDelimiters()
        {
            try
            {
                Records = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongDelimitersFilePath, "State,Population,Area,Density");


            }
            catch (StateCensusAnalyserException ex)
            {
                string expected = "Invalid Delimiter";

                Assert.AreEqual(ex.Message, expected);
            }

        }
        /// <summary>
        ///  Tc-2.1 - Test for number of records matches
        /// </summary>
        [TestMethod]
        public void TestNumberOfStateCodeRecordMatches()
        {
            Records = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, stateCodesFilePath, "serialNumber,tin,StateName,StateCode");
            int expected = 6, actual = Records.Count;
            Assert.AreEqual(actual, expected);
        }
        /// <summary>
        ///  Tc-2.2 - Test for Wrong File Extension
        /// </summary>
        [TestMethod]
        public void TestForStateCodeWrongFileExtension()
        {
            try
            {
                Records = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, stateCodeswrongExtensionFilePath, "serialNumber,tin,StateName,StateCode");


            }
            catch (StateCensusAnalyserException ex)
            {
                string expected = "Invalid file extension";

                Assert.AreEqual(ex.Message, expected);
            }

        }
        /// <summary>
        /// Tc-2.3 - Test for File not found exception
        /// </summary>
        [TestMethod]
        public void TestForStateCodeFileNotFound()
        {
            try
            {
                Records = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, stateCodeswrongFilePath, "serialNumber,tin,StateName,StateCode");


            }
            catch (StateCensusAnalyserException ex)
            {
                string expected = "File not found";

                Assert.AreEqual(ex.Message, expected);
            }

        }
        /// <summary>
        /// Tc-2.4 - Test for wrong headers exception
        /// </summary>
        [TestMethod]
        public void TestForStateCodeWrongHeaders()
        {
            try
            {
                Records = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, stateCodesWrongHeadersFilePath, "serialNumber,tin,StateName,StateCode");


            }
            catch (StateCensusAnalyserException ex)
            {
                string expected = "Invalid file headers";

                Assert.AreEqual(ex.Message, expected);
            }

        }
        /// <summary>
        ///  Tc-2.5 - Test for wrong demlimiters
        /// </summary>
        [TestMethod]
        public void TestForStateCodeWrongDelimiters()
        {
            try
            {
                Records = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, stateCodesWrongDelimitersFilePath, "serialNumber,tin,StateName,StateCode");


            }
            catch (StateCensusAnalyserException ex)
            {
                string expected = "Invalid Delimiter";

                Assert.AreEqual(ex.Message, expected);
            }

        }

    }
}
