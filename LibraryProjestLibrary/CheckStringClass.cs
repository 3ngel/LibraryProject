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
            if (name.EndsWith("-") & name.StartsWith("-"))
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
            if (name.EndsWith("-") & name.StartsWith("-"))
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
            if (name.EndsWith("-") & name.StartsWith("-"))
            {
                throw new Exception("Название содержит знак 'дефис' только в середине");
            }
            return true;
        }
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
        public bool PageCountsCheck(string year)
        {
            string correct = "1234567890";
            if (!year.All(x => correct.Contains(x)))
            {
                throw new Exception("Не корректный год");
            }
            if (year==String.Empty)
            {
                throw new Exception("Вы не ввели кол-во страниц");
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
    }
    //Класс для генерации 
    public class GenerationString
    {
        /// <summary>
        /// Генерация случайного пароля
        /// </summary>
        /// <param></param>
        /// <returns>
        /// Сгенерированный пароль с соблюдением всех условий регистрации
        /// </returns>
        public string RandomPassword()
        {
            string randompassword = "";
            Random y = new Random();
            string spezsimvol = "!?-*";
            string numbers = "1234567890";
            string letterToLower = "abcdefghijklmnopqrstuvwxyz";
            string letterToUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string[] arr = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "B", "C", "D", "F", "G", "H", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "V", "W", "X", "Z", "A", "E", "U", "Y", "b", "c", "d", "f", "g", "h", "j", "k", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "z", "a", "e", "i", "o", "u", "y", "-", "?", "!", "*" };
            int m = y.Next(3, 10);
            //генерация пароля
            for (int i = 0; i < m; i++)
            {
                randompassword += arr[y.Next(0, 62)];
            }
            //Добавление спецсимволов при их отсутствии
            if (!randompassword.All(x => spezsimvol.Contains(x)))
            {
                randompassword += arr[y.Next(59, 62)];
            }
            //Добавление цифр при их отсутствии
            if (!randompassword.All(x => numbers.Contains(x)))
            {
                randompassword += arr[y.Next(0, 9)];
            }
            //Добавление прописных букв при их отсутствии
            if (!randompassword.All(x => letterToLower.Contains(x)))
            {
                randompassword += arr[y.Next(10, 33)];
            }
            //Добавление заглавных букв при их отсутствии
            if (!randompassword.All(x => letterToUpper.Contains(x)))
            {
                randompassword += arr[y.Next(34, 58)];
            }
            return randompassword;
        }
        /// <summary>
        /// Генерация ISBN индефикатора для книг
        /// </summary>
        /// <returns></returns>
        public string ISBNGeneration() 
        {
            string str = String.Empty;
            Random x = new Random();
            int one = x.Next(1, 9);
            int two = x.Next(100,999);
            int three = x.Next(10000, 999999);
            GenerationString obj = new GenerationString();
            int control = obj.ControlNumberGeneration($"{one}{two}{three}");
            str = $"{one}-{two}-{three}-{control}";
            return str;
        }

        /// <summary>
        /// Генерация контрольной цифры для ISBN индефикатора
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public int ControlNumberGeneration(string number)
        {
            int control = 0;
            for (int i = 0; i <number.Length; i++)
            {
                control += Convert.ToInt32(number.Substring(i,1)) * (10 - i);
            }
            int ost = 0;
            if (control%11>9)
            {
                ost = control % 10;
            }
            else
            {
                ost = control % 11;
            }
            return ost;
        }
    }
}
