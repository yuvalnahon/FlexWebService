using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace FlexWebService
{
    public class VerifyPDFResponse
    {
        public string ImagesDir = WSConfig.Instance.ImagesDir;
        public string FileName { get; set; }
        public string Result { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class CountPagesResponse
    {
        public string ImagesDir = WSConfig.Instance.ImagesDir;
        public string FileName { get; set; }
        public int Count { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class RemovePagesResponse
    {
        public string ImagesDir = WSConfig.Instance.ImagesDir;
        public string SourceFileName { get; set; }
        public string TargetFileName { get; set; }
        public string Result { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class MergePagesResponse
    {
        public string ImagesDir = WSConfig.Instance.ImagesDir;
        public string SourceFileName1 { get; set; }
        public string SourceFileName2 { get; set; }
        public string TargetFileName { get; set; }
        public string Result { get; set; }
        public string ErrorMessage { get; set; }
    }
 }