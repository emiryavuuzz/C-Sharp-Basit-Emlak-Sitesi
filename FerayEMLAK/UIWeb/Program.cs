
using Bussines.Containers;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc().AddFluentValidation();
builder.Services.MyServiceInstance();

builder.Services.AddAuthentication("Cookies").AddCookie(x =>
{
    x.LoginPath = "/admin/Giris";// Giriþ yapýlan sayfalara grirldiðinde yönlendirilecek olan sayfa
    x.LogoutPath = "/admin/Cikis";//Çýkýþ yapýlmasýný saðlayan sayfa
    x.AccessDeniedPath = "/admin/Giris"; // YEtkissiz Giril Yapýldýðý zaman Yönlendirilecek sayfa


});

//builder.Services.AddAuthentication().AddFacebook(opt =>
//{
//    opt.AppId = "439295804766088";
//    opt.AppSecret = "d95ac4d4dbf13e9736bfbecbf48f7e0f";
//});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(x =>
{
    x.MapDefaultControllerRoute();
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Giris}/{action=Index}/{id?}"
    );
});

app.Run();
