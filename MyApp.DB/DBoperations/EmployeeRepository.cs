﻿using System;
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
                    Email = model.Email,
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


        public List<EmployeeModel> GetAllEmployees()
        {
            using (var context = new EmployeeDBEntities())
            {
                var result = context.Employee.Select(x => new EmployeeModel()
                {
                    Id = x.Id,
                    Fname = x.Fname,
                    Lname = x.Lname,
                    Email = x.Email,
                    Code = x.Code,
                    Addressid = x.Addressid,
                    Address = new AddressModel()
                    {
                        Id =  x.Address.Id,
                        Details = x.Address.Details,
                        Country = x.Address.Country,
                        State = x.Address.State
                    }
                }
                 ).DefaultIfEmpty().ToList() ;
                return result;
            }

        }
        public EmployeeModel GetEmployee(int id)
        {
            using (var context = new EmployeeDBEntities())
            {
                var result = context.Employee
                    .Where(x=> x.Id == id)
                    .Select(x => new EmployeeModel()
                {
                    Id = x.Id,
                    Fname = x.Fname,
                    Lname = x.Lname,
                    Email = x.Email,
                    Code = x.Code,
                    Addressid = x.Addressid,
                    Address = new AddressModel()
                    {
                        Id = x.Address.Id,
                        Details = x.Address.Details,
                        Country = x.Address.Country,
                        State = x.Address.State
                    }
                }
                 ).FirstOrDefault();
                return result;
            }

        }

        public bool UpdateEmployee(int id, EmployeeModel model)
        {
            using (var context = new EmployeeDBEntities())
            {
                var employee = context.Employee.FirstOrDefault(x => x.Id == id);

                    if (employee != null)
                {
                    employee.Fname = model.Fname;
                        employee.Lname = model.Lname;
                        employee.Email = model.Email;
                    employee.Code = model.Code;
                    //employee.Address = new Address()
                    //{
                    //    = model.Address.Details
                    //};

                }
                    context.SaveChanges();
                return true;
            }
        }

        public bool DeleteEmployee(int id)
        {
            using (var context = new EmployeeDBEntities())
            {
                var employee = context.Employee.FirstOrDefault(x => x.Id == id);
                if(employee != null)
                {
                    var address = context.Address.FirstOrDefault(x => x.Id == employee.Addressid);

                    context.Employee.Remove(employee);
                    context.Address.Remove(address);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
