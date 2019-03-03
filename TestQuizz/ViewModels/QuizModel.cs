using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestQuizz.ViewModels
{
    public class QuizModel
    {
        [Required(ErrorMessage = "Не указаны входные данные")]
        [Range(0, int.MaxValue, ErrorMessage = "Пожалуйста введите только целые числа")]
        public int InputVal { get; set; }


    }
}
