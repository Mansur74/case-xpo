using DevExpress.Xpo.DB;
using DevExpress.Xpo;
using System.Text.Json.Serialization;
using CaseAPI.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using CaseAPI;
using CaseAPI.Models.caseproj;
using CaseAPI.Business.Abstracts;
using CaseAPI.Business.Concretes;
using CaseAPI.DataAccess.Abstracts;
using CaseAPI.DataAccess.Concretes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//repos
builder.Services.AddScoped<IDocumentDal, DocumentDal>();
//services
builder.Services.AddScoped<IDocumentService, DocumentManager>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddXpoDefaultUnitOfWork(true, (DataLayerOptionsBuilder options) =>
             options.UseConnectionString(builder.Configuration.GetConnectionString("caseproj"))
             .UseAutoCreationOption(AutoCreateOption.DatabaseAndSchema)
             .UseConnectionPool(false)
             .UseEntityTypes(ConnectionHelper.GetPersistentTypes()));

builder.Services.AddHttpContextAccessor();
builder.Services.ConfigureOptions<ConfigureJsonOptions>();
builder.Services.AddSingleton(typeof(IModelMetadataProvider), typeof(XpoMetadataProvider));

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
