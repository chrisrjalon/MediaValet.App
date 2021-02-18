using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaValet.OrderSupervisor.Business.DTOs;
using MediaValet.OrderSupervisor.Business.Logics;

namespace MediaValet.OrderSupervisor.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderBusiness _orderBusiness;

        public OrderController(IOrderBusiness orderBusiness)
        {
            _orderBusiness = orderBusiness;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string orderDetails)
        {
            var result = await _orderBusiness.AddOrder(orderDetails);

            return Ok(result);
        }
    }
}
