using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupperterList.DTOs
{
    public class SupporterManagementDTO
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public int Id { get; set; }
        public string Club { get; set; }
        public string Nation { get; set; }
        public string Age { get; set; }
    }
}