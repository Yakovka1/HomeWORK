using CsvHelper.Configuration;
using CsvHelper;
using Lesson_5_P2;
using System.Globalization;
using System.Text;

try
{
    string csvPath = string.Empty;
    string txtPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Lesson12Homework.txt");
    using (var txtReader = new StreamReader(txtPath))  //1
    { csvPath = txtReader.ReadToEnd(); }

    var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)  //2
    { Delimiter = "\t", Encoding = Encoding.UTF8 };
    using (var reader = new StreamReader(csvPath))
    using (var csvReader = new CsvReader(reader, csvConfig))
    {
        var records = csvReader.GetRecords<Record>();

        foreach (var item in records.OrderByDescending(item => item.LastChange))  //3
        {
            Console.WriteLine($"{item.Type}, {item.Name}, {item.Path}, {item.LastChange}");
        }
    }

    Directory.Delete(txtPath);  //4
}
catch (DirectoryNotFoundException) { Console.WriteLine("Нет такого директория"); }
catch (FileNotFoundException) { Console.WriteLine("Нет такой папки"); }
catch (System.UnauthorizedAccessException) { Console.WriteLine("Куда лезешь"); }
catch (System.IO.IOException) { Console.WriteLine("Отказ!"); }
catch (InvalidDataException) { Console.WriteLine("Че-то не то"); }
catch (Exception ex) { Console.WriteLine("Ой ей, ну тут все"); }