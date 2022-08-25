using OnlineSchedule.Data.Contexts;
using OnlineSchedule.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineSchedule.Data.Repositories.Implementation;
using OnlineSchedule.Data.Repositories.Interfaces;
using OnlineSchedule.BusinessLogic.Mappers;
using OnlineSchedule.BusinessLogic.Authenticate;
using OnlineSchedule.BusinessLogic.Services;
using AutoMapper;
using OnlineSchedule.BusinessLogic.History;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddMvc();

builder.Services.AddDbContext<ScheduleContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<User, IdentityRole>(options =>
        options.Password = new PasswordOptions
        {
            RequireDigit = true,
            RequiredLength = 6,
            RequireLowercase = false,
            RequireUppercase = false,
            RequireNonAlphanumeric = false,
        }).AddEntityFrameworkStores<ScheduleContext>();

//builder.Services.AddAutoMapper(typeof(MappingProfile)); чомусь не робить, вирішити чому!
builder.Services.AddTransient<Mapper>(_ => new MapperFactory().Create());


// ============================================

builder.Services.AddTransient<Authenticator>();
builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<HistoryLogger>();

builder.Services.AddTransient<IScheduleRepository, ScheduleRepository>();
builder.Services.AddTransient<IDayRepository, DayRepository>();
builder.Services.AddTransient<ILessonRepository, LessonRepository>();
builder.Services.AddTransient<ICommentRepository, CommentRepository>();
builder.Services.AddTransient<IHistoryUserRepository, HistoryUserRepository>();
builder.Services.AddTransient<IHistoryScheduleRepository, HistoryScheduleRepository>();
builder.Services.AddTransient<ITypeOfActionRepository, TypeOfActionRepository>();

// ============================================ 


var app = builder.Build();


app.UseStaticFiles();

app.UseRouting(); 

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
 