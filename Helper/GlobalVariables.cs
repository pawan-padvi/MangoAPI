namespace MangoAPI.Helper
{
    public static class GlobalVariables
    {
        internal static readonly string success_insert_message = "Record inserted successfull.";
        internal static readonly string success_message = "Record found successfull.";
        internal static readonly string error_message = "Record not found.";
        internal static readonly string must_be_validate = "The input must be validate.";
        internal static readonly string success_update_message = "Record update successfully.";
        internal static readonly string success_delete_message = "Record deleted successfully.";
        internal static readonly string required_first_name = "The input of first name should not be empty.";
        internal static readonly string minimum_length_first_name = "The input of first name minimum length should be 3 characters.";
        internal static readonly string maximum_length_first_name = "The input of firstname maximum length should be 35 characters.";
        internal static readonly string required_last_name = "The input of last name is required.";
        internal static readonly string minimum_length_last_name = "The input of last name length should be minimum 3 characters.";
        internal static readonly string maximum_length_last_name = "The input of last name length should be maximum 35 characters.";
        internal static readonly string required_age = "The input of age is required.";
        internal static readonly string greaterthan_age = "The input of age should be greater than 7";
        internal static readonly string lessthan_age = "The input of age should be greater than 150";
        internal static readonly string required_salary = "The input of salary is required.";
        internal static readonly string greaterthan_salary = "The input salary must be greater than 0.";
        internal static readonly string lessthan_salary = "The input salary must be less than 1,000,000.";
        internal static readonly string required_contact = "The input contact number is required.";
        internal static readonly string contact_must_be_10 = "The input contact number must be exactly 10 digits.";
        internal static readonly string invalid_contact_number = "The input contact number format is invalid.";
    }
}
