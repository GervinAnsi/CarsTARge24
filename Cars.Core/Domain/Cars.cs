using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Core.Domain
{
    public class Cars
    {
        public Guid? Id { get; set; }
        public string? Brand {  get; set; }
        public string? Model { get; set; }
        public string? FuelType { get; set; }
        public int? Power { get; set; }
        public string? Drivetrain { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get;set; }
    }
}
