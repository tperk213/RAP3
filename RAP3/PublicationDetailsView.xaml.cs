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

namespace RAP3
{
    /// <summary>
    /// Interaction logic for PublicationDetailsView.xaml
    /// </summary>
    public partial class PublicationDetailsView : UserControl
    {
        public PublicationDetailsView()
        {
            InitializeComponent();
        }

        public void SelectPublication(object sender, EventArgs ea)
        {
            var e = (SelectionChangedEventArgs)ea;

            if (e.AddedItems.Count == 0)
            {
                PublicationLists.DataContext = null;
            }
            else
            {
                Publication r = DatabaseAdapter.FetchFullPublicationDetails((Publication)e.AddedItems[0]);
                PublicationLists.DataContext = r;

                Console.WriteLine(r);
            }
        }
    }

}
