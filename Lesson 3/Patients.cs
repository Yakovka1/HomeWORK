using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_3
{
    public abstract class Patient
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Sickness { get; set; }
        public string Disease { get; set; }
        public string Insurance { get; set; }

        public virtual void Information()
        {
            Console.WriteLine($"\nИмя пациента: {Name}\nВозраст: {Age}\nВид страхования: {Insurance}\nЗаболевание: {Disease}");
        }

        public virtual void DoctorsAppointment(Doctor doctor)
        {
            Console.WriteLine($"\nПациент {Name} записан на прием по поводу заболевания: {Disease}\nЛечащий врач: {doctor.Specialization} {doctor.Name}");
        }
    }

    public class TherapyPatient : Patient
    {
        public int District { get; set; }

        public override void Information()
        {
            base.Information();
            Console.WriteLine($"Пациент привязан к {District} участку");
        }
    }

    public class OphthalmicPatient : Patient
    {
        public double Vision { get; set; }

        public override void Information()
        {
            base.Information();
            Console.WriteLine($"Уровень зрения: {Vision}");
        }
    }

    public class NeurologicalPatient : Patient
    {
        public bool MeningealSymptoms { get; set; }

        public override void Information()
        {
            base.Information();
            if (MeningealSymptoms == true)
            {
                Console.WriteLine("Менингиальные симптомы присутствуют");
            }
            else
            {
                Console.WriteLine("Менингиальные симптомы отсутствуют");
            }
        }
    }
}