using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyApp.models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public Nullable<int> Addressid { get; set; }
        public string Code { get; set; }

        public AddressModel Address { get; set; }   

   
    }
}
