using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejemplo_uno_pila
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        //Este metodo nos permite captuar la exprecion y trasformarla a posfija
        public void convertirExprecion()
        {
             //Declaramos el objeto convertir
            convertir exprecion = new convertir();

            //Capturamos el valor del metodo
            String posFija = exprecion.infijaPosfija( textBox2.Text);

            textBox3.Text = posFija;
        }//convertirExprecion

        public void calcular()
        {
            //variables auxiliares
            String cadena;
            char caracter;

            //capturamos el valor de la caja de texto
            cadena = textBox3.Text;

            //Declaramos el objeto pila
            Pila pila = new Pila();

            //Captura de resultados
            float num1, num2, resultado = 0;

            //Captura de errores
            Boolean error = false;

            //Recorremos la cadena
            for( int i = 0; i < cadena.Length; i++)
            {
                //Obtenemos el carcater del momento
                caracter = char.Parse(cadena.Substring(i, 1));

                //Si el caracter es un numero
                if ( char.IsDigit(caracter) )
                {
                    //Guardamos en la pila el valor
                    pila.Push( float.Parse( caracter.ToString() ) );

                    //Si es un signo
                }else if ( caracter.Equals('+') || caracter.Equals('-') || caracter.Equals('*') || caracter.Equals('/'))
                {
                    //Se desapilan los ultimos dos numeros de la pila
                    num2 = 0;
                    num1 = 0;

                    //Si la pila esta vacia
                    if ( pila.PilaVacia () != true )
                    {
                        num2 = pila.Pop();
                    }
                    else
                    {
                        error = true;
                    }

                    //Evalumos el caracter y realizamos su operacion
                    if (pila.PilaVacia() != true)
                    {
                        num1 = pila.Pop();

                        if ( caracter.Equals('+') )
                        {
                            resultado = num1 + num2;
                            pila.Push(resultado);
                        }

                        if (caracter.Equals('-'))
                        {
                            resultado = num1 - num2;
                            pila.Push(resultado);
                        }

                        if (caracter.Equals('*'))
                        {
                            resultado = num1 * num2;
                            pila.Push(resultado);
                        }

                        if (caracter.Equals('/'))
                        {
                            resultado = num1 / num2;
                            pila.Push(resultado);
                        }
                    }
                    else
                    {
                        error = true;
                    }
                }
                else
                {
                    //Evalumos que sea diferente a vacio
                    if ( !caracter.Equals( ' ' ) )
                    {
                        error = true;
                    }
                }
            }

            //Si la pila esta vacia y los errores son false
            if ( pila.PilaVacia() != true && error == false )
            {   
                //Capturamos el resultado de la pila
                string resultadoFinal = pila.Pop().ToString();

                //si la pila esta vacia
                if ( pila.PilaVacia() == true )
                {
                    //Imprimimos
                    textBox4.Text = resultadoFinal;
                }
                else
                {
                    textBox4.Text = "Error";
                }
            }
        }// calcular
        
        private void button1_Click(object sender, EventArgs e)
        {
           //Lamamos a los metodos
            convertirExprecion();
            calcular();
        }
    }
}
