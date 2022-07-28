using AutoMapper;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using deila.backend.Contexts;
using deila.backend.Services;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("https://localhost:5002").WithMethods("PUT", "DELETE", "GET").AllowAnyHeader();
                      });
});

// Add services to the container.
builder.Services.AddControllers();

// Add JsonPatch service
builder.Services.AddControllers().AddNewtonsoftJson(s => s.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


// Add xml response option
builder.Services.AddControllers().AddMvcOptions(o => o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<DeilaDbContext>(o =>
{
    o.UseSqlServer(builder.Configuration["connectionStrings:DeilaDbContext"]);
});
builder.Services.AddScoped<IArticleRepo, ArticleRepo>();
builder.Services.AddScoped<IBasisRepo, BasisRepo>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler();
}


app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();
app.UseStatusCodePages(); //provide simple text-based message

app.MapControllers();
app.Run();
