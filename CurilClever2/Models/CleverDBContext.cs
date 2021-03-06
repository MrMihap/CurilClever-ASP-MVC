﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurilClever2.Models
{
  public class CleverDBContext : DbContext
  {
    public DbSet<User> Users { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Order> Orders { get; set; }
    //public DbSet<Comment> Comments { get; set; }
    public DbSet<OrderComment> OrderComments { get; set; }
    public DbSet<ClientComment> ClientComments { get; set; }
    public DbSet<CaptureModel> CaptureModels { get; set; }

    public CleverDBContext(DbContextOptions<CleverDBContext> options)
           : base(options)
    {
      Database.EnsureCreated();
    }
  }
}
