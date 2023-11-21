using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr_5
{
    public class Syllabus
    {
        private string cipher; //шифр
        private string name;//название
        private string FIO;//ФИО ответственного за план
        private int target_number_of_units;//целевое количество зачетных единиц
        private int number_of_disciplines;//количество дисциплин
        private int sum_number_of_units_by_discipline;//общее количество зачетных единиц
        private bool state;//состояние плана
        private EL level;//ступень образования
        private int numSemesters;//количество семестров
        List<List<Discipline>> semesters = new List<List<Discipline>>();


        public int NumSemesters
        {
            set
            {
                if (value < 1 || value > 8)
                {
                    throw new ArgumentOutOfRangeException("Некорректное количество семестров");
                }
                numSemesters = value;
            }
            get
            {
                return numSemesters;
            }
        }
        public string Cipher
        {
            set
            {
                if (state == true)
                {
                    throw new Exception("План нельзя редактировать, так как план введен в действие");
                }
                else
                {
                    if (value.Length != 8)
                    {
                        throw new IndexOutOfRangeException("Некорректный ввод шифра (длина шифра 8 цифр)");
                    }
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (value[i] != 32 && (value[i] < 48 || value[i] > 57))
                        {
                            throw new ArgumentException("Некорректный ввод шифра (используйте только цифры)");
                        }
                    }
                    cipher = value;
                }
            }
            get
            {
                return cipher;
            }
        }
        public string Name
        {
            set
            {
                if (state == true)
                {
                    throw new Exception("План нельзя редактировать, так как план введен в действие");
                }
                else
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (((value[i] > 32 && value[i] <= 47) || (value[i] >= 58 && value[i] <= 64) || (value[i] >= 91 && value[i] <= 96) || (value[i] >= 123 && value[i] <= 127)))
                        {
                            throw new ArgumentException("Некорректный ввод названия (содержит цифру или другой неподходящий символ)");
                        }
                    }
                    name = value;
                }
            }
            get
            {
                return name;
            }
        }

        public string Fio
        {
            set
            {
                if (state == true)
                {
                    throw new Exception("План нельзя редактировать, так как план введен в действие");
                }
                else
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (((value[i] > 32 && value[i] <= 47) || (value[i] >= 58 && value[i] <= 64) || (value[i] >= 91 && value[i] <= 96) || (value[i] >= 123 && value[i] <= 127)))
                        {
                            throw new ArgumentException("Некорректный ввод ФИО ответственного за план (содержит цифру или другой неподходящий символ)");
                        }
                    }
                    FIO = value;
                }
            }
            get
            {
                return FIO;
            }
        }
        public int Target_number_of_units
        {
            set
            {
                if (state == true)
                {
                    throw new Exception("План нельзя редактировать, так как план введен в действие");
                }
                else
                {
                    if (value < 1 || value > 100)
                    {
                        throw new ArgumentOutOfRangeException("Некорректный ввод целевого количествa зачётных единиц");
                    }
                    else
                    {
                        target_number_of_units = value;
                    }
                }
            }
            get
            {
                return target_number_of_units;
            }
        }

        public EL Level
        {
            set
            {
                if (state == true)
                {
                    throw new Exception("План нельзя редактировать, так как план введен в действие");
                }
                else
                {
                    if (value == EL.EMPTY)
                    {
                        throw new ArgumentException("Некорректный ввод ступени высшего образования");
                    }
                    else
                    {
                        level = value;
                    }
                }
            }
            get
            {
                return level;
            }
        }
        public bool State
        {
            get
            {
                return state;
            }
        }
        public int Number_of_disciplines
        {
            get
            {
                number_of_disciplines = 0;
                for (int i = 0; i < semesters.Count; i++)
                {
                    number_of_disciplines += GetNumDisciplinesInSemester(i);
                }
                return number_of_disciplines;
            }
        }
        //Подсчет количества дисциплин в семестре
        public int GetNumDisciplinesInSemester(int semester)
        {
            if (semester >= 0 && semester < semesters.Count)
            {
                if (semesters[semester] != null)
                    return semesters[semester].Count;
                else return 0;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Некорректный номер семестра");
            }
        }
        //Вывод информации о плане 
        public string Print()
        {
            string _level, _state;
            switch (level)
            {
                case EL.bakalavriat: _level = "Бакалавриат"; break;
                case EL.magistratura: _level = "Магистратура"; break;
                case EL.aspirantura: _level = "Аспирантура"; break;
                default: _level = "Пусто"; break;
            }
            number_of_disciplines = 0;

            for (int i = 0; i < semesters.Count; i++)
            {
                number_of_disciplines += GetNumDisciplinesInSemester(i);
            }

            for (int i = 0; i < numSemesters; i++)
            {
                if (number_of_disciplines != 0)
                    for (int h = 0; h < semesters[i].Count; h++)
                    {
                        sum_number_of_units_by_discipline += semesters[i][h].Target_number_of_units;
                    }
                else sum_number_of_units_by_discipline = 0;

            }

            if (!state)
            {
                _state = " Редактируется\n\n";
            }
            else
                _state = " Введён в действие\n\n";
            return "Шифр: " + Cipher + "\nНазвание: " + name + "\nФИО ответственного за план: " + FIO + 
                $"\nЦелевое количество зачётных единиц: {target_number_of_units}\nCтупень высшего образования: "+ _level + 
                $"\nКоличество семестров: {numSemesters} \nКоличество дисциплин: {number_of_disciplines}" +
                $"\nКоличество зачётных единиц за дисциплины: {sum_number_of_units_by_discipline}\nСостояние: "+_state;
        }
        //Введение плана в действие
        public void Put_the_plan()
        {
            sum_number_of_units_by_discipline = 0;
            for (int i = 0; i < numSemesters; i++)
            {
                for (int h = 0; h < semesters[i].Count; h++)
                {
                    sum_number_of_units_by_discipline += semesters[i][h].Target_number_of_units;
                }

            }
            foreach (var semester in semesters)
            {
                number_of_disciplines += semester.Count;
            }
            state = false;
            for (int i = 0; i < semesters.Count; i++)
            {
                if (semesters[i].Any() == false)
                {
                    throw new Exception("Учебный план нельзя подписать, если в нём есть семестр без каких-либо дисциплин");
                }
            }

            if (sum_number_of_units_by_discipline != target_number_of_units)
            {
                throw new Exception("План может быть введён в действие, только если сумма зачётных единиц за дисциплины совпадает с целевым количеством зачётных единиц");
            }

            if (cipher == "00000000")
            {
                throw new Exception("Ошибка введения плана в действие: Поле <Шифр> не заполнено");
            }

            if (name == "Пусто")
            {
                throw new Exception("Ошибка введения плана в действие: Поле <Название> не заполнено");
            }

            if (FIO == "Пусто")
            {
                throw new Exception("Ошибка введения плана в действие: Поле <ФИО> не заполнено");
            }

            if (target_number_of_units == 0)
            {
                throw new Exception("Ошибка введения плана в действие: Поле <Целевое количество зачётных единиц> не заполнено");
            }

            if (level == EL.EMPTY)
            {
                throw new Exception("Ошибка введения плана в действие: Поле <Cтупень высшего образования> не заполнено");
            }

            if (number_of_disciplines == 0)
            {
                throw new Exception("Ошибка введения плана в действие: Поле <Количество дисциплин> не заполнено");
            }

            for (int i = 0; i < semesters.Count; i++)
            {
                if ((GetNumDisciplinesInSemester(i) == 0 && GetTotalCreditsInSemester(i) != 0) || (GetNumDisciplinesInSemester(i) != 0 && GetTotalCreditsInSemester(i) == 0))
                {
                    throw new Exception("Ошибка введения плана в действие: Количество дисциплин и суммарное количество зачётных единиц за них могут быть равны 0 только одновременно");
                }
            }
            state = true;
        }
        
        public int GetTotalCreditsInSemester(int semester)
        {
            if (semester >= 0 && semester < semesters.Count)
            {
                int totalCredits = 0;
                for (int i = 0; i < semesters[semester].Count; ++i)
                {
                    totalCredits += semesters[semester][i].Target_number_of_units;
                }
                return totalCredits;
            }
            else
            {
                throw new Exception("Некорректный номер семестра");
            }
        }
        //Добавление дисциплины в план
        public void Dobavite(Discipline k, int semester)
        {
            if (state == true)
            {
                throw new Exception("План нельзя редактировать, так как план введен в действие");
            }
            else
            {           
                // Проверяем, что указанный семестр существует
                if (semester >= 0 && semester < semesters.Count)
                {
                    if (k.El == level)
                    {
                        for (int i = 0; i < semesters[semester].Count; i++)
                        {
                            if (semesters[semester][i].Name == k.Name)
                            {
                                throw new Exception("В семестре уже есть дисциплина с таким названием");
                            }
                        }
                        semesters[semester].Add(k);
                    }
                    else
                    {
                        throw new Exception("Дисциплина должна быть той же ступени образования, что и в учебном плане");
                    }
                }
                else
                {
                    throw new Exception("Некорректный номер семестра");
                }

            }

        }
        //Удаление дисциплины из плана
        public void Udalite(int k, int semester)
        {
            if (state == true)
            {
                throw new Exception("План нельзя редактировать, так как план введен в действие");
            }
            else
            {
                // Проверяем, что указанный семестр существует
                if (semester >= 0 && semester < semesters.Count)
                {
                    // Проверяем, что указанный номер дисциплины в пределах размера коллекции
                    if (k >= 0 && k < semesters[semester].Count)
                    {
                        semesters[semester].RemoveAt(k);
                    }
                    else
                    {
                        throw new Exception("Некорректный номер дисциплины");
                    }
                }
                else
                {
                    throw new Exception("Некорректный номер семестра");
                }

            }
        }
        //Вывод информации о семестрах
        public string Print_dis()
        {
            string result = "Список дисциплин:\n";
            for (int i = 0; i < semesters.Count; i++)
            {
                result += $"\nСеместр {i + 1}:";
                for (int j = 0; j < semesters[i].Count; j++)
                {
                    result += $"\n{j + 1}. " + semesters[i][j].Print();
                }
            }
            return  result;
        }
        static void Resize<T>(List<T> list, int newSize) where T : new()
        {
            if (newSize < list.Count)
            {
                list.RemoveRange(newSize, list.Count - newSize);
            }
            else if (newSize > list.Count)
            {
                while (list.Count < newSize)
                {
                    // В этом примере предполагается, что для T есть конструктор по умолчанию
                    var newItem = new T();
                    list.Add(newItem);
                }
            }
        }
        public Syllabus(string Cipher, string Name, string Fio, int Target_number_of_units, EL El, int kolsm)
        {
            Resize(semesters, kolsm);
            state = false;
            sum_number_of_units_by_discipline = 0;
            number_of_disciplines = 0;
            cipher = "00000000";
            name = "Пусто";
            FIO = "Пусто";
            target_number_of_units = 0;
            level = EL.EMPTY;
            target_number_of_units = 0;

            if (kolsm < 1 || kolsm > 8)
            {
                throw new Exception("Некорректное количество семестров");
            }
            else
            {
                numSemesters = kolsm;
            }

            if (Cipher.Length != 8)
            {
                throw new Exception("Некорректный ввод шифра (длина шифра должна быть 8 символов)");
            }
            else
            {
                for (int i = 0; i < Cipher.Length; i++)
                {
                    if (Cipher[i] != 32 && (Cipher[i] < 48 || Cipher[i] > 57))
                    {
                        throw new Exception("Некорректный ввод шифра (используйте только цифры)");
                    }
                    else
                    {
                        cipher = Cipher;
                    }
                }
            }

            for (int i = 0; i < Name.Length; i++)
            {
                if (((Name[i] > 32 && Name[i] <= 47) || (Name[i] >= 58 && Name[i] <= 64) || (Name[i] >= 91 && Name[i] <= 96) || (Name[i] >= 123 && Name[i] <= 127)))
                {
                    throw new Exception("Некорректный ввод названия (содержит цифру или другой неподходящий символ)");
                }
                else
                {
                    name = Name;
                }
            }

            for (int i = 0; i < Fio.Length; i++)
            {
                if (((Fio[i] > 32 && Fio[i] <= 47) || (Fio[i] >= 58 && Fio[i] <= 64) || (Fio[i] >= 91 && Fio[i] <= 96) || (Fio[i] >= 123 && Fio[i] <= 127)))
                {
                    throw new Exception("Некорректный ввод ФИО ответственного за план (содержит цифру или другой неподходящий символ)");
                }
                else
                {
                    FIO = Fio;
                }
            }

            if (Target_number_of_units < 1 || Target_number_of_units > 100)
            {
                throw new Exception("Некорректный ввод целевого количества зачётных единиц");
            }
            else
            {
                target_number_of_units = Target_number_of_units;
            }

            if (El == EL.EMPTY)
            {
                throw new Exception("Некорректный ввод ступени высшего образования");
            }
            else
            {
                level = El;
            }
        }
    }
}
