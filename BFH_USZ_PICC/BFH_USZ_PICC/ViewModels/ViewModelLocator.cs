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

namespace BFH_USZ_PICC.ViewModels
{
    public class ViewModelLocator : DynamicObject
    {
        static ViewModelResolver _resolver;

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

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
