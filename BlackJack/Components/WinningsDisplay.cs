using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlackJack.Models;

namespace BlackJack.Components
{
    public class WinningsDisplay : ViewComponent
    {
        private IGame game { get; set; }

        public WinningsDisplay(IGame g) => this.game = g;

        public IViewComponentResult Invoke() => View(game.Player.TotalWinnings);
    }
}
