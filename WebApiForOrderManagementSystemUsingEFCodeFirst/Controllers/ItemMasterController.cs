using Microsoft.AspNetCore.Mvc;
using WebApiForOrderManagementSystemUsingEFCodeFirst.Models;

namespace WebApiForOrderManagementSystemUsingEFCodeFirst.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ItemMasterController : ControllerBase
    {
       private ApiDbContext _context;
       public ItemMasterController(ApiDbContext context)
       {
            _context = context;
       }
        [HttpPost]
        public ActionResult AddItem([FromBody] ItemMaster item)
        {
          string status="Failed";
            if (item == null)
            {
                return Ok(status);
            }
            else
            {
                try
                {
                    _context.ItemMaster.Add(item);
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
        //[HttpGet("{email}")]
        //public bool IsExistEmail(string email)
        //{
        //    var status = _context.CustomerMaster.Where(cus => cus.EmailAddress == email).FirstOrDefault();
        //    if (status != null)
        //    {
        //        return true;
        //    }
        //    return false;


        //}
        [HttpDelete("{Name}")]
        public ActionResult DeleteItem(string Name)
        {
            string? status = "Failed";
            try
            {
                var deleteItem=_context.ItemMaster.Where(x => x.Name == Name).FirstOrDefault(); 
                if (deleteItem != null)
                {
                    _context.ItemMaster.Remove(deleteItem);
                    _context.SaveChanges();
                    status = "Success";
                }
                else
                {
                    status = "Failed";
                }

            }
            catch
            {
                status = "Failed";
            }
            return Ok(status);
        }
        [HttpPut("{Name}")]
        public ActionResult UpdateItem(string Name,ItemMaster updateItem)
        {
            string status = "Failed";
            try
            {
                var updateItemFind = _context.ItemMaster.Where(item => item.Name == Name).FirstOrDefault();
                if(updateItemFind != null)
                {
                    updateItemFind.Price=updateItem.Price;
                    updateItemFind.Quantity=updateItem.Quantity;
                    updateItemFind.Name=updateItem.Name;
                    
                    _context.ItemMaster.Update(updateItemFind);
                    _context.SaveChanges();
                    status = "Success";
                }
                else
                {
                    status = "failed";

                }


            }
            catch
            {
                status = "failed";

            }



            return Ok(status);  
        }
        [HttpGet]
        public ActionResult GetItemList()
        {
            var items = _context.ItemMaster.ToList();
            return Ok(items);
        }
        [HttpGet("{Id}")]
        public ActionResult GetItemById(int Id)
        {
            var item = _context.ItemMaster.FirstOrDefault(item => item.Id == Id);
            if(item != null)
            {
                return Ok(item);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPatch("{Id}")]
        public ActionResult ChangePriceQuantity(int Id,int price,int quantity)
        {
            string status = "Failed";
            var change=_context.ItemMaster.FirstOrDefault(item=>item.Id==Id);
            try
            {
                if (change != null)
                {
                    change.Price = price;
                    change.Quantity = quantity;
                    _context.ItemMaster.Update(change);
                    _context.SaveChanges();
                    status = "Success";
                }
                else
                {
                    status = "Failed";
                }
            }
            catch
            {
                status = "failed";
            }
            return Ok(status);
        }
        [HttpGet]
        public ActionResult IsItemExist(string name)
        {
            string status = "No";
            var IsExist=_context.ItemMaster.Where(n=>n.Name==name).FirstOrDefault();  
            if (IsExist != null)
            {
                status = "Yes";
            }
            else
            {
                status = "No";
            }
            return Ok(status);
        }
        
    }
}