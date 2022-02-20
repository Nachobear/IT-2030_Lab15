using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlackJack.Models;

namespace BlackJack.Components
{
    public class HandDisplay : ViewComponent
    {
        public IViewComponentResult Invoke(Hand hand) => View(hand);
    }
}
