var builder = WebApplication.CreateBuilder(args);


var apiSettings = builder.Configuration.GetSection("ApiSettings");
var baseUrl = apiSettings.GetValue<string>("BaseUrl");

if (string.IsNullOrEmpty(baseUrl))
{
    throw new Exception("ApiSettings:BaseUrl bulunamadý!");
}


builder.Services.AddHttpClient("CarBookClient", client =>
{
    client.BaseAddress = new Uri(baseUrl);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
    client.Timeout = TimeSpan.FromSeconds(30);
});
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=About}/{action=Index}/{id?}");

app.Run();
