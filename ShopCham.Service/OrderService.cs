using ShopCham.Data.Infrastructure;
using ShopCham.Data.Repositories;
using ShopCham.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCham.Service
{
    public interface IOrderService
    {
        Order Create(ref Order order, List<OrderDetail> oderDetails);
        void Save();
    }

    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        private IOrderDetailRepository _orderDetailRepository;
        private IUnitOfWork _unitOfWork;

        public OrderService(IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository,
            IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _unitOfWork = unitOfWork;
        }

        public Order Create(ref Order order, List<OrderDetail> oderDetails)
        {
            try
            {
                _orderRepository.Add(order);
                _unitOfWork.Commit();

                foreach (var oderDetail in oderDetails)
                {
                    oderDetail.OrderID = order.ID;
                    _orderDetailRepository.Add(oderDetail);
                }

                return order;
            }
            catch (Exception)
            {

                throw;
            }            
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
