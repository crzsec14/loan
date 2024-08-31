using LoanApp.Repositories.Interfaces;
using LoanApp.Repositories.Repositories;
using LoanApp.Services.Interfaces;
using LoanApp.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("LoanDB");
builder.Services.AddScoped<IDatabaseRepository>(x => new DatabaseRepository(connectionString));
builder.Services.AddScoped<ILoanRepository, LoanRepository>();
builder.Services.AddScoped<IBorrowerRepository, BorrowerRepository>();
builder.Services.AddScoped<IEmploymentRepository, EmploymentRepository>();

builder.Services.AddScoped<ITableInfoRepository, TableInfoRepository>();
builder.Services.AddScoped<IFieldInfoRepository, FieldInfoRepository>();
builder.Services.AddScoped<ITableRelationshipRepository, TableRelationshipRepository>();
// Configure the HTTP request pipeline.
builder.Services.AddScoped<ILoanService, LoanService>();
builder.Services.AddScoped<IBorrowerService, BorrowerService>();
builder.Services.AddScoped<IEmploymentService, EmploymentService>();

builder.Services.AddScoped<ITableInfoService, TableInfoService>();
builder.Services.AddScoped<IFieldInfoService, FieldInfoService>();
builder.Services.AddScoped<ITableRelationshipService, TableRelationshipService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();