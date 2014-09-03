using System;
using System.Collections.Generic;
using System.Linq;

namespace G2RF.Web.Mvc.FluentViewModel.Javascript
{
    public interface IFormScriptManager
    {
        string GetSaveFunction();

        string GetCancelFunction();
    }
}
