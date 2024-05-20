using AutoMapper;
using RESTAPI.Data;
using RESTAPI.DTO;
using RESTAPI.Models;
using RESTAPI.Repositories;
using RESTAPI.Security;
using RESTAPI.Services.Exceptions;

namespace RESTAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork? _unitOfWork;
        private readonly ILogger<UserService> _logger;
        private readonly IMapper? _mapper;

        public UserService(IUnitOfWork unitOfWork, ILogger<UserService>? logger,  IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public string CreateUserToken(int userId, string? username, string? email, UserRole? userRole, string? appSecurityKey)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllUsersFiltered(int pageNumber, int pageSize, UserFiltersDTO userFiltersDTO)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetUserByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<UserTeacherReadOnlyDTO?> GetUserTeacherByUsername(string? username)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> SignUpUserAsync(UserSignupDTO request)
        {
            Student? student;
            Teacher? teacher;
            User? user;

            try
            {
                user = ExtractUser(request);
                User? existingUser = await _unitOfWork!.UserRepository.GetByUsernameAsync(user.Username!);

                if (existingUser != null)
                {
                    throw new UserAlreadyExistsException("User Exists: " + existingUser.Username);
                }

                user.Password = EncryptionUtil.Encrypt(user.Password);
                await _unitOfWork!.UserRepository.AddAsync(user);

                if (user!.UserRole!.Value.ToString().Equals("Student"))
                {
                    student = ExtractStudent(request);
                    if (await _unitOfWork!.StudentRepository.GetByPhoneNumber(student.PhoneNumber) is not null)
                    {
                        throw new StudentAlreadyExistsException("Student Exists");
                    }
                    await _unitOfWork!.StudentRepository.AddAsync(student);
                    user.Student = student;
                }
                else if (user!.UserRole!.Value.ToString().Equals("Teacher"))
                {
                    teacher = ExtractTeacher(request);
                    if (await _unitOfWork!.TeacherRepository.GetByPhoneNumber(teacher.PhoneNumber) is not null)
                    {
                        throw new TeacherAlreadyExistsException("Teacher exists");
                    }
                    await _unitOfWork!.TeacherRepository.AddAsync(teacher);
                    user.Teacher = teacher;
                }
                else
                {
                    throw new InvalidRoleException("Invalid Role");
                }

                await _unitOfWork!.SaveAsync();
                _logger!.LogInformation("{Message}", "User: " + user + " signup success");
            } catch (Exception ex)
            {
                _logger!.LogError("{Message}{Exception}", ex.Message, ex.StackTrace);
                throw;
            }
            return user;
        }

        public Task<User?> UpdateUserAsync(int userId, UserDTO userdTO)
        {
            throw new NotImplementedException();
        }

        public Task<User?> UpdateUserPatchAsync(int userId, UserPatchDTO request)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> VerifyAndGetUserAsync(UserLoginDTO credentials)
        {
            User? user = null;

            try
            {
                user = await _unitOfWork!.UserRepository.GetUserAsync(credentials.Username!, credentials.Password!);
                _logger!.LogInformation("{Message}", "User: " + user + " found");

            } catch (Exception e)
            {
                _logger!.LogError("{Message}{Exception}", e.Message, e.StackTrace);
                throw;
            }
            return user;
        }


        private User ExtractUser(UserSignupDTO signupDTO)
        {
            return new User()
            {
                Username = signupDTO.Username,
                Password = signupDTO.Password,
                Email = signupDTO.Email,
                Firstname = signupDTO.Firstname,
                Lastname = signupDTO.Lastname,
                UserRole = signupDTO.UserRole
            };
        }

        private Student ExtractStudent(UserSignupDTO? signupDTO)
        {
            return new Student()
            {
                PhoneNumber = signupDTO!.PhoneNumber!,
                Institution = signupDTO!.Institution,
            };
        }

        private Teacher ExtractTeacher(UserSignupDTO? signupDTO)
        {
            return new Teacher()
            {
                PhoneNumber = signupDTO!.PhoneNumber!,
                Institution = signupDTO!.Institution,
            };
        }
    }
}
