using LibraryProject.Assets.Models;
using LibraryProject.Models;
using LibraryProjestLibrary;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Assets.ViewModel
{
    class UsersClass
    {
        Core db = new Core();
        CheckStringClass obj = new CheckStringClass();
        public bool RegUsers(string lastName, string name, string fastName, string number, DateTime birthday, string studyOfWork, string adress, string login, string password, string returnPassword)
        {
            if (obj.NameCheck(lastName) == true && obj.NameCheck(name) == true && obj.NameCheck(fastName) == true)
            {
                if (obj.NumberCheck(number) == true)
                {
                    if (obj.BirthdayCheck(birthday) == true)
                    {
                        if (obj.StudyOrWorkCheck(studyOfWork) == true)
                        {
                            if (obj.AdressCheck(adress) == true)
                            {
                                //Проверка на отсутсвие подобного логина в БД
                                int control = db.context.Reader.Where(x => x.Login ==login).Count();
                                if (control == 0)
                                {
                                    //Тот же ли пароль при повторном вводе
                                    if (password == returnPassword)
                                    {
                                        if (obj.ReliabilityPassword(password) == true)
                                        {
                                            Reader red = new Reader
                                            {
                                                LastName = lastName,
                                                Name = name,
                                                PatronymicName = fastName,
                                                NumberPhone = number,
                                                Birthday = birthday,
                                                StudyOrWork = studyOfWork,
                                                Adress = adress,
                                                Login = login,
                                                Password = password,
                                                IdRank = 1,
                                                Hall = 1
                                            };
                                            db.context.Reader.Add(red);
                                            try
                                            {
                                                db.context.SaveChanges();
                                                if (db.context.SaveChanges() == 0)
                                                {
                                                    return true;
                                                }
                                            }
                                            catch (DbEntityValidationException ex)
                                            {
                                                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                                                {
                                                    foreach (DbValidationError err in validationError.ValidationErrors)
                                                    {
                                                        throw new Exception(err.ErrorMessage + "");
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        throw new Exception("Пароли не совпадают");
                                    }
                                }
                                else
                                {
                                    throw new Exception("Данный логин уже занят");
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }
    }
}
