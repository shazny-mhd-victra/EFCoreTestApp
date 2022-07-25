using System;
using System.Collections.Generic;

namespace DAL.Db.Entities
{
    public partial class TblCustomer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Status { get; set; }
    }
}
