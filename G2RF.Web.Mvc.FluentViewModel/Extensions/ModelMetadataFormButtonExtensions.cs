using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using G2RF.Web.Mvc.FluentViewModel.Form.Buttons;

namespace G2RF.Web.Mvc.FluentViewModel.Extensions
{
    public static class ModelMetadataFormButtonExtensions
    {
        public static void AgregarBotones(this ModelMetadata metadata, List<FormButton> botones)
        {
            List<FormButton> botonesAux = null;
            if ((botonesAux = (List<FormButton>)metadata.AdditionalValues["Botones"]) == null)
            {
                metadata.AdditionalValues["Botones"] = botones;
            }
            else
            {
                botonesAux.AddRange(botones);
            }
        }
    }
}
