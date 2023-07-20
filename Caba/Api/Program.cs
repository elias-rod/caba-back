
namespace Api
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddCors(options => options.AddPolicy(name: "devAllowedOrigin", policy => policy.WithOrigins("http://localhost:3000")));
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("devAllowedOrigin");
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}