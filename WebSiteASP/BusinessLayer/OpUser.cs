using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSiteASP.DataLayer;

namespace WebSiteASP.BusinessLayer
{
    public class UserDb : DbItem
    {
        public int IdUser { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int idRole { get; set; }
        public DateTime timeOfRegistration { get; set; }
        public int idStatus { get; set; }
        public int? IdUserLastChange { get; set; }
        public DateTime? LastTimeChanged { get; set; }

        public string makeVerificationCode(int size = 20)
        {
            Random rand = new Random();

            string Alphabet = "abcdefghijklmnopqrstuvwyxz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
 
            char[] chars = new char[size];
            for (int i = 0; i < size; i++)
            {
                chars[i] = Alphabet[rand.Next(Alphabet.Length)];
            }

            return new string(chars);
        }
    }

    public class KriterijumUser : KriterijumZaSelekciju
    {
        public int? IdUser { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? Status { get; set; }
    }

    public class OpUserBase : Operacija
    {
        public KriterijumUser Kriterijum { get; set; }

        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            IEnumerable<UserDb> ieUser;

            if (Kriterijum != null)
            {
                ieUser = from user in entiteti.Users
                         where (
                         (Kriterijum.IdUser == null ? true : Kriterijum.IdUser == user.idUser) &&
                         (Kriterijum.Email == null ? true : Kriterijum.Email == user.email) &&
                         (Kriterijum.Status == null ? true : Kriterijum.Status == user.idStatus)
                         )
                         select new UserDb()
                         {
                             IdUser = user.idUser,
                             email = user.email,
                             firstName = user.firstName,
                             lastName = user.lastName,
                             idRole = user.idRole,
                             idStatus = user.idStatus,
                             password = user.password,
                             timeOfRegistration = user.timeOfRegistration
                         };
            }
            else
            {
                ieUser = from user in entiteti.Users
                         select new UserDb()
                         {
                             IdUser = user.idUser,
                             email = user.email,
                             firstName = user.firstName,
                             lastName = user.lastName,
                             idRole = user.idRole,
                             idStatus = user.idStatus,
                             password = user.password,
                             timeOfRegistration = user.timeOfRegistration
                         };
            }

            OperacijaRezultat rez = new OperacijaRezultat();
            rez.Status = true;
            rez.Poruka = "Select Users";
            rez.DbItems = ieUser.ToArray();
            rez.CheckDbItems();

            return rez;
        }
    }

    public class OpUserSelect : OpUserBase
    {
    }

    public class OpUserInsert : OpUserBase
    {
        public UserDb User { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            if(User != null)
                entiteti.spInsertUser(User.firstName, User.lastName, User.email, BCrypt.Net.BCrypt.HashPassword(User.password), User.makeVerificationCode(), User.idRole, User.idStatus);
            return base.izvrsi(entiteti);
        }
    }
    public class OpUserInsertOnly : OpUserBase
    {
        public UserDb User { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            if (User != null)
                entiteti.spInsertUser(User.firstName, User.lastName, User.email, BCrypt.Net.BCrypt.HashPassword(User.password), User.makeVerificationCode(), User.idRole, User.idStatus);
            OperacijaRezultat rez = new OperacijaRezultat() { HaveItems = false, Status = true};
            return rez;
        }
    }

    public class OpUserUpdate : OpUserBase
    {
        public UserDb User { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            if (User != null)
            {
                if(User.password != null)
                    entiteti.spUpdateUser(User.IdUser, User.firstName, User.lastName, User.email, BCrypt.Net.BCrypt.HashPassword(User.password), User.idRole, User.idStatus,User.IdUserLastChange);
                else
                    entiteti.spUpdateUserNoPassword(User.IdUser, User.firstName, User.lastName, User.email, User.idRole, User.idStatus, User.IdUserLastChange);

            }
            return base.izvrsi(entiteti);
        }
    }

    public class OpUserDelete : OpUserBase
    {
        public UserDb User { get; set; }

        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            if (User != null)
                entiteti.spDeleteUser(User.IdUser);
            return base.izvrsi(entiteti);
        }
    }
}