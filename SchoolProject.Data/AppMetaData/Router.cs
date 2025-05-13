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
            public const string GetDepartmentByStudentCount = Prefix + "/GetDepartmentByStudentCount";
            public const string GetDepartmentByStudentCountproc = Prefix + "/GetDepartmentByStudentCountproc/{id}";




        }


        public static class ApplicationUser
        {


            public const string Prefix = Rule + "ApplicationUser";
            public const string Create = Prefix + "/Create";
            public const string Pagnation = Prefix + "/Pagnation";
            public const string GetById = Prefix + SymbolId;
            public const string Edit = Prefix + "/Edit";
            public const string Delete = Prefix + "/Delete" + SymbolId;
            public const string ChangePassword = Prefix + "/Change-Password";







        }


        public static class Authentication
        {
            public const string Prefix = Rule + "Authentication";
            public const string SignIn = Prefix + "/SignIn";
            public const string RefreshToken = Prefix + "/RefreshToken";
            public const string ValidateToken = Prefix + "/ValidateToken";
            public const string ConfirmEmail = Prefix + "/ConfirmEmail";
            public const string SendResetPassword = Prefix + "/SendResetPassword";
            public const string ResetPassword = Prefix + "/ResetPassword";
            public const string ConfirmResetPasswordCode = Prefix + "/ConfirmResetPasswordCode";



        }


        public static class Authorize
        {
            public const string Prefix = Rule + "Autorization";
            public const string Create = Prefix + "/Add";
            public const string Edit = Prefix + "/Update";
            public const string Delete = Prefix + "/Delete" + SymbolId;
            public const string AllRoles = Prefix + "/AllRoles";
            public const string GetById = Prefix + "/GetById" + SymbolId;
            public const string ManageUserRoles = Prefix + "/ManageUserRoles" + SymbolId;
            public const string UpdateUserRoles = Prefix + "/UpdateUserRoles";
            public const string ManageUserCliams = Prefix + "/ManageUserCliams" + SymbolId;
            public const string UpdateUserCliams = Prefix + "/UpdateUserCliams";





        }
        public static class Email
        {
            public const string Prefix = Rule + "Email";
            public const string Send = Prefix + "/Send";









        }


        public static class Instractor
        {
            public const string Prefix = Rule + "Instractor";
            public const string GetSummary = Prefix + "/GetSummary";
            public const string AddInstractor = Prefix + "/AddInstractor";






        }





    }
}
