using RESTAPI.Data;

namespace RESTAPI.Repositories
{
    public interface ITeacherRepository
    {
        Task<List<Course>> GetTeacherCoursesAsync(int id);
        Task<Teacher?> GetByPhoneNumber(string? phoneNumber);
        Task<List<User>> GetAllUsersTeachersAsync();
        Task<List<User>> GetAllUsersTeachersAsync(int pageNumber, int pageSize);
        Task<User?> GetTeacherByUsernameAsync(string username);
    }
}
