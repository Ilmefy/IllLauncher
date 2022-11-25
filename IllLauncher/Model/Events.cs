using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IllLauncher.Model
{
    public class DefaultEventArgs:EventArgs
    {
        public object NewValue { get; set; }
        public object OldValue { get; set; }
        public DefaultEventArgs(){}
        public DefaultEventArgs(object? newValue) : this() => NewValue = newValue;
        public DefaultEventArgs(object? newValue, object? oldValue) : this(newValue) => OldValue = oldValue;
    }
}
