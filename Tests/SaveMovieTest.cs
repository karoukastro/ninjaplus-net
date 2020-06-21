using NinjaPlus.Common;
using NUnit.Framework;
using NinjaPlus.Pages;
using System.Threading;
using NinjaPlus.Models;
using System;

namespace NinjaPlus.Tests
{
    public class SaveMovieTest : BaseTest
    {
        private LoginPage _login;
        private MoviePage _movie;

        [SetUp]
        public void Before()
        {
            _login = new LoginPage(Browser);
            _movie = new MoviePage(Browser);
            _login.With("root@carol.com", "pwd123");
        }

        [Test]
        
        public void ShouldSaveMovie()
        {
            var movieData = new MovieModel()
            {
                Title = "Resident Evil",
                Status = "Disponível",
                Year = 2002,
                ReleaseDate = "01/05/2002",
                Cast = {"Milla Jovovich", "Ali Larter", "Ian Glen", "Shawn Roberts"},
                Plot = "A missao do esquadrao......",
                Cover = CoverPath() + "resident-evil-poster-2002.jpg"
            };

            _movie.Add();
            _movie.Save(movieData);
            Thread.Sleep(5000);
        }
    }
}