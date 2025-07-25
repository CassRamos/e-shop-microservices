﻿namespace Catalog.API.Products.UpdateProduct
{
    public record UpdateProductRequest(
       Guid Id,
       string Name,
       List<string> Category,
       string Description,
       string ImageFile,
       decimal Price);

    public record UpdateProductResponse(bool IsSuccess);

    public class UpdateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/products",
                async (UpdateProductRequest request, ISender sender) =>
                {
                    var command = request.Adapt<UpdateProductCommand>();

                    var result = await sender.Send(command);

                    var response = result.Adapt<UpdateProductResponse>();

                    return Results.Ok(response);
                })
                    .WithName("UpdateProduct")
                    .Produces<UpdateProductResponse>(StatusCodes.Status200OK)
                    .ProducesProblem(StatusCodes.Status404NotFound)
                    .WithSummary("Update an existing product")
                    .WithDescription("Updates the details of an existing product in the catalog.");
        }
    }
}
