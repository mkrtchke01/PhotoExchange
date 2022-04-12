using Applications;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistence(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddApplications();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
    options.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader());

app.UseRouting();
app.UseHttpsRedirection();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
