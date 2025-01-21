using Application.Interfaces;
using Domain.DomainModels;
using MediatR;

namespace Application.Commands
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand>
    {
        private readonly IItemRepository _itemRepository;

        public CreateItemCommandHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var item = new Item { Id = request.Id, Name = request.Name };  // mapping dto to domain

            await _itemRepository.AddItem(item).ConfigureAwait(false);
        }
    }
}
