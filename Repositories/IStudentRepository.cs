using RESTAPI.Data;

namespace RESTAPI.Repositories
{
    public interface IStudentRepository
    {
        Task<Student?> GetByPhoneNumber(string? phoneNumber);
        Task<List<Course>> GetStudentCoursesAsync(int id);
        Task<List<User>> GetAllUsersStudentsAsync();

    }
}
