﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CurilClever2.Models;
using Microsoft.AspNetCore.Authorization;
using CurilClever2.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CurilClever2.Controllers
{
  [Authorize]
  public class HomeController : Controller
  {
    private CleverDBContext db;

    public HomeController(CleverDBContext _db)
    {
      db = _db;
    }
    public IActionResult Index()
    {
      HomePageViewModel hpVM = new HomePageViewModel();
      hpVM.Clients = db.Clients.OrderByDescending(x=>x.id).Take(10);
      hpVM.Orders = db.Orders
                      .Include(x=>x.Hotel)
                      .Include(x=>x.Client)
                      .OrderByDescending(x=>x.CreationDate)
                      .Take(10);
      hpVM.Hotels = db.Hotels.OrderByDescending(x => x.id).Take(10);

      hpVM.ActiveOrders = from o in db.Orders
                          where o.PayStatus == PayStatus.Paid &&
                                o.BeginTravelDate <= DateTime.Now &&
                                o.EndTravelDate >= DateTime.Now
                          select o;

      return View(hpVM);
    }

    public IActionResult Clients()
    {
      return View();
    }

    public IActionResult Orders()
    {
      return View();
    }

    public IActionResult Login()
    {
      return View();
    }
    [AllowAnonymous]
    public IActionResult AccountInfo()
    {
      return PartialView();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
