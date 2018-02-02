using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using VoxConnections.Convidados.Core;
using Microsoft.EntityFrameworkCore;
using VoxConnections.Convidados.Application.Services;
using VoxConnections.Convidados.Application;
using VoxConnections.Convidados.Data;
using VoxConnections.Convidados.Data.Repository;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;

namespace VoxConnections.Oportunidades.WebApi
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="env"></param>
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }


        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        //public IConfiguration Configuration { get; }

        /// <summary>
        /// Configuration
        /// </summary>
        public IConfigurationRoot Configuration { get; }


        // The secret key every token will be signed with.
        // In production, you should store this securely in environment variables
        // or a key management tool. Don't hardcode this into your application!
        private static readonly string secretKey = "a-password-very-big-to-be-good";

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {

            //configure the jwt   
            ConfigureJwtAuthService(services);

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Candidato", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("Perfil", "Candidato");
                });

                options.AddPolicy("Admin", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("Perfil", "Gestor");
                });

                options.AddPolicy("Headhunter", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("Perfil", "Headhunter");
                });
            });


            //Faz a Dependency Injection do contexto
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("VoxDBConnection")));


            //Faz Dependency Injection das classes
            services.Add(new ServiceDescriptor(typeof(IBaseService<>), typeof(BaseService<>), ServiceLifetime.Transient));
            services.AddTransient<ICandidatoService, CandidatoService>();
            services.AddTransient<ICurriculoService, CurriculoService>();
            services.AddTransient<IIdiomasCandidatoService, IdiomasCandidatoService>();
            services.AddTransient<IIdiomasGestorService, IdiomasGestorService>();
            services.AddTransient<IIdiomasVagasService, IdiomasVagasService>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IGestorService, GestorService>();
            services.AddTransient<IHeadhunterService, HeadhunterService>();
            services.AddTransient<IVagasService, VagasService>();
            services.AddTransient<IVagasCandidaturaService, VagasCandidaturaService>();
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<ICandidatoRepository, CandidatoRepository>();
            services.AddTransient<ICurriculoRepository, CurriculoRepository>();
            services.AddTransient<IIdiomasCandidatoRepository, IdiomasCandidatoRepository>();
            services.AddTransient<IIdiomasVagasRepository, IdiomasVagasRepository>();
            services.AddTransient<IIdiomasGestorRepository, IdiomasGestorRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IGestorRepository, GestorRepository>();
            services.AddTransient<IGestorRepository, GestorRepository>();
            services.AddTransient<IHeadhunterRepository, HeadhunterRepository>();
            services.AddTransient<IVagasRepository, VagasRepository>();
            services.AddTransient<IVagasCandidaturaRepository, VagasCandidaturaRepository>();

            // Configurando o serviço de documentação do Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "API de Oportunidades",
                        Version = "v1",
                        Description = "API REST criada com o ASP.NET Core",
                        Contact = new Contact
                        {
                            Name = "Rodrigo Campos",
                            Email = "rooh19@globo.com"
                        }
                    });

                string caminhoAplicacao =
                    PlatformServices.Default.Application.ApplicationBasePath;
                string nomeAplicacao =
                    PlatformServices.Default.Application.ApplicationName;
                string caminhoXmlDoc =
                    Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

                c.IncludeXmlComments(caminhoXmlDoc);
            });

            services.AddMvc();

            //Faz o tratamento no CORS para autorizar o acesso de qualquer origem
            services.AddCors(o => o.AddPolicy("AllowAllOrigins", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));


        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseAuthentication();

            //if (env.IsDevelopment())
            //{
            app.UseDeveloperExceptionPage();
            //}

            //Faz a implementação do CORS
            app.UseCors("AllowAllOrigins");

            app.UseMvc();

            // Ativando middlewares para uso do Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Oportunidades V1");
            });


        }

        /// <summary>
        /// Método ConfigureJwtAuthService
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureJwtAuthService(IServiceCollection services)
        {
            var audienceConfig = Configuration.GetSection("TokenConfigurations");
            var symmetricKeyAsBase64 = secretKey;
            var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
            var signingKey = new SymmetricSecurityKey(keyByteArray);

            var tokenValidationParameters = new TokenValidationParameters
            {
                // The signing key must match!  
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,

                // Validate the JWT Issuer (iss) claim  
                ValidateIssuer = false,
                ValidIssuer = audienceConfig["Iss"],

                // Validate the JWT Audience (aud) claim  
                ValidateAudience = false,
                ValidAudience = audienceConfig["Aud"],

                // Validate the token expiry  
                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = tokenValidationParameters;
            });
        }
    }
}
