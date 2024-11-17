namespace SchoolProject.Data.AppMetaData
{
    public class Router
    {
        public const string SymbolId = "/{Id}";

        public const string root = "Api";
        public const string version = "V1";
        public const string Rule = root + "/" + version + "/";

        public static class StudentApi
        {


            public const string Prefix = Rule + "Stduent";
            public const string List = Prefix + "/List";
            public const string GetById = Prefix + SymbolId;
            public const string Create = Prefix + "/Create";
            public const string Edit = Prefix + "/Edit";
            public const string Delete = Prefix + "/Delete" + SymbolId;
            public const string Pagnation = Prefix + "/Pagnation";




        }

        public static class DepartmentApi
        {


            public const string Prefix = Rule + "Department";
            public const string GetById = Prefix + "/Id";



        }
    }
}
