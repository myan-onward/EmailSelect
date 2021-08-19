using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using EmailSelect.Data;
using EmailSelect.GraphQL;
using EmailSelect.GraphQL.SelectionAssociations;
using EmailSelect.GraphQL.RuleSelections;
using GraphQL.Server.Ui.Voyager;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace EmailSelect
{
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
            // Set the active provider via configuration
            var provider = Configuration.GetValue("Provider", "SqlServer");
            // Console.WriteLine($"Provider = {provider}");

            // Set TnsAdmin value to directory location of tnsnames.ora and sqlnet.ora files
            OracleConfiguration.TnsAdmin = @"<DIRECTORY LOCATION>";

            // Set WalletLocation value to directory location of the ADB wallet (i.e. cwallet.sso)
            OracleConfiguration.WalletLocation = @"<DIRECTORY LOCATION>";

            services.AddPooledDbContextFactory<AppDbContext>(opt => _ = provider switch
            {
                // "Sqlite" => opt.UseSqlite(
                //     Configuration.GetConnectionString("SqliteConnection"),
                //     x => x.MigrationsAssembly("SqliteMigrations")),

                "SqlServer" => opt.UseSqlServer(
                    Configuration.GetConnectionString("SqlServerConnection"),
                    x => x.MigrationsAssembly("SqlServerMigrations")),

                // Configure ODP.NET connection string
                // optionsBuilder.UseOracle(@"User Id=<USER>;Password=<PASSWORD>;Data Source=<TNS NAME>");

                "Oracle" => opt.UseOracle(
                    Configuration.GetConnectionString("OracleConnection"),
                    x => x.MigrationsAssembly("OracleMigrations")),

                _ => throw new Exception($"Unsupported provider: {provider}")
            });

            // services.AddControllers();
            services
            .AddGraphQLServer()
            .AddProjections()
            .AddQueryType<Query>()
            .AddMutationType<Mutation>()
            .AddType<SelectionAssociationType>()
            .AddType<AddSelectionAssociationInputType>()
            .AddType<AddSelectionAssociationPayloadType>()
            .AddType<RuleSelectionType>()
            .AddType<AddRuleSelectionInputType>()
            .AddType<AddRuleSelectionPayloadType>()
            .AddType<DeleteRuleSelectionInputType>()
            .AddType<DeleteRuleSelectionPayloadType>()
            .AddFiltering()
            .AddSorting();

            // services.AddSwaggerGen(c =>
            // {
            //     c.SwaggerDoc("v1", new OpenApiInfo { Title = "EmailSelect", Version = "v1" });
            // });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // app.UseSwagger();
                // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmailSelect v1"));
            }

            // app.UseHttpsRedirection();

            app.UseWebSockets();

            app.UseRouting();

            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // endpoints.MapControllers();
                endpoints.MapGraphQL();
            });

            app.UseGraphQLVoyager(new VoyagerOptions()
            {
                GraphQLEndPoint = "/graphql"
            },
            "/ui/voyager");
        }
    }
}
