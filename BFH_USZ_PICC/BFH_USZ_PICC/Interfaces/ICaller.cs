using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Interfaces
{
    public interface ICaller
    {
        /// <summary>
        /// Checks if the device is able to make a phone call.
        /// </summary>
        /// <returns></returns>
        bool CanMakePhonecall();

        /// <summary>
        /// Dials the passed number via the integrated system native dialer
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        bool Dial(string number);
    }
}
