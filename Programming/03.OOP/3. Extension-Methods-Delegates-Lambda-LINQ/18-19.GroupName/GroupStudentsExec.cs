namespace GroupName
{
    using System;

    public class GroupStudentsExec
    {
        public static void Main()
        {
            var students = new Students()
            {
                new Student("Goshko Petrov", "Mathematics"),
                new Student("Petarcho Nikolov", "Mathematics"),
                new Student("Sashko Sashev", "Physics"),
                new Student("Zuni Piperov", "History"),
                new Student("Niki Hikolaev", "Physics"),
                new Student("Nasko Ahtov", "Biology"),
                new Student("Menti Kapeli", "History"),
            };

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Grouped students by using LINQ: ");
            foreach (var studentGroup in students.GroupByGroupNameLinq())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(studentGroup.Key);
                Console.ForegroundColor = ConsoleColor.White;
                foreach (var student in studentGroup)
                {
                    Console.WriteLine("\t{0}", student.FullName);
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Grouped students by using Extension methods: ");
            foreach (var studentGroup in students.GroupByGroupNameExt())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(studentGroup.Key);
                Console.ForegroundColor = ConsoleColor.White;
                foreach (var student in studentGroup)
                {
                    Console.WriteLine("\t{0}", student.FullName);
                }
            }
        }
    }
}