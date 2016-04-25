using BFH_USZ_PICC.ViewModels;
using Xamarin.Forms;

namespace BFH_USZ_PICC.Views
{
    public class BaseView : ContentPage
    {
        public BaseView()
        {
            SetBinding(Page.TitleProperty, new Binding(BaseViewModel.TitlePropertyName));
            SetBinding(Page.IconProperty, new Binding(BaseViewModel.IconPropertyName));
        }
    }
}
