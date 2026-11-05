using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== 1. ShowName ===");
        ShowName("  Malika  ");
        ShowName("A");
        ShowName("");
        ShowName("   ");

        Console.WriteLine("\n=== 2. ShowGrades ===");
        ShowGrades(new int[] { 80, 90, 100 });
        ShowGrades(new int[] { 80, 81 });
        ShowGrades(new int[0]);

        Console.WriteLine("\n=== 3. ShowSelectedGrade ===");
        int[] g3 = { 80, 90, 100 };
        foreach (int n in new int[] { 1, 3, 0, -1, 4 })
            ShowSelectedGrade(g3, n);
        ShowSelectedGrade(new int[0], 1);

        Console.WriteLine("\n=== 4. List: qo'shish va almashtirish ===");
        List<string> students = new List<string> { "Ali", "Vali" };
        students.Add("Malika");
        students.AddRange(new string[] { "Aziza", "Ali" });
        students[1] = "Valijon";
        Console.WriteLine($"Count: {students.Count}");
        Console.WriteLine($"Capacity >= Count: {students.Capacity >= students.Count}");
        Console.WriteLine(string.Join(", ", students));
        // Izoh: ikkinchi "Ali" qoldi, chunki List takrorlarga ruxsat beradi.

        Console.WriteLine("\n=== 5. Find ===");
        ShowFirstMa(new List<string> { "Ali", "Malika", "Madina" });
        ShowFirstMa(new List<string> { "Ali", "Vali" });
        ShowFirstMa(new List<string>());
        // Izoh: Find birinchi mos elementda to'xtaydi, Malika Madinadan oldin turibdi.

        Console.WriteLine("\n=== 11. O'tish bali ===");
        CountPassed(new int[] { 45, 60, 90, 59, 100 });
        CountPassed(new int[] { 60 });
        CountPassed(new int[] { 0, 20, 59 });
        CountPassed(new int[0]);
        // Izoh: > 60 bo'lsa, aynan 60 olgan talaba noto'g'ri "o'tmadi" deb hisoblanardi.

        Console.WriteLine("\n=== 12. Baholarni ajratish ===");
        FilterGrades(new List<int> { 75, 90, 80, 60, 90 });
        FilterGrades(new List<int> { 80 });
        FilterGrades(new List<int> { 40, 55 });
        FilterGrades(new List<int>());
        // Izoh: HashSet takrorlarni olib tashlaydi va tartibni kafolatlamaydi; bizga ikkalasi kerak.
    }

    // 1
    static void ShowName(string studentName)
    {
        string cleanName = studentName.Trim();
        if (string.IsNullOrWhiteSpace(cleanName))
        {
            Console.WriteLine("Ism bo'sh.");
            return;
        }
        Console.WriteLine($"Ism: {cleanName}; Length: {cleanName.Length}; Birinchi: {cleanName[0]}");
        // Asl studentName o'zgarmaydi: string o'zgarmas, Trim yangi matn qaytaradi.
    }

    // 2
    static void ShowGrades(int[] grades)
    {
        for (int i = 0; i < grades.Length; i++)
            Console.WriteLine($"{i + 1}-baho: {grades[i]}");

        int total = 0;
        foreach (int grade in grades)
            total += grade;
        Console.WriteLine($"Jami: {total}");

        if (grades.Length > 0)
        {
            double average = (double)total / grades.Length;
            Console.WriteLine($"O'rtacha: {average.ToString(CultureInfo.InvariantCulture)}");
        }
        else
        {
            Console.WriteLine("Baholar hali yo'q.");
        }
    }

    // 3
    static void ShowSelectedGrade(int[] grades, int gradeNumber)
    {
        if (gradeNumber < 1 || gradeNumber > grades.Length)
        {
            Console.WriteLine("Raqam noto'g'ri.");
            return;
        }
        Console.WriteLine($"{gradeNumber}-baho: {grades[gradeNumber - 1]}");
    }

    // 5
    static bool StartsWithMa(string studentName)
    {
        return studentName.StartsWith("Ma");
    }

    static void ShowFirstMa(List<string> list)
    {
        string? found = list.Find(StartsWithMa);
        Console.WriteLine(found ?? "Talaba topilmadi.");
    }

    // 11
    static void CountPassed(int[] grades)
    {
        int passed = 0;
        int failed = 0;
        foreach (int grade in grades)
        {
            if (grade >= 60) passed++;
            else failed++;
        }
        Console.WriteLine($"O'tganlar: {passed}; O'tmaganlar: {failed}");
    }

    // 12
    static void FilterGrades(List<int> grades)
    {
        List<int> selectedGrades = new List<int>();
        foreach (int grade in grades)
        {
            if (grade >= 80)
                selectedGrades.Add(grade);
        }

        if (selectedGrades.Count == 0)
            Console.WriteLine("Mos baholar yo'q.");
        else
            Console.WriteLine($"Yangi: {string.Join(", ", selectedGrades)}");
        Console.WriteLine($"Yangi Count: {selectedGrades.Count}; Asl: {string.Join(", ", grades)}");
    }
}
