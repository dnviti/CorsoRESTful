namespace API
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
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin();
                                      builder.AllowAnyHeader();
                                      builder.AllowAnyMethod();
                                  });
            });

            services.AddOptions();
            services.Configure<CorsoRESTSettings>(Configuration.GetSection("CorsoRESTSettings"));
            var settings = Configuration.GetSection("CorsoRESTSettings").Get<CorsoRESTSettings>();
            var availDb = settings.AvailableDatabases;

            string connectionString = string.Empty;

            // Reading connection string from appsettings
            foreach (var item in availDb.AsDictionary())
            {
                var dbSettings = (BaseConnectionString)item.Value;
                if (settings.DefaultDatabase != dbSettings.Code)
                {
                    continue;
                }
                if (string.IsNullOrEmpty(dbSettings.ConnectionString))
                {
                    continue;
                }
                connectionString = dbSettings.ConnectionString;
                break;
            }

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new System.Exception($"No Connection String found, please configure one and try again");
            }

            //----- Using connection string
            services.AddPooledDbContextFactory<CorsoRESTDbContext>(
                opt =>
                {
                    opt.EnableServiceProviderCaching(false);
                    // Select db
                    if (settings.DefaultDatabase == availDb.SQLServerLocal.Code || settings.DefaultDatabase == availDb.SQLSever.Code)
                    {
                        opt.UseSqlServer(connectionString);
                    }
                    if (settings.DefaultDatabase == availDb.MySQL.Code || settings.DefaultDatabase == availDb.MariaDB.Code)
                    {
                        opt.UseMySQL(connectionString);
                    }
                    if (settings.DefaultDatabase == availDb.PostgreSQL.Code)
                    {
                        opt.UseNpgsql(connectionString);
                    }
                    if (settings.DefaultDatabase == availDb.Oracle.Code)
                    {
                        opt.UseOracle(connectionString);
                    }
                }
            );

            //-----

            services.AddControllers().AddNewtonsoftJson(s =>
            {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });

            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = long.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
            // Add framework services.
            services.AddMvc();

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ActorsProfile());
                mc.AddProfile(new AuthorsProfile());
                mc.AddProfile(new MoviesProfile());
                mc.AddProfile(new ShopsProfile());
                mc.AddProfile(new ActorMovieProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            // Database
            // Sql Server
            services.AddScoped<IMovieService, CorsoRESTMovieRepo>();
            services.AddScoped<IAuthorService, CorsoRESTAuthorRepo>();
            services.AddScoped<IActorService, CorsoRESTActorRepo>();
            services.AddScoped<IShopService, CorsoRESTShopRepo>();

            // Mongo DB
            ////

            // Utilities
            services.AddSingleton<StringUtilities>();
            services.AddSingleton<Crypto>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}