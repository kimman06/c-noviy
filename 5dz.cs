using System;

ShowWelcome();
static  void ShowWelcome()
{
    Console.WriteLine("Welcome to C# MEDHODIS");
}


ShowGreeting("ali");
ShowGreeting("Madina");
static void ShowGreeting(string name)
{
    Console.WriteLine($"HELLO, {name}!");
}


int passingscore = GetPassingScore();
Console.WriteLine($"Passingscore, {passingscore}");
static int GetPassingScore()
{
    return 60;
}

Console.WriteLine(Add(4, 7));
Console.WriteLine(Add(0, 5));
Console.WriteLine(Add(-3, 3));

static int Add(int first, int second)
{
    return first + second;
}


Console.WriteLine(CreateOrderMessage("Book", 2));
Console.WriteLine(CreateOrderMessage("Pen", 5));

static string CreateOrderMessage(string product, int quantity)
{
    return $"Order: {quantity} {product}";
}


ShowTicket(-1, false);
ShowTicket(121, true);
ShowTicket(6, true);
ShowTicket(7, false);
ShowTicket(60, true);
ShowTicket(61, true);

static void ShowTicket(int age, bool isWeekend)
{
    int price = GetTicketPrice(age, isWeekend);

    if (price == -1)
    {
        Console.WriteLine("Invalid age");
    }
    else if (price == 0)
    {
        Console.WriteLine("Free");
    }
    else
    {
        Console.WriteLine(price);
    }
}

static int GetTicketPrice(int age, bool isWeekend)
{
    if (age < 0 || age > 120)
    {
        return -1;
    }

    if (age < 7)
    {
        return 0;
    }

    int price = isWeekend ? 15000 : 10000;

    if (isWeekend && age > 60)
    {
        price = price * 80 / 100;
    }

    return price;
}


ShowDivision(17, 5);
ShowDivision(12, 3);
ShowDivision(8, 0);

static void ShowDivision(int number, int divisor)
{
    if (TryDivide(number, divisor, out int quotient, out int remainder))
    {
        Console.WriteLine($"Quotient: {quotient}; Remainder: {remainder}");
    }
    else
    {
        Console.WriteLine("Cannot divide by zero.");
    }
}

static bool TryDivide(int number, int divisor, out int quotient, out int remainder)
{
    if (divisor == 0)
    {
        quotient = 0;
        remainder = 0;
        return false;
    }

    quotient = number / divisor;
    remainder = number % divisor;
    return true;
}


ShowBonus(70, 20);
ShowBonus(95, 10);
ShowBonus(40, 0);
ShowBonus(105, 5);
ShowBonus(50, -1);

static void ShowBonus(int score, int bonus)
{
    int before = score;
    AddBonus(ref score, bonus);
    Console.WriteLine($"Before: {before}; After: {score}");
}

static void AddBonus(ref int score, int bonus)
{
    if (score < 0 || score > 100 || bonus < 0 || bonus > 30)
    {
        return;
    }

    score += bonus;

    if (score > 100)
    {
        score = 100;
    }
}


ShowSale(20, 5);
ShowSale(10, 10);
ShowSale(10, 12);
ShowSale(5, -1);

static void ShowSale(int stock, int quantity)
{
    bool success = TrySellItems(ref stock, quantity);
    Console.WriteLine($"Success: {success}; Stock: {stock}");
}

static bool TrySellItems(ref int stock, int quantity)
{
    if (stock < 0 || quantity < 0 || quantity > stock)
    {
        return false;
    }

    stock -= quantity;
    return true;
}



ShowStats(8, 3, 5);
ShowStats(9, 2, 6);
ShowStats(4, 4, 1);
ShowStats(7, 7, 7);

static void ShowStats(int first, int second, int third)
{
    GetNumberStats(first, second, third, out int min, out int middle, out int max);
    Console.WriteLine($"Min: {min}; Middle: {middle}; Max: {max}");
}

static void GetNumberStats(int first, int second, int third,
                           out int min, out int middle, out int max)
{
    min = first;
    if (second < min) min = second;
    if (third < min) min = third;

    max = first;
    if (second > max) max = second;
    if (third > max) max = third;

    middle = first + second + third - min - max;
}
