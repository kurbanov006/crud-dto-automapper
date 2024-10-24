using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/studetns/")]
public class StudentController(IStudentService studentService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] StudentCreateInfo studentCreate)
    {
        bool res = await studentService.Create(studentCreate);
        if (res == false)
            return BadRequest(ApiResponse<bool>.Fail(null, false));

        return Ok(ApiResponse<bool>.Success(null, true));
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromBody] StudentUpdateInfo studentUpdate)
    {
        bool res = await studentService.Update(studentUpdate);
        if (res == false)
            return BadRequest(ApiResponse<bool>.Fail(null, false));

        return Ok(ApiResponse<bool>.Success(null, true));
    }


    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        bool res = await studentService.Delete(id);
        if (res == false)
            return BadRequest(ApiResponse<bool>.Fail(null, false));

        return Ok(ApiResponse<bool>.Success(null, true));
    }


    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        StudentGetInfo? studentGet = await studentService.GetById(id);
        if (studentGet == null)
            return NotFound(ApiResponse<StudentGetInfo?>.Fail(null, null));

        return Ok(ApiResponse<StudentGetInfo?>.Success(null, studentGet));
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetAll([FromQuery] StudentFilter filter)
    {
        PaginationResponse<IEnumerable<StudentGetInfo>> studentGet = studentService.GetAll(filter);
        if (studentGet == null)
            return NotFound(ApiResponse<PaginationResponse<IEnumerable<StudentGetInfo>>>.Fail(null, null));

        return Ok(ApiResponse<PaginationResponse<IEnumerable<StudentGetInfo>>>.Success(null, studentGet));
    }
}