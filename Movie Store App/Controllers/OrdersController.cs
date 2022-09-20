using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Movie_Store_App.Data;
using Movie_Store_App.Models;
using Newtonsoft.Json.Linq;
using static NuGet.Packaging.PackagingConstants;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Store_App.Controllers
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
              return View(await _context.Orders.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }



            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public async Task<IActionResult> Create(int? id)
        {
            var movie = await _context.Movies.FindAsync(id);
            return View(movie);
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Create(int movieId, [Bind("CustomerId,OrderDate")] Order order)
        {
            var customer = JsonConvert.DeserializeObject<Customer>(HttpContext.Session.GetString("CustomerIdSession"));
            order.CustomerId = customer.Id;
            order.OrderDate = DateTime.Now;
            
            _context.Add(order);
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(myorder), new { action = "myorders", Id = order.Id });
        }

        public async Task<IActionResult> myorder( int Id , [Bind("OrderId,MovieId,Price")] OrderRow orderRow)
        {
            var customer = JsonConvert.DeserializeObject<Customer>(HttpContext.Session.GetString("CustomerIdSession"));
            var customerId = customer.Id;
            var order = await _context.Orders.FindAsync(Id);
            //orderRow.MovieId = Id;
            orderRow.OrderId = order.Id;

            var movie = await _context.Movies.FindAsync(Id);
            orderRow.Price = movie.Pirce;

            int quantity = 1;
            List<OrderRow> cart = new List<OrderRow>();

            if (cart.Contains(orderRow))
            {
                quantity++;
                orderRow.Price = quantity * orderRow.Price;
                cart.Add(orderRow);
            }
            _context.Add(orderRow);
            await _context.SaveChangesAsync();
            
            return View(Index);
        }

      
        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerId,OrderDate")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orders == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Orders'  is null.");
            }
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
          return _context.Orders.Any(e => e.Id == id);
        }
    }
}
