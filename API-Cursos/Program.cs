using API_Cursos.Models;
using API_Cursos.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Controllers
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new System.Text.Json.Serialization.JsonStringEnumConverter());
    });

// 🔹 Swagger + JWT
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.OrderActionsBy(apiDesc =>
    {
        var methodOrder = apiDesc.HttpMethod switch
        {
            "GET" => "1",
            "POST" => "2",
            "PUT" => "3",
            "DELETE" => "4",
            _ => "5"
        };

        return methodOrder;
    });
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Curso",
        Version = "v1.0",
        Description = """
        
        API para gerenciamento de cursos
        

        Desenvolvido por Gabriel Duarte
        
        """,
        Contact = new OpenApiContact
        {
            Name = "Gabriel Duarte"
        }
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    options.IncludeXmlComments(xmlPath);

    
});
// 🔹 DbContext
builder.Services.AddDbContext<DbCursosContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

// services
builder.Services.AddScoped<CursoService>();
builder.Services.AddHttpContextAccessor();


var app = builder.Build();

// 🔹 Swagger
app.UseSwagger();
app.UseSwaggerUI();

// arquivo
app.UseStaticFiles();

// 🔹 Pipeline
app.UseAuthentication(); // ⚠️ sempre antes
app.UseAuthorization();

app.MapControllers();

app.Run();