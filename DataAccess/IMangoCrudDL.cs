using MangoAPI.Model;

namespace MangoAPI.DataAccess
{
    public interface IMangoCrudDL
    {
        public InsertRecordResponse FetchRecord();
        public InsertRecordResponse InsertRecord(InsertRecordRequest insertRecord);
        public InsertRecordResponse UpdateRecord(InsertRecordRequest insertRecord);
        public InsertRecordResponse DeleteRecord(string Id);
    }
}
