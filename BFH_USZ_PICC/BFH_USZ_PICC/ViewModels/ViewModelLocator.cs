using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.Services;
using BFH_USZ_PICC.Services.Design;
using BFH_USZ_PICC.ViewModels.JournalEntries;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BFH_USZ_PICC.ViewModels
{
    public class ViewModelLocator : DynamicObject
    {
        private static ViewModelResolver _resolver;

        private static readonly ViewModelLocator _instance = new ViewModelLocator();

        public static ViewModelLocator Instance
        {
            get { return _instance; }
        }

        private ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            // Register the Dataservices
            if(ViewModelBase.IsInDesignModeStatic)
            {
                // Register designtime service. Not really needed now, since xamarin designer is only just released as preview. But could proove useful later
                SimpleIoc.Default.Register<ILocalUserDataService, LocalUserDataServiceDesign>();
            } else
            {
                // We're live, register either Realm (iOS, Droid) or SQLite (UWP) as Datastore
                if (Device.OS == TargetPlatform.iOS || Device.OS == TargetPlatform.Android)
                {
                    SimpleIoc.Default.Register<ILocalUserDataService, LocalUserDataServiceRealm>();
                }
                else
                {
                    SimpleIoc.Default.Register<ILocalUserDataService, LocalUserDataServiceSQLite>();
                }
            }

            // Register the Services
            if(Device.OS == TargetPlatform.iOS)
            {
                SimpleIoc.Default.Register<INavigationService, NavigationService_iOS>();
            } else
            {
                SimpleIoc.Default.Register<INavigationService, NavigationService>();
            }

            // Register the ViewModels
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<MenuViewModel>();
            SimpleIoc.Default.Register<AddPICCViewModel>();
            SimpleIoc.Default.Register<MyPICCViewModel>();
            SimpleIoc.Default.Register<PICCDetailViewModel>();
            SimpleIoc.Default.Register<KnowledgeEntriesViewModel>();
            SimpleIoc.Default.Register<KnowledgeEntryDetailViewModel>();
            SimpleIoc.Default.Register<GlossaryViewModel>();
            SimpleIoc.Default.Register<DisorderViewModel>();
            SimpleIoc.Default.Register<DisorderDetailViewModel>();
            SimpleIoc.Default.Register<MaintenanceInstructionViewModel>();
            SimpleIoc.Default.Register<JournalOverviewViewModel>();
            SimpleIoc.Default.Register<AdministeredDrugViewModel>();
            SimpleIoc.Default.Register<BandageChangingViewModel>();
            SimpleIoc.Default.Register<BloodWithdrawalViewModel>();
            SimpleIoc.Default.Register<CatheterFlushViewModel>();
            SimpleIoc.Default.Register<InfusionViewModel>();
            SimpleIoc.Default.Register<MicroClaveChangingViewModel>();
            SimpleIoc.Default.Register<StatlockChangingViewModel>();
            SimpleIoc.Default.Register<MasterDataViewModel>();
            SimpleIoc.Default.Register<SettingsViewModel>();            
        }

        public static T Resolve<T>()
        {
            return ServiceLocator.Current.GetInstance<T>();
        } 

        public static ViewModelResolver Resolver
        {
            get
            {
                if (_resolver == null)
                {
                    _resolver = new ViewModelResolver();
                }
                return _resolver;
            }
        }

        public object this[string viewModelName]
        {
            get
            {
                return Resolver.Resolve(viewModelName);
            }
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = this[binder.Name];
            return true;
        }
    }

    public class ViewModelResolver
    {
        public ViewModelResolver()
        { }

        public object Resolve(string viewModelName)
        {
            var vmtype = this.GetType()
                .GetTypeInfo()
                .Assembly
                .DefinedTypes
                .FirstOrDefault(t => t.Name.Equals(viewModelName))
                .AsType();

            return ServiceLocator.Current.GetInstance(vmtype);
        }
    }
}
