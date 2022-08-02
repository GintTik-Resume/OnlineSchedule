var builder = WebApplication.CreateBuilder(args);


builder.Services.AddMvc();


var app = builder.Build();


app.UseRouting(); // ���������� ������� �������������

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
 