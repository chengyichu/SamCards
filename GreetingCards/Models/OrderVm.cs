using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreetingCards.Models
{
    public class OrderVm
    {
        public Order Order { get; set; }
        public CardInfo CardInfo { get; set; }
        public Recipient Recipient { get; set; }
    }
}