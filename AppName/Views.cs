using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AppName
{
    /// <summary>
    /// Create a only one Form to App, only one xD!
    /// </summary>
    public class Views
    {
        private List<string> vistaName = new List<string>();
        private List<List<bool>> enable = new List<List<bool>>();
        private List<List<string>> texts = new List<List<string>>();
        private List<List<Type>> types = new List<List<Type>>();
        private List<List<Control>> vistas = new List<List<Control>>();
        private int actualView = 0;
        private string sactualVista;
              

        public string ActualView
        {
            get
            {
                return sactualVista;
            }            
        }

        public Views()
        {

        }
        /// <summary>
        /// You can Create a new List of Controls
        /// </summary>
        /// <param name="name">Name of View</param>
        public void CreateNewView(string name)
        {
            vistaName.Add(name);
            List<Control> nuevo = new List<Control>();
            List<Type> ntype = new List<Type>();
            List<string> ntext = new List<string>();
            List<bool> nen = new List<bool>();
            types.Add(ntype);
            texts.Add(ntext);
            vistas.Add(nuevo);
            enable.Add(nen);
        }
        /// <summary>
        /// method to insert a new objet on last created View
        /// </summary>
        /// <typeparam name="T">a Class extends of Control</typeparam>
        /// <param name="var">Objet</param>
        /// <param name="newText">Objet.Text</param>
        /// <param name="Enable_">Objet.Enable</param>
        public void InsertNewControlOnView<T>(T var, string newText = "", bool Enable_ = true) where T : Control
        {
            var x = var as Control;
            int index = texts.Count - 1;
            texts[index].Add(newText);
            types[index].Add(var.GetType());
            vistas[index].Add(x);
            enable[index].Add(Enable_);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">a Class extends of Control</typeparam>
        /// <param name="nameView">The name of the View</param>
        /// <param name="var"></param>
        /// <param name="newText"></param>
        /// <param name="Enable_"></param>
        public void InsertNewControlOnView<T>(string nameView, T var, string newText = "", bool Enable_ = true) where T : Control
        {
            var x = var as Control;
            int index = SharVista(nameView);
            if (index != -1)
            {
                texts[index].Add(newText);
                types[index].Add(var.GetType());
                vistas[index].Add(x);
                enable[index].Add(Enable_);
            }

        }

        public void InitViews()
        {
            for (int i = 0; i < vistas.Count; i++)
            {
                if (i != actualView)
                {
                    Visbale(i, false);
                }
                else
                {
                    Visbale(i, true);
                }
            }
            MoveToOtherView(vistaName[actualView]);


        }
        public void Visbale(int index, bool op)
        {
            for (int i = 0; i < vistas[index].Count; i++)
            {
                vistas[index][i].Visible = op;
                vistas[index][i].Text = texts[index][i];
                vistas[index][i].Enabled = enable[index][i];
            }
        }

        public int SharVista(string text)
        {
            for (int i = 0; i < vistaName.Count; i++)
            {
                if (text == vistaName[i])
                    return i;
            }
            return -1;
        }

        public void MoveToOtherView(string text)
        {
            int next = SharVista(text);
            if (next != -1)
            {
                Visbale(actualView, false);
                Visbale(next, true);
                actualView = next;
                sactualVista = text;
            }

        }

        public void ModificarControlOnVista<T>(string nameVista, T x, string textControl, bool en = true)
        {
            int i = SharVista(nameVista);
            if (i != -1)
            {
                int j = 0;
                foreach (Control aux in vistas[i])
                {
                    if (aux.Name == (x as Control).Name)
                    {
                        texts[i][j] = textControl;
                        enable[i][j] = en;
                    }
                    j++;
                }
            }
        }

        public void ReplaceVista(string oldVista, string newVista, bool clear = false)
        {
            int ioldvista = SharVista(oldVista);
            if (ioldvista != -1)
            {
                vistaName[ioldvista] = newVista;
                if (clear)
                {
                    vistas[ioldvista].Clear();
                    texts[ioldvista].Clear();
                    enable[ioldvista].Clear();
                }
            }
        }

        public  void ValInt(ref TextBox x)
        {
            int i = 0;
            foreach (char a in x.Text)
            {
                if (!(a >= '0' && a <= '9'))
                    x.Text = x.Text.Remove(i);
                i++;
            }
        }
        public  void ValDouble(ref TextBox x)
        {
            int i = 0;
            bool ready = false;
            foreach (char a in x.Text)
            {

                if (a == '.')
                {
                    if (ready)
                        x.Text = x.Text.Remove(i);
                    else
                        ready = true;
                }
                else
                    if (!(a >= '0' && a <= '9'))
                    x.Text = x.Text.Remove(i);

                i++;
            }
        }
        public void PasswordTextBox(ref TextBox x, ref string pass)
        {
            pass = x.Text;
            x.PasswordChar = '*';                     
        }

    }
}
