using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi_AB_Solutions_jr.Models;

namespace WebApi_AB_Solutions_jr.Controllers
{
    public class EmployeesController : ApiController
    {
        private Prueba_ab_pos_solutions_josueromeroEntities db = new Prueba_ab_pos_solutions_josueromeroEntities();

        // GET: api/Employees
        // GET: api/Employees
        public List<ClaseReporte> GetEmployees()
        {
            var Empleados = db.Employees.ToList();
            var ListaEspecifica = (from e in Empleados
                                   select new ClaseReporte()
                                   { ID = e.EmployeeID, Name = e.EmployeeName, PositionName = e.Position.PositionName, ProfileName = e.Profile.ProfileName }).ToList();

            return ListaEspecifica;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeExists(int id)
        {
            return db.Employees.Count(e => e.EmployeeID == id) > 0;
        }
    }
}