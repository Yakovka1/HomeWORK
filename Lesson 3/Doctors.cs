using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_3
{
    public abstract class Doctor
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Specialization { get; set; }
        public string Experience { get; set; }

        public virtual void Information()
        {
            Console.WriteLine($"\nИмя врача: {Name}\nВозраст: {Age}\nСпециализация: {Specialization}\nОпыт работы: {Experience}");
        }

        public virtual void Treatment(Patient patient)
        {
            if (new Random().Next(0, 11) > 2)
            {
                patient.Sickness = false;
                Console.WriteLine($"\nВрач {Name} провел успешное лечение пациенту {patient.Name}\nПациент выздоровел");
            }
            else
            {
                patient.Sickness = true;
                Console.WriteLine($"\nВрач {Name} не смог провести успешное лечение пациента {patient.Name}\nПациент не выздоровел");
            }
        }
    }
    public class Therapist : Doctor
    {
        public int DoctorsDistrict { get; set; }

        public override void Information()
        {
            base.Information();
            Console.WriteLine($"Рабочий участкок врача: {DoctorsDistrict}");
        }
    }

    public class Ophthalmologist : Doctor
    {
        public override void Treatment(Patient patient)
        {
            if (new Random().Next(0, 11) > 3)
            {
                patient.Sickness = true;
                Console.WriteLine($"\nВрач {Name} назначил успешное лечение пациенту {patient.Name}, скомпенсировавшее состояние пациента\nТем не менее этиологический фактор устранить не удалось");
            }
            else
            {
                patient.Sickness = true;
                Console.WriteLine($"\nВрач {Name} не смог провести успешное лечение пациента {patient.Name}\nПациент направлен на оперативную корекцию глаза");
            }
        }
    }

    public class Neurolog : Doctor
    {
        public override void Treatment(Patient patient)
        {
            patient.Sickness = true;
            Console.WriteLine($"\nНазначенное врачом {Name} лечение компенсирует состояние пациента {patient.Name}, однако перенесенное заболевание навсегда оставит свой след\nПациент остается больным");
        }
    }
}