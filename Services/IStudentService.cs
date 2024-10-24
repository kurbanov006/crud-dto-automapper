public interface IStudentService
{
    Task<bool> Create(StudentCreateInfo studentCreate);
    Task<bool> Update(StudentUpdateInfo studentUpdate);
    Task<bool> Delete(int id);
    PaginationResponse<IEnumerable<StudentGetInfo>> GetAll(StudentFilter filter);
    Task<StudentGetInfo?> GetById(int id);
}