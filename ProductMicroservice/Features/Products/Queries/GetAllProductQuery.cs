// Features/Products/Queries/GetAllProductsQuery.cs
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Context;
using ProductMicroservice.Models;

namespace ProductMicroservice.Features.Products.Queries
{
  public class GetAllProductsQuery : IRequest<IEnumerable<Product>> { }

  public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
  {
    private readonly AppDbContext _context;

    public GetAllProductsQueryHandler(AppDbContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
      return await _context.Products.ToListAsync(cancellationToken);
    }
  }
}
