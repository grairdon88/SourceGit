using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloDocker.Domain.AggregateRoot;
using Microsoft.AspNetCore.Mvc;

namespace HelloDocker.Controllers {
    [ApiController]
    public class OrdersController : ControllerBase{
        private IOrderRepository _orderRepository;
        public OrdersController(IOrderRepository orderRepository){
            _orderRepository = orderRepository;
        }

        public async Task<dynamic> GetByOrderNumber(string orderNumber){
            try{
                return Ok(await _orderRepository.GetByOrderNumber(orderNumber));
            }
            catch(Exception ex){
                return BadRequest(ex);
            }
        }

    }
}