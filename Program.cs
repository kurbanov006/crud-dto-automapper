using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddDbContext<AppDbContext>(x =>
x.UseNpgsql(builder.Configuration["ConnectionString"]));
builder.Services.AddAutoMapper(typeof(Mapper));


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();