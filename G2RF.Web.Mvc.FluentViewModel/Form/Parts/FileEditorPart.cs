using G2RF.Web.Mvc.FluentViewModel.Common;
using G2RF.Web.Mvc.FluentViewModel.Form.Info;
using System;
using System.Collections.Generic;
using System.Linq;

namespace G2RF.Web.Mvc.FluentViewModel.Form.Parts
{
    public class FileEditorPart : TextEditorPart
    {
        protected readonly FileFormPropertyInfo _FormPropertyInfo;

        public FileEditorPart(SimpleKeyValue<string, SimpleFormPropertyInfo> propertyNode)
            : base(propertyNode)
        {
            _PropertyNode.Value = _FormPropertyInfo = new FileFormPropertyInfo(propertyNode.Value);
        }

        public FileEditorPart AddAcceptedExtension(string fileExtension)
        {
            List<string> acceptedExts = _FormPropertyInfo.AcceptedFileExtensions;
            if (acceptedExts == null)
            {
                acceptedExts = new List<string>();
                _FormPropertyInfo.AcceptedFileExtensions = acceptedExts;
            }
            acceptedExts.Add(fileExtension);
            return this;
        }

        public FileEditorPart SetMaxSize(int bytes)
        {
            _FormPropertyInfo.MaxSizeBytes = bytes;
            return this;
        }
    }
}
