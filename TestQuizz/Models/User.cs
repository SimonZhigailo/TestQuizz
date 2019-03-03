using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestQuizz.Models
{
    public class User
    {
        public User()
        {
            Quizes = new List<Quiz>();
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string InternalAccess { get; set; }
        public DateTime LastLogin { get; set; }
        public ICollection<Quiz> Quizes { get; set; }


        [NotMapped]
        private bool[] _access;
        [NotMapped]
        public bool[] Access
        {
            get
            {
                return Array.ConvertAll(InternalAccess.Split(';'), Boolean.Parse);
            }
            set
            {
                _access = value;
                InternalAccess = String.Join(";", _access.Select(p => p.ToString()).ToArray());
            }
        }
    }
}
