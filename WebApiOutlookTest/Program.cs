var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOriginPolicy", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("AllowAnyOriginPolicy");

app.UseHttpsRedirection();

app.Map("/api/signature", () => Results.Ok("<p>Signature <b>Test</b></p>"));

app.Run();