﻿using System;

namespace TestSimpleDB
{
    class GenerateData
    {

         static Random rnd = new Random();

        public string[] Positions = 
        {
          "Професор",
          "Доцент",
          "Завідувач_кафедри",
          "Асистент",
          "Завідувач_навчальної_лабораторії",
          "Cтарший_лаборант_кафедри",
          "Cтарший_лаборант_навчальної_лабораторії",
          "Завідувач_відділу",
          "Медичний_працівник",
          "Завідувач_складу",
          "Прибиральниця",
          "Сантехнік"
        };

        private string[] Surnames =
        {
            "Андрушенко", "Артишенко", "Мармот", "Смарик", "Купер",
            "Вакуленко", "Роттус", "Стріла", "Голобородько", "Стулент", "Вайбір",
            "Дейнеженко", "Диденко", "Жиган", "Жорик", "Мищенко", "Зеленський",
            "Маг", "Кук", "Лют", "Марченко", "Миколенко", "Зінченко",
            "Опопиренко", "Остапишин", "Павлол", "Павловський", "Филипенко",
            "Руденко", "Рудик", "Староста", "Сиваченко", "Орган", "Смирнов",
            "Солонко", "Капiтан", "Суденко", "Мироненко", "Тимошенко", "Самилович",
            "Кличенко", "Хоменко","Чубаюба", "Шмайра","Шевченко", "Соха","Бебрун"
        };

        private string[] Names =
        {
            "Данило", "Артем", "Богдан", "Олександр", "Назар", "Андрiй", "Олександр",
            "Олексiй", "Денис", "Юрiй", "Олексiй", "Маргарита", "Богдан", "Артем", "Олександр",
            "Ксенiя", "Олександр", "Богдан", "Владислав", "Максим", "Ольга", "Олександр",
            "Владислав", "Дмитро", "Олександр", "Данiель", "Андрiй", "Михайло",
            "Всеволод", "Денис", "Андрiй", "Олег", "Олег", "Богдан", "Валентин",
            "Сергiй", "Ярослав", "Михайло", "Андрiй", "Денис", "Олександр",
            "Денис", "Олег", "Марта", "Назар", "Костянтин", "Юрiй"
        };
        private string[] Last_Names =
        {
            "Володимирович", "Артемович", "Богданович", "Олександрович", "Назарович", "Олегович", "Олександрович",
            "Олексiйович", "Денисович", "Юрiйович", "Олексiйович", "Iванiвна", "Богданович", "Артемович", "Олександрович",
            "Iванiвна", "Олександрович", "Богданович", "Ростиславович", "Максимович", "Максимiвна", "Олександрович",
            "Владиславович", "Дмиторвич", "Олександрович", "Артемович", "Андрiйович", "Михайлович",
            "Артемович", "Денисович", "Андрiйович", "Олегович", "Ростиславович", "Богданович", "Владиславович",
            "Владиславович", "Юрiйович", "Олегович", "Андрiйович", "Денисович", "Олександрович",
            "Денисович", "Юрiєвич", "Iванiвна", "Максимович", "Костянтинович", "Артемович"
        };
        private string[] gender =
      {
           "Man", "Man", "Man", "Man", "Man", "Man", "Man",
            "Man", "Man", "Man", "Man", "Woman", "Man", "Man", "Man",
            "Woman", "Man", "Man", "Man", "Man", "Woman", "Man",
            "Man", "Man", "Man", "Man", "Man", "Man",
            "Man", "Man", "Man", "Man", "Man", "Man", "Man",
            "Man", "Man", "Man", "Man", "Man", "Man",
            "Man", "Man", "Woman", "Man", "Man", "Man"
        };
        private string[] residence_addresses =
        {
            "Полтавська область, місто Полтава, пл. Інститутська, 29", "Запорізька область, місто Запоріжжя, пл. Солом’янська, 14", "Херсонська область, місто Херсон, вул. Урицького, 84",
            "Луганська область, місто Луганськ, пров. Урицького, 85", "Полтавська область, місто Полтава, вул. Різницька, 44", "Миколаївська область, місто Миколаїв, просп. П. Орлика, 50",
            "Хмельницька область, місто Хмельницький, вул. Лук’янівська, 7","Дніпропетровська область, місто Дніпро, пл. Артема, 57", "Херсонська область, місто Херсон, пл. Львівська, 60",
            "Харківська область, місто Харків, пл. Пирогова, 32", "Миколаївська область, місто Миколаїв, пров. Лесі Українки, 01", "Миколаївська область, місто Миколаїв, вул. М. Коцюбинського, 75",
            "Миколаївська область, місто Миколаїв, просп. Володимирська, 20", "Одеська область, місто Одеса, пров. М. Коцюбинського, 88", "Сумська область, місто Суми, пров. Львівська, 87",
            "вано-Франківська область, місто Івано-Франківськ, просп. Копиленка, 77", "Черкаська область, місто Черкаси, просп. М. Коцюбинського, 77", "Миколаївська область, місто Миколаїв, пров. Арсенальна, 37",
            "Миколаївська область, місто Миколаїв, пл. Урицького, 42", "Вінницька область, місто Вінниця, вул. Солом’янська, 07", "Полтавська область, місто Полтава, пров. П. Орлика, 74",
            "Запорізька область, місто Запоріжжя, пров. Мельникова, 12", " Миколаївська область, місто Миколаїв, просп. Володимирська, 28", "Івано-Франківська область, місто Івано-Франківськ, пров. Пирогова, 62",
            "Миколаївська область, місто Миколаїв, пров. Різницька, 60", "Полтавська область, місто Полтава, просп. Інститутська, 02", "Одеська область, місто Одеса, пл. М. Коцюбинського, 83",
            "Запорізька область, місто Запоріжжя, вул. Володимирська, 67", "Одеська область, місто Одеса, пров. Тараса Шевченка, 64", "Закарпатська область, місто Ужгород, вул. Урицького, 21",
            "Луганська область, місто Луганськ, просп. Лук’янівська, 61", "Луганська область, місто Луганськ, пров. І. Франкa, 57", "Чернігівська область, місто Чернігів, вул. Фізкультури, 64",
            "Харківська область, місто Харків, просп. Шота Руставелі, 76", "Полтавська область, місто Полтава, просп. Артема, 96","Київська область, місто Київ, вул. Михайла Грушевського, 87",
            " Закарпатська область, місто Ужгород, вул. І. Франкa, 86", " Сумська область, місто Суми, пров. І. Франкa, 92", "Луганська область, місто Луганськ, просп. Мельникова, 04",
            "Закарпатська область, місто Ужгород, пл. Копиленка, 25", "Кіровоградська область, місто Кропивницький, вул. Паторжинського, 52",
            "Черкаська область, місто Черкаси, пл. Лесі Українки, 69",  "Херсонська область, місто Херсон, пров. Мельникова, 60", "Чернівецька область, місто Чернівці, пл. Різницька, 42",
            "Херсонська область, місто Херсон, вул. Інститутська, 09", "Чернівецька область, місто Чернівці, вул. Інститутська, 33", "Київська область, місто Київ, просп. Володимирська, 46"
        };

        private string[] Staffs =
        {
            "професорсько_викладацький_склад",
            "навчально_допоміжний_склад",
            "адміністративно_господарський_склад"
        };
        private string[] Units =
        {
            "основний_склад",
            "сумісники",
            "допоміжні_працівники",
            "технічні_працівники"

        };
        public int k = rnd.Next(4);
        public int m = rnd.Next(0,14);
        public int n = rnd.Next(3);
        
        public string getPosition(int m) => Positions[m];
        public string getGender(byte i) => gender[i];
        public byte getGenderCount() => (byte)gender.Length;
        public string getName(byte i) => Names[i];
        public byte getNamesCount() => (byte)Names.Length;
        public string getSurname(int i) => Surnames[i];
        public int getSurnamesCount() => Surnames.Length;
        public string getLast_Names(int i) => Last_Names[i];
        public int getLast_Names_count() => Last_Names.Length;
        public string getresidence_addresses(int i) => residence_addresses[i];
        public int getresidence_addresses_count() => residence_addresses.Length;
        public string getStaff(int n) => Staffs[n]; 
        public string getUnit(int k) => Units[k];

    }
}