using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using G2RF.Extensions.Linq.Expressions;
using G2RF.Web.Mvc.FluentViewModel.Form.Info;
using G2RF.Web.Mvc.FluentViewModel.Common;

namespace G2RF.Web.Mvc.FluentViewModel.Form.Parts
{
    public class SimpleTabularListEditorPart<TProperty> : SimpleListEditorPart<TProperty>
    {
        public SimpleTabularListEditorPart(SimpleKeyValue<string, SimpleFormPropertyInfo> nodoPropiedad)
            : base(nodoPropiedad)
        {
            
        }

        public SimpleTabularListEditorPart<TProperty> AddDisplayColumn<TListModelProperty>(string columnHeader, Expression<Func<TProperty, TListModelProperty>> expression)
        {
            if (_FormPropertyInfo.Columns == null)
            {
                _FormPropertyInfo.Columns = new List<SimpleKeyValue<string, string>>();
            }
            ((List<SimpleKeyValue<string, string>>)_FormPropertyInfo.Columns).Add(new SimpleKeyValue<string, string>(expression.GetPropertyInfo().Name, columnHeader));
            return this;
        }

        //public SimpleTabularListEditorPart<TProperty> DisplayAsColumns<TListModelProperty>(Action<Dictionary<string, Expression<Func<TProperty, TListModelProperty>>>> metodoMiembrosLista)
        //{
        //    //Creando diccionario vacío de columnas. La clave es el nombre de la columna, y el valor es la expresión que indica qué propiedad se usará como valor
        //    Dictionary<string, Expression<Func<TProperty, TListModelProperty>>> listaMiembros = new Dictionary<string, Expression<Func<TProperty, TListModelProperty>>>();

        //    //Ejecutando acción para llenar lista de miembros
        //    metodoMiembrosLista(listaMiembros);

        //    //Obteniendo nombre de propiedades a usar como columnas
        //    _FormPropertyInfo.Columnas
        //        = listaMiembros
        //            .Select<SimpleKeyValue<string, Expression<Func<TProperty, TListModelProperty>>>, SimpleKeyValue<string, string>>(x => new SimpleKeyValue<string, string>(x.Key, x.Value.ObtenerInfoPropiedad().Name));
        //            //.ToList();

        //    return this;
        //}
    }
}
