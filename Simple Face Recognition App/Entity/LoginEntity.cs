using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS.Entity
{
    public class LoginEntity
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public int Nivel { get; set; }

        public LoginEntity() { }
        public LoginEntity(string login)
        {
            Login = login;
        }
        public LoginEntity(int id, string name, int nivel)
        {
            Id = id;
            Login = name;
            Nivel = nivel;
        }
    }
}
