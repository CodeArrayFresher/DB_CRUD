using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.models;
namespace MyApp.DB.DBoperations
{
    public class EmployeeRepository
    {
        public int AddEmployee(EmployeeModel model)
        {
            using (var context = new EmployeeDBEntities())
            {
                Employee emp = new Employee()
                {
                    Fname = model.Fname,
                    Lname = model.Lname,
                    Email   = model.Email,
                    Code = model.Code
                };

                if (model.Address != null)
                {
                    emp.Address = new Address()
                    {
                        Details = model.Address.Details,
                        State = model.Address.State,
                        Country = model.Address.Country
                    };
                }

                context.Employee.Add(emp);
                context.SaveChanges();
                return emp.Id;
            }
        }
    }
}
