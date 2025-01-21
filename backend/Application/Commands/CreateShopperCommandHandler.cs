﻿using Application.Interfaces;
using Domain.DomainModels;
using MediatR;

namespace Application.Commands
{
    public class CreateShopperCommandHandler : IRequestHandler<CreateShopperCommand>
    {
        private readonly IShopperRepository _shopperRepository;

        public CreateShopperCommandHandler(IShopperRepository shopperRepository)
        {
            _shopperRepository = shopperRepository;
        }

        public async Task Handle(CreateShopperCommand request, CancellationToken cancellationToken)
        {
            var shopper = new Shopper { Id = request.Id, Name = request.Name };   // mapping dto to domain

            await _shopperRepository.AddShopper(shopper);
        }
    }
}
