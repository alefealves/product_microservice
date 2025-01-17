using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Context;
using ProductMicroservice.Models;


namespace ProductMicroservice.Features.Products.Queries
{
  public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
  {
    private readonly AppDbContext _context;

    public GetProductByIdQueryHandler(AppDbContext context)
    {
      _context = context;
    }

    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
      return await _context.Products
                           .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
    }
  }
}
