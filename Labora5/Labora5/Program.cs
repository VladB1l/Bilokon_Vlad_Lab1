using System;
using System.IO;



namespace Laborat1
{
    class Complex
    {
       
        public override string ToString()
        {
            return (String.Format("{0}+({1})i", realvalue, imaginary));
        }

        public double realvalue { get; }
        public double imaginary { get; }


        public Complex ComplexSum(Complex number2)
        {
            double x = realvalue + number2.realvalue;
            double y = imaginary + number2.imaginary;
            return (new Complex(x, y));
        }

        public Complex ComplexDifference(Complex number2)
        {
            double x = realvalue - number2.realvalue;
            double y = imaginary - number2.imaginary;
            return (new Complex(x, y));

        }

        public Complex ComplexProduct(Complex number2)
        {
            double firstproductx = realvalue * number2.realvalue;
            double firstproducty = imaginary * number2.imaginary;
            double secondproductx = realvalue * number2.imaginary;
            double secondproducty = imaginary * number2.realvalue;
            double resproductx = firstproductx + (firstproducty * -1);
            double resproducty = secondproductx + secondproducty;

            return (new Complex(resproductx, resproducty));
        }

        public Complex ComplexDivision(Complex number2)
        {
            double firstpart = (realvalue * number2.realvalue + (imaginary * -number2.imaginary) * -1);
            double secondpart = (realvalue * -number2.imaginary + imaginary * number2.realvalue);
            double dil = Math.Pow(number2.realvalue, 2) - Math.Pow((-number2.imaginary), 2) * -1;



            string result = $"z= ({firstpart}/{dil}) + ({secondpart}/{dil})i";
            return (new Complex(firstpart / dil, secondpart / dil));
        }


        public void ComplexTrigom(Complex number2)
        {

            double modul = Math.Sqrt(Math.Pow(realvalue, 2) + Math.Pow(imaginary, 2));

            if (realvalue > 0 && imaginary > 0 || realvalue > 0 && imaginary < 0)
            {

                Console.WriteLine($"Тригонометрическая форма первого комплексного числа:\n " +
                    $"{modul}*(cos(arctg({imaginary}/{realvalue}))+sin(arctg({imaginary}/{realvalue}))*i)");
            }
            if (realvalue < 0 && imaginary > 0)
            {
                Console.WriteLine($"Тригонометрическая форма первого комплексного числа:\n " +
                    $"{modul}*(cos(pi + arctg({imaginary}/{realvalue}))+sin(pi + arctg({imaginary}/{realvalue}))*i)");
            }
            if (realvalue < 0 && imaginary < 0)
            {
                Console.WriteLine($"Тригонометрическая форма первого комплексного числа:\n " +
                   $"{modul}*(cos(-pi + arctg({imaginary}/{realvalue}))+sin(-pi + arctg({imaginary}/{realvalue}))*i)");
            }
        }

        public void ComplexEsxpo(Complex number2)
        {

            double modul = Math.Sqrt(Math.Pow(realvalue, 2) + Math.Pow(imaginary, 2));

            if (realvalue > 0 && imaginary > 0 || realvalue > 0 && imaginary < 0)
            {

                Console.WriteLine($"Экспоненциальная форма первого комплексного числа:\n " +
                    $"{modul}*(e^(arctg({imaginary}/{realvalue})*i))");
            }
            if (realvalue < 0 && imaginary > 0)
            {
                Console.WriteLine($"Экспоненциальная форма первого комплексного числа:\n " +
                    $"{modul}*(e^(pi + arctg({imaginary}/{realvalue})*i))");
            }
            if (realvalue < 0 && imaginary < 0)
            {
                Console.WriteLine($"Экспоненциальная форма первого комплексного числа:\n " +
                   $"{modul}*(e^(-pi + arctg({imaginary}/{realvalue})*i))");
            }
            Console.WriteLine(" ");
        }

       /* public void Serialize(Complex complex1, Complex complex2)
        {
            string jsonStringSF = JsonSerializer.Serialize(complex1);
            string jsonStringSS = JsonSerializer.Serialize(complex2);
            File.WriteAllText("Serialization1.json ", jsonStringSF);  //serialization
            File.WriteAllText("Serialization2.json ", jsonStringSS);
            Console.WriteLine(jsonStringSF + "\n" + jsonStringSS);

        }*/


    }
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Введите данные первого комплексного числа");
            Console.WriteLine("Real: ");
            int realvalue1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Imagine: ");
            int imaginary1 = Convert.ToInt32(Console.ReadLine());
            Complex complex1 = new Complex(realvalue1, imaginary1);


            Console.WriteLine("Данные для второго комплексного числа берутся из файла:");
            string fileName = "Deserialization.json ";
            string jsonStringD = File.ReadAllText(fileName);   //deserialization
            /*Complex complexjson = JsonSerializer.Deserialize<Complex>(jsonStringD);*/
            Console.WriteLine(jsonStringD);


            /*double realvalue2 = complexjson.realvalue;
            double imaginary2 = complexjson.imaginary;
            Complex complex2 = new Complex(realvalue2, imaginary2);*/
            Console.WriteLine("Введите данные первого комплексного числа");
            Console.WriteLine("Real: ");
            int realvalue2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Imagine: ");
            int imaginary2 = Convert.ToInt32(Console.ReadLine());
            Complex complex2 = new Complex(realvalue2, imaginary2);

            Console.WriteLine("Сумма двух комплексных чисел:\n" + complex1.ComplexSum(complex2));
            /*  complex1.ComplexDifference(complex2);
              complex1.ComplexProduct(complex2);*/
            Console.WriteLine("Разница двух комплексных чисел:\n" + complex1.ComplexDifference(complex2));
            Console.WriteLine("Умножение двух комплексных чисел:\n" + complex1.ComplexProduct(complex2));
            Console.WriteLine("Диление двух комплексных чисел:\n" + complex1.ComplexDivision(complex2));

            Console.WriteLine("Хотите перевести первое комплексное число в другую форму?");
            Console.WriteLine("1-ДА\t2-НЕТ");
            int m = Convert.ToInt32(Console.ReadLine());
            if (m == 1)
            {
                Console.WriteLine("1. Перевести в тригонометрическую;");
                Console.WriteLine("2. Перевести в экспоненциальную;");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        complex1.ComplexTrigom(complex2);
                        break;
                    case 2:
                        complex1.ComplexEsxpo(complex2);
                        break;
                    default:
                        Console.WriteLine("Error!");
                        break;
                }
            }
            else
            {
                Console.WriteLine("");
            }
            Console.WriteLine("\nИнформация, про два комплексных  числа, записана в файл");
           /* complex1.Serialize(complex1, complex2);*/

        }

    }
}
