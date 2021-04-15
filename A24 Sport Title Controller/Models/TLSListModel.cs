using A24_Sport_Title_Controller.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A24_Sport_Title_Controller.Models
{
    public class TLSListModel : OnPropertyChangedClass
    {
        private string _tLSName;
        public string TLSName { get => _tLSName; set => SetProperty(ref _tLSName, value?.Trim()); }
    }
}
