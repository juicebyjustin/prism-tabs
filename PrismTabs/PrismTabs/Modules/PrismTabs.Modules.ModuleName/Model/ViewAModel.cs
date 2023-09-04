using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismTabs.Modules.ModuleName.Model
{
    [AddINotifyPropertyChangedInterface]
    public class ViewAModel
    {
        public string Data { get; set; }
    }
}
