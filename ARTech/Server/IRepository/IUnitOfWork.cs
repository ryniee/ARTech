using ARTech.Shared.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARTech.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Logistic> Logistics { get; }
        IGenericRepository<OrderSummary> OrderSummarys { get; }
        IGenericRepository<OrderItem> OrderItems { get; }
        IGenericRepository<Payment> Payments { get; }
        IGenericRepository<Product> Products { get; }
        IGenericRepository<Customer> Customers { get; }
        IGenericRepository<Staff> Staffs { get; }
    }
}