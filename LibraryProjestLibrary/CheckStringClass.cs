using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProjestLibrary
{
    //Класс на проверку правильного введённого поля
    public class CheckStringClass
    {
        /// <summary>
        /// Проверка имени и отчества
        /// </summary>
        /// <param name="name">
        /// 
        /// </param>
        /// <returns>
        /// true если введено верно
        /// false введено не верно
        /// </returns>
        public bool NameCheck(string name)
        {
            string correctSymbols = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя-";
            string nameOne = name;
            name = name.ToLower();
            if (!name.All(x => correctSymbols.Contains(x)))
            {
                throw new Exception("ФИО содержит недоступные символы. Писать на кириллице");
            }
            if (name == String.Empty)
            {
                throw new Exception("Вы не ввели ФИО полностью");
            }
            if (name.EndsWith("-") || name.StartsWith("-"))
            {
                throw new Exception("ФИО содержит знак 'дефис' только в середине");
            }
            name = nameOne;
            char symbol = name[0];
            if (Char.IsLower(symbol))
            {
                throw new Exception("ФИО должно начинаться с заглавной буквы");
            }
            return true;
        }
        /// <summary>
        /// Проверка ФИО автора
        /// </summary>
        /// <param name="name">
        /// 
        /// </param>
        /// <returns>
        /// true если введено верно
        /// false введено не верно
        /// </returns>
        public bool AuthorCheck(string name)
        {
            string correctSymbols = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя- ";
            string nameOne = name;
            name = name.ToLower();
            if (!name.All(x => correctSymbols.Contains(x)))
            {
                throw new Exception("ФИО автора содержит недоступные символы. Писать на кириллице");
            }
            if (name == String.Empty)
            {
                throw new Exception("Вы не ввели ФИО автора");
            }
            if (name.EndsWith("-") || name.StartsWith("-"))
            {
                throw new Exception("ФИО автора содержит знак 'дефис' только в середине");
            }
            name = nameOne;
            char symbol = name[0];
            if (Char.IsLower(symbol))
            {
                throw new Exception("ФИО автора должно начинаться с заглавной буквы");
            }
            return true;
        }
        /// <summary>
        /// Проверка Названия книги
        /// </summary>
        /// <param name="name">
        /// 
        /// </param>
        /// <returns>
        /// true если введено верно
        /// false введено не верно
        /// </returns>
        public bool TitleCheck(string name)
        {
            string correctSymbols = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя- :,;.";
            string nameOne = name;
            name = name.ToLower();
            if (!name.All(x => correctSymbols.Contains(x)))
            {
                throw new Exception("Название содержит недоступные символы. Писать на кириллице");
            }
            if (name == String.Empty)
            {
                throw new Exception("Вы не ввели Название");
            }
            if (name.EndsWith("-") || name.StartsWith("-"))
            {
                throw new Exception("Название содержит знак 'дефис' только в середине");
            }
            return true;
        }
        /// <summary>
        /// Проверка года выхода книги
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public bool YearCheck(string year) 
        {
            if (year == String.Empty)
            {
                throw new Exception("Вы не ввели год выхода");
            }
            string correct = "1234567890";
            if (!year.All(x=> correct.Contains(x)))
            {
                throw new Exception("Не корректный год");
            }
            else
            {
                int yearcont = Convert.ToInt32(year);
                int today = DateTime.Now.Year;
                if (yearcont>today)
                {
                    throw new Exception("Неверный год выхода");
                }
            }
            return true;
        }
        /// <summary>
        /// Проверка кол-ва книг
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public bool PageCountsCheck(string year)
        {
            string correct = "1234567890";
            if (!year.All(x => correct.Contains(x)))
            {
                throw new Exception("Не корректное кол-во страниц");
            }
            if (year==String.Empty)
            {
                throw new Exception("Вы не ввели кол-во страниц");
            }
            if(Convert.ToInt32(year)<5)
            {
                throw new Exception("Слишком мало страниц");
            }
            return true;
        }
        /// <summary>
        /// Проверка строки дом публикации
        /// </summary>
        /// <param name="house"></param>
        /// <returns></returns>
        public bool HousePublicationCheck(string house)
        {
            char startHouse = house[0];
            house = house.ToLower();
            string correctSymbols = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя-";
            string correctSymbolsLat = "qazxswedcvfrtgbnhyujmkiolp-";
            if (!house.All(x => correctSymbols.Contains(x)) && !house.All(x => correctSymbolsLat.Contains(x)))
            {
                throw new Exception("Название дома публикации содержит недоступные символы. Писать на кириллице или на латинице (не смешивать)");
            }
            if (house == String.Empty)
            {
                throw new Exception("Вы не ввели дом публикации");
            }
            if (house.EndsWith("-") || house.StartsWith("-"))
            {
                throw new Exception("Название дома публикации содержит знак 'дефис' только в середине");
            }
            if (Char.IsLower(startHouse))
            {
                throw new Exception("Название дома публикации начинается с заглавной буквы");
            }
            return true;
        }
        public bool CityCheck (string city)
        {
            string correctSymbols = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя-";
            city = city.ToLower();
            if (!city.All(x => correctSymbols.Contains(x)))
            {
                throw new Exception("Название города содержит недоступные символы. Писать на кириллице");
            }
            if (city==String.Empty)
            {
                throw new Exception("Вы не ввели название города");
            }            
            return true;
        }
        /// <summary>
        /// Проверка номера
        /// </summary>
        /// <param name="number">
        /// </param>
        /// <returns>
        /// true если введено верно
        /// false введено не верно
        /// </returns>
        public bool NumberCheck(string number)
        {
            string correctSymbols = "1234567890";
            number = number.Replace("+7", "8").Trim(); ;
            number = number.Replace("7", "8");
            number = number.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            if (!number.All(x => correctSymbols.Contains(x)))
            {
                throw new Exception("Номер содержит недоступные символы.Номер состоит из цифр");
            }
            if (number == String.Empty)
            {
                throw new Exception("Вы не ввели номер");
            }
            int lenght = number.Length;
            if (lenght != 11)
            {
                throw new Exception("Номер телефона должен состоять из 11 цифр");
            }
            if (!number.StartsWith("8"))
            {
                throw new Exception("Номер должен начинаться с цифры 8 или +7 ");
            }
            return true;
        }
        /// <summary>
        /// Проверка дня рождения
        /// </summary>
        /// <param name="birthday">
        /// День рождения
        /// </param>
        /// <returns>
        /// true если введено верно
        /// false введено не верно
        /// </returns>
        public bool BirthdayCheck(DateTime birthday)
        {
            DateTime today = DateTime.Now;
            int yearNow = today.Year;
            int monthNow = today.Month;
            int dayNow = today.Day;
            int year = birthday.Year;
            int month = birthday.Month;
            int day = birthday.Day;
            if (month==2 && day>29)
            {
                throw new Exception("Такого числа не существует");
            }
            if ((month==4 || month==6 || month==9 || month==11) && day>=31)
            {
                throw new Exception("Такого числа не существует");
            }
            if ((month == 1 || month == 3 || month == 5 || month == 7 || month==8 || month==10 || month==12) && day > 31)
            {
                throw new Exception("Такого числа не существует");
            }
            if (today<birthday)
            {
                throw new Exception("Мы не дожил до этого дня, чтоб вы родились");
            }
            if (year<1903)
            {
                throw new Exception("Вы уже умерли");
            }
            return true;
        }
        /// <summary>
        /// Проверка логина
        /// </summary>
        /// <param name="login">
        /// LogInTextBox
        /// </param>
        /// <returns>
        /// true если введено верно
        /// false введено не верно
        /// </returns>
        public bool LoginCheck(string login)
        {
            string correctSymbols = "abcdefghijklmpnopqrstuvwxyz0123456789-_.";
            login = login.ToLower();
            if (!login.All(x => correctSymbols.Contains(x)))
            {
                throw new Exception("Логин содержит недоступные символы");
            }
            if (login == String.Empty)
            {
                throw new Exception("Вы не ввели логин");
            }
            if (login.EndsWith("."))
            {
                throw new Exception("Логин не может заканчиваться символом 'точка'");
            }
            return true;
        }        
        /// <summary>
        /// Проверка надёжности  пароля
        /// </summary>
        /// <returns>
        /// true если все условия соблюдены
        /// false если хотя бы одно условие является неверным
        /// </returns>
        public bool ReliabilityPassword(string password)
        {
            //Проверка длины пароля в диапозоне от 8 до 20 символов
            if ((password.Length <= 20) & (password.Length >= 8))
            {
                string correctSymbols = "abcdefghijklmpnopqrstuvwxyz0123456789-_.?!*ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                if (!password.All(x => correctSymbols.Contains(x)))
                {
                    throw new Exception("Пароль содержит недоступные символы");
                }
                if (password == String.Empty)
                {
                    throw new Exception("Вы не ввели пароль");
                }
                if (password.EndsWith("."))
                {
                    throw new Exception("Пароль не может заканчиваться символом 'точка'");
                }
                //Счётчики
                int kolLett = 0;
                int kolBlett = 0;
                int kolNull = 0;
                int kolDig = 0;
                //Цикл, в котором считают наличие указанных условий
                for (int i = 0; i < password.Length; i++)
                {
                    char symbol = password[i];
                    if ((Char.IsSymbol(symbol)) || (Char.IsSeparator(symbol)) || (Char.IsSurrogate(symbol)) || (Char.IsPunctuation(symbol)))
                    {
                        kolDig++;
                    }
                    else if (Char.IsUpper(symbol))
                    {
                        kolBlett++;
                    }
                    else if (Char.IsLower(symbol))
                    {
                        kolLett++;
                    }
                    else if (Char.IsNumber(symbol))
                    {
                        kolNull++;
                    }
                }
                //Проверка условий 
                if (kolBlett == 0)
                {
                    throw new Exception("В пароле нет букв латиницы верхнего регистра");
                }
                else if (kolDig == 0)
                {
                    throw new Exception("В пароле нет спец.символов");
                }
                else if (kolLett == 0)
                {
                    throw new Exception("В пароле нет букв латиницы нижнего регистра");
                }
                else if (kolNull == 0)
                {
                    throw new Exception("В пароле нет цифр");
                }
            }
            else
                throw new Exception("Длина пароля должна быть от 8 до 20 символов");
            return true;
        }
        //Проверка корректности ввода места жительства
        public bool AdressCheck(string adress)
        {
            if (adress == String.Empty)
            {
                throw new Exception("Вы не введи адрес");
            }
            string correctSymbols = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя1234567890, ";
            adress = adress.ToLower();
            if (!adress.All(x => correctSymbols.Contains(x)))
            {
                throw new Exception("Адрес содержит недоступные символы. Писать на кириллице");
            }
            return true;
        }
        //Проверка корректности ввода места учёбы/работы
        public bool StudyOrWorkCheck(string text) 
        {
            if (text == String.Empty)
            {
                throw new Exception("Вы не введи место учёбы/работы");
            }
            string correctSymbols = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя ,1234567890";
            text = text.ToLower();
            if (!text.All(x => correctSymbols.Contains(x)))
            {
                throw new Exception("Наименование места учёбы/работы содержит недоступные символы. Писать на кириллице");
            }
            return true;
        }
        /// <summary>
        /// Проверка индикатора книги
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        public bool ISBNcheck(string isbn)
        {
            isbn = isbn.Replace(" ", "");
            isbn = isbn.Replace("x", "X").Replace("х","X").Replace("Х","X");
            if (isbn.Length!=13)
            {
                throw new Exception("Длина ISBN невернаая");
            }
            string control = "1234567890-X";
            if (!isbn.All(x=>control.Contains(x)))
            {
                throw new Exception("В ISBN не корректные символы");
            }
            //bool trie = (isbn[1]==t && isbn[6] == t && isbn[11] == t) &&
            //    (isbn[0] != t && isbn[2] != t && isbn[3] != t && isbn[4] != t && isbn[5] != t && isbn[7] != t && isbn[8] != t && isbn[9] != t && isbn[10] != t && isbn[12] != t);
            //if (trie==false)
            //{
            //    throw new Exception("Неверный формат ISBN");
            //}
            string number = $"{isbn[0]}{isbn[2]}{isbn[3]}{isbn[4]}{isbn[5]}{isbn[7]}{isbn[8]}{isbn[9]}{isbn[10]}";
            int[] numb = new int[9];
            for (int i = 0; i < number.Length; i++)
            {
                numb[i] = Convert.ToInt32(number.Substring(i,1));
            }
            int controlNumb = 0;
            int summ = 0;
            int[] koff = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            for (int i = 0; i < number.Length; i++)
            {
                summ = summ+numb[i] * koff[i];
            }
            controlNumb = summ % 11;
            controlNumb = 11 - controlNumb;
            string check = "";
            if (controlNumb==10)
            {
                check = "X";
            }
            else if (controlNumb==11)
            {
                check = "0";
            }
            else
            {
                check = controlNumb.ToString(); 
            }
            if (isbn.Substring(12,1) != check)
            {
                throw new Exception($"{controlNumb}");
            }
            return true;
        }
    }
}
