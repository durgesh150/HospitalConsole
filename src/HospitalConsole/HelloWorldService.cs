using System;
using System.Linq;
using System.Threading.Tasks;
using HospitalConsole.Domain;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Volo.Abp.DependencyInjection;
using Hospital.EntityFrameworkcore;
using System.Security.Cryptography;
using System.Text;

namespace HospitalConsole;

public class HelloWorldService : ITransientDependency
{
    public ILogger<HelloWorldService> Logger { get; set; }
    
    public HelloWorldService()
    {
        Logger = NullLogger<HelloWorldService>.Instance;
    }

    public Task SayHelloAsync()
    {
        Logger.LogInformation("Hello World!");
        return Task.CompletedTask;
    }
    public Task InsertAdminData()
    {
        HospitalDbContext dbobj = new HospitalDbContext();
        String[] FirstnameArray = { "Durgesh", "Jyoti Prakash", "Rahul", "Khitish Kumar" };
        String[] LastnameArray = { "Sahu", "Jena", "Juneja", "Mishra" };
        String[] UsernameArray = { "durgesh", "jyoti", "rahul", "khitish" };
        string[] PasswordArray = { "durgesh@123", "jyoti@123", "rahul@123", "khitish@123" };
        bool[] IsadminArary = { true, true, true, false };
        string[] EncryptedPasswordArray = new string[10];
        for (int i = 0; i < PasswordArray.Length; i++)
        {
            byte[] plainText = Encoding.UTF8.GetBytes(PasswordArray[i]);
            byte[] cipherText = ProtectedData.Protect(plainText, null, DataProtectionScope.CurrentUser);
            EncryptedPasswordArray[i] = Convert.ToBase64String(cipherText);
        }
        for (int i = 0; i < FirstnameArray.Length; i++)
        {

            Appuser newuser = new Appuser()
            {
                FirstName = FirstnameArray[i],
                LastName = LastnameArray[i],
                Username = UsernameArray[i],
                password = EncryptedPasswordArray[i],
                Isadmin = IsadminArary[i]
            };
            dbobj.Appusertable.Add(newuser);
        }
        dbobj.SaveChangesAsync();
        return Task.CompletedTask;
    }
    public Task InsertPatientData()
    {
        
        HospitalDbContext dbobj = new HospitalDbContext();

        Console.Clear();
        System.Console.WriteLine("How Many Records do you want to insert in DataBase");
        int rec = Convert.ToInt32(System.Console.ReadLine());
        int rec1 = 0;
        int rec2 = 0;
        if (rec % 2 != 0)
        {
            rec1 = (rec / 2) + 1;
            rec2 = rec / 2;

        }
        else
        {
            rec1 = rec / 2;
            rec2 = rec / 2;
        }
        if (dbobj.patienttable.Count() != 0)
        {
            System.Console.WriteLine("Deleting Previous Data at {0} ", DateTime.Now);
            //dbobj.patienttable.RemoveRange(dbobj.patienttable);       // Takes too much of time 
            dbobj.Database.ExecuteSqlCommand("TRUNCATE TABLE patients");
        }
        string[] genderArray = { "Male", "Female" };
        string[] LastNameArray = { "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor", "Anderson", "Thomas", "Jackson", "White", "Harris", "Martin", "Thompson", "Garcia", "Martinez", "Robinson", "Clark", "Rodriguez", "Lewis", "Lee", "Walker", "Hall", "Allen", "Young", "Hernandez", "King", "Wright", "Lopez", "Hill", "Scott", "Green", "Adams", "Baker", "Gonzalez", "Nelson", "Carter", "Mitchell", "Perez", "Roberts", "Turner", "Phillips", "Campbell", "Parker", "Evans", "Edwards" };
        string[] FirstNameArray = { "John", "Jane", "Bob", "Emily", "Michael", "Jessica", "Jacob", "Emily", "Amanda", "Ashley", "Matthew", "Daniel", "Nicholas", "Anthony", "Ryan", "David", "Jacob", "Alyssa", "Joshua", "Andrew", "James", "Justin", "Joseph", "Jordan", "Christine", "Megan", "Emily", "Hannah", "Ashley", "Samantha", "Elizabeth", "Rachel", "Lauren", "Amanda", "Stephanie", "Brian", "Kevin", "Adam", "Jonathan", "Justin", "Brandon", "Frank", "Benjamin" };
        int[] useridarray = { 1, 2, 3, 4 };
        string[] CityArray = { "New York", "Los Angeles", "Chicago", "Houston", "Phoenix", "Philadelphia",
              "San Antonio", "San Diego", "Dallas", "San Jose", "Austin", "Jacksonville",
              "Fort Worth", "Columbus", "San Francisco", "Charlotte", "Indianapolis",
              "Seattle", "Denver", "Washington", "Boston", "El Paso", "Nashville",
              "Detroit", "Portland", "Memphis", "Oklahoma City", "Las Vegas", "Louisville",
              "Baltimore", "Milwaukee", "Albuquerque", "Tucson", "Fresno", "Sacramento",
              "Mesa", "Kansas City", "Atlanta", "Long Beach", "Omaha", "Raleigh",
              "Miami", "Oakland", "Minneapolis", "Tulsa", "Cleveland", "Wichita"};
        string[] AddressArray = { "1234 Main St", "5678 Elm St", "91011 Oak Ave", "12345 Pine Rd", "67890 Cedar Blvd",
                "11111 Maple St", "22222 Oak St", "33333 Pine Ave", "44444 Elm Rd", "55555 Cedar Blvd",
                "66666 Maple Ave", "77777 Oak St", "88888 Pine Rd", "99999 Elm Blvd", "100001 Cedar St",
                "200002 Maple Ave", "300003 Oak St", "400004 Pine Rd", "500005 Elm Blvd", "600006 Cedar St",
                "700007 Maple Ave", "800008 Oak St", "900009 Pine Rd", "1000010 Elm Blvd", "2000011 Cedar St",
                "3000012 Maple Ave", "4000013 Oak St", "5000014 Pine Rd", "6000015 Elm Blvd", "7000016 Cedar St",
                "8000017 Maple Ave", "9000018 Oak St", "10000019 Pine Rd", "10000020 Elm Blvd", "10000021 Cedar St",
                "10000022 Maple Ave", "10000023 Oak St", "10000024 Pine Rd", "10000025 Elm Blvd", "10000026 Cedar St",
                "10000027 Maple Ave", "10000028 Oak St", "10000029 Pine Rd", "10000030 Elm Blvd", "10000031 Cedar St"
               };
        string[] HealthIssuesArray = { "Cancer", "Heart disease", "Diabetes", "Stroke", "Lung disease", "Mental health disorders", "Infectious diseases", "Chronic obstructive pulmonary disease (COPD)", "Kidney disease", "Obesity", };
        Random rand = new Random();
        DateTime starttime = DateTime.Now;
        System.Console.WriteLine("Started adding NEW data at {0} Please wait...........", starttime);

        for (int i = 1; i <= rec1; i++)
        {
            Patient newPatient = new Patient()
            {

                FirstName = FirstNameArray[rand.Next(0, FirstNameArray.Length)] + i,
                LastName = LastNameArray[rand.Next(0, LastNameArray.Length)] + i,
                DOB = DateTime.Today,
                Gender = genderArray[rand.Next(0, genderArray.Length)],
                HealthIssues = HealthIssuesArray[rand.Next(0, HealthIssuesArray.Length)],
                Address = AddressArray[rand.Next(0, AddressArray.Length)] + i,
                City = CityArray[rand.Next(0, CityArray.Length)],
                CreatedOnDateTime = DateTime.Now,
                LastVisitDateTime = DateTime.Now,
                CreatedByUserId = useridarray[rand.Next(0, useridarray.Length)],
                UpdatedByUserId = useridarray[rand.Next(0, useridarray.Length)],
                IsDeleted = false
            };
            dbobj.patienttable.Add(newPatient);

        }

        for (int i = 1; i <= rec2; i++)
        {
            Patient Patient = new Patient()
            {

                LastName = FirstNameArray[rand.Next(0, FirstNameArray.Length)] + i,
                FirstName = LastNameArray[rand.Next(0, LastNameArray.Length)] + i,
                DOB = DateTime.Today,
                Gender = genderArray[rand.Next(0, genderArray.Length)],
                HealthIssues = HealthIssuesArray[rand.Next(0, HealthIssuesArray.Length)],
                Address = AddressArray[rand.Next(0, AddressArray.Length)] + i,
                City = CityArray[rand.Next(0, CityArray.Length)],
                CreatedOnDateTime = DateTime.Now,
                LastVisitDateTime = DateTime.Now,
                CreatedByUserId = useridarray[rand.Next(0, useridarray.Length)],
                UpdatedByUserId = useridarray[rand.Next(0, useridarray.Length)],
               IsDeleted = false
            };
            dbobj.patienttable.Add(Patient);

        }
        dbobj.SaveChanges();
        DateTime Endtime = DateTime.Now;
        System.Console.WriteLine("\n\n\n-----------------------------\tData Added Successfully at{0}--------------------------------", Endtime);
        System.Console.WriteLine("\n\n\n\n\n-----------------Total time = {0} sec-----------------------", (Endtime - starttime).ToString("ss"));

    
        return Task.CompletedTask;
    }
}
