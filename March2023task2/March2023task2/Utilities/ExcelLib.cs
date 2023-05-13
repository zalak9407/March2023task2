using ExcelDataReader;
using System.Data;
using System.Text.Json.Serialization.Metadata;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SharpCompress.Common;



namespace CompetitionTask.Utilites
{

    public class ExcelLib
    {
        static List<Datacollection> dataCol = new List<Datacollection>();
        public class Datacollection
        {
            public int rowNumber { get; set; }
            public string colName { get; set; }
            public string colValue { get; set; }
        }


        public static void ClearData()
        {
            dataCol.Clear();
        }


        private static DataTable ExcelToDataTable(string filename, string SheetName)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            FileStream stream = File.Open(filename, FileMode.Open, FileAccess.ReadWrite);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            // excelReader.IsFirstRowAsColumnNames = true * Does not works anymore

            DataSet resultSet = excelReader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            });
            DataTableCollection table = resultSet.Tables;
            DataTable resultTable = table[SheetName];
            return resultTable;
        }

        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                ////Retrieving Data using LINQ
                var data = (from colData in dataCol
                            where colData.colName == columnName && colData.rowNumber == rowNumber
                            select colData.colValue).First().ToString();

                //var data = dataCol.Where(x => x.colName == columnName && x.rowNumber == rowNumber).SingleOrDefault().colValue;
                return data.ToString();
            }
            catch (Exception e)
            {
                e.Message.ToString();
                return null;
            }

        }

        public static string WriteData(int rowNumber, string columnName)
        {
            try
            {
                ////Retrieving Data using LINQ
                var data = (from colData in dataCol
                            where colData.colName == columnName && colData.rowNumber == rowNumber
                            select colData.colValue).First().ToString();
                //var data = dataCol.Where(x => x.colName == columnName && x.rowNumber == rowNumber).SingleOrDefault().colValue;
                return data.ToString();
            }
            catch (Exception e)
            {
                e.Message.ToString();
                return null;
            }

        }

        public static void PopulateInCollection(string filename, string SheetName)
        {
            //ExcelLib.ClearData();
            DataTable table = ExcelToDataTable(filename, SheetName);
            //int totalRowCount = table.Rows.Count;
            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    Datacollection dtTable = new Datacollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()
                    };


                    dataCol.Add(dtTable);
                }
            }
        }
    }
}
