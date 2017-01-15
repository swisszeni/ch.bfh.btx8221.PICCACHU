using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BFH_USZ_PICC.Controls
{
    public partial class SettingsButton : StackLayout
    {
        public SettingsButton()
        {
            InitializeComponent();

            GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = TransitionCommand
            });
        }

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create("Command", typeof(ICommand), typeof(SettingsButton));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create("CommandParameter", typeof(object), typeof(SettingsButton));

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        private ICommand TransitionCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await this.ScaleTo(0.97, 50, Easing.Linear);
                    await Task.Delay(90);
                    await this.ScaleTo(1, 50, Easing.Linear);

                    if (Command != null)
                    {
                        Command.Execute(CommandParameter);
                    }
                });
            }
        }
    }
}
