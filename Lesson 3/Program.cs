using Lesson_3;

class Program
{
    static void Main(string[] args)
    {

        var therapist1 = new Therapist
        {
            Name = "Александр Рева",
            Age = 35,
            Specialization = "Терапевт, пульманолог",
            Experience = "2 года ординатуры и 9 лет работы в поликлинике",
            DoctorsDistrict = 1
        };

        var ophthalmologist1 = new Ophthalmologist
        {
            Name = "Маргарита Гольдберг",
            Age = 28,
            Specialization = "Офтальмолог",
            Experience = "2 года ординатуры и 2 года работы в поликлинике"
        };

        var neurolog1 = new Neurolog
        {
            Name = "Эльвира Хабибулина",
            Age = 45,
            Specialization = "Невролог",
            Experience = "2 года ординатуры, 10 лет работы в поликлинике и 9 лет работы в ОКБ"
        };

        var patient1 = new TherapyPatient
        {
            Name = "Иван Иванов",
            Age = 41,
            Disease = "ОРЗ",
            Insurance = "ОМС",
            Sickness = true,
            District = 1
        };

        var patient2 = new OphthalmicPatient
        {
            Name = "Дуся Ковальчук",
            Age = 77,
            Insurance = "ОМС",
            Sickness = true,
            Disease = "Миопия",
            Vision = -1.5
        };

        var patient3 = new NeurologicalPatient
        {
            Name = "Владимир Дикий",
            Age = 60,
            Disease = "Алкогольная деменция",
            Insurance = "ОМС",
            Sickness = true,
            MeningealSymptoms = false
        };
        patient3.Information();
        patient3.DoctorsAppointment(neurolog1);
        neurolog1.Information();
        neurolog1.Treatment(patient3);

        patient2.Information();
        patient2.DoctorsAppointment(ophthalmologist1);
        ophthalmologist1.Information();
        ophthalmologist1.Treatment(patient2);

        patient1.Information();
        patient1.DoctorsAppointment(therapist1);
        therapist1.Information();
        therapist1.Treatment(patient1);
    }
}