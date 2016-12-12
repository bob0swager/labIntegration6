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

namespace CommunicationWithDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ComboBox selDesign;
        public MainWindow()
        {
            InitializeComponent();
            cmbType.Items.Insert(0, "XML");
            cmbType.Items.Insert(1, "JSON");
            cmbType.Items.Insert(2, "YAML");
            cmbType.Items.Insert(3, "OGDL");
            cmbType.Items.Insert(4, "XML with style");
            cmbType.SelectedIndex = 0;

            cmbStyle.Items.Insert(0, "style 1");
            cmbStyle.Items.Insert(1, "style 2");
            cmbStyle.SelectedIndex = 0;
            selDesign = cmbStyle;
            Connection con = new Connection();
        }

        private void btngetTop5_Click(object sender, RoutedEventArgs e)
        {
            Connection.getTop5(cmbType.SelectedItem);
        }

        private void btnGetNewest_Click(object sender, RoutedEventArgs e)
        {
            Connection.getNewest(cmbType.SelectedItem);
        }

        private void btnGetSpecFields_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtFlds.Text))
            {

                Connection.getSpecFields(txtFlds.Text, cmbType.SelectedItem);
            }
            else
                MessageBox.Show("Not correct fields");
        }

        private void btnGetById_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtId.Text))
            {
                
                Connection.getById(txtId.Text, cmbType.SelectedItem);
            }
            else
                MessageBox.Show("Not correct Id");
        }

        private void btnGetByLocation_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtLocat.Text))
            {
                Connection.getByLocation(txtLocat.Text, cmbType.SelectedItem);
            }
            else
                MessageBox.Show("Not correct location");
        }

        private void btnGetByManyId_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtIds.Text))
            {
                Connection.getByIds(txtIds.Text, cmbType.SelectedItem);
            }
            else
                MessageBox.Show("Not correct Ids");
        }

        private void btnGetOldest_Click(object sender, RoutedEventArgs e)
        {
            Connection.getOldest(cmbType.SelectedItem);
        }

        private void btnGetAll_Click(object sender, RoutedEventArgs e)
        {
            Connection.getAll(cmbType.SelectedItem);
        }

        private void btnGetNameLinkById_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtIdNL.Text))
            {
                Connection.getNameAndLinkById(txtIdNL.Text, cmbType.SelectedItem);
            }
            else
                MessageBox.Show("Not correct Id");
           
        }

        private void btnGetNameLink_Click(object sender, RoutedEventArgs e)
        {
            Connection.getNameAndLink(cmbType.SelectedItem);
        }
    }
}
