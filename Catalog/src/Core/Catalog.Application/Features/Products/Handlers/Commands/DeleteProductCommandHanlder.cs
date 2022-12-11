using AutoMapper;
using Catalog.Application.Exceptions;
using Catalog.Application.Features.Products.Requests.Commands;
using Catalog.Application.Persistence.Contracts;
using Catalog.Application.Utilities.Result.Contract;
using Catalog.Domain.Common;
using Catalog.Domain.Entities;
using Catalog.Persistance.Utilities.Result;
using MediatR;

namespace Catalog.Application.Features.Products.Handlers.Commands
{
    public class DeleteProductCommandHanlder : IRequestHandler<DeleteProductCommand, IResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public DeleteProductCommandHanlder(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var deleteToProduct = await _productRepository.GetAsync(x => x.Id == request.Id);

            if (deleteToProduct == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            deleteToProduct.Status = Status.Deleted;

            await _productRepository.UpdateAsync(deleteToProduct);

            return new SuccessResult($"Product with Id: {request.Id} is deleted.");
        }
    }
}
