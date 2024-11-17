using SchoolProject.Core.Wapper;

namespace SchoolProject.Core.Results
{
    public class GetDepartmentDto
    {
        public int Id { get; set; }
        public string ManagerName { get; set; }
        public string Name { get; set; }
        public PaginatedResult<StudentResponse>? StudentList { get; set; }
        public List<SubjectResonse>? Subjects { get; set; }

        public List<InstractorResponse>? Instractors { get; set; }


    }

    public class StudentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StudentResponse(int id, string name)
        {
            Id = id;
            Name = name;

        }


    }

    public class SubjectResonse
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }


    public class InstractorResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
