using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.CarCommands
{
    public class UpdateCarCommand
    {
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public string Km { get; set; }
        public string Transmission { get; set; }
        public string Seats { get; set; }
        public string Luggage { get; set; }
        public string Fuel { get; set; }
        public string BigCarImageUrl { get; set; }
    }
}
