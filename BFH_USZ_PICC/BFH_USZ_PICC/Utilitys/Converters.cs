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
    }

    public class PICCInsertSideToIndexConverter : IValueConverter
    {
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
    }

    public class PICCInsertCountryToIndexConverter : IValueConverter
    {
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
    }

    public class AllJournalEntriesConverter
    {
        public class EntryAndImage
        {
            public string Entry { get; set; }
            public string Image { get; set; }

            public EntryAndImage(string entry, string image)
            {
                Entry = entry;
                Image = image;
            }
        }
        public EntryAndImage Convert(object value)
        {   
        
            AllPossibleJournalEntries entry = (AllPossibleJournalEntries)value;
            switch (entry)
            {
                case AllPossibleJournalEntries.BandagesChangingEntry:
                    return new EntryAndImage("Verbandswechsel", "icon.png");
                case AllPossibleJournalEntries.BloodWithdrawalEntry:
                    return new EntryAndImage("Blutentnahme", "icon.png");
                case AllPossibleJournalEntries.CatheterFlushEntry:
                    return new EntryAndImage("Spülen des Katheters", "icon.png");
                case AllPossibleJournalEntries.InfusionEntry:
                    return new EntryAndImage("Verabreichte Infusion", "icon.png");
                case AllPossibleJournalEntries.MicroClaveEntry:
                    return new EntryAndImage("Wechsel Microclave", "icon.png");
                case AllPossibleJournalEntries.PICCAppliedDrugEntry:
                    return new EntryAndImage("Über den PICC verabreichte Medikamente", "icon.png");
                case AllPossibleJournalEntries.StatlockEntry:
                    return new EntryAndImage("Wechsel Statlock", "icon.png");
            }

            return new EntryAndImage("", "");
        }

        public object ConvertBack(object value)
        {
            return (AllPossibleJournalEntries)value;
        }
    }
}
