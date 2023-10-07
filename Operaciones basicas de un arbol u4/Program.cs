using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operaciones_basicas_de_un_arbol_u4
{
    using System;

    class NodoArbol
    {
        public int Valor;
        public NodoArbol Izquierda;
        public NodoArbol Derecha;

        public NodoArbol(int valor)
        {
            Valor = valor;
            Izquierda = null;
            Derecha = null;
        }
    }

    class ArbolBinario
    {
        private NodoArbol Raiz;

        public ArbolBinario()
        {
            Raiz = null;
        }

        public void Insertar(int valor)
        {
            Raiz = InsertarRecursivo(Raiz, valor);
        }

        private NodoArbol InsertarRecursivo(NodoArbol nodo, int valor)
        {
            if (nodo == null)
            {
                return new NodoArbol(valor);
            }

            if (valor < nodo.Valor)
            {
                nodo.Izquierda = InsertarRecursivo(nodo.Izquierda, valor);
            }
            else if (valor > nodo.Valor)
            {
                nodo.Derecha = InsertarRecursivo(nodo.Derecha, valor);
            }

            return nodo;
        }

        public bool Buscar(int valor)
        {
            return BuscarRecursivo(Raiz, valor);
        }

        private bool BuscarRecursivo(NodoArbol nodo, int valor)
        {
            if (nodo == null)
            {
                return false;
            }

            if (valor == nodo.Valor)
            {
                return true;
            }

            if (valor < nodo.Valor)
            {
                return BuscarRecursivo(nodo.Izquierda, valor);
            }
            else
            {
                return BuscarRecursivo(nodo.Derecha, valor);
            }
        }

        public void Eliminar(int valor)
        {
            Raiz = EliminarRecursivo(Raiz, valor);
        }

        private NodoArbol EliminarRecursivo(NodoArbol nodo, int valor)
        {
            if (nodo == null)
            {
                return nodo;
            }

            if (valor < nodo.Valor)
            {
                nodo.Izquierda = EliminarRecursivo(nodo.Izquierda, valor);
            }
            else if (valor > nodo.Valor)
            {
                nodo.Derecha = EliminarRecursivo(nodo.Derecha, valor);
            }
            else
            {
                if (nodo.Izquierda == null)
                {
                    return nodo.Derecha;
                }
                else if (nodo.Derecha == null)
                {
                    return nodo.Izquierda;
                }

                nodo.Valor = MinValor(nodo.Derecha);
                nodo.Derecha = EliminarRecursivo(nodo.Derecha, nodo.Valor);
            }

            return nodo;
        }

        private int MinValor(NodoArbol nodo)
        {
            int minValor = nodo.Valor;
            while (nodo.Izquierda != null)
            {
                minValor = nodo.Izquierda.Valor;
                nodo = nodo.Izquierda;
            }
            return minValor;
        }

        public void ImprimirInOrden()
        {
            ImprimirInOrdenRecursivo(Raiz);
            Console.WriteLine();
        }

        private void ImprimirInOrdenRecursivo(NodoArbol nodo)
        {
            if (nodo != null)
            {
                ImprimirInOrdenRecursivo(nodo.Izquierda);
                Console.Write(nodo.Valor + " ");
                ImprimirInOrdenRecursivo(nodo.Derecha);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            ArbolBinario arbol = new ArbolBinario();
            int opcion;

            do
            {
                Console.WriteLine("\nMenú:");
                Console.WriteLine("1. Insertar");
                Console.WriteLine("2. Buscar");
                Console.WriteLine("3. Eliminar");
                Console.WriteLine("4. Imprimir en orden");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese un valor para insertar: ");
                        int valorInsertar = Convert.ToInt32(Console.ReadLine());
                        arbol.Insertar(valorInsertar);
                        break;

                    case 2:
                        Console.Write("Ingrese un valor para buscar: ");
                        int valorBuscar = Convert.ToInt32(Console.ReadLine());
                        if (arbol.Buscar(valorBuscar))
                        {
                            Console.WriteLine($"El valor {valorBuscar} está en el árbol.");
                        }
                        else
                        {
                            Console.WriteLine($"El valor {valorBuscar} no está en el árbol.");
                        }
                        break;

                    case 3:
                        Console.Write("Ingrese un valor para eliminar: ");
                        int valorEliminar = Convert.ToInt32(Console.ReadLine());
                        arbol.Eliminar(valorEliminar);
                        break;

                    case 4:
                        Console.WriteLine("Árbol en orden:");
                        arbol.ImprimirInOrden();
                        break;

                    case 0:
                        Console.WriteLine("Saliendo del programa.");
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }

            } while (opcion != 0);
        }
    }

}
