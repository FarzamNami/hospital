var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();  // Add session services for user data storage

// Configure authentication and authorization (simulating an Identity system for now)
builder.Services.AddAuthentication("CookieAuth")
    .AddCookie("CookieAuth", options =>
    {
        options.LoginPath = "/Account/Login"; // Redirect to Login if not authenticated
        options.AccessDeniedPath = "/Account/AccessDenied"; // Redirect if access is denied
    });

// Define policies for roles (although session-based, we simulate role-based access)
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("PatientPolicy", policy => policy.RequireClaim("Role", "Patient"));
    options.AddPolicy("DoctorPolicy", policy => policy.RequireClaim("Role", "Doctor"));
    options.AddPolicy("ManagementPolicy", policy => policy.RequireClaim("Role", "Management"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // Add HSTS for production environments
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Enable session-based authentication
app.UseSession();  // Access session data

app.UseAuthentication(); // Authentication middleware
app.UseAuthorization(); // Authorization middleware

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Landing}/{action=Login}/{id?}");

app.Run();