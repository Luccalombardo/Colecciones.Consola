





using System.Linq;

namespace List.Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listaNro = new List<int>();
            bool seguir;
            string preg;
            int elementList = GetInt("Ingrese la cantidad de elementos que quiere introducir: ");
            for (int i = 0; i < elementList; i++)
            {
                int nroList = GetInt($"Ingrese el numero para el elemento nro {i+1}: ");
                listaNro.Add(nroList);
            }
            int CantidadIndex = listaNro.Count;

            //Insertar en lista
            OpcionContin("¿Desea insertar algun numero?");
            string confirmarAccion = GetStringPreg("Ingrese la opcion: ");
            bool entrar = false;
            if (confirmarAccion.ToUpper() == "S")
            {
                 entrar = true;
            }
            if (entrar)
            {
                
                seguir = true;
                do
                {

                    Console.WriteLine($"Hay {CantidadIndex - 1} indices");
                    int indexList = GetIntMax("Ingresa el indice en el que quiere ingresar el nro: ", CantidadIndex);
                    int nroList = GetInt($"Ingrese el nro que quiere poner en la lista en el indice nro {indexList}: ");
                    listaNro.Insert(indexList, nroList);


                    CantidadIndex = listaNro.Count();
                    OpcionContin("¿Desea continuar ingresando algun otro numero a la lista?(Ponga la letra segun la opcion)");
                    preg = GetStringPreg("Ingrese la opcion: ");
                    if (preg.ToUpper() == "N")
                    {
                        seguir = false;
                    }
                    EsperarTecla();
                } while (seguir);
            }

            //Eliminar de la lista
            OpcionContin("¿Desea eliminar algun numero?");
            confirmarAccion = GetStringPreg("Ingrese la opcion: ");
            entrar = false;
            if (confirmarAccion.ToUpper() == "S")
            {
                entrar = true;
            }
            if (entrar)
            {
                seguir = true;
                do
                {

                    Console.WriteLine($"Hay {CantidadIndex - 1} indices");

                    int nroList = GetInt($"Ingrese el nro que quieres eliminar: ");
                    bool existe = false;
                    for (int i = 0; i < CantidadIndex; i++)
                    {

                        if (nroList == listaNro[i])
                        {
                            existe = true;
                        }

                    }
                    if (existe == false)
                    {
                        Console.WriteLine("El nro ingresado no existe");
                    }
                    listaNro.Remove(nroList);

                    CantidadIndex = listaNro.Count();



                    Console.WriteLine("");

                    OpcionContin("¿Desea eliminar algo de la lista?(Ponga la letra segun la opcion)");
                    preg = GetStringPreg("Ingrese la opcion: ");
                    if (preg.ToUpper() == "N")
                    {
                        seguir = false;
                    }
                    EsperarTecla();
                } while (seguir);
            }
            Console.WriteLine("Numeros desordenados");
            Console.WriteLine("Sali");
            foreach (int i in listaNro) {
                Console.WriteLine($"Esta el nro {i}");
            }
            listaNro.Sort();
            Console.WriteLine("Numeros en orden");
            foreach (int i in listaNro)
            {
                
                Console.WriteLine($"Esta el nro {i}");
            }
            EsperarTecla();

            //Verifica si un número específico está en la lista.
            OpcionContin("¿Desea saber si algun numero esta en la lista?");
            confirmarAccion = GetStringPreg("Ingrese la opcion: ");
            entrar = false;
            if (confirmarAccion.ToUpper() == "S")
            {
                entrar = true;
            }
            if (entrar)
            {
                seguir = true;
                do
                {

                    Console.WriteLine($"Hay {CantidadIndex - 1} indices");

                    int nroList = GetInt($"Ingrese el nro que quiera confirmar si esta: ");
                    if (listaNro.Contains(nroList))
                    {
                        Console.WriteLine($"El nro {nroList} si se encuentra en la lista");
                    }
                    else
                    {
                        Console.WriteLine($"El nro {nroList} no se encuentra en la lista");
                    }


                    OpcionContin("¿Desea verificar si existe u numero en la lista?(Ponga la letra segun la opcion)");
                    preg = GetStringPreg("Ingrese la opcion: ");
                    if (preg.ToUpper() == "N")
                    {
                        seguir = false;
                    }
                    EsperarTecla();
                } while (seguir);
            }
            //Muestra la cantidad de elementos de la lista.
            Console.WriteLine($"La cantidad de elemento que hay son {CantidadIndex}");
        }

        private static int GetIntMax(string mensaje, int cantidadIndex)
        {
            do
            {
                Console.Write(mensaje);
                if (int.TryParse(Console.ReadLine(), out int nro) && (nro>=0) && (nro<cantidadIndex))
                {
                    return nro;
                }
                else
                {
                    Console.WriteLine("Error, el valor ingresado no es valido");
                }
            } while (true);
        }

        private static void EsperarTecla()
        {
            Console.Write("Toque cualquier tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }

        private static string GetStringPreg(string mensaje)
        {
            
            do
            {
                Console.Write(mensaje);
                string cadena = Console.ReadLine();
                if ((cadena.ToUpper() == "N") || (cadena.ToUpper() == "S"))
                {
                    return cadena;
                }
                else
                {
                    Console.WriteLine("ERROR: El valor ingresado no esta entre las opciones");
                }
            }while (true);
        }

        private static void OpcionContin(string mensaje)
        {
            Console.WriteLine(mensaje);
            Console.WriteLine("S - Si");
            Console.WriteLine("N - No");

        }

        private static int GetInt(string mensaje)
        {
            do { 
            Console.Write(mensaje);
                if (int.TryParse(Console.ReadLine(), out int nro))
                {
                    return nro;
                }
                else
                {
                    Console.WriteLine("Error, el valor ingresado no es valido");
                }
            }while (true);
        }
    }
}
//✅ Actividad 1: Lista de Números (Operaciones Básicas)
//Objetivo: Practicar el uso de List<T> con números enteros.

//Instrucciones:

//Crea una lista de enteros vacía.

//Agrega al menos 5 números enteros a la lista.

//Inserta un número en una posición específica.

//Elimina un número específico de la lista.

//Muestra todos los números en pantalla.

//Ordena la lista en forma ascendente.

//Verifica si un número específico está en la lista.

//Muestra la cantidad de elementos de la lista.

//Métodos que deberías usar:

//Add(), Insert(), Remove(), Sort(), Contains(), Count