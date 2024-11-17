namespace SchoolProject.Core.Results
{
    public class GetStudentPagnationDto
    {
        public int StudID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string DepartmentName { get; set; }
        public GetStudentPagnationDto(int StudID, string Name, string Address, string DepartmentName)
        {
            this.StudID = StudID;
            this.Name = Name;
            this.Address = Address;
            this.DepartmentName = DepartmentName;
        }
    }
}
