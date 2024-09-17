using AutoMapper;
using Online_Course_API.DTO;
using Online_Course_API.Model;

namespace Online_Course_API.Mapper
{
    public class mapping : Profile
    {
        public mapping()
        {

            CreateMap<Instructor, InstructorDTO>().ReverseMap();
            CreateMap<Student, StudentDTO>().ReverseMap();
            //.ForMember(dest => dest.Parent_Email, opt => opt.MapFrom(src => src.Parent.Email))
            //.ForMember(dest => dest.Parent_FirstName, opt => opt.MapFrom(src => src.Parent.First_Name))
            //.ForMember(dest => dest.Parent_LastName, opt => opt.MapFrom(src => src.Parent.Last_Name));


            CreateMap<StudentDTO, Student>()
                .ForMember(dest => dest.Parent, opt => opt.Ignore()); // Ignore mapping for Parent, as it's not in StudentDTO
            CreateMap<Session, SessionDTO>().ReverseMap();


            CreateMap<StudentQuizDTO, Student_Quiz>().ReverseMap();


            CreateMap<Group, CourseGroupesDTO>()
                .ForMember(dest => dest.InstructorName, opt => opt.MapFrom(src => src.Instructor.ApplicationUser.Name))
                .ForMember(dest => dest.courseName, opt => opt.MapFrom(src => src.Course.Name));

            CreateMap<Quiz, AllExamByGroupDTO>()
                .ForMember(dest => dest.numQuestion, opt => opt.MapFrom(src => src.Questions.Count())).ReverseMap();

            CreateMap<Session, ALlSessionDTO>().ReverseMap();

            CreateMap<Question, AllQuestionsinExamDTO>().ReverseMap();
            //.ForMember(dest => dest.ChoisesText,
            // opt => opt.MapFrom(src => src.Choises.Select(c => c.Text)));




            CreateMap<Choise, ChoiseDTO>().ReverseMap();
            CreateMap<Course, CourseDTO>().ReverseMap();
            CreateMap<Grade, GradeDTO>().ReverseMap();
            CreateMap<Group, GroupDTO>().ReverseMap();
            CreateMap<Question, QuestionDTO>().ReverseMap();
            CreateMap<Quiz, QuizDTO>().ReverseMap();


            CreateMap<Student_Group, Student_GroupDTO>().ReverseMap();
        }
    }
}
