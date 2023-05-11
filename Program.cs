using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Batch;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using ODataBatching.Db;
using ODataBatching.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TestDbContext>(opt =>
    opt.UseInMemoryDatabase("BatchDemo")
);

var batchHandler = new DefaultODataBatchHandler
{
    MessageQuotas =
    {
        MaxNestingDepth = 1,
        MaxPartsPerBatch = 1
    }
};

builder.Services.AddControllers().AddOData(opt =>
    opt.AddRouteComponents("odata", GetModel(), batchHandler)
        .Select()
        .Count()
        .Filter()
        .OrderBy()
);
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

app.UseODataBatching();
app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static IEdmModel GetModel()
{
    var builder = new ODataConventionModelBuilder();
    builder.EntitySet<ClockAction>("ClockActions");

    return builder.GetEdmModel();
}