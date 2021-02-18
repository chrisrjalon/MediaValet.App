using System;
using System.Collections.Generic;
using System.Text;

namespace MediaValet.OrderSupervisor.DataAccess.Helpers
{
    public class LabelAttribute : Attribute
    {
        public string Label { get; }

        public LabelAttribute(string label)
        {
            Label = label;
        }
    }
}
