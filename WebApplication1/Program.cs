using HelperClasses;
using Microsoft.Extensions.Configuration;
using Repository.Branch.V1;
using Repository.Customer.V1;
using Repository.CustomerBranch.V1;
using Repository.Item.V1;
using Repository.Order.V1;
using Repository.OrderType.V1;
using Repository.Region.V1;
using Repository.User.V1;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using Microsoft.Identity.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Forgo.Task.Filter;
using Microsoft.Identity.Web.UI;
using ForgoAPI.Entity.Item.BusinessModels;
using Microsoft.AspNetCore.Server.IISIntegration;
using ForgoAPI.Services.OrderDistribute.V1;
using Repository.OrderDistribute.V1;


var builder = WebApplication.CreateBuilder(args);

var Configuration = builder.Configuration;

//builder.Services.AddMicrosoftIdentityWebAppAuthentication(Configuration).EnableTokenAcquisitionToCallDownstreamApi().AddDistributedTokenCaches();

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
   {
       options.TokenValidationParameters = new TokenValidationParameters
       {
           ValidateIssuer = true,
           ValidateAudience = true,
           ValidateLifetime = true,
           ValidIssuer = builder.Configuration["Jwt:Issuer"],
           ValidAudience = builder.Configuration["Jwt:Audience"],
           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
       };
   });

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();
builder.Services.AddMvc(option =>
{
    option.Filters.Add(typeof(CITFilter));
});


//builder.Services.AddMicrosoftIdentityWebApiAuthentication(Configuration, subscribeToJwtBearerMiddlewareDiagnosticsEvents: true)
//    .EnableTokenAcquisitionToCallDownstreamApi()
//    .AddInMemoryTokenCaches();

//builder.Services.AddControllersWithViews(options =>
//{
//    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
//    options.Filters.Add(new AuthorizeFilter(policy));
//    options.Filters.Add(typeof(CITFilter));
//}).AddMicrosoftIdentityUI();

builder.Services.AddResponseCaching();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60);
    options.Cookie.IsEssential = true;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(IISDefaults.AuthenticationScheme);

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICustomerBranchRepository, CustomerBranchRepository>();
builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<IOrderTypeRepository, OrderTypeRepository>();
builder.Services.AddScoped<IRegionRepository, RegionRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderDistributeRepository, OrderDistributeRepository>();

builder.Services.AddScoped<ForgoAPI.Services.Item.V1.IItemService, ForgoAPI.Services.Item.V1.ItemService>();
builder.Services.AddScoped<ForgoAPI.Services.Customer.V1.ICustomerService, ForgoAPI.Services.Customer.V1.CustomerService>();
builder.Services.AddScoped<ForgoAPI.Services.Item.V2.IItemService, ForgoAPI.Services.Item.V2.ItemService>();
builder.Services.AddScoped<ForgoAPI.Services.User.V1.IUserService, ForgoAPI.Services.User.V1.UserService>();
builder.Services.AddScoped<ForgoAPI.Services.CustomerBranch.V1.ICustomerBranchService, ForgoAPI.Services.CustomerBranch.V1.CustomerBranchService>();
builder.Services.AddScoped<ForgoAPI.Services.Branch.V1.IBranchService, ForgoAPI.Services.Branch.V1.BranchService>();
builder.Services.AddScoped<ForgoAPI.Services.OrderType.V1.IOrderTypeService, ForgoAPI.Services.OrderType.V1.OrderTypeService>();
builder.Services.AddScoped<ForgoAPI.Services.Region.V1.IRegionTypeService, ForgoAPI.Services.Region.V1.RegionTypeService>();
builder.Services.AddScoped<ForgoAPI.Services.Order.V1.IOrderService, ForgoAPI.Services.Order.V1.OrderService>();
builder.Services.AddScoped<ForgoAPI.Services.OrderDistribute.V1.IOrderDistributeService, ForgoAPI.Services.OrderDistribute.V1.OrderDistributeService>();

AppSettings appSettings = new AppSettings(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //app.UseSwagger();
    app.UseSwaggerUI();
}
{
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseSwagger();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});

//app.UseSwaggerUI(c =>
//{
//    c.SwaggerEndpoint("v1/swagger.json", "3.0.0");
//});
app.Run();

