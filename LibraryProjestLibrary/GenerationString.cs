using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProjestLibrary
{
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
            int one = 5;
            int two = x.Next(100, 999);
            int three = x.Next(10000, 99999);
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
            for (int i = 0; i < number.Length; i++)
            {
                control += Convert.ToInt32(number.Substring(i, 1)) * (10 - i);
            }
            int ost = 0;
            if (control % 11 > 9)
            {
                ost = control % 10;
            }
            else
            {
                ost = control % 11;
            }
            ost = 11 - ost;
            return ost;

        }
        public string NumberBilletGeneration(int hall, string year, int count) 
        {
            string number = "";
            if (hall == 1)
                number = "А";
            if (hall == 2)
                number = "Ч";
            if (hall == 3)
                number = "О";
            //Определяем порядковый номер
            string countString = String.Empty;
            count++;
            if (count < 9)
                countString = $"000{count}";
            else if (count < 99)
                countString = $"00{count}";
            else if (count < 999)
                countString = $"0{count}";
            else if (count < 9999)
                countString = $"{count}";
            else if (count == 9999)
                countString = "0001";
            number += $"{countString}-" + year;
            return number;
        }
    }
}
