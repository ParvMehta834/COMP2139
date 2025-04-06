using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders.Include(o => o.OrderItems).ThenInclude(oi => oi.Product).ToListAsync();
            return View(orders);
        }

        // GET: Orders/Create
        public IActionResult CreateOrder()
        {
            ViewBag.Products = _context.Products.ToList();
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order, int[] productIds, int[] quantities)
        {
            if (ModelState.IsValid)
            {
                decimal totalPrice = 0;

                for (int i = 0; i < productIds.Length; i++)
                {
                    var product = await _context.Products.FindAsync(productIds[i]);
                    if (product != null)
                    {
                        var orderItem = new OrderItem
                        {
                            ProductId = productIds[i],
                            Quantity = quantities[i]
                        };
                        order.OrderItems.Add(orderItem);
                        totalPrice += product.Price * quantities[i];
                    }
                }

                order.TotalPrice = totalPrice;
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Products = _context.Products.ToList();
            return View(order);
        }
    }
}