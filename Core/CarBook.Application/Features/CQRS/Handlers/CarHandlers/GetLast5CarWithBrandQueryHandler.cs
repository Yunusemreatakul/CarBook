using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetLast5CarWithBrandQueryHandler
    {
        private readonly ICarRepository _carRepository;

        public GetLast5CarWithBrandQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public List<GetLast5CarsWithBrandQueryResult> Handle()
        {
            var values = _carRepository.GetLast5CarsWithBrands();
            return values.Select(x => new GetLast5CarsWithBrandQueryResult
            {
                BrandName = x.Brand.Name,
                CarId = x.CarId,
                BrandId = x.BrandId,
                BigCarImageUrl = x.BigCarImageUrl,
                CoverImageUrl = x.CoverImageUrl,
                Fuel = x.Fuel,
                Km = x.Km,
                Luggage = x.Luggage,
                Model = x.Model,
                Seats = x.Seats,
                Transmission = x.Transmission,

            }).ToList();
        }
    }
}
