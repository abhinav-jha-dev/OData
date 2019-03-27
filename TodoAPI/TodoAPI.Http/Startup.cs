using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OData.Edm;
using Todo.Service.Mongo.Models;
using Todo.Service.Mongo.Services;

namespace TodoAPI.Http
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
            // Application Dependencies
            services.AddScoped<IAuthorService>(x => new AuthorService(Configuration.GetValue<string>("ConnectionSettings:MongoDB"), Configuration.GetValue<string>("Databases:ApplicationDatabase")));
            // ---

            // Register Services through Dependency Injection Register the OData Services
            services.AddOData();
            // ---

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Register the OData Endpoint
            app.UseMvc(b =>
            {
                b.MapODataServiceRoute("odata", "odata", GetEdmModel());
            });
            // ---
        }

        /*
        OData uses the Entity Data Model (EDM) to describe the structure of data. 
        In ASP.NET Core OData, it’s easily to build the EDM Model based on the above CLR types. 
        So, add the following private static method at the end of class “Startup”. As I have done 
        Here, we define entity sets.
        */
        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Author>("Author");
            builder.EntityType<Author>().HasKey(ai => ai.Id);
            return builder.GetEdmModel();
        }
    }
}
