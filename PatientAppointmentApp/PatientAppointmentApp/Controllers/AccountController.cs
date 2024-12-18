using Microsoft.AspNetCore.Mvc;
using PatientAppointmentApp.Models;

public class LandingController : Controller
{
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        var user = ValidateUser(username, password);
        if (user != null)
        {
            HttpContext.Session.SetString("Username", user.Username);
            HttpContext.Session.SetString("Role", user.Role.ToString());


            if (user.Role == UserRole.Patient) 
                return RedirectToAction("PatientDashboard", "Dashboard");
            else if (user.Role == UserRole.Doctor) 
                return RedirectToAction("DoctorDashboard", "Dashboard");
            else if (user.Role == UserRole.Management) 
                return RedirectToAction("ManagementDashboard", "Dashboard");
        }

        ModelState.AddModelError("", "Invalid login attempt.");
        return View();
    }


    private ApplicationUser ValidateUser(string username, string password)
    {
        var dummyUsers = new List<ApplicationUser>
    {
        new ApplicationUser { Username = "patientUser", Password = "password", Role = UserRole.Patient },
        new ApplicationUser { Username = "doctorUser", Password = "password", Role = UserRole.Doctor },
        new ApplicationUser { Username = "ManagementUser", Password = "password", Role = UserRole.Management }
    };

        return dummyUsers.FirstOrDefault(u => u.Username == username && u.Password == password);
    }
}
