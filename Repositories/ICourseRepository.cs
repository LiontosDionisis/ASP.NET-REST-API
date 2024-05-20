using RESTAPI.Data;

namespace RESTAPI.Repositories
{
    public interface ICourseRepository
    {
        Task<List<Student>> GetCourseStudentAsync(int id);


        Task<Teacher?>GetCourseTeacherAsync(int id);
    }
}
