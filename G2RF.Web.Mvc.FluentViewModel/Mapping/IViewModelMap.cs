using System;
using System.Collections.Generic;
using System.Linq;
using G2RF.Web.Mvc.FluentViewModel.Form.Info;
using FluentValidation;
using G2RF.Web.Mvc.FluentViewModel.Common;

namespace G2RF.Web.Mvc.FluentViewModel.Mapping
{
    public interface IViewModelMap : IValidator
    {
        List<SimpleKeyValue<string, SimpleFormPropertyInfo>> GetPropertiesInfo();

        SimpleFormPropertyInfo GetPropertyFormInfo(string nombreProp);

        FormInfo GetFormInfo();

        //IEnumerable<FormButton> GetFormButtons();
    }
}
