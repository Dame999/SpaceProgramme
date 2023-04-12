using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceProgramTask
{
    public class Program
    {
        static void Main(string[] args)
        {
            string fileName;
            string senderEmailAddress;
            string password;
            string recieverEmailAddress;

            Console.WriteLine("Enter the file path: ");
            fileName = Console.ReadLine();

            Console.WriteLine("Enter the sender email address: ");
            senderEmailAddress = Console.ReadLine();

            Console.WriteLine("Enter the password: ");
            password = Console.ReadLine();

            Console.WriteLine("Enter the reciever email address: ");
            recieverEmailAddress = Console.ReadLine();

            FileReader fileReader = new FileReader();

            try
            {
                List<string> fileData = fileReader.GetData(fileName);

                WeatherConverter weatherConverter = new WeatherConverter();
                List<List<string>> convertedData = weatherConverter.UnpackWeatherData(fileData);
                List<WeatherData> weatherData = weatherConverter.MapWeatherData(convertedData);

                WeatherData mostAppropriateDay = CriteriaCheck.MostAppropriateDateFinder(weatherData);

                NumberWithSuffix numberWithSuffix = new NumberWithSuffix();
                string numWithSuffix = numberWithSuffix.SuffixNumber(mostAppropriateDay.Id);

                Console.WriteLine($"The most appropriate date for rocket launch is {numWithSuffix} of July");
                CSVFileCreator csvFileCreator = new CSVFileCreator(convertedData);
                csvFileCreator.GenerateWatherReport(mostAppropriateDay);


                EmailSender emailSender = new EmailSender();
                emailSender.SendEmail(senderEmailAddress, password, recieverEmailAddress, "WeatherReport.csv");
                Console.WriteLine($"An email with the WeatherReport.csv file was sent to the {recieverEmailAddress}. Please check your email and analyze the weather report parameters.");

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
