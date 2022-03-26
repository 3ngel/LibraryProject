using LibraryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryProject.Assets.Models; 

namespace LibraryProject.Controlers
{
    class ClientContolers
    {
        Core db = new Core();
        public bool AddReader(int count, string lastName, string name, string firstName, string number, DateTime birthday, string studyOrWork, string adress, string login, string password)
        {
            Reader reader = new Reader
            {
                IdReader = count,
                LastName = lastName,
                Name = name,
                PatronymicName = firstName,
                NumberPhone = number,
                Birthday = birthday,
                StudyOrWork = studyOrWork,
                Adress = adress,
                Login = login,
                Password = password,
                IdRank = 1
            };
            db.context.Reader.Add(reader);
            try
            {
                db.context.SaveChanges();
                if (db.context.SaveChanges() == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
            
            
        }

    }
}
