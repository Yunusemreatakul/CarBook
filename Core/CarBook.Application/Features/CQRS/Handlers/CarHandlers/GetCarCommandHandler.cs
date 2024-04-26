using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetCarQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetCarQueryResult { 
                CarId= x.CarId,
                BrandId= x.BrandId,
                BigCarImageUrl= x.BigCarImageUrl,
                CoverImageUrl= x.CoverImageUrl,
                Fuel=x.Fuel,
                Km =x.Km,
                Luggage=x.Luggage,
                Model=x.Model,
                Seats=x.Seats,
                Transmission = x.Transmission
            
            }).ToList();
        }
    }
}
