namespace Component
{
    public struct APIVersions
    {
        public const int Version1 = 1;
        public const int Version2 = 2;
        public const int Version3 = 3;
        public const int Version4 = 4;
        public const int Version5 = 5;
    }

    public struct ResponseCodes
    {
        public const int Success = 0;
        public const int NoDataFound = -101;
        public const int Fail = -102;
        public const int InternalServerError = 500;
    }

    public struct ResponseMessages
    {
        public const string Success = "Success";
        public const string NoDataFound = "No Data Found";
        public const string InternalServerError = "Internal Server Error";
    }

    public struct strctCRUDAction
    {
        public const string Create = "C";
        public const string Read = "R";
        public const string Update = "U";
        public const string Delete = "D";
        public const string GetAll = "A";
    }
}
