using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CH_DTDD.DTO
{
   public class BoPhan : ICloneable, INotifyPropertyChanged
   {
        public int boPhanId { get; set; }
        public string tenBoPhan { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public object Clone()
        {
            return MemberwiseClone();
        }


    }
}
