using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace FlexWebService
{
    [ServiceContract]
    public interface IFlexService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "verify_pdf/{filename}/{ext}")]
        VerifyPDFResponse verify_pdf(string filename, string ext);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "count_pages/{filename}/{ext}")]
        CountPagesResponse count_pages(string filename, string ext);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "remove_pages/{filename_source}/{first_page_number}/{last_page_number}/{rotate_angle}/{filename_target}/{ext}")]
        RemovePagesResponse remove_pages(string filename_source, string first_page_number, string last_page_number, string rotate_angle, string filename_target, string ext);
        
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "merge_pages/{source_filename1}/{source_filename2}/{rotate_angle}/{filename_target}/{ext}")]
        MergePagesResponse merge_pages(string source_filename1, string source_filename2, string rotate_angle, string filename_target, string ext);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
