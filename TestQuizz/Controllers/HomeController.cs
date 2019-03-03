using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestQuizz.Models;
using TestQuizz.Models.AuthApp.Models;
using TestQuizz.StaticHelper;
using TestQuizz.ViewModels;

namespace TestQuizz.Controllers
{
    public class HomeController : Controller
    {
        private UserContext db;
        public HomeController(UserContext context)
        {
            db = context;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> History()
        {
            List<User> users = await Task.Run(() => db.Users.Include(p => p.Quizes).ToList());
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> Quiz1(string quizInput)
        {
            try
            {
                int input;
                if (int.TryParse(quizInput, out input) && Enumerable.Range(0, 2048).Contains(input))
                {
                    var result = await Task.Run(() => Convert.ToString(input, 2));

                    await SaveQuiz(1, quizInput, result.ToString());

                    return Ok(result);
                }
                else
                {
                    return Conflict("Значение должно быть целочисленным в диапозоне 0...2048");
                }
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }


        }

        [HttpPost]
        public async Task<IActionResult> Quiz2(string quizInput)
        {
            try
            {
                int input;
                if (int.TryParse(quizInput, out input) && Enumerable.Range(0, 2048).Contains(input))
                {
                    var result = await Task.Run(() => Convert.ToString(input, 16));
                    await SaveQuiz(2, quizInput, result.ToString());
                    return Ok(result);
                }
                else
                {
                    return Conflict("Значение должно быть целочисленным в диапозоне 0...2048");
                }
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }


        }

        [HttpPost]
        public async Task<IActionResult> Quiz3(string quizInput)
        {
            try
            {
                int input;
                if (int.TryParse(quizInput, out input) && Enumerable.Range(1, 2048).Contains(input))
                {
                    var res = new int[input];
                    Random randNum = new Random();
                    for (int i = 0; i < res.Length; i++)
                    {
                        res[i] = randNum.Next(0, 2048);
                    }

                    var result = await Task.Run(() => Helper.SortAndCountArray(res).ToString());
                    await SaveQuiz(3, quizInput, result.ToString());
                    return Ok(result);
                }
                else
                {
                    return Conflict("Значение должно быть целочисленным в диапозоне 1...2048");
                }
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Quiz4(string quizInput)
        {
            try
            {
                int input;
                if (int.TryParse(quizInput, out input) && Enumerable.Range(1, 2048).Contains(input))
                {
                    var result = await Task.Run(() => Helper.CreateAndMultiplyFibonacci(input).ToString());
                    await SaveQuiz(4, quizInput, result.ToString());
                    return Ok(result);
                }
                else
                {
                    return Conflict("Значение должно быть целочисленным в диапозоне 1...30");
                }
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Quiz5(string quizInput)
        {
            try
            {
                if (!quizInput.Contains(' ') && !String.IsNullOrEmpty(quizInput) && quizInput.Contains('/'))
                {
                    string[] words = quizInput.Split(new char[] { '/' });
                    User user = await db.Users.FirstOrDefaultAsync(u => u.UserName == words[0]);
                    if (user == null)
                    {
                        db.Users.Add(new User { UserName = words[0], Password = words[1], Access = new bool[7] });
                        await db.SaveChangesAsync();
                        var result = words[1].Length.ToString();
                        await SaveQuiz(5, quizInput, result.ToString());
                        return Ok(result);
                    }
                    else
                    {
                        return Conflict("Пользователь уже существует");
                    }
                }
                else
                {
                    return Conflict("Значение должно быть в формате login/password без пробелов");
                }
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }

        }

        //Вот вообще не понял задания, это просто работа со строкой? поиск в бд и сравнение прав доступа?

        [HttpPost]
        public async Task<IActionResult> Quiz6(string quizInput)
        {
            try
            {
                string searchKey = "";
                var users = db.Users.ToList();
                char[] rights;
                string output;
                var matchedUser = new User();

                foreach (char ch in quizInput)
                {
                    searchKey += ch;

                    foreach (User user in users)
                    {
                        if (user.UserName.Contains(searchKey))
                        {
                            matchedUser = user;
                        }
                    }
                }
                if (matchedUser != null)
                {
                    rights = quizInput.Replace(matchedUser.UserName, "").ToCharArray();
                    output = matchedUser.UserName + "/";
                    foreach (var r in rights)
                    {
                        output += r + ";";
                    }

                    await SaveQuiz(6, quizInput, rights.Length.ToString());

                    return Ok(rights.Length.ToString());
                }

                else
                {
                    return Conflict("Пользователь не найден");
                }

            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        public async Task<IActionResult> Quiz7(string quizInput)
        {
            try
            {
                string input = quizInput;
                if (!String.IsNullOrEmpty(input.Trim()))
                {
                    var result = await Task.Run(() => Helper.Reverse(quizInput));
                    await SaveQuiz(7, quizInput, result.ToString());

                    return Ok(result);
                }
                else
                {
                    return Conflict("Строка не найдена");
                }
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        public async Task SaveQuiz(int taskNum, string input, string output)
        {
            User user = await db.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);
            if (user != null)
            {

                db.Quizes.Add(new Quiz
                {
                    Input = input,
                    Output = output,
                    TaskNumber = taskNum,
                    Time = DateTime.Now,
                    UserId = user.Id,
                    User = null
                });
                await db.SaveChangesAsync();
            }
            else
            {
                throw new Exception();
            }
        }
    }
}