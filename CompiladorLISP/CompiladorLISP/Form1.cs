using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompiladorLISP
{
    public partial class frmPrincipal : Form
    {
        //Variables de clase
        String[] textoEntrada; //Array de lineas
        List<Variable> listaVariables; //Listado de variables
        String recsultado;

        //Método constructor
        public frmPrincipal()
        {
            InitializeComponent();
        }

        //botob salir
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit(); //termina la aplicación
        }

        //botón convertir
        private void btnConvertir_Click(object sender, EventArgs e)
        {
            listaVariables = new List<Variable>(); //Crea un objeto de lista de variables
            textoEntrada = rtxtLISP.Text.Split(new[] { "\n" }, StringSplitOptions.None); //separa el texto de entrada por lineas en un array
            
            bool ok = true;
            limpiar(); //limpia los textbox
            rtxtCS.Text = "";
            if (!textoEntrada[0].Equals("("))
            {
                MessageBox.Show("El programa debe iniciar con '('");
                ok = false;
            } else
            {
                textoEntrada[0] = "";
            }
            if (!textoEntrada[textoEntrada.Length-1].Equals(")"))
            {
                MessageBox.Show("El programa debe terminar con ')'");
                ok = false;
            }
            else
            {
                textoEntrada[textoEntrada.Length - 1] = "";
            }

            validarPalabReserv(textoEntrada); //valida que las palabras usadas sean las palabras reservadas

            for (int i = 0; i < textoEntrada.Length; i++)
            {
                int parentesis = 0;
                for (int j = 0; j < textoEntrada[i].ToCharArray().Length; j++)
                {
                    if (textoEntrada[i].ToCharArray()[j] == '(')
                    {
                        parentesis++;
                    }
                    if (textoEntrada[i].ToCharArray()[j] == ')')
                    {
                        parentesis--;
                    }
                }
                if(parentesis != 0)
                {
                    MessageBox.Show("Error de paréntesis");
                    limpiar();
                    ok = false;
                }
            }

            if (ok)
            {
                for (int i = 0; i < textoEntrada.Length; i++) //Recorre el psudo lisp  linea por linea
                {
                    if (textoEntrada[i].StartsWith("(LEER") || textoEntrada[i].StartsWith("(leer") || textoEntrada[i].StartsWith("(Leer"))
                    {
                        if (textoEntrada[i].EndsWith(")"))
                        {
                            Leer(textoEntrada[i].Substring(1, textoEntrada[i].Length - 2), i + 1); //Si encuentra la palabra reservada leer ejecuta el código

                        }
                        else
                        {
                            MessageBox.Show("Paréntesis no cerrado");
                        }
                    }
                    if (textoEntrada[i].StartsWith("(ASIGNAR") || textoEntrada[i].StartsWith("(asignar") || textoEntrada[i].StartsWith("(Asignar"))
                    {
                        if (textoEntrada[i].EndsWith(")"))
                        {
                            Asignar(textoEntrada[i].Substring(1, textoEntrada[i].Length - 2), i + 1); //Si encuentra la palabra reservada asignar ejecuta el código
                        }
                        else
                        {
                            MessageBox.Show("Paréntesis no cerrado");
                        }
                    }
                    if (textoEntrada[i].StartsWith("(ESCRIBIR") || textoEntrada[i].StartsWith("(escribir") || textoEntrada[i].StartsWith("(Escribir"))
                    {
                        if (textoEntrada[i].EndsWith(")"))
                        {
                            Escribir(textoEntrada[i].Substring(1, textoEntrada[i].Length - 2), i + 1); //Si encuentra la palabra reservada escribir ejecuta el código
                        }
                        else
                        {
                            MessageBox.Show("Paréntesis no cerrado");
                        }
                    }
                }
            }
        }

        //Evento de cambio de texto en el textbox de LISP
        private void rtxtLISP_TextChanged(object sender, EventArgs e)
        {
            //Cambia de color el texto cada que encuentra una palabra reservada
            this.CheckKeyword("LEER", Color.Blue, 0);
            this.CheckKeyword("ESCRIBIR", Color.Blue, 0);
            this.CheckKeyword("ASIGNAR", Color.Blue, 0);
            this.CheckKeyword("leer", Color.Blue, 0);
            this.CheckKeyword("escribir", Color.Blue, 0);
            this.CheckKeyword("asignar", Color.Blue, 0);
            this.CheckKeyword("Leer", Color.Blue, 0);
            this.CheckKeyword("Escribir", Color.Blue, 0);
            this.CheckKeyword("Asignar", Color.Blue, 0);
        }

        //Resalta las palabras resrvadas
        private void CheckKeyword(string word, Color color, int startIndex)
        {
            if (this.rtxtLISP.Text.Contains(word))
            {//Si contiene las palabras declaradas en rtxtLISP_TextChanged
                int index = -1;
                int selectStart = this.rtxtLISP.SelectionStart;

                while ((index = this.rtxtLISP.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.rtxtLISP.Select((index + startIndex), word.Length); //detecta que la palabra esté escrita completamente
                    this.rtxtLISP.SelectionColor = color; //Se le asigna un nuevo color, viene de parametro, azul en este caso
                    this.rtxtLISP.Select(selectStart, 0); //Comienzo de la seleccion
                    this.rtxtLISP.SelectionColor = Color.Black; //Cuando se termina de asignar color, regresa a ser negro
                }
            }
        }


        private void rtxtLISP_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        //Valida que se empiece con las palabras reservadas
        private void validarPalabReserv(String[] texto)
        {
            int numLinea = 0;
            for(int i = 0; i < texto.Length; i++)
            { //recorre todo el texto del textbox
                numLinea = i + 1; //suma 1 a la linea actual
                if(
                    !texto[i].StartsWith("(LEER") &&
                    !texto[i].StartsWith("(ESCRIBIR") &&
                    !texto[i].StartsWith("(ASIGNAR") &&
                    !texto[i].Equals("") &&
                    !texto[i].StartsWith("(leer") &&
                    !texto[i].StartsWith("(escribir") &&
                    !texto[i].StartsWith("(asignar") &&
                    !texto[i].StartsWith("(Leer") &&
                    !texto[i].StartsWith("(Escribir") &&
                    !texto[i].StartsWith("(Asignar")
                    )
                {//Si no detecta ninguna de esas palabras, lanza el error con descripcion en numero de linea
                    limpiar();
                    MessageBox.Show("Eror en linea: "+numLinea+" La sentenia no empieza o contiene palabra reservada mal escrita ((LEER), (ESCRIBIR), (ASIGNAR))");
                }
            }
        }

        //Lee variables
        private void Leer(String linea, int numLinea)
        {
            string nombre;
            //double valor;
            Variable varItem = new Variable();
            bool agregar=true;
            
            for(int i=0; i < linea.Length; i++)
            {
                if(linea.EndsWith(" "))
                {
                    linea = linea.Substring(0, linea.Length - 1);
                }
            }
            

            nombre = linea.Split(' ')[1];

            for (int i = 1; i < linea.Split(' ').Length; i++)
            {
                if(!linea.Split(' ')[i].Equals(" ")){
                    nombre = linea.Split(' ')[i];
                }
            }

            if (listaVariables.Count == 0)
            {//Si no existen variables
                varItem.Nombre = nombre; //se obtiene el nombre de la variable -- (Leer x) -- nombre = x
                varItem.Valor = 0; //se le asigna valor 0 por defecto

                listaVariables.Add(varItem); //Se agrega a la lista de Variables

                rtxtCS.Text = rtxtCS.Text + "double " + nombre + ";"+"\n"; //traduce a C# el pseudoLISP

            } else
            { //Si existen variables se valida que la nueva variable, no repita el nombre de ninguna variable existente
                foreach (var item in listaVariables)
                {
                    if (nombre.Equals(item.Nombre))
                    {
                        agregar = false; //bandera
                        MessageBox.Show("Error linea: "+numLinea+". La variable '" + nombre + "' ya fue declarada.");
                    }
                }

                if (agregar)
                {//si no hay problema con el nombre se agrega a la Lista d variables
                    varItem.Nombre = nombre;
                    varItem.Valor = 0;

                    listaVariables.Add(varItem);

                    rtxtCS.Text = rtxtCS.Text + "double " + nombre + ";" + "\n";
                }

            }
        }

        private String recAsignar(string nuevalinea)
        {
            String respuesta = "";
            int inicio = 0;
            int fin = 0;
            int cierre=1;
            //'+ x (- x y) z'
            // x + (x - y) + z
            //'+ x (- x (* x z) y) z'
            //x + (x - (x * z) -y) + z{}
            //MessageBox.Show(nuevalinea);



            //for (int ini = 0; ini < nuevalinea.Split(' ').Length; ini++)
            //{
                if (nuevalinea.StartsWith("+"))
                {
                //MessageBox.Show("Empieza con+");
                for (int i = 1; i < nuevalinea.Split(' ').Length; i++)
                {
                    //MessageBox.Show("i= "+i);
                    if (nuevalinea.Split(' ')[i].Contains("("))
                    {

                        for (int fi = 0; fi < nuevalinea.ToCharArray().Length; fi++)
                        {
                            if (nuevalinea.ToCharArray()[fi].ToString().Equals("("))
                            {
                                inicio = fi;
                                break;
                            }
                        }
                        //MessageBox.Show("Contiene (");
                        if (nuevalinea.Split(' ')[1].StartsWith("("))
                        {
                            rtxtCS.Text = rtxtCS.Text + "(";
                        }
                        else
                        {
                            rtxtCS.Text = rtxtCS.Text + " + (";
                        }
                        for (int j = i + 1; j < nuevalinea.Split(' ').Length; j++)
                        {
                            if (nuevalinea.Split(' ')[j].Contains(")"))
                            {
                                cierre = j;
                                for (int fj = 0; fj < nuevalinea.ToCharArray().Length; fj++)
                                {
                                    if (nuevalinea.ToCharArray()[fj].ToString().Equals(")"))
                                        //MessageBox.Show("Contiene ) j= " + fj);
                                        fin = fj;
                                }

                            }
                        }
                        //MessageBox.Show("nueva linea: inicio= "+inicio +" fin= "+fin);
                        recAsignar(nuevalinea.Substring(inicio + 1, fin - inicio - 1));
                        rtxtCS.Text = rtxtCS.Text + ")";
                        i = cierre;
                    }
                    else
                    if (i == 1)
                    {
                        rtxtCS.Text = rtxtCS.Text + nuevalinea.Split(' ')[i];
                    }
                    else
                    {
                        if (nuevalinea.Split(' ')[i].Equals("")) { }
                        else
                        {
                            rtxtCS.Text = rtxtCS.Text + " + " + nuevalinea.Split(' ')[i];
                        }
                    }
                }
            }
            if (nuevalinea.StartsWith("-"))
            {
                //MessageBox.Show("Empieza con+");
                for (int i = 1; i < nuevalinea.Split(' ').Length; i++)
                {
                    //MessageBox.Show("i= "+i);
                    if (nuevalinea.Split(' ')[i].Contains("("))
                    {

                        for (int fi = 0; fi < nuevalinea.ToCharArray().Length; fi++)
                        {
                            if (nuevalinea.ToCharArray()[fi].ToString().Equals("("))
                            {
                                inicio = fi;
                                break;
                            }
                        }
                        //MessageBox.Show("Contiene (");
                        if (nuevalinea.Split(' ')[1].StartsWith("("))
                        {
                            rtxtCS.Text = rtxtCS.Text + "(";
                        }
                        else
                        {
                            rtxtCS.Text = rtxtCS.Text + " - (";
                        }
                        for (int j = i + 1; j < nuevalinea.Split(' ').Length; j++)
                        {
                            if (nuevalinea.Split(' ')[j].Contains(")"))
                            {
                                cierre = j;
                                for (int fj = 0; fj < nuevalinea.ToCharArray().Length; fj++)
                                {
                                    if (nuevalinea.ToCharArray()[fj].ToString().Equals(")"))
                                        //MessageBox.Show("Contiene ) j= " + fj);
                                        fin = fj;
                                }

                            }
                        }
                        //MessageBox.Show("nueva linea: inicio= "+inicio +" fin= "+fin);
                        recAsignar(nuevalinea.Substring(inicio + 1, fin - inicio - 1));
                        rtxtCS.Text = rtxtCS.Text + ")";
                        i = cierre;
                    }
                    else
                    if (i == 1)
                    {
                        rtxtCS.Text = rtxtCS.Text + nuevalinea.Split(' ')[i];
                    }
                    else
                    {
                        if (nuevalinea.Split(' ')[i].Equals("")) { }
                        else
                        {
                            rtxtCS.Text = rtxtCS.Text + " - " + nuevalinea.Split(' ')[i];
                        }
                    }
                }
            }
            if (nuevalinea.StartsWith("*"))
            {
                //MessageBox.Show("Empieza con+");
                for (int i = 1; i < nuevalinea.Split(' ').Length; i++)
                {
                    //MessageBox.Show("i= "+i);
                    if (nuevalinea.Split(' ')[i].Contains("("))
                    {

                        for (int fi = 0; fi < nuevalinea.ToCharArray().Length; fi++)
                        {
                            if (nuevalinea.ToCharArray()[fi].ToString().Equals("("))
                            {
                                inicio = fi;
                                break;
                            }
                        }
                        //MessageBox.Show("Contiene (");
                        if (nuevalinea.Split(' ')[1].StartsWith("("))
                        {
                            rtxtCS.Text = rtxtCS.Text + "(";
                        }
                        else
                        {
                            rtxtCS.Text = rtxtCS.Text + " * (";
                        }
                        for (int j = i + 1; j < nuevalinea.Split(' ').Length; j++)
                        {
                            if (nuevalinea.Split(' ')[j].Contains(")"))
                            {
                                cierre = j;
                                for (int fj = 0; fj < nuevalinea.ToCharArray().Length; fj++)
                                {
                                    if (nuevalinea.ToCharArray()[fj].ToString().Equals(")"))
                                        //MessageBox.Show("Contiene ) j= " + fj);
                                        fin = fj;
                                }

                            }
                        }
                        //MessageBox.Show("nueva linea: inicio= "+inicio +" fin= "+fin);
                        recAsignar(nuevalinea.Substring(inicio + 1, fin - inicio - 1));
                        rtxtCS.Text = rtxtCS.Text + ")";
                        i = cierre;
                    }
                    else
                    if (i == 1)
                    {
                        rtxtCS.Text = rtxtCS.Text + nuevalinea.Split(' ')[i];
                    }
                    else
                    {
                        if (nuevalinea.Split(' ')[i].Equals("")) { }
                        else
                        {
                            rtxtCS.Text = rtxtCS.Text + " * " + nuevalinea.Split(' ')[i];
                        }
                    }
                }
            }
            if (nuevalinea.StartsWith("/"))
            {
                //MessageBox.Show("Empieza con+");
                for (int i = 1; i < nuevalinea.Split(' ').Length; i++)
                {
                    //MessageBox.Show("i= "+i);
                    if (nuevalinea.Split(' ')[i].Contains("("))
                    {

                        for (int fi = 0; fi < nuevalinea.ToCharArray().Length; fi++)
                        {
                            if (nuevalinea.ToCharArray()[fi].ToString().Equals("("))
                            {
                                inicio = fi;
                                break;
                            }
                        }
                        //MessageBox.Show("Contiene (");
                        if (nuevalinea.Split(' ')[1].StartsWith("("))
                        {
                            rtxtCS.Text = rtxtCS.Text + "(";
                        }
                        else
                        {
                            rtxtCS.Text = rtxtCS.Text + " / (";
                        }
                        for (int j = i + 1; j < nuevalinea.Split(' ').Length; j++)
                        {
                            if (nuevalinea.Split(' ')[j].Contains(")"))
                            {
                                cierre = j;
                                for (int fj = 0; fj < nuevalinea.ToCharArray().Length; fj++)
                                {
                                    if (nuevalinea.ToCharArray()[fj].ToString().Equals(")"))
                                        //MessageBox.Show("Contiene ) j= " + fj);
                                    fin = fj;
                                }

                            }
                        }
                        //MessageBox.Show("nueva linea: inicio= "+inicio +" fin= "+fin);
                        recAsignar(nuevalinea.Substring(inicio + 1, fin - inicio - 1));
                        rtxtCS.Text = rtxtCS.Text + ")";
                        i = cierre;
                    }
                    else
                    if (i == 1)
                    {
                        rtxtCS.Text = rtxtCS.Text + nuevalinea.Split(' ')[i];
                    }
                    else
                    {
                        if (nuevalinea.Split(' ')[i].Equals("")) { }
                        else
                        {
                            rtxtCS.Text = rtxtCS.Text + " / " + nuevalinea.Split(' ')[i];
                        }
                    }
                }
            }
            if (nuevalinea.StartsWith("\\"))
            {
                //MessageBox.Show("pleca invertida");
                //MessageBox.Show("Empieza con+");
                for (int i = 1; i < nuevalinea.Split(' ').Length; i++)
                {
                    //MessageBox.Show("i= "+i);
                    if (nuevalinea.Split(' ')[i].Contains("("))
                    {

                        for (int fi = 0; fi < nuevalinea.ToCharArray().Length; fi++)
                        {
                            if (nuevalinea.ToCharArray()[fi].ToString().Equals("("))
                            {
                                inicio = fi;
                                break;
                            }
                        }
                        //MessageBox.Show("Contiene (");
                        if (nuevalinea.Split(' ')[1].StartsWith("("))
                        {
                            rtxtCS.Text = rtxtCS.Text + "(";
                        }
                        else
                        {
                            rtxtCS.Text = rtxtCS.Text + " / (";
                        }
                        for (int j = i + 1; j < nuevalinea.Split(' ').Length; j++)
                        {
                            if (nuevalinea.Split(' ')[j].Contains(")"))
                            {
                                cierre = j;
                                for (int fj = 0; fj < nuevalinea.ToCharArray().Length; fj++)
                                {
                                    if (nuevalinea.ToCharArray()[fj].ToString().Equals(")"))
                                        //MessageBox.Show("Contiene ) j= " + fj);
                                        fin = fj;
                                }

                            }
                        }
                        //MessageBox.Show("nueva linea: inicio= "+inicio +" fin= "+fin);
                        recAsignar(nuevalinea.Substring(inicio + 1, fin - inicio - 1));
                        rtxtCS.Text = rtxtCS.Text + ")";
                        i = cierre;
                    }
                    else
                    if (i == 1)
                    {
                        rtxtCS.Text = rtxtCS.Text + nuevalinea.Split(' ')[i];
                    }
                    else
                    {
                        if (nuevalinea.Split(' ')[i].Equals("")) { }
                        else
                        {
                            rtxtCS.Text = rtxtCS.Text + " / " + nuevalinea.Split(' ')[i];
                        }
                    }
                }
            }
            if (!nuevalinea.StartsWith("\\"))
            {
                if (!nuevalinea.StartsWith("/"))
                {
                    if(!nuevalinea.StartsWith("*"))
                    {
                        if(!nuevalinea.StartsWith("-"))
                        {
                            if (!nuevalinea.StartsWith("+"))
                            {
                                MessageBox.Show("operador no identificado");
                                rtxtCS.Text = "";
                            }
                        }
                    }
                }
            }
            //rtxtCS.Text = rtxtCS.Text + ")";
            //}
            /*
            else
            {
                for (int i = 0; i < nuevalinea.Length; i++)
                {
                    if (nuevalinea.ToCharArray()[i].ToString().Equals("("))
                    {
                        inicio = i+1;
                        break;
                    }
                }
                for (int i = 0; i < nuevalinea.Length; i++)
                {
                    if (nuevalinea.ToCharArray()[i].ToString().Equals(")"))
                    {
                        fin = i;
                    }
                }
                
                //MessageBox.Show(nuevalinea.Substring(inicio, fin-inicio));
                recAsignar(nuevalinea.Substring(inicio, fin - inicio));
            }
            */



            return respuesta;
        }

        private void imprimir(char simbolo, string[] variabs)
        {
            
        }

        //Asigna valores a las variables
        private void Asignar(String linea, int numLinea)
        {
            //declaración de variables
            string nombre;
            double valor;
            string valornuevavar,nuevalinea="",parentesisentrada;
            int parentesisCount=0;
            Variable varItem = new Variable();
            bool existe = false;
            bool existeas = false;

            for (int i = 0; i < linea.Length; i++)
            {
                if (linea.EndsWith(" "))
                {
                    linea = linea.Substring(0, linea.Length - 1);
                }
            }

            for(int pars = 0; pars < linea.Length; pars++)
            {
                //MessageBox.Show(linea.ToCharArray()[pars].ToString());
                if (linea.ToCharArray()[pars].ToString().Equals("("))
                {
                    parentesisCount += 1;
                }
            }
            //MessageBox.Show("parentesis count: "+parentesisCount);

            if (parentesisCount >= 2)
            {
                String[] nvars = linea.Split(' ');



                for (int nv = 2; nv < nvars.Length; nv++)
                {
                    nuevalinea = nuevalinea + " " + nvars[nv];
                }

                //MessageBox.Show("Nueva linea: '" + nuevalinea+"'");
                rtxtCS.Text = rtxtCS.Text + "double " + linea.Split(' ')[1] + ";\n";
                rtxtCS.Text = rtxtCS.Text + linea.Split(' ')[1] + " = ";
                varItem.Nombre = linea.Split(' ')[1];
                varItem.Valor = 0;
                listaVariables.Add(varItem);
                recAsignar(nuevalinea.Substring(2, nuevalinea.Length - 3));
                rtxtCS.Text = rtxtCS.Text + ";\n";

            }
            else if(parentesisCount ==1){
                String[] nvars = linea.Split(' ');
                for (int i = 0; i < nvars.Length; i++)
                {
                    existe = false;
                    foreach (var item in listaVariables)
                    {
                        if (item.Nombre.Equals(nvars[i]))
                        {
                            existe = true;
                        }
                    }
                    foreach (var item in listaVariables)
                    {
                        if (item.Nombre.Equals(linea.Split(' ')[1]))
                        {
                            existeas = true;
                        }
                    }
                    

                    if (esNumero(nvars[i]))
                    {
                        existe = true;
                    }
                    if (!existe)
                    {
                        //MessageBox.Show("La variable " + nvars[i] + " no existe");
                        DialogResult dialogResult = MessageBox.Show("La variable " + nvars[i] + " no existe. ¿Desea declararla?", "Variable no existe", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            do
                            {
                                valornuevavar = Microsoft.VisualBasic.Interaction.InputBox("Valor de la variable", "valor de " + nvars[i], "0");
                                if (!esNumero(valornuevavar))
                                {
                                    MessageBox.Show("Debe ser valor numerico");
                                }
                            } while (!esNumero(valornuevavar));

                            rtxtLISP.Text = "(\n";
                            rtxtLISP.Text = rtxtLISP.Text + "(leer " + nvars[i] + ")\n";
                            rtxtLISP.Text = rtxtLISP.Text + "(asignar " + nvars[i] + " " + valornuevavar + ")\n";
                            varItem.Nombre = nvars[i];
                            varItem.Valor = double.Parse(valornuevavar);
                            for (int j = 1; j < textoEntrada.Length - 1; j++)
                            {
                                rtxtLISP.Text = rtxtLISP.Text + textoEntrada[j] + "\n";
                            }
                            rtxtLISP.Text = rtxtLISP.Text + ")";
                            MessageBox.Show("Al terminar proceso, Clickee convertir");
                            btnConvertir_Click(null,EventArgs.Empty);

                        }
                        else if (dialogResult == DialogResult.No)
                        {

                        }
                    }
                    if (!existeas)
                    {
                        //MessageBox.Show("La variable " + linea.Split(' ')[1] + " no existe");
                        DialogResult dialogResult = MessageBox.Show("La variable " + linea.Split(' ')[1] + " no existe. ¿Desea declararla?", "Variable no existe", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            do
                            {
                                valornuevavar = Microsoft.VisualBasic.Interaction.InputBox("Valor de la variable", "valor de " + linea.Split(' ')[1], "0");
                                if (!esNumero(valornuevavar))
                                {
                                    MessageBox.Show("Debe ser valor numerico");
                                }
                            } while (!esNumero(valornuevavar));

                            rtxtLISP.Text = "(\n";
                            rtxtLISP.Text = rtxtLISP.Text + "(leer " + linea.Split(' ')[1] + ")\n";
                            rtxtLISP.Text = rtxtLISP.Text + "(asignar " + linea.Split(' ')[1] + " " + valornuevavar + ")\n";
                            varItem.Nombre = linea.Split(' ')[1];
                            varItem.Valor = double.Parse(valornuevavar);
                            for (int j = 1; j < textoEntrada.Length - 1; j++)
                            {
                                rtxtLISP.Text = rtxtLISP.Text + textoEntrada[j] + "\n";
                            }
                            rtxtLISP.Text = rtxtLISP.Text + ")";
                            MessageBox.Show("Al terminar proceso, Clickee convertir");
                            
                            btnConvertir_Click(null, EventArgs.Empty);

                        }
                        else if (dialogResult == DialogResult.No)
                        {

                        }
                    }
                }

                if (linea.Split('(')[1].StartsWith("+"))
                {
                    //ES SUMA
                    rtxtCS.Text = rtxtCS.Text+linea.Split(' ')[1]+" = ";
                    foreach (var item in listaVariables)
                    {
                        if (linea.Split(' ')[1].Equals(item.Nombre))
                        {
                            item.Valor = Sumar(linea.Split('(')[1].Substring(1, linea.Split('(')[1].Substring(1).Length - 1), "A");
                        }
                    }
                }
                if (linea.Split('(')[1].StartsWith("-"))
                {
                    //ES RESTA
                    rtxtCS.Text = rtxtCS.Text + linea.Split(' ')[1] + " = ";
                    foreach (var item in listaVariables)
                    {
                        if (linea.Split(' ')[1].Equals(item.Nombre))
                        {
                            item.Valor = Restar(linea.Split('(')[1].Substring(1, linea.Split('(')[1].Substring(1).Length - 1), "A");
                        }
                    }
                }
                if (linea.Split('(')[1].StartsWith("*"))
                {
                    //ES MULT
                    rtxtCS.Text = rtxtCS.Text + linea.Split(' ')[1] + " = ";
                    foreach (var item in listaVariables)
                    {
                        if (linea.Split(' ')[1].Equals(item.Nombre))
                        {
                            item.Valor = Multiplicar(linea.Split('(')[1].Substring(1, linea.Split('(')[1].Substring(1).Length - 1), "A");
                        }
                    }
                }
                if (linea.Split('(')[1].StartsWith("/"))
                {
                    //ES DIVISION
                    rtxtCS.Text = rtxtCS.Text + linea.Split(' ')[1] + " = ";
                    foreach (var item in listaVariables)
                    {
                        if (linea.Split(' ')[1].Equals(item.Nombre))
                        {
                            item.Valor = Dividir(linea.Split('(')[1].Substring(1, linea.Split('(')[1].Substring(1).Length - 1), "A");
                        }
                    }
                }
            }
            else
            {

                //MessageBox.Show(linea);
                nombre = linea.Split(' ')[1];
                valor = Double.Parse(linea.Split(' ')[2]);

                if (listaVariables.Count == 0)
                {
                    MessageBox.Show("Error linea: " + numLinea + "No hay ninguna variable declarada.");
                }
                else
                {
                    foreach (var item in listaVariables)
                    {
                        if (nombre.Equals(item.Nombre))
                        {
                            existe = true;
                            item.Valor = valor;
                            rtxtCS.Text = rtxtCS.Text + item.Nombre + " = " + item.Valor + ";\n";
                        }
                    }
                }
            }

            if (!existe)
            {
                //MessageBox.Show("No se ha declarado la variable.");
                limpiar();
            }

        }

        private void Escribir(String linea, int numLinea)
        {
            string nombre;
            int parentesis=0;
            Variable varItem = new Variable();
            bool existe = false;

            for (int i = 0; i < linea.Length; i++)
            {
                if (linea.EndsWith(" "))
                {
                    linea = linea.Substring(0, linea.Length - 1);
                }
            }

            nombre = linea.Substring(9);
            

            for(int i = 0; i < nombre.ToCharArray().Length; i++)
            {
                if (nombre.ToCharArray()[i] == '(')
                {
                    parentesis += 1;
                }
                if(nombre.ToCharArray()[i] == ')')
                {
                    parentesis -= 1;
                }
            }

            if (nombre.StartsWith(")")){
                limpiar();
                MessageBox.Show("Error en linea: " + numLinea + " No se puede iniciar con ')'");
            }

            if (nombre.StartsWith("("))
            {

                String[] nvars = (linea.Split('(')[1].Substring(1, linea.Split('(')[1].Substring(1).Length - 1)).Split(' ');

                for (int i = 0; i < nvars.Length; i++)
                {
                    existe = false;
                    foreach (var item in listaVariables)
                    {
                        if (item.Nombre.Equals(nvars[i]))
                        {
                            if (i == 0)
                            {
                            }
                            else
                            {
                                existe = true;
                            }
                        }
                    }

                    if (esNumero(nvars[i]))
                    {
                        existe = true;
                    }
                }

                if (nombre.Substring(1).StartsWith("+"))
                {
                    //ES SUMA
                    Sumar(" " + nombre.Substring(3, nombre.Length - 4), "E");
                }
                if (nombre.Substring(1).StartsWith("-"))
                {
                    //ES RESTA
                    Restar(" " + nombre.Substring(3, nombre.Length - 4), "E");
                }
                if (nombre.Substring(1).StartsWith("*"))
                {
                    //ES MULTIPLICACION
                    Multiplicar(" " + nombre.Substring(3, nombre.Length - 4), "E");
                    
                }
                if (nombre.Substring(1).StartsWith("/"))
                {
                    //ES DIVISION
                    Dividir(" " + nombre.Substring(3, nombre.Length - 4), "E");
                }
            }
                     if (listaVariables.Count == 0)
            {
                MessageBox.Show("Error linea: " + numLinea + " No hay ninguna variable declarada.");
            }
            else
            {
                foreach (var item in listaVariables)
                {
                    if (nombre.Equals(item.Nombre))
                    {
                        rtxtCS.Text = rtxtCS.Text + "Console.WriteLine("+item.Nombre+");\n";
                        existe = true;
                    }
                }
            }

            if (parentesis != 0)
            {
                if (parentesis > 0)
                {
                    MessageBox.Show("Error en linea: "+numLinea+" Hay un '(' sin cerrar");
                }
                else{
                    MessageBox.Show("Error en linea: " + numLinea + " Hay un ')' sin abrir");
                }
                limpiar();
            }

            if (!existe)
            {
                MessageBox.Show("No se ha declarado la variable.");
                limpiar();
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            rtxtLISP.Text = "";
            limpiar();
        }

        private void limpiar()
        {
            //rtxtCS.Text = "";
        }

        private double Sumar(String variables, String tipo)
        {
            bool existe = false;
            double total = 0;
            String[] nvars = variables.Split(' ');
            Variable varItem = new Variable();

            if (tipo.Equals("E"))
            {
                rtxtCS.Text = rtxtCS.Text + "Console.WriteLine(";
            }
            
            for(int i = 0; i < nvars.Length; i++)
            {
                existe = false;
                foreach (var item in listaVariables)
                {
                    if (item.Nombre.Equals(nvars[i]))
                    {
                        if (i==0)
                        {
                            total = item.Valor;
                            rtxtCS.Text = rtxtCS.Text + item.Nombre;
                        }
                        else
                        {
                            rtxtCS.Text = rtxtCS.Text + item.Nombre;
                            existe = true;
                            total = total + item.Valor;
                        }
                    }
                }
                if (esNumero(nvars[i]) && !nvars[i].Equals(""))
                {
                    rtxtCS.Text = rtxtCS.Text + nvars[i];
                    existe = true;
                }
                if (i != 0 && i != nvars.Length-1)
                {
                    rtxtCS.Text = rtxtCS.Text + " + ";
                }
                if (i == nvars.Length-1)
                {
                    if (tipo.Equals("E"))
                    {
                        rtxtCS.Text = rtxtCS.Text + ");";
                    }
                    else
                    {
                        rtxtCS.Text = rtxtCS.Text + ";\n";
                    }
                    
                }


                
            }

            if (!existe)
            {
                MessageBox.Show("Variable no declarada");
                limpiar();
                return 0;
            }
            else
            {
                return total;
            }
        }
        private double Restar(String variables, String tipo)
        {
            bool existe = false;
            double total = -1;
            String[] nvars = variables.Split(' ');

            if (tipo.Equals("E")){
                rtxtCS.Text = rtxtCS.Text + "Console.WriteLine(";
            }
            

            for (int i = 0; i < nvars.Length; i++)
            {
                existe = false;
                foreach (var item in listaVariables)
                {
                    if (item.Nombre.Equals(nvars[i]))
                    {
                        if (i == 0)
                        {
                            total = item.Valor;
                            rtxtCS.Text = rtxtCS.Text + item.Nombre;
                        }
                        else
                        {
                            rtxtCS.Text = rtxtCS.Text + item.Nombre;
                            existe = true;
                            total = total - item.Valor;
                        }
                    }
                }
                if (esNumero(nvars[i]) && !nvars[i].Equals(""))
                {
                    rtxtCS.Text = rtxtCS.Text + nvars[i];
                    existe = true;
                }

                if (i != 0 && i != nvars.Length - 1)
                {
                    rtxtCS.Text = rtxtCS.Text + " - ";
                }
                if (i == nvars.Length - 1)
                {
                    if (tipo.Equals("E"))
                    {
                        rtxtCS.Text = rtxtCS.Text + ");";
                    }
                    else
                    {
                        rtxtCS.Text = rtxtCS.Text + ";\n";
                    }

                }

            }

            if (!existe)
            {
                MessageBox.Show("Variable no declarada");
                limpiar();
                return 0;
            }
            else
            {
                return total;
            }
        }
        private double Multiplicar(String variables, String tipo)
        {
            bool existe = false;
            double total = 1;
            String[] nvars = variables.Split(' ');

            if (tipo.Equals("E"))
            {
                rtxtCS.Text = rtxtCS.Text + "Console.WriteLine(";
            }

            for (int i = 0; i < nvars.Length; i++)
            {
                existe = false;
                foreach (var item in listaVariables)
                {
                    if (item.Nombre.Equals(nvars[i]))
                    {
                        if (i == 0)
                        {
                            total = item.Valor;
                            rtxtCS.Text = rtxtCS.Text + item.Nombre;
                        }
                        else
                        {
                            rtxtCS.Text = rtxtCS.Text + item.Nombre;
                            existe = true;
                            total = total * item.Valor;
                        }
                    }
                }
                if (esNumero(nvars[i]) && !nvars[i].Equals(""))
                {
                    rtxtCS.Text = rtxtCS.Text + nvars[i];
                    existe = true;
                }

                if (i != 0 && i != nvars.Length - 1)
                {
                    rtxtCS.Text = rtxtCS.Text + " * ";
                }
                if (i == nvars.Length - 1)
                {
                    if (tipo.Equals("E"))
                    {
                        rtxtCS.Text = rtxtCS.Text + ");";
                    }
                    else
                    {
                        rtxtCS.Text = rtxtCS.Text + ";\n";
                    }

                }

            }

            if (!existe)
            {
                MessageBox.Show("Variable no declarada");
                limpiar();
                return 0;
            }
            else
            {
                return total;
            }
        }
        private double Dividir(String variables, String tipo)
        {
            bool existe = false;
            double total = 0;
            String[] nvars = variables.Split(' ');

            if (tipo.Equals("E"))
            {
                rtxtCS.Text = rtxtCS.Text + "Console.WriteLine(";
            }

            for (int i = 0; i < nvars.Length; i++)
            {
                existe = false;
                foreach (var item in listaVariables)
                {
                    if (item.Nombre.Equals(nvars[i]))
                    {
                        if (total==0)
                        {
                            total = item.Valor;
                            rtxtCS.Text = rtxtCS.Text + item.Nombre;
                            existe = true;
                        }
                        else
                        {
                            rtxtCS.Text = rtxtCS.Text + item.Nombre;
                            existe = true;
                            if (item.Valor == 0)
                            {
                                MessageBox.Show("Division entre 0");
                            }
                            else
                            {
                                total = total / item.Valor;
                            }
                            
                        }
                    }
                }
                if (esNumero(nvars[i]) && !nvars[i].Equals(""))
                {
                    rtxtCS.Text = rtxtCS.Text + nvars[i];
                    existe = true;
                }
                if (i != 0 && i != nvars.Length - 1)
                {
                    rtxtCS.Text = rtxtCS.Text + " / ";
                }
                if (i == nvars.Length - 1)
                {
                    if (tipo.Equals("E"))
                    {
                        rtxtCS.Text = rtxtCS.Text + ");";
                    }
                    else
                    {
                        rtxtCS.Text = rtxtCS.Text + ";\n";
                    }

                }

            }

            if (!existe)
            {
                MessageBox.Show("Variable no declarada");
                limpiar();
                return 0;
            }
            else
            {
                return total;
            }
        }

        private bool esNumero(string variable)
        {
            bool numero = true;
            int punto = 0;

            for (int i = 0; i < variable.Length; i++)
            {
                if (!(variable.ToCharArray()[i] >= '0' && variable.ToCharArray()[i] <= '9' && (!variable.ToCharArray()[i].ToString().Equals(""))))
                {
                    numero = false;
                    if (variable.ToCharArray()[i].ToString().Equals("."))
                    {
                        punto += 1;
                        numero = true;
                    }
                    if (variable.StartsWith("-"))
                    {
                        numero = true;
                        if (variable.Substring(1,variable.Length-2).Contains("-"))
                        {
                            numero = false;
                        }
                    }
                }

                if (!(punto == 0 || punto == 1))
                {
                    numero = false;
                }

            }

            return numero;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rtxtLISP.Text = "(\n\n)";
            this.ActiveControl = rtxtLISP;
            rtxtLISP.Select(2, 0);
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            String[] txt = rtxtLISP.Text.Split(new[] { "\n" }, StringSplitOptions.None);
            rtxtLISP.Text = "";
            for(int i = 0; i < txt.Length-1; i++)
            {
                rtxtLISP.Text = rtxtLISP.Text + txt[i]+"\n";
            }
            rtxtLISP.Text = rtxtLISP.Text + "(leer "+ Microsoft.VisualBasic.Interaction.InputBox("Nombre de la variable", "Leer ", "0")+")\n\n)";
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            String[] txt = rtxtLISP.Text.Split(new[] { "\n" }, StringSplitOptions.None);
            rtxtLISP.Text = "";
            for (int i = 0; i < txt.Length - 1; i++)
            {
                rtxtLISP.Text = rtxtLISP.Text + txt[i] + "\n";
            }
            rtxtLISP.Text = rtxtLISP.Text + "(asignar " + Microsoft.VisualBasic.Interaction.InputBox("Nombre de la variable", "Asignar ", "variable") + " "+ Microsoft.VisualBasic.Interaction.InputBox("Valor de la variable", "Asignar ", "0") + ")\n\n)";
        }

        private void btnEscribir_Click(object sender, EventArgs e)
        {
            String[] txt = rtxtLISP.Text.Split(new[] { "\n" }, StringSplitOptions.None);
            rtxtLISP.Text = "";
            for (int i = 0; i < txt.Length - 1; i++)
            {
                rtxtLISP.Text = rtxtLISP.Text + txt[i] + "\n";
            }
            rtxtLISP.Text = rtxtLISP.Text + "(escribir " + Microsoft.VisualBasic.Interaction.InputBox("Nombre de la variable", "Escribir", "variable") + ")\n\n)";
        }

        private void btnToCBLISP_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(rtxtLISP.Text.Replace("\n",Environment.NewLine));
            MessageBox.Show("LISP copiado al portapapeles");
        }

        private void btnToCBCS_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(rtxtCS.Text.Replace("\n", Environment.NewLine));
            MessageBox.Show("C# copiado al portapapeles");
        }

        private void btnGuardarLISP_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            String[] txt = rtxtLISP.Text.Split(new[] { "\n" }, StringSplitOptions.None);

            save.FileName = "CodigoLISP.txt";
            save.Filter = "Text File | *.txt";

            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(save.OpenFile());

                for (int i = 0; i<txt.Length; i++)
                {
                    writer.WriteLine(txt[i]);
                }
                writer.Dispose();
                writer.Close();
            }
        }

        private void btnGuardarCS_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            String[] txt = rtxtCS.Text.Split(new[] { "\n" }, StringSplitOptions.None);

            save.FileName = "codigoCS.txt";
            save.Filter = "Text File | *.txt";

            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(save.OpenFile());

                for (int i = 0; i < txt.Length; i++)
                {
                    writer.WriteLine(txt[i]);
                }
                writer.Dispose();
                writer.Close();
            }
        }

        private void btnGuardarTodo_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            String[] txtL = rtxtLISP.Text.Split(new[] { "\n" }, StringSplitOptions.None);
            String[] txtC = rtxtCS.Text.Split(new[] { "\n" }, StringSplitOptions.None);

            save.FileName = "DefaultOutputName.txt";
            save.Filter = "Text File | *.txt";

            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(save.OpenFile());

                for (int i = 0; i < txtL.Length; i++)
                {
                    writer.WriteLine(txtL[i]);
                }
                writer.WriteLine();
                writer.WriteLine("#");
                writer.WriteLine();
                for (int i = 0; i < txtC.Length; i++)
                {
                    writer.WriteLine(txtC[i]);
                }
                writer.Dispose();
                writer.Close();
            }
        }
    }
}
