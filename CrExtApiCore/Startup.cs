using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrExtApiCore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using CrExtApiCore.Repositories;
using Entities;
using CrExtApiCore.Providers;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CrExtApiCore.Factories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;

namespace CrExtApiCore
{
    public class Startup
    {
        //  public  IConfigurationRoot Configuration { get; }
        private const string SecretKey = "QNivDmHLpUA223EqsfhqGOMRdRj1PVpH"; // todo: get this from somewhere secure
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));

        public static IConfigurationRoot Configuration;
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public Startup()
        {
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddCors();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());
            });

            // Add framework services.
            services.AddMvc();
            // var connectionString = @"Data Source=localhost;Initial Catalog=CrExtDb;Integrated Security=True;";
               var connectionString = Startup.Configuration["ConnectionString:CrExtConnectionString"];
            //var connectionString = new Startup().Configuration["ConnectionString:CrExtConnectionString"];

            services.AddScoped<IJwtFactory, JwtFactory>();
            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));

            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });

            services.AddIdentity<Users, Roles>
               (o =>
               {
                   // configure identity options
                   o.Password.RequireDigit = false;
                   o.Password.RequireLowercase = false;
                   o.Password.RequireUppercase = false;
                   o.Password.RequireNonAlphanumeric = false;
                   o.Password.RequiredLength = 6;
                   o.User.RequireUniqueEmail = true;

               })
               .AddEntityFrameworkStores<CrExtContext>();
            //.AddDefaultTokenProviders();
            //.AddTokenProvider();

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(configureOptions =>
            {
                configureOptions.ClaimsIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                configureOptions.TokenValidationParameters = tokenValidationParameters;
                configureOptions.SaveToken = true;
            });

            services.AddDbContext<Entities.CrExtContext>(o=>o.UseSqlServer(connectionString));

           // services.AddAutoMapper();
            services.AddScoped<IPackageAsync, Package>();
            services.AddScoped<IUserAsync, UserAsync>();
            services.AddScoped<IRoleAsync, Role>();
            services.AddScoped<IOrganisationAsync, Organisation>();
            services.AddScoped<IProject, Project>();
            services.AddScoped<ICustomer, Customer>();
            services.AddScoped<ITeam, Team>();
            services.AddScoped<ITeamMember, TeamMember>();
            services.AddScoped<IReview, Review>();
            services.AddScoped<IReviewAction, ReviewAction>();
            services.AddScoped<IReviewKind, ReviewKind>();
            services.AddScoped<IReviewNotification, ReviewNotification>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            
                //app.UseCors(builder =>
                // builder.WithOrigins("http://localhost:4200"));
            app.UseStaticFiles();
           

            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                RequireExpirationTime = false, 
                ValidateLifetime = false,
                ClockSkew = TimeSpan.Zero
            };

            //app.UseJwtBearerAuthentication(new JwtBearerOptions
            //{

            //});
            //app.UseJwtBearerAuthentication(new JwtBearerOptions
            //{
            //    AutomaticAuthenticate = true,
            //    AutomaticChallenge = true,
            //    TokenValidationParameters = tokenValidationParameters
            //});

            AutoMapper.Mapper.Initialize(map =>
            {
                map.CreateMap<Entities.Organisations, Models.OrganisationDto>();
                map.CreateMap<OrganisationDto, Entities.Organisations>();

                map.CreateMap<Users, UserDto>();
              map.CreateMap<UserDto, Users>().ForMember(a=>a.UserName, m=> m.MapFrom(c=>c.Email));
             
                map.CreateMap<Teams, TeamDto>();
                map.CreateMap<TeamDto, Teams>();
                map.CreateMap<CreateTeamDto, Teams>();

                map.CreateMap<TeamMembers, TeamMemberDto>();
                map.CreateMap<TeamMemberDto, TeamMembers>();
                map.CreateMap<CreateTeamMemberDto, TeamMembers>();

                map.CreateMap<Projects, ProjectDto>();
                map.CreateMap<ProjectDto, Projects>();
                map.CreateMap<CreateProjectDto, Projects>();

                map.CreateMap<Entities.Packages, PackageDto>();
                map.CreateMap<PackageDto, Entities.Packages>();

                map.CreateMap<CustomerDto, Entities.Customers>();
                map.CreateMap<Entities.Customers, CustomerDto>();
                map.CreateMap<CreateCustomerDto, Customers>();

                map.CreateMap<ReviewDto, Entities.Reviews>();
                map.CreateMap<Entities.Reviews, ReviewDto>();
                map.CreateMap<CreateReviewDto, Entities.Reviews>();


                map.CreateMap<ReviewNotificationsDto, Entities.ReviewNotifications>();
                map.CreateMap< Entities.ReviewNotifications,  ReviewNotificationsDto >();
                map.CreateMap<CreateReviewNotificationsDto, Entities.ReviewNotifications>()
                //.ForMember(des=>des.DateAdded, src=> src.UseValue(System.DateTime.UtcNow));
                .ForMember(des=>des.DateAdded, src=> src.MapFrom(r => System.DateTime.UtcNow));


                map.CreateMap<CreateReviewAndNotitficationDto, CreateReviewDto>();
                map.CreateMap<CreateReviewAndNotitficationDto, CreateReviewNotificationsDto>();

                //map.CreateMap<PackageRoleListDto, PackagePRoles>().ForMember(a => a.Package, b => b.MapFrom(src => src.Package))
                //                                                     .ForMember(a => a.PRole, ma => ma.MapFrom(src => src.PRole))
                //                                                     .ForMember(a => a.PackageId, ma => ma.MapFrom(src => src.Package.Id))
                //                                                     .ForMember(a => a.PRoleId, ma => ma.MapFrom(src => src.PRole.Id));
            });
            app.UseMvc();
            //app.UseMvc(routes =>
            //{ 
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});
        }
    }
}
