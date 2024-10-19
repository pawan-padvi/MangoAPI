
using MangoAPI.Helper;
using MangoAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;

namespace MangoAPI.DataAccess
{
    public class MangoCrudDL : IMangoCrudDL
    {
        private readonly IConfiguration _configuration;
        private readonly MongoClient _mongoClient;
        private readonly InsertRecordResponse _insertRecordResponse;
        public MangoCrudDL(IConfiguration configuration, InsertRecordResponse insertRecordResponse)
        {
            _configuration = configuration;
            _mongoClient = new MongoClient(_configuration["Database:ConnectionString"]);
            _insertRecordResponse = insertRecordResponse;
        }

        public InsertRecordResponse FetchRecord()
        {
            try
            {
                var db = _mongoClient.GetDatabase(_configuration["Database:DatabaseName"] ?? "");
                var collection = db.GetCollection<InsertRecordRequest>("UserDetail");
                var records = collection.Find(_ => true).ToList();
                _insertRecordResponse.Body = records;
                _insertRecordResponse.IsSuccess = true;
                _insertRecordResponse.Message = GlobalVariables.success_message;
            }
            catch(Exception ex)
            {
                _insertRecordResponse.IsSuccess = false;
                _insertRecordResponse.Message = ex.Message;

            }
            return _insertRecordResponse;
        }

        InsertRecordResponse IMangoCrudDL.InsertRecord(InsertRecordRequest insertRecord)
        {
            try
            {
                var db = _mongoClient.GetDatabase(_configuration["Database:DatabaseName"] ?? "");
                var collection = db.GetCollection<InsertRecordRequest>("UserDetail");
                insertRecord.CreatedDate = DateTime.Now.ToShortDateString();
                collection.InsertOne(insertRecord);
                _insertRecordResponse.IsSuccess = true;
                _insertRecordResponse.Message = GlobalVariables.success_insert_message;
            }
            catch(Exception ex)
            {

                _insertRecordResponse.IsSuccess = false;
                _insertRecordResponse.Message += ex.Message;
            }
            return _insertRecordResponse;
        }
        public InsertRecordResponse UpdateRecord(InsertRecordRequest updateRecord)
        {
            try
            {
                var db = _mongoClient.GetDatabase(_configuration["Database:DatabaseName"] ?? "");
                var collection = db.GetCollection<InsertRecordRequest>("UserDetail");

                // Assuming you're updating a record by an "Id" field or some unique identifier
                var filter = Builders<InsertRecordRequest>.Filter.Eq("Id", updateRecord.Id); // Replace "Id" with the actual unique field


                var update = Builders<InsertRecordRequest>.Update
                    .Set("FirstName", updateRecord.FirstName)
                    .Set("LastName", updateRecord.LastName)
                    .Set("Age", updateRecord.Age)
                    .Set("Contact", updateRecord.Contact)
                    .Set("Contact", updateRecord.Contact)
                    .Set("Salary", updateRecord.Salary)
                    .Set("UpdatedDate", DateTime.Now.ToShortDateString());

                // Perform the update
                var result = collection.UpdateOne(filter, update);

                // Check if the update was successful
                if(result.ModifiedCount > 0)
                {
                    _insertRecordResponse.IsSuccess = true;
                    _insertRecordResponse.Message = GlobalVariables.success_update_message;
                }
                else
                {
                    _insertRecordResponse.IsSuccess = false;
                    _insertRecordResponse.Message = "No records were updated.";
                }
            }
            catch(Exception ex)
            {
                _insertRecordResponse.IsSuccess = false;
                _insertRecordResponse.Message += ex.Message;
            }

            return _insertRecordResponse;
        }
        public InsertRecordResponse DeleteRecord([FromBody] string id)
        {
            try
            {
                var db = _mongoClient.GetDatabase(_configuration["Database:DatabaseName"] ?? "");
                var collection = db.GetCollection<InsertRecordRequest>("UserDetail");

                // Define the filter to find the record by "Id" or any unique identifier
                var filter = Builders<InsertRecordRequest>.Filter.Eq("Id", id);

                // Perform the delete operation
                var result = collection.DeleteOne(filter);

                // Check if the deletion was successful
                if(result.DeletedCount > 0)
                {
                    _insertRecordResponse.IsSuccess = true;
                    _insertRecordResponse.Message = GlobalVariables.success_delete_message;
                }
                else
                {
                    _insertRecordResponse.IsSuccess = false;
                    _insertRecordResponse.Message = "No records were deleted.";
                }
            }
            catch(Exception ex)
            {
                _insertRecordResponse.IsSuccess = false;
                _insertRecordResponse.Message += ex.Message;
            }

            return _insertRecordResponse;
        }

    }
}
