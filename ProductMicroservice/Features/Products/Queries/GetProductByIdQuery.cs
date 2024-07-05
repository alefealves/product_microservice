using MediatR;
using ProductMicroservice.Models;

namespace ProductMicroservice.Features.Products.Queries
{
  public class GetProductByIdQuery : IRequest<Product>
  {
    public int Id { get; set; }

    public GetProductByIdQuery(int id)
    {
      Id = id;
    }
  }
}
