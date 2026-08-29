var builder = WebApplication.CreateBuilder(args);


var baseUrl = builder.Configuration["ApiSettings:BaseUrl"];

if (string.IsNullOrWhiteSpace(baseUrl))
{
    throw new Exception("ApiSettings:BaseUrl bulunamadı!");
}


builder.Services.AddHttpClient("CarBookClient", client =>
{
    client.BaseAddress = new Uri(baseUrl.EndsWith("/") ? baseUrl : baseUrl + "/");
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Add("Accept", "application/json");
    client.Timeout = TimeSpan.FromSeconds(30);
});


builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseHttpsRedirection(); 
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.UseStaticFiles();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=AdminStatistics}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();