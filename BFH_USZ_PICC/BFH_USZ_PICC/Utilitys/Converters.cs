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
            JournalEntryType entry = (JournalEntryType)value;

            switch (entry)
            {
                case JournalEntryType.BandagesChangingEntry:
                    return AppResources.JournalOverviewPageBandagesChangingEntry;
                case JournalEntryType.BloodWithdrawalEntry:
                    return AppResources.JournalOverviewPageBloodWithdrawalEntry;
                case JournalEntryType.CatheterFlushEntry:
                    return AppResources.JournalOverviewPageCatheterFlushEntry;
                case JournalEntryType.InfusionEntry:
                    return AppResources.JournalOverviewPageInfusionEntry;
                case JournalEntryType.MicroClaveEntry:
                    return AppResources.JournalOverviewPageMicroClaveChangingEntry;
                case JournalEntryType.AdministeredDrugEntry:
                    return AppResources.JournalOverviewPageAdministeredDrugEntry;
                case JournalEntryType.StatlockEntry:
                    return AppResources.JournalOverviewPageStatlockChangingEntry;
                default:
                    return " ";
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (JournalEntryType)value;
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
            BandageChangementReason reason = (BandageChangementReason)value;
            switch (reason)
            {
                case BandageChangementReason.NoInformation:
                    return 0;
                case BandageChangementReason.Routine:
                    return 1;
                case BandageChangementReason.PunctureNotCovered:
                    return 2;
                case BandageChangementReason.BandageWet:
                    return 3;
                case BandageChangementReason.BandageDoesNotStickAnymore:
                    return 4;
                case BandageChangementReason.SecondaryBleeding:
                    return 5;
                case BandageChangementReason.Pain:
                    return 6;

            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (BandageChangementReason)value;
        }

        #endregion
    }

    public class BandageChangingAreaToIndexConverter : IValueConverter
    {
        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            BandageChangementArea reason = (BandageChangementArea)value;
            switch (reason)
            {
                case BandageChangementArea.NoInformation:
                    return 0;
                case BandageChangementArea.Complete:
                    return 1;
                case BandageChangementArea.OnlyBandage:
                    return 2;
                case BandageChangementArea.OnlyStatlock:
                    return 3;

            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (BandageChangementArea)value;
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

    public class BandageArmProcessSituationToIndexConverter : IValueConverter
    {
        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            BandageArmProcessSituation situation = (BandageArmProcessSituation)value;
            switch (situation)
            {
                case BandageArmProcessSituation.NoInformation:
                    return 0;
                case BandageArmProcessSituation.Painful:
                    return 1;
                case BandageArmProcessSituation.Swollen:
                    return 2;
                case BandageArmProcessSituation.Reddended:
                    return 3;

            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (BandageArmProcessSituation)value;
        }

        #endregion
    }

    public class InfusionTypeToIndexConverter : IValueConverter
    {
        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            InfusionType type = (InfusionType)value;
            switch (type)
            {
                case InfusionType.NoInformation:
                    return 0;
                case InfusionType.Antibiotic:
                    return 1;
                case InfusionType.NutritionalSubstance:
                    return 2;
                case InfusionType.BloodComponent:
                    return 3;
                case InfusionType.ExaminationSubstance:
                    return 4;
                case InfusionType.Chemotherapy:
                    return 5;
                case InfusionType.Other:
                    return 6;
            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (InfusionType)value;
        }

        #endregion
    }

    public class InfusionAdministrationToIndexConverter : IValueConverter
    {
        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            InfusionAdministration adm = (InfusionAdministration)value;
            switch (adm)
            {
                case InfusionAdministration.NoInformation:
                    return 0;
                case InfusionAdministration.WithoutProblem:
                    return 1;
                case InfusionAdministration.WithResistance:
                    return 2;
                case InfusionAdministration.NotPossible:
                    return 3;
            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (InfusionAdministration)value;
        }

        #endregion
    }

    public class FlushReasonToIndexConverter : IValueConverter
    {
        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            FlushReason reason = (FlushReason)value;
            switch (reason)
            {
                case FlushReason.NoInformation:
                    return 0;
                case FlushReason.Routine:
                    return 1;
                case FlushReason.BloodSampling:
                    return 2;
                case FlushReason.PartiallyBlocked:
                    return 3;
                case FlushReason.Blocked:
                    return 4;
            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (FlushReason)value;
        }

        #endregion
    }

    public class FlushTypeToIndexConverter : IValueConverter
    {
        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            FlushType type = (FlushType)value;
            switch (type)
            {
                case FlushType.NoInformation:
                    return 0;
                case FlushType.NaCi:
                    return 1;
                case FlushType.Heparin:
                    return 2;
                case FlushType.Urokinase:
                    return 3;
            }
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (FlushType)value;
        }

        #endregion
    }

    public class FlushResultToIndexConverter : IValueConverter
    {
        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            FlushResult type = (FlushResult)value;
            switch (type)
            {
                case FlushResult.NoInformation:
                    return 0;
                case FlushResult.FlushWithoutResistance:
                    return 1;
                case FlushResult.FlushWithResistance:
                    return 2;
                case FlushResult.FlushNotPossible:
                    return 3;
            }
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (FlushResult)value;
        }

        #endregion
    }

    public class GenderToIndexConverter : IValueConverter
    {
        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Gender sex = (Gender)value;
            switch (sex)
            {
                case Gender.Unspecified:
                    return 0;
                case Gender.Male:
                    return 1;
                case Gender.Female:
                    return 2;
                
            }
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Gender)value;
        }

        #endregion
    }


    public class GuideWireLenghtToTextConverter : IValueConverter
    {
        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double lengt = (double)value;
          
            if (lengt > 1)
            {
                return AppResources.PICCDetailPageGuideWireLenghtText + " " + lengt;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)value;
        }

        #endregion
    }
}

