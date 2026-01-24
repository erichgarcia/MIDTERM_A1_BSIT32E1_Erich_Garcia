using Microsoft.EntityFrameworkCore;
using MIDTERM_A1_BASICAUTH.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MIDTERM_A1_BASICAUTH.Data.BasicAuthDBContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("BasicAuthDBContext") ??
    "Data Source=BasicAuthDB.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MIDTERM_A1_BASICAUTH.Data.BasicAuthDBContext>();
    db.Database.EnsureCreated();
}
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<BasicAuthMiddleware>();

app.MapControllers();

app.Run();
