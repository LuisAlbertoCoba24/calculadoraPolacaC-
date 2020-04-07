using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Ejemplo_uno_pila
{

    class convertir
    {
        
        //este metodo nos permite generar la operacion posfija, pasando el valor de 
        public string infijaPosfija( String operacion )
        {
            //Declaramos las variables que utilizaremos para la convercion
            char carcater = ' ';
            //almacenamos la exprecion
            string posfija = " ";
           
            //Declarmos nuestro objeto pila
            Stack pila = new Stack();

            //Recorremos la cadena
            for ( int i = 0; i < operacion.Length; i++ )
            {
                //Obtenemos el valor de la cadena
                carcater = Char.Parse( operacion.Substring( i, 1 ) );

                //si el caracter es un numero
                if ( char.IsDigit( carcater ) || carcater.Equals(' ') )
                {
                    posfija += carcater; //concatenamos
                }
                else
                {
                    //si la pila esta vacia
                    if ( pilaVacia( pila ) )
                    {   
                        pila.Push( carcater ); //agregamos a la pila
                    }
                    else
                    {
                        // obtenemos el valor de los operadores
                        int Pe = PrioridadOperador( carcater );
                        int Pp = prioridadPila( char.Parse( pila.Peek().ToString() ) );

                        //si el operador de la esprecion es mayor 
                        if ( Pe > Pp )
                        {
                            //apilamos
                            pila.Push( carcater );
                        }
                        else
                        {
                            //si se encuentra el caracter
                            if ( carcater == ')' )
                            {
                                //mientras no encontremos el caracter
                                while ( char.Parse( pila.Peek().ToString() ) != '(' )
                                {
                                    posfija += pila.Pop().ToString(); //concatenamos y desapilamos
                                }

                                pila.Pop(); //Desapilamos el parentesis 
                            }
                            else
                            {
                                //Desapilamos y concatenmos
                                posfija += pila.Pop();
                                //Apilamos
                                pila.Push( carcater );
                            }
                        }

                    }
                }
            }

            //Mientras la pila no este vacia
            while( pilaVacia(pila) != true)
            {
                posfija += " " + pila.Pop();//Desapilamos
            }

            return posfija;
        }//infijaPosfija

        //Este metodo nos permite saber si la pila se encuentra bacia
        public Boolean pilaVacia( Stack comprovar )
        {
            //Si la pila no tiene elementos
            if ( comprovar.Count == 0 )
            {
                return true;
            }
            else
            {
                return false;
            }
        }//pilaVacia

        //Esta nos da la prioridad dde los operadores que se manejan comun mente
        public int PrioridadOperador( char signo )
        {
            //Comparamos los caracteres, y retornamos un valor, con la gerarquia de las ecuaciones
            if ( signo == '(')
            {
                return 5;

            }else if ( signo == '^' )
            {
                return 4;

            } else if ( (signo == '*') || ( signo == '/' ) )
            {
                return 2;

            }else if ( (signo == '+') || (signo == '-') )
            {
                return 1;
            }

            return 0;

        }//PrioridadOperador

        //Vemos la prioridad de los operadores, dentro de la pila
        public int prioridadPila( char operador )
        {

            if (operador == '(')
            {
                return 0;

            }
            else if (operador == '^')
            {
                return 3;

            }
            else if ((operador == '*') || (operador == '/'))
            {
                return 2;

            }
            else if ((operador == '+') || (operador == '-'))
            {
                return 1;
            }

            return 0;
        }//prioridadPila


    }


}
