using System;
using System.Collections.Generic;
using System.Linq;

namespace G2RF.Web.Mvc.FluentViewModel.Common
{
    public class SimpleKeyValue<TKey, TValue>
    {
        public TKey Key { set; get; }

        public TValue Value { set; get; }

        public SimpleKeyValue()
        {
        }

        public SimpleKeyValue(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }
}
