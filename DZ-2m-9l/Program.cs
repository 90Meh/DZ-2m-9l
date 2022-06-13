using System;

namespace DZ_2m_9l
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Calculate();
            }

            catch (Exception)
            {
                Console.WriteLine("Я не смог обработать ошибку");
            }

        }
        static void Calculate()
        {

            var startCalc = true;
            do
            {
                //Переменные 
                int firstNumberInt = 0;
                string simbol;
                int secondNumberInt = 0;
                string[] divString = { "", "☺", "" };
                int result = 0;



                //Метод получения строки и остановка выполнения программы
                Console.WriteLine("Введите выражение");

                var function = Console.ReadLine();

                if (function.ToLower() == "стоп")
                {
                    startCalc = false;
                    break;
                }

                //Разделение строки на массив
                try
                {
                    divString = function.Split(' ');
                    if (divString[0] == "" || divString[1] == "☺" || divString[2] == "")
                    {
                        throw new Exception("Выражение некорректное, попробуйте написать в формате \n a + b \n a * b  \n a - b \n a / b");
                    }
                }
                catch (IndexOutOfRangeException)

                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Выражение некорректное, попробуйте написать в формате \n a + b \n a * b  \n a - b \n a / b");
                    Console.BackgroundColor = ConsoleColor.Black;
                    continue;
                }
                catch (Exception ex)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.BackgroundColor = ConsoleColor.Black;
                    continue;
                }

                //Прроверка оператора на неверный символ
                try
                {
                    if (divString[1] == "+" || divString[1] == "-" || divString[1] == "*" || divString[1] == "/" || divString[1] == "")
                    {

                    }
                    else
                    {
                        throw new WrongOperException($"Я пока не умею работать с оператором {divString[1]}");
                    }
                }
                catch (WrongOperException wEx)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine(wEx.Message);
                    Console.BackgroundColor = ConsoleColor.Black;

                }



                //Парсим строки
                try
                {
                    firstNumberInt = int.Parse(divString[0]);
                }
                catch (Exception)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Операнд {divString[0]} не является числом");
                    Console.BackgroundColor = ConsoleColor.Black;
                    continue;
                }

                try
                {
                    secondNumberInt = int.Parse(divString[2]);
                }
                catch (Exception)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Операнд {divString[2]} не является числом");
                    Console.BackgroundColor = ConsoleColor.Black;
                    continue;
                }
                finally
                {
                    simbol = divString[1];
                }





                //Вывод программы

                try
                {
                    switch (simbol)
                    {
                        case "+":
                            result = Sum(firstNumberInt, secondNumberInt);
                            Console.WriteLine($"Ответ:{result}");
                            break;
                        case "-":
                            result = Sub(firstNumberInt, secondNumberInt);
                            Console.WriteLine($"Ответ:{result}");
                            break;
                        case "*":
                            result = Mul(firstNumberInt, secondNumberInt);
                            Console.WriteLine($"Ответ:{result}");
                            break;
                        case "/":
                            result = Div(firstNumberInt, secondNumberInt);
                            Console.WriteLine($"Ответ:{result}");
                            break;
                        case "":
                            throw new WrongOperException("Укажите в выражении оператор: +, -, *, /");

                    }

                    try
                    {
                        if (result == 13)
                        {
                            throw new ThirteenException("вы получили ответ 13!");
                        }

                    }
                    catch (ThirteenException exT)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine(exT.Message);
                        Console.BackgroundColor = ConsoleColor.Black;
                    }

                }


                catch (WrongOperException ex)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                catch (OverflowException)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Результат выражения вышел за границы int");
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                catch (DivideByZeroException)
                {
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Деление на ноль");
                    Console.BackgroundColor = ConsoleColor.Black;
                }

            } while (startCalc);
        }


        //Метод сложения
        static int Sum(int a, int b)
        {
            int c = checked(a + b);
            return c;

        }

        // Метод вычитания
        static int Sub(int a, int b)
        {
            int c = checked(a - b);
            return c;
        }
        //Метод умножения
        static int Mul(int a, int b)
        {
            int c = checked(a * b);
            return c;
        }
        //Метод деления
        static int Div(int a, int b)
        {
            int c = checked(a / b);
            return c;
        }

        //Исключение пустой оператор
        class WrongOperException : Exception
        {
            public WrongOperException(string message) : base(message)
            {

            }

        }

        //Исключение число 13
        class ThirteenException : Exception
        {
            public ThirteenException(string message) : base(message)
            {

            }

        }

    }
}
