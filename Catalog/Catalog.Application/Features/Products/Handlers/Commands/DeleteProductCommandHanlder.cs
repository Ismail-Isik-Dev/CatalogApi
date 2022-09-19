using AutoMapper;
using Catalog.Application.Features.Products.Requests.Commands;
using Catalog.Application.Persistence.Contracts;
using Catalog.Domain.Common;
using MediatR;

namespace Catalog.Application.Features.Products.Handlers.Commands
{
    public class DeleteProductCommandHanlder : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public DeleteProductCommandHanlder(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var deleteToProduct = await _productRepository.GetAsync(x => x.Id == request.Id);

            if (deleteToProduct == null)
            {
                throw new Exception("Product not found!");
            }

            deleteToProduct.Status = Status.Active;

            await _productRepository.UpdateAsync(deleteToProduct);

            return Unit.Value;
        }
    }
}
