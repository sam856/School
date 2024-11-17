using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entites;
using SchoolProject.Data.Helper;
using SchoolProject.Infrastruture.Abstract;
using SchoolProject.Services.Abstract;

namespace SchoolProject.Services.Implementatios
{
    public class StduentServices : IStudentServies
    {
        #region Fields
        private readonly IStudentRepositiers studentRepositiers;

        #endregion
        #region Contractor
        public StduentServices(IStudentRepositiers studentRepositiers)
        {
            this.studentRepositiers = studentRepositiers;
        }


        #endregion
        #region Handle Function
        public async Task<List<Student>> GetStudentsAsync()
        {

            return await studentRepositiers.GetStudentsAsync();


        }

        public async Task<Student> GetStudentByIDWithIncludeAsync(int id)
        {
            // var student = await _studentRepository.GetByIdAsync(id);
            var student = studentRepositiers.GetTableNoTracking()
                                          .Include(x => x.Department)
                                          .Where(x => x.StudID.Equals(id))
                                          .FirstOrDefault();
            return student;
        }

        public async Task<string> AddStudent(Student student)
        {

            await studentRepositiers.AddAsync(student);
            return "Success";


        }

        public async Task<bool> NameIsExist(string name)
        {
            var studentRepositiry = studentRepositiers.GetTableNoTracking().Where(x => x.NameAr.Equals(name)).FirstOrDefault();
            if (studentRepositiry == null) return false;
            return true;
        }

        public async Task<bool> NameIsExistExcludeSelf(string name, int id)
        {
            var studentRepositiry = await studentRepositiers.GetTableNoTracking().Where(x => x.NameAr.Equals(name) && x.StudID != id).FirstOrDefaultAsync();
            if (studentRepositiry == null) return false;
            return true;
        }

        public async Task<string> EditAsync(Student student)
        {
            await studentRepositiers.UpdateAsync(student);
            return "Success";
        }

        public async Task<string> DeleteAsync(Student student)
        {
            var trans = studentRepositiers.BeginTransaction();
            try
            {
                await studentRepositiers.DeleteAsync(student);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Failed";

            }



        }

        public IQueryable<Student> GetAllStudents()
        {
            return studentRepositiers.GetTableNoTracking().Include(x => x.Department).AsQueryable();
        }



        public IQueryable<Student> FilterStudentIqurable(OrderingStudentEnum studentEnum, string search)
        {
            var SearchedItem =
                studentRepositiers.GetTableNoTracking().Include(x => x.Department).AsQueryable();
            if (search != null)
            {
                SearchedItem = SearchedItem.Where(x => x.NameAr.Contains(search) || x.Address.Contains(search));

            }
            switch (studentEnum)
            {
                case OrderingStudentEnum.StudID:
                    SearchedItem = SearchedItem.OrderBy(x => x.StudID);
                    break;
                case OrderingStudentEnum.Name:
                    SearchedItem = SearchedItem.OrderBy(X => X.NameAr);
                    break;
                case OrderingStudentEnum.Address:
                    SearchedItem = SearchedItem.OrderBy(x => x.Address);
                    break;
                case OrderingStudentEnum.DepartmentName:
                    SearchedItem = SearchedItem.OrderBy(x => x.Department.DNameAr);
                    break;

                default:
                    SearchedItem = SearchedItem.OrderBy(x => x.StudID);
                    break;



            }
            return SearchedItem;

        }

        public IQueryable<Student> GetStudentByDepartment(int Id)
        {
            var student = studentRepositiers
                .GetTableNoTracking().Where(x => x.Department.DID.Equals(Id)).AsQueryable();

            return student;
        }

        #endregion

    }
}
