﻿using ARTech.Server.Data;
using ARTech.Server.IRepository;
using ARTech.Server.Models;
using ARTech.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ARTech.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Logistic> _logistics;
        private IGenericRepository<Order> _orders;
        private IGenericRepository<OrderItem> _orderitems;
        private IGenericRepository<Payment> _payments;
        private IGenericRepository<Customer> _customers;
        private IGenericRepository<Product> _products;
        private IGenericRepository<Staff> _staffs;

        private UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IGenericRepository<Logistic> Logistics
            => _logistics ??= new GenericRepository<Logistic>(_context);
        public IGenericRepository<Order> Orders
            => _orders ??= new GenericRepository<Order>(_context);
        public IGenericRepository<OrderItem> OrderItems
            => _orderitems ??= new GenericRepository<OrderItem>(_context);
        public IGenericRepository<Payment> Payments
            => _payments ??= new GenericRepository<Payment>(_context);
        public IGenericRepository<Product> Products
            => _products ??= new GenericRepository<Product>(_context);
        public IGenericRepository<Customer> Customers
            => _customers ??= new GenericRepository<Customer>(_context);
        public IGenericRepository<Staff> Staffs
            => _staffs ??= new GenericRepository<Staff>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(HttpContext httpContext)
        {
            //To be implemented
            //string user = "System";

            var entries = _context.ChangeTracker.Entries()
                .Where(q => q.State == EntityState.Modified ||
                    q.State == EntityState.Added);

            //foreach (var entry in entries)
            //{
            //    ((BaseDomainModel)entry.Entity).DateUpdated = DateTime.Now;
            //    ((BaseDomainModel)entry.Entity).UpdatedBy = user;
            //    if (entry.State == EntityState.Added)
            //   {
            //        ((BaseDomainModel)entry.Entity).DateCreated = DateTime.Now;
            //        ((BaseDomainModel)entry.Entity).CreatedBy = user;
            //    }
            //}

            await _context.SaveChangesAsync();
        }
    }
}