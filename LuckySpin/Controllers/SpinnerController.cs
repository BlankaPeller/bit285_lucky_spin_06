using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LuckySpin.Models;
using LuckySpin.ViewModels;
using LuckySpin.Services;
using System.Globalization;

namespace LuckySpin.Controllers
{
    public class SpinnerController : Controller
    {
        private RepositoryService repoService;

        /***
         *  Constructor -  with RepositoryService DIJ
         **/
        public SpinnerController(RepositoryService repoService)
        {
            this.repoService = repoService;
        }

        /***
         * Index Action
         **/
        [HttpGet]
        public IActionResult Index()
        {
                return View(); //Sends the empty Index form
        }
        
        [HttpPost]
        public IActionResult Index(Player player, IndexViewModel IndexViewModel) //TODO: Update Index() to receive form data as IndexViewModel
        {
            if (!ModelState.IsValid) { return View(); } //Check for missing data

            //TODO: Complete adding Player data to store in the repoService
            repoService.Player = new Player
            {
                PlayerId = player.PlayerId,
                FirstName = player.FirstName,
                Luck = player.Luck,
                StartingBalance = (int)player.StartingBalance,
            };

            return RedirectToAction("Spin");
        }

        /***
         * Spin Action
         **/  
               
        public IActionResult Spin() //Start a Spin WITHOUT data
        {
            //CHARGE 
            // TODO: Load Player balance from the repoService

            //TODO: Charge $0.50 to spin
            repoService.Player.StartingBalance -= 0.50m;
            decimal balance = repoService.Player.StartingBalance;


            //SPIN
            //TODO: Complete adding data to a new SpinViewModel to gather items for the View
            SpinViewModel spinVM = new SpinViewModel
            {
                CurrentBalance = string.Format(new CultureInfo("en-SG", false), "{0:C2}", balance),
                PlayerName = repoService.Player.FirstName,
                PlayerLuck = repoService.Player.Luck,

            };

            //GAMEPLAY
            //TODO: Check the Balance to see if the game is over
            if (balance < 0.50m)
            {
                return RedirectToAction("LuckList");
            }

            //TODO: Pay $1.00 if Winning

            if (spinVM.IsWinning)
            {
                repoService.Player.StartingBalance += 1.00m;
                spinVM.CurrentBalance = string.Format(new CultureInfo("en-SG", false), "{0:C2}", repoService.Player.StartingBalance);
            }
            //UPDATE DATA STORE
            //TODO: Save balance to repoService
            Spin spin = new Spin
            {
                Player = repoService.Player,
                IsWinning = spinVM.IsWinning
            };
            repoService.AddSpin(spin);

            //TODO: Use the repoService to add a spin to the repository


            return View("Spin", spinVM);
        }

        //TODO: BONUS:  the LuckList
        /***
         * LuckList Action
         **/
        [HttpGet]
        public IActionResult LuckList()
        {
            return new ContentResult { Content = "<h1>Luck's Run Out</h1>", ContentType = "text/html" };
        }

    }
}

