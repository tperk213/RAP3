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
using RAPFinal;
using RAPFinal.Controllers;
using RAPFinal.Models;
using RAPFinal.Views;

namespace RAPFinal.Views
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
                SetPublication(e.AddedItems[0]);
            }
        }

        public void SetPublication(object passedInPublication)
        {
            Publication r = DatabaseAdapter.FetchFullPublicationDetails((Publication)passedInPublication);
            PublicationLists.DataContext = r;
        }
    }

}
