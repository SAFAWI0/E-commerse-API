using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.Data;
using project.Models;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/v1/Order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET Test
        [HttpGet]
        [Route("gettest")]
        public IActionResult GetTest()
        {
            return Ok("Hi Safaa");
        }

        // Get All Orders
        [HttpGet]
        [Route("getallorder")]
        public IActionResult GetAllOrder()
        {
            var allOrder = _context.Orders.ToList();
            if (allOrder == null || !allOrder.Any())
            {
                return NotFound("No orders found!");
            }
            return Ok(allOrder);
        }

        // Get Order By Id
        [HttpGet]
        [Route("getorderbyid")]
        public IActionResult GetOrderById([FromQuery] int id)
        {
            var order = _context.Orders.FirstOrDefault(el => el.Id == id);
            if (order == null)
            {
                return NotFound("Order not found!");
            }
            return Ok(order);
        }

        // Post Add Order
        [HttpPost]
        [Route("addorder")]
        public IActionResult AddOrder([FromBody] OrderDTO orderDTO)
        {
            var order = new Order
            {
                FullName = orderDTO.FullName,
                Phone = orderDTO.Phone,
                City = orderDTO.City,
                Street = orderDTO.Street,
                Note = orderDTO.Note,
            };

            _context.Orders.Add(order); 
            _context.SaveChanges();

            var result = new
            {
                Message = "Order created successfully!",
                Order = order,
            };
            return Ok(result);
        }

        // Delete Order
        [HttpDelete]
        [Route("deleteorder")]
        public IActionResult DeleteOrder(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid order ID.");
            }
            var order = _context.Orders.FirstOrDefault(el => el.Id == id);
            if (order == null)
            {
                return NotFound("Order with the given ID does not exist.");
            }
            _context.Orders.Remove(order);
            _context.SaveChanges();
            var result = new
            {
                Message = "Order deleted successfully!",
                Order = order,
            };
            return Ok(result);
        }

        // Put Update Order
        [HttpPut]
        [Route("updateorder")]
        public IActionResult UpdateOrder(int id, [FromBody] OrderDTO orderDTO)
        {
            var order = _context.Orders.FirstOrDefault(el => el.Id == id);
            if (order == null)
            {
                return NotFound("Order not found!");
            }
            order.FullName = orderDTO.FullName;
            order.Phone = orderDTO.Phone;
            order.City = orderDTO.City;
            order.Street = orderDTO.Street;
            order.Note = orderDTO.Note;

            _context.Orders.Update(order);
            _context.SaveChanges();
            var result = new
            {
                Message = "Order updated successfully!",
                Order = order,
            };
            return Ok(result);
        }
    }
}
