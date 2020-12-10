using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

namespace Final_NakasoneF
{
    class Program
    {

        public static void Main(string[] args)
        {
            Stack patente = null;
            patente = new Stack();


            Console.WriteLine("======================");
            Console.WriteLine(" CONTROL DE PATENTES ");
            Console.WriteLine("======================");
            Console.WriteLine("\nBienvenido!");
            

            string opcion = "0";

            //ciclo qi¥ue se repetira hasta que el usuario quiera salir
            while (opcion != "11") 
            {
                Console.Clear();
                Console.WriteLine("\nMENU PRINCIPAL\n" +
                                  "\n1) Crear Pila" +
                                  "\n2) Borrar Pila" +
                                  "\n3) Agregar Patente" +
                                  "\n4) Borrar Patente" +
                                  "\n5) Lista de Patentes" +
                                  "\n6) Listar última patente" +
                                  "\n7) Listar primera patente" +
                                  "\n8) Cantidad de Patentes" +
                                  "\n9) Imprimir Registro" +
                                  "\n10) Buscador" +
                                  "\n0) Salir");
                Console.Write("\nElija una opcion: ");
                opcion = Console.ReadLine();

                switch (opcion) //Menu de opciones
                {
                    case "1":
                        CreateStack(patente);
                        break;
                    case "2":
                        DeleteStack(patente);
                        break;
                    case "3":
                        Add(patente);
                        break;
                    case "4":
                        Delete(patente);
                        break;
                    case "5":
                        Read(patente);
                        break;
                    case "6":
                        ultimaPatente(patente);
                        break;
                    case "7":
                        primeraPatente(patente);
                        break;
                    case "8":
                        totalPatentes(patente);
                        break;
                    case "9":
                        CrearArchivo(patente);
                        break;
                    case "10":
                        Buscar(patente);
                        break;
                    case "11":
                        Console.WriteLine("\nHa salido del programa");
                        return;
                    default:
                        Console.WriteLine("ERROR: La opción ingresada no es válida");
                        break;
                }
                Console.WriteLine("\nPresione cualquier tecla para continuar.");
                Console.ReadKey();
            }

         
        }

        //1)funcion que crea una pila por defecto
        public static void CreateStack(Stack patente)
        {
            int count = 0; //cree el contsdor para que me enumere las patentes agregadas a la pila

            patente.Push("GFN293");
            patente.Push("FLV439");
            patente.Push("RSV694");
            patente.Push("VOG456");
            patente.Push("AXP205");
            patente.Push("TDL390");


            Console.WriteLine("Patentes cargadas en el sistema: ");
            foreach (string i in patente) // recorremos cada elemento de la pila
            {
                count++; //incrementamos el valor del contador
                Console.Write($"{count}- {i}\n");
          
            }
        }

        //2)funcion para borrar la pila
        public static void DeleteStack(Stack patente)
        {
            if (patente == null) //igualamos a nulo, para ver si tiene valores la pila
            {
                Console.WriteLine("No hay patentes disponibles.");
            }
            else
            {
                patente.Clear(); //se borra la pila
                Console.WriteLine("La pila ha sido borrada");
            }
        }

        //3)funcion para agregar una patente a la pila
        public static void Add(Stack patente)
        {
            Console.WriteLine("Ingrese la patente: ");
            string PatenteNueva = Console.ReadLine();

            if (PatenteNueva.Length == 6) //condicion que sean 6 caracteres
            {
                bool estado = Regex.IsMatch(PatenteNueva, @"^[A-Z]{3}[0-9]{3}$"); //validacion de datos alfanumericos por medio de expresiones regulares
                if (estado) 
                {
                    bool isLetter = false; 
                    for (int i = 0; i < 3; i++) //ciclo para recorrer los primeros 3 valores
                    {
                        isLetter = Char.IsLetter(PatenteNueva, i);
                        if (!isLetter)
                            break;
                    }
                    if (isLetter) //para corroborar que esos sean valores alfabeticos
                    {
                        patente.Push(PatenteNueva);//se agrega la patente
                        Console.WriteLine(PatenteNueva + ": " + estado + " - Patente AGREGADA -");
                    }
                    else
                    {
                        Console.WriteLine("Deben ser 3 letras seguidos de 3 numeros");
                    }
                }
                else
                {
                    Console.WriteLine("Solo letras mayusculas y numeros");
                }
            }
            else
            {
                Console.WriteLine("Deben ser 6 digitos");
            }
        }

        //4)funcion para borrar la ultima patente de la pila
        public static void Delete(Stack patente)
        {
            Console.WriteLine($"Patente eliminada\t{patente.Pop()}");
            
        }


        //5)funcion para listar todas las patentes (de la ultima a la primera)
        public static void Read(Stack patente)
        {
            int contador = patente.Count; //el contador inicia en el valor de la cant de elemtos
            Console.WriteLine("Patentes cargadas en el sistema: ");

            foreach (string i in patente) // recorremos cada elemento de la pila
            {
                Console.Write($"{contador}- {i}\n");
                contador--; //decrece en uno en cada ciclo

            }

        }

        //6)funcion para mostrar la ultima patente agregada
        public static void ultimaPatente(Stack patente)
        {
            Console.WriteLine($"Ultima patente agregada: {patente.Peek()}");
        }

        //7)funcion para mostrar la primera patente agregada
        public static void primeraPatente(Stack patente)
        {
            Console.WriteLine($"Primera patente agregada: {patente.ToArray()[patente.Count - 1]}");
        }                       //

        //8)funcion para mostrar la cant de patentes
        public static void totalPatentes(Stack patente)
        {
            Console.WriteLine($"Total de patentes cargadas: {patente.Count}");
        }


        //9)funcion para crear un archivo con las patentes
        public static void CrearArchivo(Stack patente)
        {
            try
            {
                Console.WriteLine("Ingrese el nombre del archivo: "); //Te pide el nombre del archivo

                string fileName = Console.ReadLine() + ".txt";  //Agrega extension

                StreamWriter writer = File.CreateText(fileName);

                DateTime today = DateTime.Now;  //Usamos datetime para agregar la fecha al archivo
                DateTime dateonly = today.Date;

                writer.WriteLine($"PATENTES CARGADAS // {today.ToString("MM/dd/yyyy HH:mm")}"); //Titulo del archivo



                foreach (string i in patente)  //Print de todos los productos
                {

                    writer.WriteLine(i);

                }

                writer.Close(); //Cierro archivo

                FileInfo file = new FileInfo(fileName); //Uso file info para acceder a informacion del archivo y luego poder consultar el directorio
                DirectoryInfo dir = file.Directory; //Guardo el directorio en una variable para indicarselo al usuario

                Console.WriteLine($"\nEl archivo {fileName} esta listo para imprimir en la ruta {dir}.");
            }

            catch (IOException) //Atrapa el error al manipular el archivo si es que hay
            {
                Console.WriteLine("\nError con el archivo.");
            }

        }

        //10)funcion para buscar una patente
        public static void Buscar(Stack patente)
        {
            bool resultado = false; //variable para que nos devuelva si esta o no 

            Console.WriteLine("Ingrese la patente deseada:  ");
            string patenteBuscada = Convert.ToString(Console.ReadLine());

            resultado = patente.Contains(patenteBuscada); //busca un elemento en la pila
            if (resultado)
            {
                Console.WriteLine($"La patente {patenteBuscada} se encuentra en la pila");
            }
            else
            {
                Console.WriteLine("Esa patente no se encuentra en la pila");
            }
            

        }

    }

}



