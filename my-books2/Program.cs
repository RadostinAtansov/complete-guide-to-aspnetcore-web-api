using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using my_books2.Data;
using my_books2.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//
var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
                                                                //Server=.;Database=myDataB;Trusted_Connection=True;
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConnectionString));

//configure the services
builder.Services.AddTransient<BooksService>();
builder.Services.AddTransient<AuthorsService>();
builder.Services.AddTransient<PublisherService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//AppDbInitializer.Seed(app);

app.Run(); 