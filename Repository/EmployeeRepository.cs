using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using HumanResourceApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Protocols;

namespace HumanResourceApp.Repository
{
	public class EmployeeRepository
	{
		//connection string variable
		public static string ConnString = "Data Source=OLUWATOBI;Initial Catalog=employeedb;Integrated Security=True";

		//adds an employee
        public void AddEmployee(AddModel Employee) 
		{
			using (IDbConnection db = new SqlConnection(ConnString))
			{
				db.Execute("uspAddEmployee", Employee, commandType: CommandType.StoredProcedure);
			}
		}

		//returns all employees
		public List<EmployeeModel> GetAllEmployees()
		{
			using (IDbConnection db = new SqlConnection(ConnString))
			{
				List<EmployeeModel> EmployeesList = db.Query<EmployeeModel>("uspGetAllEmployees").ToList();
				return EmployeesList;
			}
		}


		//updates an employee by id
		public void UpdateEmployee(UpdateModel EmployeeUpdate)
		{
			using (IDbConnection db = new SqlConnection(ConnString))
			{
				db.Execute("uspUpdateEmployeeById", EmployeeUpdate, commandType: CommandType.StoredProcedure);
			}

		}


		//deletes an employee
		public bool DeleteEmployee(int Id)
		{
			DynamicParameters param = new DynamicParameters();
			param.Add("@id_no", Id);
			using (IDbConnection db = new SqlConnection(ConnString))
			{
				db.Execute("uspDeleteEmployeeById", param, commandType: CommandType.StoredProcedure);
				return true;
			}
		}

		//gets employee levels from database
		public List<LevelModel> GetAllLevels()
		{
			using (IDbConnection db = new SqlConnection(ConnString))
			{
				List <LevelModel>  LevelList= db.Query<LevelModel>("uspGetAllLevels", commandType: CommandType.StoredProcedure).ToList();
				return LevelList;
			}
		}
	}
}
