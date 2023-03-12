using Medical_laboratory.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_laboratory
{
    class CurrentList
    {
        public static User user;
        public static Employee employee;
        public static History history;
        public static List<Employee> employees = new List<Employee>();
        public static List<Service> services = new List<Service>();
        public static List<Result> results = new List<Result>();
        public static List<User> users = new List<User>();
        public static _43pBaseForMedicalLaboratoryZelentsovContext db = new _43pBaseForMedicalLaboratoryZelentsovContext();
    }
}
