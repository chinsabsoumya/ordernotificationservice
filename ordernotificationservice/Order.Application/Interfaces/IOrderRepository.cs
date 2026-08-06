namespace Order.Application.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Order.Domain.Entities;

    public interface IOrderRepository
    {
        Task AddAsync(Order order);
        Task<List<Order>> GetAllAsync();  
     }
}
