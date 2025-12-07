using BuildingBlocks.CQRS;
using Catalog.API.Exceptions;
using Catalog.API.Models;
using Catalog.API.Products.GetProducts;
using Marten;
using Marten.Linq.QueryHandlers;

namespace Catalog.API.Products.GetProductById
{

    public record GetProductByIdQuery(Guid  Id) :IQuery<GetProductByIdResult>;
    public record GetProductByIdResult(Product Product);
    internal class GetProductByIdHandler(IDocumentSession session) : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(query.Id, cancellationToken);
            if (product == null)
            {
                throw new ProductNotFoundException();

            }
            return new GetProductByIdResult(product);   
        }
    }
}
