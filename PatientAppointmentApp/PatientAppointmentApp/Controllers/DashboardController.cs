using Microsoft.AspNetCore.Mvc;
using PatientAppointmentApp.Models;

public class DashboardController : Controller
{
    public IActionResult PatientDashboard()
    {
        var role = HttpContext.Session.GetString("Role");
        return View(model: role);
    }

    public IActionResult DoctorDashboard()
    {
        return View();
    }

    public IActionResult ManagementDashboard()
    {
        return View();
    }
}
