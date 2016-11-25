using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Resx;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static BFH_USZ_PICC.Models.JournalEntry;
using static BFH_USZ_PICC.Models.PICC;

namespace BFH_USZ_PICC.Utilitys
{
    public class PICCInsertPositionToIndexConverter : IValueConverter
    {
        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            PICCInsertPosition position = (PICCInsertPosition)value;
            switch (position)
            {
                case PICCInsertPosition.AboveElbow:
                    return 2;
                case PICCInsertPosition.BelowElbow:
                    return 1;
            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (PICCInsertPosition)value;
        }

        #endregion
    }

    public class PICCInsertSideToIndexConverter : IValueConverter
    {
        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            PICCInsertSide side = (PICCInsertSide)value;
            switch (side)
            {
                case PICCInsertSide.Right:
                    return 2;
                case PICCInsertSide.Left:
                    return 1;
            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (PICCInsertSide)value;
        }

        #endregion
    }

    public class PICCInsertCountryToIndexConverter : IValueConverter
    {
        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            PICCInsertCountry country = (PICCInsertCountry)value;
            switch (country)
            {
                case PICCInsertCountry.Abroad:
                    return 2;
                case PICCInsertCountry.Switzerland:
                    return 1;
            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (PICCInsertCountry)value;
        }

        #endregion
    }

    public class HealthInstitutionToIndexConverter : IValueConverter
    {
        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            HealthInstitution healthInstitution = (HealthInstitution)value;
            switch (healthInstitution)
            {
                case HealthInstitution.NoInformation:
                    return 0;
                case HealthInstitution.Hospital:
                    return 1;
                case HealthInstitution.Ambulatory:
                    return 2;
                case HealthInstitution.Rehabilitation:
                    return 3;
                case HealthInstitution.HomeCare:
                    return 4;
                case HealthInstitution.Others:
                    return 5;
            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (HealthInstitution)value;
        }

        #endregion
    }

    public class HealthPersonToIndexConverter : IValueConverter
    {
        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            HealthPerson healthInstitution = (HealthPerson)value;
            switch (healthInstitution)
            {
                case HealthPerson.NoInformation:
                    return 0;
                case HealthPerson.FamilyDoctor:
                    return 1;
                case HealthPerson.Specialist:
                    return 2;
                case HealthPerson.NursingStaff:
                    return 3;
                case HealthPerson.XRayStaff:
                    return 4;
                case HealthPerson.MedicalTechnicalAssistant:
                    return 5;
                case HealthPerson.HealthExpertStaff:
                    return 6;
                case HealthPerson.Relative:
                    return 7;
                case HealthPerson.AffectedPerson:
                    return 8;
                case HealthPerson.Others:
                    return 9;
     
            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (HealthPerson)value;
        }

        #endregion
    }

    public class AllPossibleJournalEntriesToStringConverter : IValueConverter
    {
        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            AllPossibleJournalEntries entry = (AllPossibleJournalEntries)value;

            switch (entry)
            {
                case AllPossibleJournalEntries.BandagesChangingEntry:
                    return AppResources.JournalOverviewPageBandagesChangingEntry;
                case AllPossibleJournalEntries.BloodWithdrawalEntry:
                    return AppResources.JournalOverviewPageBloodWithdrawalEntry;
                case AllPossibleJournalEntries.CatheterFlushEntry:
                    return AppResources.JournalOverviewPageCatheterFlushEntry;
                case AllPossibleJournalEntries.InfusionEntry:
                    return AppResources.JournalOverviewPageInfusionEntry;
                case AllPossibleJournalEntries.MicroClaveEntry:
                    return AppResources.JournalOverviewPageMicroClaveChangingEntry;
                case AllPossibleJournalEntries.AdministeredDrugEntry:
                    return AppResources.JournalOverviewPageAdministeredDrugEntry;
                case AllPossibleJournalEntries.StatlockEntry:
                    return AppResources.JournalOverviewPageStatlockChangingEntry;
                default:
                    return " ";
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (AllPossibleJournalEntries)value;
        }

        #endregion
    }

    public class NegateBooleanConverter : IValueConverter
    {
        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(bool)value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(bool)value;
        }

        #endregion
    }

    public class MicroClaveChangementReasonToIndexConverter : IValueConverter
    {
        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            MicroClaveChangementReason reason = (MicroClaveChangementReason)value;
            switch (reason)
            {
                case MicroClaveChangementReason.NoInformation:
                    return 0;
                case MicroClaveChangementReason.Pollution:
                    return 1;
                case MicroClaveChangementReason.Routine:
                    return 2;              
            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (MicroClaveChangementReason)value;
        }

        #endregion
    }

    public class StatlockChangementReasonToIndexConverter : IValueConverter
    {
        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            StatLockChangementReason reason = (StatLockChangementReason)value;
            switch (reason)
            {
                case StatLockChangementReason.NoInformation:
                    return 0;
                case StatLockChangementReason.Routine:
                    return 1;
                case StatLockChangementReason.SticksUnsatisfactorily:
                    return 2;
                case StatLockChangementReason.Pollution:
                    return 3;
                case StatLockChangementReason.DamagedWing:
                    return 4;
            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (StatLockChangementReason)value;
        }

        #endregion
    }

    public class BloodFlowToIndexConverter : IValueConverter
    {
        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            BloodFlow reason = (BloodFlow)value;
            switch (reason)
            {
                case BloodFlow.NoInformation:
                    return 0;
                case BloodFlow.Speedy:
                    return 1;
                case BloodFlow.Hesitant:
                    return 2;
                case BloodFlow.None:
                    return 3;                    
            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (BloodFlow)value;
        }

        #endregion
    }
    public class BandageChangingReasonToIndexConverter : IValueConverter
    {
        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            BandageChangingReason reason = (BandageChangingReason)value;
            switch (reason)
            {
                case BandageChangingReason.NoInformation:
                    return 0;
                case BandageChangingReason.Routine:
                    return 1;
                case BandageChangingReason.PunctureNotCovered:
                    return 2;
                case BandageChangingReason.BandageWet:
                    return 3;
                case BandageChangingReason.BandageDoesNotStickAnymore:
                    return 4;
                case BandageChangingReason.SecondaryBleeding:
                    return 5;
                case BandageChangingReason.Pain:
                    return 6;

            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (BandageChangingReason)value;
        }

        #endregion
    }

    public class BandageChangingAreaToIndexConverter : IValueConverter
    {
        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            BandageChangingArea reason = (BandageChangingArea)value;
            switch (reason)
            {
                case BandageChangingArea.NoInformation:
                    return 0;
                case BandageChangingArea.Complete:
                    return 1;
                case BandageChangingArea.OnlyBandage:
                    return 2;
                case BandageChangingArea.OnlyStatlock:
                    return 3;
                
            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (BandageChangingArea)value;
        }

        #endregion
    }

    public class BandagePunctureSituationToIndexConverter : IValueConverter
    {
        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            BandagePunctureSituation situation = (BandagePunctureSituation)value;
            switch (situation)
            {
                case BandagePunctureSituation.NoInformation:
                    return 0;
                case BandagePunctureSituation.SkinNotIrritant:
                    return 1;
                case BandagePunctureSituation.ReddenedPuncture:
                    return 2;
                case BandagePunctureSituation.SwollenPuncture:
                    return 3;
                case BandagePunctureSituation.PainfulPuncture:
                    return 4;
                case BandagePunctureSituation.LiquidDischarge:
                    return 5;

            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (BandagePunctureSituation)value;
        }

        #endregion
    }

    
}

