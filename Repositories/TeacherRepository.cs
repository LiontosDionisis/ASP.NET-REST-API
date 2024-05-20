using RESTAPI.Data;
using RESTAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace RESTAPI.Repositories
{
    public class TeacherRepository: BaseRepository<Teacher>, ITeacherRepository
    {
       
        public TeacherRepository(UsersTeachersAPITestDbContext context) : base(context) { }

        public async Task<List<User>> GetAllUsersTeachersAsync()
        {
            var usersWithTeacherRole = await _context.Users.Where(u => u.UserRole == UserRole.Teacher).Include(u => u.Teacher).ToListAsync();
            return usersWithTeacherRole;
        }

        public async Task<List<User>> GetAllUsersTeachersAsync(int pageNumber, int pageSize)
        {
            int skip = pageSize * pageNumber;
            var usersWithTeaherRole = await _context.Users.Where(u => u.UserRole == UserRole.Teacher).Include(u => u.Teacher).Skip(skip).Take(pageSize).ToListAsync();
            return usersWithTeaherRole;
        }

        public async Task<Teacher?> GetByPhoneNumber(string? phoneNumber)
        {
            return await _context.Teachers.Where(s => s.PhoneNumber == phoneNumber).FirstOrDefaultAsync();
        }

        public async Task<User?> GetTeacherByUsernameAsync(string username)
        {
            var userTeacher = await _context.Users.Where(u => u.Username == username && u.UserRole == UserRole.Teacher).SingleOrDefaultAsync();
            return userTeacher;
        }

        public async Task<List<Course>> GetTeacherCoursesAsync(int id)
        {
            List<Course> courses;
            courses = await _context.Teachers.Where(t => t.Id == id).SelectMany(t => t.Courses!).ToListAsync();
            return courses;
        }
    }
}
