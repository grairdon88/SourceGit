using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloDocker.Domain.AggregateRoot;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HelloDocker.Controllers {
    [ApiController]
    public class OrdersController : ControllerBase{
        private IOrderRepository _orderRepository;
        public OrdersController(IOrderRepository orderRepository){
            _orderRepository = orderRepository;
        }

        [HttpGet, Route("Orders/GetByOrderNumber/{orderNumber}")]
        public async Task<dynamic> GetByOrderNumber(string orderNumber){
            try{
                return Ok(await _orderRepository.GetByOrderNumberAsync(orderNumber, Dns.GetHostName()));
            }
            catch(Exception ex){
                return BadRequest(ex);
            }
        }

        [HttpPost, Route("Orders/CreateOrder")]
        public async Task<dynamic> CreateOrder(Order newOrder) {
            try {
                await _orderRepository.CreateOrder(newOrder, Dns.GetHostName());
                return Ok();
            }
            catch (Exception ex) {
                return BadRequest(ex);
            }
        }

    }
}