using System.Windows.Controls;
using Lab1ParkhomenkoCSharp2019.ViewModels.Authentication;

namespace Lab1ParkhomenkoCSharp2019.Views.Authentication
{
    public partial class SignInControl : UserControl
    {
        internal SignInControl()
        {
            InitializeComponent();
            DataContext = new SignInViewModel();
        }
    }
}
