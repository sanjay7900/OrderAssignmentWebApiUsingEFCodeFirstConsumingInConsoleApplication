using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiForOrderManagementSystemUsingEFCodeFirst;
using WebApiForOrderManagementSystemUsingEFCodeFirst.Models;

namespace WebApiForOrderManagementSystemUsingEFCodeFirst.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class CustomerMastersController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public CustomerMastersController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerMaster>>> GetCustomerMaster()
        {
            if (_context.CustomerMaster == null)
            {
                return NotFound();
            }
            return await _context.CustomerMaster.ToListAsync();
        }

        // GET: api/CustomerMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerMaster>> GetCustomerMasterById(int id)
        {
            if (_context.CustomerMaster == null)
            {
                return NotFound();
            }
            var customerMaster = await _context.CustomerMaster.FindAsync(id);

            if (customerMaster == null)
            {
                return NotFound();
            }

            return customerMaster;
        }
        [HttpGet("{email}")]
        public bool GetCustomerByEmail(string email)
        {
            var customerMaster =  _context.CustomerMaster.Where(cus => cus.EmailAddress == email).FirstOrDefault();
            if(customerMaster == null)
            {
                return false;
            }
            else
            {
                return true;
            }

            //return false;

        }
        // PUT: api/CustomerMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{email}")]
        public ActionResult PutCustomerMaster(string email,[FromBody] CustomerMaster customerMaster)
        {
            var updateCustomer=_context.CustomerMaster.Where(c=>c.EmailAddress==email).FirstOrDefault();  
            updateCustomer.FirstName = customerMaster.FirstName;
            updateCustomer.LastName = customerMaster.LastName;
            updateCustomer.PhoneNumber=customerMaster.PhoneNumber;
            updateCustomer.EmailAddress=customerMaster.EmailAddress;    
            _context.CustomerMaster.Update(updateCustomer);

            try
            {
                 _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GetCustomerByEmail(email))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CustomerMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult PostCustomerMaster([FromBody] CustomerMaster customerMaster)
        {
            string status = "Failed";
            if (customerMaster == null)
            {
                return Ok(status);
            }
            else
            {
                try
                {
                    _context.CustomerMaster.Add(customerMaster);
                    _context.SaveChanges();
                    status = "Success";
                }
                catch
                {
                    status = "Failed";

                }

            }
            return Ok(status);
        }

        // DELETE: api/CustomerMasters/5
        [HttpDelete("{email}")]
        public async Task<IActionResult> DeleteCustomerMaster(string email)
        {
            if (_context.CustomerMaster == null)
            {
                return NotFound();
            }
            var customerMaster = await _context.CustomerMaster.FirstOrDefaultAsync(cus=>cus.EmailAddress==email);
            if (customerMaster == null)
            {
                return NotFound();
            }

            _context.CustomerMaster.Remove(customerMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerMasterExists(int id)
        {
            return (_context.CustomerMaster?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
