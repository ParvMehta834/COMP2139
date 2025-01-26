using comp2139.Models;
using Microsoft.AspNetCore.Mvc;

namespace comp2139.Controllers;

public class ProjectController : Controller
{

    /// <summary>
    /// Index action will retrieve a listing of Projects (database)
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult Index()
    {
        //Retrieve all projects from the database
        var projects = new List<Project>
        {
            new Project { ProjectId = 1, Name = "Project 1", Description = "First Project 1" },

        };
        return View(projects);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Create(Project project)
    {
        return RedirectToAction("Index");
    }
    //CRUD - Create - Read - Update - Delete
    
    [HttpGet]
    public IActionResult Details(int id)
    {
        //Database --> Retrieve project from databse
        var project = new Project { ProjectId = id, Name = "Project 1", Description = "First Project 1" };
        return View(project);
    }
    
   


}