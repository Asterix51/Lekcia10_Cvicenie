namespace Lekcia10_Cvicenie
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<int> Grades { get; set; }

    }


    internal class Program
    {
        static void Main(string[] args)
        {
            // Vytvorenie vzorových dát
            var random = new Random();
            var names = new List<string> { "Alice_", "Bob_", "Charlie_", "Diana_", "Edward_", "Fiona_", "George_", "Hannah_", "Ian_", "Julia_" };
            var students = new List<Student>();

            for (int i = 0; i < 100; i++)
            {
                var student = new Student
                {
                    Name = names[random.Next(names.Count)] + i,
                    Age = random.Next(18, 25),
                    Grades = new List<int> { random.Next(20, 100), random.Next(50, 100), random.Next(70, 100) }
                };
                students.Add(student);
            }

                // LINQ metódy

                // a. Select - získanie zoznamu mien všetkých študentov
                var studentNames = students.Select(s => s.Name).ToList();
                Console.WriteLine("Meno študentov:");
                studentNames.ForEach(name => Console.WriteLine(name));

                // b. Where - filtrovanie študentov s aspoň jednou známkou > 90
                var highGradeStudents = students.Where(s => s.Grades.Any(g => g > 90)).ToList();
                Console.WriteLine("\nŠtudenti s aspoň jednou známkou > 90:");
                highGradeStudents.ForEach(s => Console.WriteLine(s.Name));

                // c. Any - existuje študent, ktorý má všetky známky > 80
                var allGradesAbove80 = students.Any(s => s.Grades.All(g => g > 80));
                Console.WriteLine($"\nExistuje študent s všetkými známkami > 80: {(allGradesAbove80 ? "Áno" : "Nie")}");


                // d. SelectMany - získanie zoznamu všetkých známok všetkých študentov
                var allGrades = students.SelectMany(s => s.Grades).ToList();
                Console.WriteLine("\nVšetky známky všetkých študentov:");
                students.ForEach (s =>
                    {
                        Console.WriteLine($"Študent: {s.Name}, Vek: {s.Age}");
                        Console.WriteLine($"Známky: {string.Join(", ", s.Grades)}\n");
                    });

                // e. OrderBy - zoradenie študentov podľa veku
                var studentsOrderedByAge = students.OrderBy(s => s.Age).ToList();
                Console.WriteLine("\nŠtudenti zoradení podľa veku:");
                studentsOrderedByAge.ForEach(s => Console.WriteLine($"{s.Name}, Vek: {s.Age}"));
            
        }
    }
}
