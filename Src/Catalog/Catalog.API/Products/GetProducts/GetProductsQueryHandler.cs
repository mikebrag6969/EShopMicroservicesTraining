using BuildingBlocks.CQRS;
using Catalog.API.Models;
using Marten;
using Marten.Linq.QueryHandlers;

namespace Catalog.API.Products.GetProducts
{

    public record GetProductQuery (): IQuery<GetProductResult>;

    public record GetProductResult(IEnumerable<Product> products);


    public class GetProductsQueryHandler (IDocumentSession session) : IQueryHandler<GetProductQuery, GetProductResult>

    {
        public async Task<GetProductResult> Handle(GetProductQuery query, CancellationToken cancellationToken)
        {
            var products = await session.Query<Product>().ToListAsync(cancellationToken);
            return new GetProductResult(products);  


        }
    }
}
