using Catalog.API.Models;
using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.GetProducts
{
    public class GetProductsEndpoint
    {


        public record GetProductRequest();


        public record GetProductResponse(IEnumerable<Product> Products);

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/products", async (ISender sender) =>
            {

                var result = await sender.Send(new GetProductQuery());
                var response = result.Adapt<GetProductResponse>();
                 return Results.Ok(response);



            });
        }
    }
}
