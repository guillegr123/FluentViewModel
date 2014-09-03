using System;
using System.Collections.Generic;
using System.Linq;
using G2RF.Web.Mvc.FluentViewModel.Common;
using System.Web.Mvc;
using System.Collections;

namespace G2RF.Web.Mvc.FluentViewModel.Form.Info
{
    public class ListFormPropertyInfo : SimpleFormPropertyInfo
    {
        public string TextFormat { protected internal set; get; }

        public string ValueField { protected internal set; get; }

        public string DisplayField { protected internal set; get; }

        public IList<string> DependentFields { protected internal set; get; }

        public string DependsOnField { protected internal set; get; }

        private IEnumerable _StaticOptions;
        protected internal IEnumerable StaticOptions
        {
            set
            {
                _StaticOptions = value;
            }
            get
            {
                return _StaticOptions;
            }
        }

        public Func<ViewDataDictionary, IEnumerable> GetOptions { protected internal set; get; }

        /// <summary>
        /// Propiedad para listas tabulares, que permite especificar las columnas a mostrar.
        /// La llave es el nombre de la columna, y el valor es el nombre de la propiedad a mostrar.
        /// </summary>
        public IEnumerable<SimpleKeyValue<string, string>> Columns { internal set; get; }

        //private object GetStaticOptions()
        //{
        //    return _StaticOptions;
        //}

        public ListFormPropertyInfo(SimpleFormPropertyInfo sfpinfo) : base(sfpinfo)
        {
            DependentFields = new List<string>();
        }
    }
}
