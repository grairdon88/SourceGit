using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ordering.Domain.AggregateRoot;

namespace Ordering.API.Controllers {
    [ApiController]
    public class OrdersController : ControllerBase {
        private IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository) {
            _orderRepository = orderRepository;
        }

        [HttpPost, Route("Orders/Add")]
        public IActionResult AddOrder([FromBody]Order order) {
            try {
                _orderRepository.Add(order);
                return Ok();
            }
            catch (Exception ex) {
                return BadRequest(ex);
            }
        }

        [HttpPost, Route("OrderDetails/{orderNumber}/Add")]
        public IActionResult AddOrder(string orderNumber, [FromBody]OrderDetail newOrderDetail) {
            try {
                _orderRepository.AddOrderDetail(orderNumber, newOrderDetail);
                return Ok();
            }
            catch (Exception ex) {
                return BadRequest(ex);
            }
        }

        [HttpGet, Route("Orders/GetByOrderNumber/{orderNumber}")]
        public IActionResult GetByOrderNumber(string orderNumber) {
            try {
                return Ok(_orderRepository.GetByOrderNumberAsync(orderNumber));
            }
            catch (Exception ex) {
                return BadRequest(ex);
            }
        }

        [HttpGet, Route("Orders/GetList")]
        public IActionResult GetList() {
            try {
                return Ok(_orderRepository.GetList());
            }
            catch (Exception ex) {
                return BadRequest(ex);
            }
        }

        [HttpDelete, Route("Orders/{orderNumber}")]
        public IActionResult DeleteOrder(string orderNumber) {
            try {
                _orderRepository.Delete(orderNumber);
                return Ok();
            }
            catch (Exception ex) {
                return BadRequest(ex);
            }
        }
    }
}