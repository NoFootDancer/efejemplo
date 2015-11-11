using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Inicializar base de datos
            //Hackear facebook
            mibd db = new mibd();
            Empleados emp = new Empleados();

            if (Regex.IsMatch(unombre.Text, "[a-zA-z]") && Regex.IsMatch(unombre2.Text, @"^\d+$"))
            {
                emp.Nombre = unombre.Text;
                emp.sueldo = int.Parse(unombre2.Text);

                db.Empleados.Add(emp);
                db.SaveChanges();
            }
            else {

                MessageBox.Show("No se admiten numeros en nombre, ni letras en sueldo");
            
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            mibd db = new mibd();
             if (Regex.IsMatch(unombre.Text, "[a-zA-z]") && Regex.IsMatch(unombre2.Text, @"^\d+$") && Regex.IsMatch(unombre3.Text, @"^\d+$"))
            {
            int id = int.Parse(unombre3.Text);
            var emp = /*from x in*/ db.Empleados
                      //where x.id == id
                      //select x;
                      .SingleOrDefault(x => x.id == id);

            if(emp != null){
                emp.Nombre = unombre.Text;
                emp.sueldo = int.Parse(unombre2.Text);
                db.SaveChanges();
            }
             }else{
             
             MessageBox.Show("Motherfucker, llena bien los recuadros");
             }

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            mibd db = new mibd();
            if (Regex.IsMatch(unombre3.Text, @"^\d+$"))
            {
                int id = int.Parse(unombre3.Text);
                var emp = /*from x in*/ db.Empleados
                    //where x.id == id
                    //select x;
                          .SingleOrDefault(x => x.id == id);

                if (emp != null)
                {
                    db.Empleados.Remove(emp);

                    db.SaveChanges();
                }
            }//if confirmar
            else {

                MessageBox.Show("MEH");
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            mibd db = new mibd();
            int id = int.Parse(unombre3.Text);
         //   var emp = /*from x in*/ db.Empleados
                //where x.id == id
                //select x;
                      //.SingleOrDefault(x => x.id == id);

            var reg = from s in db.Empleados
                      where s.id == id
                      select new
                      {
                          s.Nombre,
                          s.sueldo
                      };

        //    if (emp != null)
       //     {
                //db.Empleados.Remove(emp);

          //      db.SaveChanges();
           //}

            dbgrid.ItemsSource = reg.ToList();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {


            mibd db = new mibd();
          //  int id = int.Parse(unombre3.Text);
            //   var emp = /*from x in*/ db.Empleados
            //where x.id == id
            //select x;
            //.SingleOrDefault(x => x.id == id);

            var reg = from s in db.Empleados
                      select s;

            //    if (emp != null)
            //     {
            //db.Empleados.Remove(emp);

            //      db.SaveChanges();
            //}

            dbgrid.ItemsSource = reg.ToList();
            


            // \d+  /   \d{3}  /   \d{1,5}[a-zA-z\s]  
            //
        }

        private void Grid_Loaded_1(object sender, RoutedEventArgs e)
        {
           /* mibd db = new mibd();
            cbdepts.ItemsSource = db.departamentos.toList();
            cbdepts.DisplayMemberPath = "Nombre";
            cbdepts.SelectedValuePath = "id";
        
            */ }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtDeps.Text, @"^[a-zA-Z]+$"))
            {
                mibd db = new mibd();
                Departamento dep = new Departamento();
                dep.Nombre = txtDeps.Text;


                db.Departamentos.Add(dep);
                db.SaveChanges();
            }
            else { MessageBox.Show("Verifique ingresar los campos correctos"); }
        }
    }
}
