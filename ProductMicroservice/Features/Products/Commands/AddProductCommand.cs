// Features/Products/Commands/AddProductCommand.cs
using MediatR;
using ProductMicroservice.Context;
using ProductMicroservice.Models;

namespace ProductMicroservice.Features.Products.Commands
{
  public class AddProductCommand : IRequest<int>
  {
    public string Name { get; set; }
    public decimal Price { get; set; }
  }

  public class AddProductCommandHandler : IRequestHandler<AddProductCommand, int>
  {
    private readonly AppDbContext _context;

    public AddProductCommandHandler(AppDbContext context)
    {
      _context = context;
    }

    public async Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
      var product = new Product
      {
        Name = request.Name,
        Price = request.Price
      };

      _context.Products.Add(product);
      await _context.SaveChangesAsync(cancellationToken);

      return product.Id;
    }
  }
}
