using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BFH_USZ_PICC.Controls
{
    public partial class SpeechButton : Grid
    {
        public SpeechButton()
        {
            InitializeComponent();

            BindingContext = this;

            GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = SwapCommand
            });
        }

        public static readonly BindableProperty OnStateProperty =
    BindableProperty.Create("IsOnState", typeof(bool), typeof(SpeechButton));

        public bool IsOnState
        {
            get { return (bool)GetValue(OnStateProperty); }
            set { SetValue(OnStateProperty, value); }
        }

        public static readonly BindableProperty EnabledImagePathProperty =
    BindableProperty.Create("EnabledImagePath", typeof(string), typeof(SpeechButton));

        public string EnabledImagePath
        {
            get { return (string)GetValue(EnabledImagePathProperty); }
            set { SetValue(EnabledImagePathProperty, value); }
        }

        public static readonly BindableProperty DisabledImagePathProperty =
BindableProperty.Create("DisabledImagePath", typeof(string), typeof(SpeechButton));

        public string DisabledImagePath
        {
            get { return (string)GetValue(DisabledImagePathProperty); }
            set { SetValue(DisabledImagePathProperty, value); }
        }

        public static readonly BindableProperty CommandProperty =
    BindableProperty.Create("Command", typeof(ICommand), typeof(SpeechButton));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        private ICommand SwapCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (Command != null)
                    {
                        Command.Execute(IsOnState);
                    }
                });
            }
        }
    }
}
