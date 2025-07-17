




namespace Lista2.Consoal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Crea una lista de strings con al menos 5 nombres (puede haber repetidos).

            List<string> listaNro = new List<string>();
            int elementList = GetInt("Ingrese la cantidad de elementos que quiere introducir: ");
            for (int i = 0; i < elementList; i++)
            {
                string nroList = GetString($"Ingrese el {i+1}º nombre para la lista: ");
                listaNro.Add(nroList);
            }
            int CantidadIndex = listaNro.Count;
            
           
            bool seguir=true;
            do
            {
                if(listaNro.Count == 0)
                {
                    do
                    {
                        Console.WriteLine("La lista esta vacia asi que introduzca una nueva lista");
                        elementList = GetInt("Ingrese la cantidad de elementos que quiere introducir en la lista: ");
                        for (int i = 0; i < elementList; i++)
                        {
                            string nroList = GetString($"Ingrese el {i + 1}º nombre para la lista: ");
                            listaNro.Add(nroList);
                        }
                    }while (listaNro.Count==0);
                    
                }
                MenuOpcion();
                int nroOpcion = GetInt("Ingrese la opcion: ");
                string nombre;
                switch (nroOpcion)
                {
                    
                    //Muestra la lista
                    case 1:
                        Console.WriteLine("Numeros en lista");
                        foreach (string nroList in listaNro)
                        {
                            Console.WriteLine(nroList);
                        }
                        
                            break;


                    //Encuentra el primer nombre que empiece con una letra específica.
                    case 2:
                        char letra = GetChar("Ingrese la letra con la que quires que empiece");
                        string nombreLetra = listaNro.Find(x => x.StartsWith(letra));
                        if (nombreLetra != null)
                        {
                            Console.WriteLine(nombreLetra);
                        }
                        else
                        {
                            Console.WriteLine("No hay ningun nombre que tenga esa letra");
                        }
                            break;


                    //Crea una nueva lista con todos los nombres que contengan la letra "a".
                    case 3:
                         letra = GetChar("Ingrese la letra con la que quieres crear la lista");
                        //List < String > listLetra= new List<string>(listaNro.FindAll(x => x.StartsWith(letra))); 
                        List<string> listLetra = listaNro.FindAll(x => x.Contains(letra));
                        if (listLetra != null)
                        {
                            foreach (string nroList in listLetra)
                            {
                                Console.WriteLine(nroList);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No hay ningun nombre que tenga esa letra");
                        }
                        break;


                    //Elimina de la lista original todos los nombres repetidos (usa RemoveAll() o lógica similar).
                    case 4:
                        //for(int i = 0; i < listaNro.Count; i++)
                        //{
                        //    bool repite = false;
                        //    string nombre = listaNro[i];
                        //    for(int j = 0; j < listaNro.Count; j++)
                        //    {
                        //        if (nombre == listaNro[j] && (j != i))
                        //        {
                        //            repite = true;
                        //        }

                        //        if (repite)
                        //        {
                        //            int eliminados = listaNro.RemoveAll(n => n == nombre);
                        //            listaNro.Add(nombre);
                        //        }
                        //    }

                        //    foreach(string nroLista  in listaNro)
                        //    {
                        //        Console.WriteLine(nroLista);
                        //    }
                        for (int i = 0; i < listaNro.Count; i++)
                        {
                              nombre = listaNro[i];
                            // Elimina TODAS las repeticiones excepto la primera
                            listaNro.RemoveAll((n) => n == nombre && listaNro.IndexOf(n) != i);
                        }
                        break;


                    //Busca la posición (índice) de un nombre específico.
                    case 5:
                         nombre = GetString("Ingrese el nombre que quiere buscar en la lista: ");
                        int indiceNombre = listaNro.IndexOf(nombre);
                        if(indiceNombre == -1)
                        {
                            Console.WriteLine("El numero no existe");
                        }
                        {
                            Console.WriteLine($"El numero se encuentra en {indiceNombre}");
                        }
                        break;


                    //Vacía la lista completamente.
                    case 6:
                        listaNro.Clear();
                        break;
                default:
                        Console.WriteLine("El valor ingresado no correspone a ninguna opcion");
                        break;
                }
                        
                        

                
                //Realizar otra opcion
                OpcionContin("¿Quiere realizar alguna otra opcion?(Ingrese segun la opcion)");
                seguir = PregSiNo("S");
                EsperarTecla();
            } while (seguir);
            

        }

        private static char GetChar(string mensaje)
        {
            do
            {
                Console.Write(mensaje);
                if (char.TryParse(Console.ReadLine(), out char letra))
                {
                    return letra;
                }
                else
                {
                    Console.WriteLine("Error: El valor ingresado no es valido");
                }
            } while (true);
        }

        private static string GetString(string mensaje)
        {
            
                Console.Write(mensaje);
                return Console.ReadLine();
                
        }

        private static void MenuOpcion()
        {
            Console.WriteLine("Ingrese lo que quiera hacer con la lista que creo");
            Console.WriteLine("1 - Muestra todos los nombres en pantalla");
            Console.WriteLine("2 - Encuentra el primer nombre que empiece con una letra específica");
            Console.WriteLine("3 - Crea una nueva lista con todos los nombres que contengan la letra a");
            Console.WriteLine("4 - Elimina de la lista original todos los nombres repetidos");
            Console.WriteLine("5 - Busca la posición (índice) de un nombre específico");
            Console.WriteLine("6 - Vacía la lista completamente");

        }

        private static bool PregSiNo(string respActiva)
        {
            string confirmarAccion = GetStringPreg("Ingrese la opcion: ");
            
            if (confirmarAccion.ToUpper() == respActiva)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static int GetInt(string mensaje)
        {
            do
            {
                Console.Write(mensaje);
                if (int.TryParse(Console.ReadLine(), out int nro) && (nro>=0))
                {
                    return nro;
                }
                else
                {
                    Console.WriteLine("Error: El valor ingresado no es valido");
                }
            }while (true);
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
            } while (true);
        }

        private static void OpcionContin(string mensaje)
        {
            Console.WriteLine(mensaje);
            Console.WriteLine("S - Si");
            Console.WriteLine("N - No");

        }

    }
}
//✅ Actividad 2: Lista de Nombres (Búsqueda y Filtrado)
//Objetivo: Practicar búsquedas, filtrado y eliminación en listas.
//Métodos que deberías usar:

//Find(), FindAll(), RemoveAll(), IndexOf(), Clear()