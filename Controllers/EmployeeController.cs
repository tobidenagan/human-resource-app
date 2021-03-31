using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using HumanResourceApp.Models;
using HumanResourceApp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace HumanResourceApp.Controllers
{
	public class EmployeeController : Controller
	{
		
		// GET: Employee/GetAllEmpDetails   
		public ActionResult GetAllEmployees()
		{
            try 
			{ 
				EmployeeRepository EmployeeRepo = new EmployeeRepository();
				return View(EmployeeRepo.GetAllEmployees());
			} 
			catch (Exception e) 
			{ 
				return View(e.Message); 
			}
		}

		// GET: Employee/AddEmployee      
		public ActionResult AddEmployee()
		{
			try
			{
				EmployeeRepository EmployeeRepo = new EmployeeRepository();
				ViewBag.LevelList = new SelectList(EmployeeRepo.GetAllLevels(), "level_id", "level_name");
				return View();
			}
			catch (Exception e)
			{
				return View(e.Message);
			}
			
		}

		// POST: Employee/AddEmployee 
		[HttpPost]
		public ActionResult AddEmployee(AddModel Employee)
		{
		
			try
			{
				if (ModelState.IsValid)
				{
					EmployeeRepository EmployeeRepo2 = new EmployeeRepository();
					ViewBag.LevelList = new SelectList(EmployeeRepo2.GetAllLevels(), "level_id", "level_name");

					EmployeeRepository EmployeeRepo = new EmployeeRepository();
					EmployeeRepo.AddEmployee(Employee);

					TempData["AddMsg"] = "Employee added successfully.";
				}
				TryUpdateModelAsync(Employee);
				ModelState.Clear();
				return View();
			}
			catch (Exception e)
			{

				return View(e.Message);
			}
		}

		// GET: Bind controls to Update details      
		public ActionResult UpdateEmployee(int id)
		{
			try
			{
				EmployeeRepository EmployeeRepo = new EmployeeRepository();
				EmployeeRepository EmployeeRepo2 = new EmployeeRepository();
				ViewBag.LevelList = new SelectList(EmployeeRepo.GetAllLevels(), "level_id", "level_name");
				return View(EmployeeRepo2.GetAllEmployees().Find(Employee => Employee.id_no == id));
			}
			catch (Exception e)
			{
				return View(e.Message);
			}
		}

		// POST:Update the details into database      
		[HttpPost]
		public ActionResult UpdateEmployee(int id, UpdateModel objEmployee)
		{
			try
			{

				EmployeeRepository EmployeeRepo2 = new EmployeeRepository();
				ViewBag.LevelList = new SelectList(EmployeeRepo2.GetAllLevels(), "level_id", "level_name");

				EmployeeRepository EmployeeRepo = new EmployeeRepository();
				EmployeeRepo.UpdateEmployee(objEmployee);

				TempData["UpdateMsg"] = "Employee details updated successfully";

				return View();

			}
			catch(Exception e)
			{
				return View(e.Message);
			}
		}

		// GET: Delete  Employee details by id      
		public ActionResult DeleteEmployee(int id)
		{
			try
			{
				EmployeeRepository EmployeeRepo = new EmployeeRepository();
				if (EmployeeRepo.DeleteEmployee(id))
				{
					TempData["DeleteMsg"] = "Employee details deleted successfully";

				}
				return RedirectToAction("GetAllEmployees");
			}
			catch (Exception e) 
			{
				return View(e.Message);
			}
		}
	}
}
