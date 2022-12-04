/* 
ЗАДАЧА:
Написать программу, которая из имеющегося массива строк формирует массив из строк, 
длина которых либо меньше либо равна 3 символа. Первоначальный массив можно ввести с клавиатуры, 
либо задать на старте выполнения алгоритма.
При решение не рекомендуется пользоваться коллекциями, лучше обойтись исключительно массивами.

Примеры:
["hello", "2", "world", ":-)"] -> ["2", ":-)"]
["1234", "1567", "-2", "computer science"] -> ["-2"]
["Russia", "Denmark", "Kazan"] -> []
*/

#nullable disable  // отключаем предупреждения о NULL
Console.Clear();
Console.Write("Укажите каким способом задается массив: \n 1) Пример №1 из задачи \n " +
"2) Пример №2 из задачи \n 3) Пример №3 из задачи \n 4) Ввод с клавиатуры \n 5) Случайная генерация \n\n");

int strLen = 3;  // Искомая длинна строк в массиве по условию задачи # 3
int min = 1;  // Начальное значение диапазона для метода isRange(int, int, int) # 1
int max = 5;  // Конечное значение диапазона для метода isRange(int, int, int) # 5

int input = intInputCheck();  // Ввод и проверка правильности ввода (целое число) методом intInputCheck()
int inputChecked = isRange(input, min, max);  // Проверка введенного числа на соответствие обозначенного диапазону

string[] array = getArray(inputChecked);  // Объявление массива методом getArray(int)
string[] newArray = getNewArray(array, strLen);  // Объявление нового массива при помощи метода getNewArray(str[])

//Console.Write("\nРезультат:\n");
showArray(array);  // Вывод изначального массива на экран.
Console.Write(" -> ");
showArray(newArray);  // Вывод итогового массива на экран.
Console.WriteLine();


/************************ МЕТОДЫ НАЧАЛО ************************/

// Метод проверяет, является ли целым числом вводимые пользователем данные,
// иначе возвращает пользователя к повторному вводу.
//
int intInputCheck()
{
    string text = String.Empty;
    while (true)
    {
        Console.Write("Введите число: ");
        text = Console.ReadLine();
        if (int.TryParse(text, out int number))
        {
            return number;
        }
        else
        {
            Console.WriteLine("Ошибка ввода! Повторите попытку.\n");
        }
    }
}

// Метод проверяет находится ли введенное число в диапазоне [min; max],
// иначе возвращает пользователя к повторному вводу.
// value - входящее значение вводимое пользователем
// min, max - минимальное и максимальное значения диапазона
// 
int isRange(int value, int min, int max)
{
    while (true)
    {
        if (value >= min && value <= max)
        {
            return value;
        }
        else
        {
            Console.Write($"Введите число от {min} до {max}.\n\n");
        }
        value = intInputCheck();
    }
}

// Метод содержит варианты ввода массива:
//  Ввод строк массива пользователем самостоятельно;
//  Три варианта примера из условия задачи;
//  Пустой массив (для быстрого завершения);
//  Рандомная генерация строк массива с различной длинной от 1 до 9 символов.
// arrayNum - передаваемое число (номер варианта ввода массива)
//
string[] getArray(int arrayNum)
{
    if (arrayNum == 1)
    {
        Console.Write("\nПример №1 из задачи:\n");
        return new string[] { "hello", "2", "world", ":-)" };  // ["hello", "2", "world", ":-)"] -> ["2", ":-)"]
    }
    else if (arrayNum == 2)
    {
        Console.Write("\nПример №2 из задачи:\n");
        return new string[] { "1234", "1567", "-2", "computer science" };  // ["1234", "1567", "-2", "computer science"] -> ["-2"]
    }
    else if (arrayNum == 3)
    {
        Console.Write("\nПример №3 из задачи:\n");
        return new string[] { "Russia", "Denmark", "Kazan" };  // ["Russia", "Denmark", "Kazan"] -> []
    }
    else if (arrayNum == 4)
    {
        Console.Write("\nВвод с клавиатуры:\n");
        Console.Write("Укажите размер массива.\n");
        int size = intInputCheck();
        string[] arrayElement = new string[size];
        for (int i = 0; i < size; i++)
        {
            Console.Write($"Введите {i + 1}-й элемент массива: ");
            arrayElement[i] = Convert.ToString(Console.ReadLine());
        }
        return arrayElement;
    }
    else
    {
        Console.Write("\nСлучайная генерация:\n");
        char symbol;
        string[] array = new string[new Random().Next(0, 10)];
        for (int i = 0; i < array.Length; i++)
        {
            symbol = Convert.ToChar(new Random().Next(Convert.ToInt32('a'), Convert.ToInt32('z') + 1));
            array[i] = new string(symbol, new Random().Next(1, 10));
        }
        return array;
    }
}

// Возвращает массив, сформированный из передаваемого в метод массива для поиска строк, 
// которые меньше или равны искомой передаваемой длине. Если в передаваемом массиве нет 
// элементов удовлетворяющих условию поиска, метод возвращает пустой массив. 
// array - входящий массив для выборки элементов в новый массив.
// len - искомая длинна строки.
// 
string[] getNewArray(string[] array, int len)
{
    string[] newArray = { };
    int size = getNewArraySize(array, len);
    if (size > 0)
    {
        newArray = new string[size];
        int i, k;
        for (i = k = 0; i < array.Length && k < newArray.Length; i++)
        {
            if (array[i].Length <= len)
            {
                newArray[k] = array[i];
                k++;
            }
        }
    }
    return newArray;
}

// Метод для определения длинны нового массива.
// array - входящий массив для определения длины нового массива
// в соответствии с поисковым условием (len).
// len - искомая длинна строки.
// 
int getNewArraySize(string[] array, int len)
{
    int result = 0;
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i].Length <= len)
        {
            result++;
        }
    }
    return result;
}

// Метод вывода массива в консоль. Если массив пуст метод выводит "[]".
// array - входящий массив для печати.
// 
void showArray(string[] array)
{
    if (array.Length == 0)
    {
        Console.Write("[]");
    }
    else
    {
        Console.Write("[\"" + String.Join("\", \"", array) + "\"]");
    }
}

/************************ МЕТОДЫ КОНЕЦ ************************/