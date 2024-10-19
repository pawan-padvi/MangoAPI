using MangoAPI.DataAccess;
using MangoAPI.Model;
using MangoAPI.Model.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using FluentValidation.Results;
using MangoAPI.Helper;
namespace MangoAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MangoCrudController(IMangoCrudDL mangoCrudDL, InsertRecordResponse insertRecordResponse) : ControllerBase
    {
        private readonly IMangoCrudDL _mangoCrudDL = mangoCrudDL;
        private readonly InsertRecordResponse _insertRecordResponse = insertRecordResponse;

        [HttpGet]
        public ActionResult FetchRecord()
        {
            try
            {
                return Ok(_mangoCrudDL.FetchRecord());

            }
            catch(Exception exc)
            {

                _insertRecordResponse.IsSuccess = false;
                _insertRecordResponse.Message = exc.Message;
            }
            return Ok(_insertRecordResponse);
        }
        [HttpPost]
        public ActionResult InsertRecord([FromBody] InsertRecordRequest insertRecord)
        {
            try
            {
                var errors = VALIDATOR.ValidateModel(insertRecord, new InsertRecordRequestValidator());
                if(errors is not null)
                {
                    _insertRecordResponse.IsSuccess = false;
                    _insertRecordResponse.Message = GlobalVariables.must_be_validate;
                    _insertRecordResponse.Body = errors;
                }
                else
                {
                    return Ok(_mangoCrudDL.InsertRecord(insertRecord));
                }
            }
            catch(Exception exc)
            {

                _insertRecordResponse.IsSuccess = false;
                _insertRecordResponse.Message = exc.Message;
            }
            return Ok(_insertRecordResponse);
        }
        [HttpPost]
        public ActionResult UpdateRecord([FromBody] InsertRecordRequest insertRecord)
        {
            try
            {
                return Ok(_mangoCrudDL.UpdateRecord(insertRecord));

            }
            catch(Exception exc)
            {

                _insertRecordResponse.IsSuccess = false;
                _insertRecordResponse.Message = exc.Message;
            }
            return Ok(_insertRecordResponse);
        }
        [HttpPost]
        public ActionResult DeleteRecord([FromBody] InsertRecordRequest recordRequest)
        {
            try
            {
                if(recordRequest.Id is not null)
                {
                    return Ok(_mangoCrudDL.DeleteRecord(recordRequest?.Id ?? ""));
                }
            }
            catch(Exception exc)
            {

                _insertRecordResponse.IsSuccess = false;
                _insertRecordResponse.Message = exc.Message;
            }
            return Ok(_insertRecordResponse);
        }
    }
}
