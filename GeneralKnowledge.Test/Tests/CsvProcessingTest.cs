using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// CSV processing test
    /// </summary>
    public class CsvProcessingTest : ITest
    {
        public void Run()
        {
            // TODO
            // Create a domain model via POCO classes to store the data available in the CSV file below
            // Objects to be present in the domain model: Asset, Country and Mime type
            // Process the file in the most robust way possible
            // The use of 3rd party plugins is permitted
            var csvFile = Resources.AssetImport;

            try
            {
                List<AssetImport> lstAssetImport = new List<AssetImport>();
                lstAssetImport= AssetImportsList(csvFile);

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public void UpdateRecordInCSV(AssetImport assetImportItem)
        {
           
            try
            {

             string ResourceDirectoryPath = Directory.GetParent(Directory.GetCurrentDirectory()) + @"/GeneralKnowledge.Test/Resources/AssetImport.csv";
              var lstAssetImport=  File.ReadAllLines(ResourceDirectoryPath).ToList();
              
                foreach (var rowitem in lstAssetImport)
                {
                   List<string>  colvalue= rowitem.Split(',').ToList<string>();
                    StringBuilder NewRow = new StringBuilder();                    string line = string.Empty;                    foreach (var col in colvalue)
                    {
                       
                        if (col.Equals(assetImportItem.assetId))
                        {
                            line = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}",
                                assetImportItem.assetId,
                                 assetImportItem.fileName,
                                 assetImportItem.mimeType,
                                 assetImportItem.createdBy,
                                 assetImportItem.email,
                                assetImportItem.country,
                                assetImportItem.description,
                                Environment.NewLine);
                           
                        }
                        NewRow.Append(line);
                        File.AppendAllText(ResourceDirectoryPath, NewRow.ToString());
                    }                  

                }
              

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void addNewValuetoCSV(AssetImport assetImportItem)
        {
            try
            {
                string ResourceDirectoryPath = Directory.GetParent(Directory.GetCurrentDirectory()) + @"/GeneralKnowledge.Test/Resources/AssetImport.csv";
                StringBuilder NewRow = new StringBuilder();
                var newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}",
                                assetImportItem.assetId,
                                 assetImportItem.fileName,
                                 assetImportItem.mimeType,
                                 assetImportItem.createdBy,
                                 assetImportItem.email,
                                assetImportItem.country,
                                assetImportItem.description,
                                Environment.NewLine);
                NewRow.Append(newLine);
                File.AppendAllText(ResourceDirectoryPath, NewRow.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
        public  List<AssetImport> AssetImportsList(string csvFile=null)
        {
            List<AssetImport> lstAssetImport = null;
            if (string.IsNullOrEmpty(csvFile))
            {
                csvFile = Resources.AssetImport;

            }
                byte[] byteArray = Encoding.ASCII.GetBytes(csvFile);
                MemoryStream stream = new MemoryStream(byteArray);

               
                // using (var sr = new StreamReader(ResourceDirectoryPath))
                using (var sr = new StreamReader(stream))
                {
                    using (var csvReader = new CsvReader(sr))
                    {

                        csvReader.Configuration.RegisterClassMap<AssetCsvMap>();
                        lstAssetImport = csvReader.GetRecords<AssetImport>().ToList();
                        //int numberofUS= lstAssetImport.Where(r => r.country.ToString() == "United States").ToList().Count();
                        //Console.WriteLine("Number of list : " + lstAssetImport.Count);
                        //Console.WriteLine("US list : " + numberofUS);
                    }
                }
               // return lstAssetImport;
            
            return lstAssetImport;

            //Console.ReadLine();

        }
    }


    public class AssetImport
    {

        public string assetId { get; set; }

        public string fileName { get; set; }

        public string mimeType { get; set; }

        public string createdBy { get; set; }

        public string email { get; set; }

        public string country { get; set; }

        public string description { get; set; }
    }

    internal sealed class AssetCsvMap : ClassMap<AssetImport>
    {
        public AssetCsvMap()
        {
            Map(x => x.assetId).Name("asset id");
            Map(x => x.fileName).Name("file_name");
            Map(x => x.mimeType).Name("mime_type");
            Map(x => x.createdBy).Name("created_by");
            Map(x => x.email).Name("email");
            Map(x => x.country).Name("country");
            Map(x => x.description).Name("description");
        }
    }


}
