// Задача 19
// Напишите программу, которая принимает на вход пятизначное число и проверяет, является ли оно палиндромом.
// 14212 -> нет
// 12821 -> да
// 23432 -> да

Console.WriteLine("Welcome to the palindrome checker application! \nPlease, insert five-digit number for checking:");
var input = Console.ReadLine();
#region InputCheck
if (input?[0] == '-')
{
    input = input.Substring(1);
}

var errors = new List<string>();
if (CheckIsWrongCount(input, 5, errors) | CheckIsNotInteger(input, errors))
{
    foreach (var error in errors)
    {
        Console.WriteLine(error);
    }

    return;
}
#endregion
for (var i = 0; i < 3; i++)
{
    if (input[i] != input[4 - i])
    {
        Console.WriteLine("No, inserted number is not a palindrome!");
        return;
    }
}

Console.WriteLine("Yes, inserted number is a palindrome!");

static bool CheckIsWrongCount(string input, int count, List<string> errors)
{
    if (input?.Length != count)
    {
        errors.Add($"Inserted value must contain {count} symbols");
        return true;
    }

    return false;
}

static bool CheckIsNotInteger(string input, List<string> errors)
{
    if (!int.TryParse(input, out _))
    {
        errors.Add($"Inserted value is not an integer");
        return true;
    }

    return false;
}