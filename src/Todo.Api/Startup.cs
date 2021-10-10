using System.Diagnostics.CodeAnalysis;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Todo.Domain.CommandHandlers;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Repositories;
using Todo.Infra.Contexts;
using Todo.Infra.Repositories;

namespace Todo.Api
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup));
            services.AddControllers();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "Todo.Api", Version = "v1"}); });

            ConfigureDatabase(services);
            services.AddScoped<ITodoRepository, TodoRepository>();
            ConfigureCommands(services);
        }

        private void ConfigureDatabase(IServiceCollection services)
        {
            if (Env.IsDevelopment())
            {
                services.AddDbContext<TodoItemContext>(opt =>
                    opt.UseInMemoryDatabase("Database"));
                return;
            }
            
            services.AddDbContext<TodoItemContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("Database")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
        
        private void ConfigureCommands(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<CreateTodo, ICommandResult>, CreateTodoCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateTodo, ICommandResult>, UpdateTodoCommandHandler>();
        }
    }
}