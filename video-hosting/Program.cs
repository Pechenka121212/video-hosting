using video_hosting.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

//ApplicationContext databaseConnection = new ApplicationContext();
//databaseConnection.Videos.Add(new video_hosting.Models.Video() { Name = "Белый властелин", Categories = "Black men, Domination, More cum", FileName = "BBC", PathToFile = "C:/Windiws", Description = "Черный властелин жаждет встречи с тобой", PuthToThumbnail="C:/Linux" });
//databaseConnection.SaveChanges();

app.Run();

