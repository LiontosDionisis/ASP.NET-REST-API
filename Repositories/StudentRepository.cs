using Microsoft.EntityFrameworkCore;
using RESTAPI.Data;
using RESTAPI.Models;

namespace RESTAPI.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(UsersTeachersAPITestDbContext context) : base(context) { }

        public async Task<List<User>> GetAllUsersStudentsAsync()
        {
            var userWithStudentRole = await _context.Users.Where(s => s.UserRole == UserRole.Student).Include(s => s.Student).ToListAsync();
            return userWithStudentRole;
        }

        public async Task<Student?> GetByPhoneNumber(string? phoneNumber)
        {
            return await _context.Students.Where(s => s.PhoneNumber == phoneNumber).FirstOrDefaultAsync();
        }

        public async Task<List<Course>> GetStudentCoursesAsync(int id)
        {
            List<Course> courses;
            courses = await _context.Students.Where(s => s.Id == id).SelectMany(s => s.Courses).ToListAsync();
            return courses;
        }
    }
}
