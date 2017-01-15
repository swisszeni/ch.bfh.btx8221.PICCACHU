using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Resx;
using BFH_USZ_PICC.Utilitys;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Reflection;
using PCLStorage;

namespace BFH_USZ_PICC.ViewModels
{
    class ExportViewModel : ViewModelBase
    {
        public async override Task OnNavigatedToAsync(object parameter, NavigationMode mode)
        {
            await base.OnNavigatedToAsync(parameter, mode);
        }
   

        // ICommand implementations
        private RelayCommand _exportButtonCommand;
        public RelayCommand ExportButtonCommand => _exportButtonCommand ?? (_exportButtonCommand = new RelayCommand(async () =>
       {
           if (await ((Shell)Application.Current.MainPage).DisplayAlert(AppResources.WarningText, AppResources.ExportPagePageInformationPopUpText, AppResources.ConfirmationButtonText, AppResources.CancelButtonText))
           {    
               //Get the path of the c
               var journalEntryCSVPathTask = DatabaseExporter.getDatabaseCSVPath();
               var journalEntryCSVPath = journalEntryCSVPathTask.Result;
             
               var emailTask = MessagingPlugin.EmailMessenger;
               if (emailTask.CanSendEmail)
               {
                   var email = new EmailMessageBuilder()
                   .To("schnf8@bfh.ch")
                   .Subject("Notizen zum PICC-Katheter")
                   .WithAttachment(journalEntryCSVPath, "csv")
                   .Build();

                   var test = email.Attachments;

                   emailTask.SendEmail(email);
                   // Device.OpenUri(new Uri("mailto:schnf8@bfh.ch?subject=PICC-Katheter&body=MyFile&attachment='" + filePath + "'""));
               }
           }
       }));

    }
}
