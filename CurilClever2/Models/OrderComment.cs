﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurilClever2.Models
{
  public class OrderComment
  {
    public int id { get; set; }

    public int CommetId { get; set; }
    public Comment Comment { get; set; }

    public int OrderId { get; set; }
    public Order Order { get; set; }
  }
}