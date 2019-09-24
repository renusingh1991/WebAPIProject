using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using GeneralKnowledge.Test.App.Tests;

namespace APIRestFulController.Controllers
{
    public class AssetController : ApiController
    {
        // TODO
        // Create an API controller via REST to perform all CRUD operations on the asset objects created as part of the CSV processing test
        // Visualize the assets in a paged overview showing the title and created on field
        // Clicking an asset should navigate the user to a detail page showing all properties
        // Any data repository is permitted
        // Use a client MVVM framework

        CsvProcessingTest objCsvProcessingTest = new CsvProcessingTest();
        List<AssetImport> lstAssetImport = new List<AssetImport>();
        public List<AssetImport> GetAllAssets()
        {
            return objCsvProcessingTest.AssetImportsList();
        }
        
        public AssetImport GetAssetsByID(string asstetID)
        {
            return objCsvProcessingTest.AssetImportsList().Where(p => p.assetId == asstetID).FirstOrDefault();
        }
        /*
        
        public bool PostAsset( AssetImport assetImportItem)
        {
            //adding value to CSV file 
            bool status = false;
            try
            {
                objCsvProcessingTest.addNewValuetoCSV(assetImportItem);
                objCsvProcessingTest.AssetImportsList().Add(assetImportItem);

                status = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return status;
        }

       */
        public List<AssetImport> PostAddList(AssetImport assetImportItem)
        {
            try
            {
                lstAssetImport = objCsvProcessingTest.AssetImportsList();
                lstAssetImport.Add(assetImportItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstAssetImport;
        }
        public List<AssetImport> PutAsset(AssetImport assetImportItem)
        {
            try
            {
                lstAssetImport = objCsvProcessingTest.AssetImportsList();
                var ispresento= lstAssetImport.Where(x => x.assetId.Equals(assetImportItem.assetId)).Any();
                AssetImport objAssetImport = lstAssetImport.Where(x => x.assetId.Equals(assetImportItem.assetId)).FirstOrDefault();
                if (objAssetImport != null)
                {
                    objAssetImport.country = assetImportItem.country;
                    objAssetImport.createdBy = assetImportItem.createdBy;
                    objAssetImport.description = assetImportItem.description;
                    objAssetImport.email = assetImportItem.email;
                    objAssetImport.mimeType = assetImportItem.mimeType;
                    objAssetImport.fileName = assetImportItem.fileName;
               }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstAssetImport;
        }
        
        public List<AssetImport> DeleteAsset(string AssetID)
        {
           
            try
            {
                lstAssetImport = objCsvProcessingTest.AssetImportsList();
                AssetImport objAssetImport = lstAssetImport.Where(p => p.assetId == AssetID).FirstOrDefault();
                if (objAssetImport != null)
                {
                    lstAssetImport.RemoveAll(x=>x.assetId.Equals(AssetID));

                }
                else
                {
                    Console.WriteLine("ID doesnot exist");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstAssetImport;
        }

    }
}
