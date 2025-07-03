namespace Catalog.API.Products.GetProductById
{
    public record GetPorductByIdResponse(Product product);

    public class GetProductByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{id}", async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByIdQuery(id));

                var response = result.Adapt<GetPorductByIdResponse>();

                return Results.Ok(response);
            })
                .WithName("GetProductById")
                .Produces<GetPorductByIdResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Get Product By Id")
                .WithDescription("Get a product by its unique identifier.");
        }
    }
}
