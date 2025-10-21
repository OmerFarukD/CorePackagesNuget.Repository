using LibrarySystem.API.Repositories.Abstracts;
using LibrarySystem.API.Repositories.Concretes;
using LibrarySystem.API.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using QubitTech.Repositories.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IPublisherRepository, PublisherRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ILoanRepository, LoanRepository>();
builder.Services.AddScoped<IPublisherRepository, PublisherRepository>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();


builder.Services.AddQubitRepositories<LibraryDbContext>(opt =>
{
    opt.AutoSaveChanges = false;
    opt.EnableSoftDelete = true;
    opt.EnableAuditLogging = false;
}).ConfigureDbContext((sp,opt)=> opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



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

app.Run();