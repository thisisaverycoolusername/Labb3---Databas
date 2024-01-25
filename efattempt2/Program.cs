using efattempt1.Models;
using efattempt2.Data;
using Microsoft.EntityFrameworkCore;
namespace efattempt2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SchoolContext dbcontext = new SchoolContext();
            var kurser = dbcontext.kurser.ToList();
            var personal = dbcontext.personal.ToList();
            var studenter = dbcontext.studenter.ToList();
            var betyg = dbcontext.betyg.ToList();

            void returnMenu()
            {
                Console.WriteLine("Klart!\n Tryck på valfri knapp för att återgå till huvudmenyn");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Återgår till huvudmenyn...");
                Thread.Sleep(3000);
                Console.Clear();
                menu();
            }
            menu();

            void menu()
            {
                Console.WriteLine("Välkommen till databas menu:n.\nVad vill du göra?");

                Console.WriteLine("1. Hämta personal\n2. Hämta elever\n3. Hämta alla elever i en viss klass\n" +
                    "4. Hämta alla betyg som satts den senaste månaden\n5. Snittbetyg i alla kurser\n" +
                    "6. Lägg till ny elev\n7. Lägg till ny personal\n8. Avsluta.");


                Console.Write("Skriv här: ");
                string menuInput = Console.ReadLine();
                int.TryParse(menuInput, out int input);
                
                switch (input)
                {
                    case 1:
                        gatherStaff();
                        break;
                    case 2:
                        gatherStudents();
                        break;
                    case 3:
                        studentsInclass();
                        break;
                    case 4:
                        assignmentLastmonth();
                        break;
                    case 5:
                        avgAssignmentclass();
                        break;
                    case 6:
                        addStudent();
                        break;
                    case 7:
                        addStaff();
                        break;
                    case 8:
                        Environment.Exit(0);
                        break;
                }

            }
            void gatherStaff()
            {
                foreach (var person in personal)
                {
                    Console.WriteLine($"{person.Förnamn} {person.Efternamn}");
                }
                returnMenu();
            }
            void gatherStudents()
            {
                foreach(var person in studenter)
                {
                    Console.WriteLine($"{person.Förnamn} {person.Efternamn} {person.Klass}");
                }
                returnMenu();
            }
            void studentsInclass()
            {
                Console.WriteLine("Vilken klass vill du se?");
                string readUser = Console.ReadLine();
               
                
                
                foreach (var person in studenter)
                {
                    //Console.WriteLine($"{person.Förnamn} {person.Efternamn} {person.Klass}");
                    if(person.Klass == readUser)
                    {
                        Console.WriteLine($"{person.Förnamn} {person.Efternamn} {person.Klass}");
                    }
                }
                returnMenu();
            }
            void assignmentLastmonth()
            {
                DateTime now = DateTime.Now;
                DateTime thisMonth = now.AddMonths(-1);
                foreach (var betyget in betyg)
                {
                    if(betyget.SattDatum <= thisMonth)
                    {
                        Console.WriteLine($"{betyget.BetygID}");
                    }
                }

                returnMenu();


            }
            void avgAssignmentclass()
            {
                using (var dbContext = new SchoolContext())
                {
                    // Hämta en lista med alla kurser och relaterade betyg
                    var kursBetygQuery = from kurs in dbContext.kurser
                                         join betyg in dbContext.betyg on kurs.KursID equals betyg.KursID into kursBetyg
                                         select new
                                         {
                                             KursID = kurs.KursID,
                                             Mattematik = kurs.Mattematik,
                                             SnittBetyg = kursBetyg.Average(b => b.Betyget), // Snittbetyg för kursen
                                             HögstaBetyg = kursBetyg.Max(b => b.Betyget),     // Högsta betyg för kursen
                                             LägstaBetyg = kursBetyg.Min(b => b.Betyget)     // Lägsta betyg för kursen
                                         };

                    // Skriv ut resultaten
                    foreach (var result in kursBetygQuery)
                    {
                        Console.WriteLine($"KursID: {result.KursID}, Mattematik: {result.Mattematik}");
                        Console.WriteLine($"Snittbetyg: {result.SnittBetyg}, Högsta betyg: {result.HögstaBetyg}, Lägsta betyg: {result.LägstaBetyg}");
                        Console.WriteLine();
                    }
                }
                returnMenu();
            }
            void addStudent()
            {
                int currentStudentid = 0;
                

                foreach(var student in studenter)
                {
                    currentStudentid = student.StudentID;
                }
                int nextid = currentStudentid + 1;
                int nextid2 = nextid;
                
                Console.WriteLine("Förnamn: ");
                string firstName = Console.ReadLine();
                Console.WriteLine("Efternamn: ");
                string lastName = Console.ReadLine();
                Console.WriteLine("Personnummer: ");
                string personnummer = Console.ReadLine();
                Console.WriteLine("Klass: ");
                string klass = Console.ReadLine();

                Studenter studenter1 = new Studenter(firstName, lastName, nextid, personnummer, klass)
                {
                    Förnamn = firstName,
                    Efternamn = lastName,
                    StudentID = nextid,
                    Personnummer = personnummer,
                    Klass = klass
                };
              
                dbcontext.studenter.Add(studenter1);
                dbcontext.SaveChanges();
                returnMenu();

            }
            void addStaff()
            {
                int currentStudentid = 0;


                foreach (var personalen in personal)
                {
                    currentStudentid = personalen.PersonID;
                }
                int nextid = currentStudentid + 1;
                int nextid2 = nextid;
                string userRole = "";

                Console.WriteLine("Vilken roll? \n1. Lärare \n2. Administratör \n3. Rektor \n4. Annat");
                string userInput = Console.ReadLine();
                Int32.TryParse(userInput, out int result);
                switch(result)
                {
                    case 1:
                        userRole = "Lärare";
                        break;
                    case 2:
                        userRole = "Administratör";
                        break;
                    case 3:
                        userRole = "Rektor";
                        break;
                    case 4:
                        userRole = "Annat";
                        break;


                }

                Console.WriteLine("Förnamn: ");
                string firstName = Console.ReadLine();
                Console.WriteLine("Efternamn: ");
                string lastName = Console.ReadLine();
                Console.WriteLine("Personnummer: ");
                string personnummer = Console.ReadLine();


                Personal personal1 = new Personal(userRole, firstName, lastName, personnummer, nextid) 
                {
                    Befattning = userRole,
                    Förnamn = firstName,
                    Efternamn = lastName,
                    Personnummer = personnummer,
                    PersonID = nextid
                };
                
                dbcontext.personal.Add(personal1);
                dbcontext.SaveChanges();
                returnMenu();
            }
        }
    }
}


