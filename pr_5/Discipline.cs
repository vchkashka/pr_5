using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr_5
{
    public enum EL
    {
        bakalavriat,
        magistratura,
        aspirantura,
        EMPTY
    };
    public class Discipline
    {
        private string _name;//название
        private int target_number_of_units;//целевое количество зачетных единиц
        private EL el;//ступень образования

        public int Target_number_of_units
        {
            set
            {
                if (value < 1 || value > 100)
                {
                    target_number_of_units = 0;
                    throw new Exception("Некорректный ввод количества зачётных единиц");
                }
                else
                {
                    target_number_of_units = value;
                }
            }
            get
            {
                return target_number_of_units;
            }
        }
        public EL El
        {
            set
            {
                if (value == EL.EMPTY)
                {
                    el = EL.EMPTY;
                    throw new Exception("Некорректный ввод ступени высшего образования");
                }
                else
                {
                    el = value;
                }
            }
            get
            {
                return el;
            }
        }
        public string Name
        {
            set
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if (((value[i] >= 32 && value[i] <= 47) || (value[i] >= 58 && value[i] <= 64) || (value[i] >= 91 && value[i] <= 96) || (value[i] >= 123 && value[i] <= 127)))
                    {
                        _name = "Пусто";
                        throw new Exception("Некорректный ввод названия");
                    }
                    else
                    {
                        _name = value;
                    }
                }
            }
            get
            {
                return _name;
            }
        }
        //Вывод информации о дисциплине
        public string Print()
        {
            string _el;
            switch (el)
            {
                case EL.bakalavriat: _el = " Бакалавриат\n"; break;
                case EL.magistratura: _el = " Магистратура\n"; break;
                case EL.aspirantura: _el = " Аспирантура\n"; break;
                default: _el = " Пусто\n"; break;
            }
            return "Название: " + _name + $"\nКоличество зачетных единиц: {target_number_of_units} \nСтупень высшего образования: " + _el;
        }
        public Discipline(string name, int i, EL e)
        {
            if (i < 1 || i > 100)
            {
                target_number_of_units = 0;
                throw new Exception("Некорректный ввод количества зачётных единиц");
            }
            else
            {
                target_number_of_units = i;
            }
            if (e == EL.EMPTY)
            {
                el = EL.EMPTY;
                throw new Exception("Некорректный ввод ступени высшего образования");
            }
            else
            {
                el = e;
            }
            for (int j = 0; j < name.Length; j++)
            {
                if (((name[j] >= 32 && name[j] <= 47) || (name[j] >= 58 && name[j] <= 64) || (name[j] >= 91 && name[j] <= 96) || (name[j] >= 123 && name[j] <= 127)))
                {
                    _name = "Пусто";
                    throw new Exception("Некорректный ввод названия");
                }
                else
                {
                    _name = name;
                }
            }
        }
    }
}
