using System.Collections.Generic;
using System.Threading;
using Coypu;
using NinjaPlus.Models;
using OpenQA.Selenium;

namespace NinjaPlus.Pages
{
    public class MoviePage
    {
        private readonly BrowserSession _browser;

        public MoviePage(BrowserSession browser)
        {
            _browser = browser;
        }
        public void Add()
        {
            _browser.FindCss(".movie-add").Click();
        }

        private void SelectStatus(string status)
        {
            _browser.FindCss("input[placeholder=Status]").Click();
            var option = _browser.FindCss("ul li span", text: status);
            option.Click();
            //_browser.Select("Disponível").From("status");
        }

        private void InputCast(List<string> Cast)
        {
            var element = _browser.FindCss("input[placeholder$=ator]");

            foreach(var actor in Cast)
            {
                element.SendKeys(actor);
                element.SendKeys(Keys.Tab);
                Thread.Sleep(500); // Thinking Time

            }
        }

        private void UploadCover(string cover)
        {
            var jsScript = "document.getElementById('upcover').classList.remove('el-upload__input');";
            _browser.ExecuteScript(jsScript);

            _browser.FindCss("#upcover").SendKeys(cover);
       
        }
        public void Save(MovieModel movie)
        {
            _browser.FindCss("input[name=title]").SendKeys(movie.Title);
            SelectStatus(movie.Status);
            _browser.FindCss("input[name=year]").SendKeys(movie.Year.ToString());
            _browser.FindCss("input[name=release_date]").SendKeys(movie.ReleaseDate);
            InputCast(movie.Cast);
            _browser.FindCss("textarea[name=overview]").SendKeys(movie.Plot);
            UploadCover(movie.Cover);
            
       }
    }
}