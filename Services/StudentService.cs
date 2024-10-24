
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

public class StudentService(AppDbContext context, IMapper mapper) : IStudentService
{
    public async Task<bool> Create(StudentCreateInfo studentCreate)
    {
        try
        {
            Student student = mapper.Map<Student>(studentCreate);
            int maxId = (from s in context.Students
                         orderby s.Id descending
                         select s.Id).FirstOrDefault();
            student.Id = maxId + 1;

            await context.Students.AddAsync(student);
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            Student? student = await context.Students.FindAsync(id);
            if (student == null)
                return false;

            context.Students.Remove(student);
            await context.SaveChangesAsync();
            return true;

        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            throw;
        }
    }

    public PaginationResponse<IEnumerable<StudentGetInfo>> GetAll(StudentFilter filter)
    {
        try
        {
            IQueryable<Student> studentsGet = context.Students;

            if (filter.Age != null)
                studentsGet = studentsGet.Where(x => x.Age == filter.Age);

            IEnumerable<StudentGetInfo> res = studentsGet.Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize).ProjectTo<StudentGetInfo>(mapper.ConfigurationProvider);

            int totalRecord = context.Students.Count();

            return PaginationResponse<IEnumerable<StudentGetInfo>>.Create(filter.PageNumber, filter.PageSize, totalRecord, res);

        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task<StudentGetInfo?> GetById(int id)
    {
        try
        {
            Student? student = await context.Students.FindAsync(id);
            if (student == null)
                return null;

            StudentGetInfo res = mapper.Map<Student?, StudentGetInfo>(student);


            return res;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task<bool> Update(StudentUpdateInfo studentUpdate)
    {
        try
        {
            Student? student = await context.Students.FindAsync(studentUpdate.Id);
            if (student == null)
                return false;

            context.Students.Update(mapper.Map(studentUpdate, student));
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            throw;
        }
    }
}