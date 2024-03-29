using Microsoft.EntityFrameworkCore;
using TodoListAPI.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        // Register DbContext
        services.AddDbContext<TodoDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("YourConnectionString")));

        // Other service registrations can go here
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Configure middleware and request pipeline
    }
}
