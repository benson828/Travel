using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Travel.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("TravelContextConnection") ?? throw new InvalidOperationException("Connection string 'TravelContextConnection' not found.");

builder.Services.AddDbContext<TravelContext>(options => options.UseSqlServer(connectionString));

//�ϥΪ̦W�ٳ]�m
builder.Services.AddDefaultIdentity<TravelUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.User.RequireUniqueEmail = false; //���A�n�D�q�l�l��ߤ@
    options.User.AllowedUserNameCharacters = null; // ���\����r�ŧ@���Τ�W
}).AddEntityFrameworkStores<TravelContext>();

//�K�X�]�m
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true; //�ܤ֤@�ӼƦr
    options.Password.RequireLowercase = true; //�ܤ֤@�Ӥp�g�r��
    options.Password.RequireUppercase = true; //�ܤ֤@�Ӥj�g�r��
    options.Password.RequireNonAlphanumeric = false; //���ݭn�D�Ʀr�M�D�r�����Ÿ�
    //options.Password.RequiredLength = 8; // �̤p�K�X����(�w�]6 max:100)
});



// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
