using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using System.IO.Compression;
using System.Text;

try
{
    string zipPath = @"D\";  //1    //я вбивал путь к своему зип файлу, поэтому тут оставил это так.... 
    string extractPath = @"D\";
    ZipFile.ExtractToDirectory(zipPath, extractPath);

    var directory = new DirectoryInfo(extractPath);  //2
    var files = directory.GetFiles();

    var csvObject = files.Select(u => new   //3
    {
        Type = u.Extension.TrimStart('.'),
        Name = u.Name,
        Path = u.FullName,
        LastChange = u.LastWriteTime
    });
    var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
    { Delimiter = "\t", Encoding = Encoding.UTF8 };
    string csvPath = Path.Combine(extractPath, "fileInformation.csv");
    using (var writer = new StreamWriter(csvPath))
    using (var csv = new CsvWriter(writer, csvConfig))
    { csv.WriteRecords(csvObject);}

    Directory.Delete(extractPath);  //4

    string txtPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Lesson12Homework.txt");  //5
    using (StreamWriter writer = new StreamWriter(txtPath, false))  
    {writer.WriteLine(Path.Combine(extractPath, "fileInformation.csv"));}
}
catch (DirectoryNotFoundException) { Console.WriteLine("Нет такого директория"); }
catch (FileNotFoundException) { Console.WriteLine("Нет такой папки"); }
catch (System.UnauthorizedAccessException) { Console.WriteLine("Куда лезешь"); }
catch (System.IO.IOException) { Console.WriteLine("Отказ!"); }
catch (InvalidDataException) { Console.WriteLine("Че-то не то"); }
catch (Exception ex) { Console.WriteLine("Ой ей, ну тут все"); }