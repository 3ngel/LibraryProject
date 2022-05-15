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
    public class UsersClass
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
                                    control = db.context.Reader.Where(x => x.NumberPhone == number).Count();
                                    if (control == 0)
                                    {
                                        //Тот же ли пароль при повторном вводе
                                        if (password == returnPassword)
                                        {
                                            if (obj.ReliabilityPassword(password) == true)
                                            {
                                                number = number.Replace("+7", "8").Trim(); ;
                                                number = number.Replace("7", "8");
                                                number = number.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
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
                                        throw new Exception("Данный номер телефона уже занят");
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
        public bool EditUser(string lastname, string name, string patronymicname, string number, string password, int hall, int rank, string adress, string study, string login)
        {
            Core db = new Core();
            CheckStringClass check = new CheckStringClass();
            Reader read = db.context.Reader.Where(x => x.Login==login).First();
            try
            {
                if (check.NameCheck(lastname) == true)
                {
                    if (check.NameCheck(name) == true)
                    {
                        if (check.NameCheck(patronymicname) == true)
                        {
                            if (check.NumberCheck(number) == true)
                            {
                                if (check.ReliabilityPassword(password) == true)
                                {
                                    if (check.AdressCheck(adress)==true)
                                    {
                                        if (check.StudyOrWorkCheck(study)==true)
                                        {
                                            number = number.Replace("+7", "8").Trim(); ;
                                            number = number.Replace("7", "8");
                                            number = number.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                                            read.LastName = lastname;
                                            read.Name = name;
                                            read.PatronymicName = patronymicname;
                                            read.NumberPhone = number;
                                            read.Password = password;
                                            read.Adress = adress;
                                            read.StudyOrWork = study;
                                            read.IdRank = rank;
                                            read.Hall = hall;
                                            db.context.SaveChanges();
                                            if (db.context.SaveChanges() == 0)
                                            {
                                                return true;
                                            }
                                        }
                                    }                                    
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return true; 
        }
        public bool AutoUser(string login, string password)
        {
            Core db = new Core();
            List<Reader> arrayReader;
            arrayReader = db.context.Reader.ToList();
            int acount = arrayReader.Where(x => x.Login == login).Count();
            int countRecord = 0;
            if (login == String.Empty || password == String.Empty)
            {
                throw new Exception("Вы не ввели логин или пароль");
            }
            //Проверка на наличие логина
            if (acount == 1)
            {
                arrayReader = db.context.Reader.Where(x => x.Login == login).ToList();
                //Если есть данный логин, проверка пароля при этом логине 
                countRecord = arrayReader.Where(x => x.Login == login && x.Password == password).Count();
            }
            else
            {
                throw new Exception("Нет пользователя с таким логином");
            }
            //При совпдании занесение логина в запись приложения и переход на главную страницу
            if (countRecord == 1)
            {
                Properties.Settings.Default.loginClient = login;
                Properties.Settings.Default.RoleClient = db.context.Reader.Where(x => x.Login == login).First().IdRank;
                Properties.Settings.Default.Save();
                return true;
            }
            else
            {
                throw new Exception("Неверный пароль или логин");
            }       
        }
        public bool DeleteUser(string login)
        {
            Core db = new Core();
            Reader read = db.context.Reader.Where(x => x.Login == login).First();
            db.context.Reader.Remove(read);
            db.context.SaveChanges();
            return true;
        }
    }
}
