using AutoMapper;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<Student, StudentGetInfo>();
        CreateMap<StudentCreateInfo, Student>();
        CreateMap<StudentUpdateInfo, Student>();
    }
}