using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cars.Core.ServiceInterface;
using Cars.Data;

namespace Cars.ApplicationServices.Services
{
    public class CarServices : ICarServices
    {
        private readonly CarsTARge24Context _context;
    }
}
