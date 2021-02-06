using System;
using System.Collections.Generic;

namespace academy.net
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = "\n***************************";
            string menu = "\n\t1) Mostrar los números impares entre el 0 y el 100." +
                "\n\t2) Ingresar 2 números, imprima los números naturales que hay entre ambos" +
                "\n\t3) Ingresar una frase no más de 20 caracteres y mostrar cuántas vocales tiene." +
                "\n\t4) Ingresar 3 datos y decir qué clase de triángulo es." +
                "\n\t5) Mostrar los múltiplos de 3 y de 2 entre el 0 y 100." +
                "\n\t0) Exit.";

            int opcion;
            do
            {
                Console.WriteLine(line);
                Console.WriteLine(menu);
                Console.WriteLine("\nIngrese una opcion");
                opcion = int.Parse(Console.ReadLine());
                
                switch (opcion)
                {
                    case 1:
                        imprimirImpar();
                        break;
                    case 2:
                        float number1, number2;

                        Console.WriteLine("Ingrese el primer numero");
                        number1 = float.Parse(Console.ReadLine());

                        Console.WriteLine("Ingrese el segundo numero");
                        number2 = float.Parse(Console.ReadLine());

                        if (number1 == number2)
                            Console.WriteLine("numeros identicos");

                        if (number1 < number2)
                            printNaturales(number1, number2);

                        if (number1 > number2)
                            printNaturales(number2,number1);

                        break;
                    case 3:
                        Console.WriteLine("ingrese una frase");
                        string frase = Console.ReadLine();
                        if (frase.Length > 20)
                        {
                            Console.WriteLine("frase demasiado larga");
                            break;
                        }
                        else
                        {
                            countVowels(frase);
                        }
                        break;
                    case 4:
                        calcularTriangulo();
                        break;
                    case 5:
                        showMultiples();
                        break;
                    case 0:
                        break;
                    default:
                        continue;
                }
            } while (opcion != 0);
            Console.WriteLine("\nMuchas Gracias.\n\tEscuelita Dicsys.");

            //PUNTO 1
            static void imprimirImpar()
            {
                for (int i = 0; i < 100; i++)
                {
                    if (i % 2 != 0)
                    {
                        Console.WriteLine("{0}|", i);
                    }
                }
            }
            //PUNTO 2
            static void printNaturales(float first, float second)
            {
                int cont = 0;
                int contPar = 0;
                for (int i = (int)first + 1; i <= (int)second - 1; i++)
                {
                    Console.Write("{0}|", i);
                    cont++;

                    if (i % 2 == 0)
                        contPar++;
                }
                Console.WriteLine("\nHay " + cont + " cantidad de numeros");
                Console.WriteLine("\nHay "+contPar + " cantidad de pares");
            }

            //PUNTO 3
            static void countVowels(string frase)
            {
                int count = 0;
                for (int i = 0; i < frase.Length; i++)
                {
                    switch (frase[i])
                    {
                        case 'a':
                            count++;
                            break;
                        case 'e':
                            count++;
                            break;
                        case 'i':
                            count++;
                            break;
                        case 'o':
                            count++;
                            break;
                        case 'u':
                            count++;
                            break;
                    }
                }
                Console.WriteLine("\nla cantidad de vocales en la frase: " + frase + "\nes: " + count);
            }

            //PUNTO 4

            static void calcularTriangulo(){
                float[] lado = new float[3];
                float mayor = 0, aux = 0, sumar = 0;
                int i, j, flag = 0;

                for (i = 0; i < 3; i++)
                {
                    Console.WriteLine("ingrese lado " + (i + 1));
                    lado[i] = float.Parse(Console.ReadLine());
                    if (lado[i] > mayor)
                    {
                        mayor = lado[i];
                        aux = i;
                    }
                }
                for (i = 0; i < 3; i++)
                {
                    if (aux != i)
                    {
                        sumar += lado[i];
                    }
                }

                if (mayor < sumar)
                {
                    Console.WriteLine("es un triangulo");

                    for (i = 0; i < 2; i++)
                        for (j = i + 1; j < 3; j++)
                            if (lado[i] == lado[j])
                                flag++;
                    if (flag == 3)
                        Console.Write(" ---> Equilatero");
                    else
                    {
                        flag = 0;
                        for (i = 0; i < 2; i++)
                            for (j = i + 1; j < 3; j++)
                                if (lado[i] != lado[j])
                                    flag++;
                        if (flag == 3)
                            Console.Write(" ---> Escaleno");
                        else
                            Console.Write(" ---> Isosceles");
                    }
                }
                else
                {
                    Console.Write("No es un triangulo");
                }
            }

            //PUNTO 5
            static void showMultiples(){
                List<int> lista = new List<int> { };
                for (int i = 0; i < 100; i++)
                {
                    //para los multiplos tanto de 2 como de 3
                    if (i % 2 == 0 || i % 3 == 0)
                        lista.Add(i);
                    
                    /*
                     * para los multiplos de 2 y 3 
                     * if(i % 2 == 0 && i % 3 == 0)
                     * lista.Add(i);
                     */
                }

                foreach (var i in lista)
                    Console.WriteLine("{0}|", i);
                
            }

            }
        }
    }

