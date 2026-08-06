namespace Order.Infrastructure.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using Order.Application.Interfaces;
    using Order.Domain.Entities;
    using Order.Infrastructure.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _dbContext;
        public OrderRepository(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Order order)
        {
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _dbContext.Orders.ToListAsync();
        }
    }
}
