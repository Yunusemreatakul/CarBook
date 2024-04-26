using CarBook.Application.Features.CQRS.Queries.CarQueries;
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
    public class GetCarByIdCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarByIdCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            return new GetCarByIdQueryResult
            {
                CarId = value.CarId,
                BigCarImageUrl = value.BigCarImageUrl,
                BrandId  = value.BrandId,
                CoverImageUrl = value.CoverImageUrl,
                Fuel = value.Fuel,
                Km = value.Km,
                Luggage = value.Luggage,
                Model = value.Model,
                Seats = value.Seats,
                Transmission = value.Transmission
               
            };
        }
    }
}
