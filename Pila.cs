using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo_uno_pila
{
    class Pila
    {
        public nodo tope; //hace referencia al ultimo dato que entra a nuestra pila

        public Pila()
        {
            tope = null;
        }

        public void Push( float valor )
        {
            //Agregamos el valor a la pila
            nodo aux = new nodo();
            aux.info = valor;

            //Si no hay nada en la pila 
            if ( tope == null )
            {
                //Se asigna el aux como el unico nodo
                tope = aux;
                //Como solo hay un dato en la pila el puntero se dirige a null
                aux.sgte = null;

            }
            else
            {
                //Si la pila no esta vacia el dato se inserta arriba de la pila 
                aux.sgte = tope;
                tope = aux;
            }
        }

        //Este metodo nos permite quitar elementos de la pila
        public float Pop()
        {
            //Iniciamos una varible que la cual esta vacia, usaremos para cambiar la el valor del tope recorriendo los espacios de la pila.
            float valor = 0;

            //Evaluamos el tope de la pila.
            if ( tope == null)
            {
                Console.WriteLine("Pila vacia");//Notificamos
            }
            else
            {
                //nos movemos del valor de poccion de la pila
                valor = tope.info;
                tope = tope.sgte;
            }

            //Regresmos el valor de la pila
            return valor;
        }

        //Con este metodo podremos evaluar si nuestra pila se encuentra vacia.
        public Boolean PilaVacia()
        {
            //Comparamos el valor, regresmos o retornamos un resultado.
            if (tope == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Este metodo nos regresa la paralbra a la inversa, de la cual contenga la pila o se ingreso en la pila.
        public String mostrarPalindromo()
        {
            //Iniciamos variable palabra, contendra la palabra al reves.
            string palabra = "";
            //Cramos un puntero
            nodo puntero;
            puntero = tope;//colocamos en el tope de la pila.

            palabra = puntero.info.ToString();//Capturamos el valor del puntero.

            //Recorremos el puntero.
            while (puntero.sgte != null)
            {
                //Cambiamos la pocicion del puntero.
                puntero = puntero.sgte;
                palabra = palabra + puntero.info.ToString();//Concatemos los resultados.
            }
            //Regremos la palabra.
            return palabra;
        }

    }
}
