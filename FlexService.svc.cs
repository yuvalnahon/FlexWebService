using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;

namespace FlexWebService
{
    public class FlexService : IFlexService
    {
        /// <summary>
        /// Verify if it's a valid PDF file
        /// </summary>
        /// <param name="filename">filename</param>
        /// <param name="ext">extension</param>
        /// <returns></returns>
        public VerifyPDFResponse verify_pdf(string filename, string ext)
        {
            string result = "Error";
            try
            {
                LeadToolsHelper helper = new LeadToolsHelper();
                filename = filename + "." + ext;
                int count = helper.PDFFilePageCount(filename);
                return new VerifyPDFResponse()
                {
                    FileName = filename,
                    Result = (count > 0) ? "Success" : "Error",
                    ErrorMessage = ""
                };
            }
            catch (Exception e)
            {
                return new VerifyPDFResponse()
                {
                    FileName = filename,
                    Result = result,
                    ErrorMessage = e.Message
                };
            }
        }

        /// <summary>
        /// Count Pages
        /// </summary>
        /// <param name="filename">filename</param>
        /// <param name="ext">extension</param>
        /// <returns></returns>
        public CountPagesResponse count_pages(string filename, string ext)
        {
            int count = -1;
            try
            {
                LeadToolsHelper helper = new LeadToolsHelper();
                filename = filename + "." + ext; 
                count = helper.PDFFilePageCount(filename);
                return new CountPagesResponse()
                {
                    FileName = filename,
                    Count = count,
                    ErrorMessage = ""
                };
            }
            catch (Exception e)
            {
                return new CountPagesResponse()
                {
                    FileName = filename,
                    Count = count,
                    ErrorMessage = e.Message
                };
            }
        }

        /// <summary>
        /// Remove Pages
        /// </summary>
        /// <param name="filename_source"></param>
        /// <param name="first_page_number"></param>
        /// <param name="last_page_number"></param>
        /// <param name="rotate_angle"></param>
        /// <param name="filename_target"></param>
        /// <param name="ext"></param>
        /// <returns></returns>
        public RemovePagesResponse remove_pages(string filename_source, string first_page_number, string last_page_number, string rotate_angle, string filename_target, string ext)
        {
            try
            {
                LeadToolsHelper helper = new LeadToolsHelper();
                filename_source = filename_source + "." + ext;
                filename_target = filename_target + "." + ext;
                int firstPageNumber = int.Parse(first_page_number);
                int lastPageNumber = int.Parse(last_page_number);
                int angle = int.Parse(rotate_angle);
                helper.PDFDeletePages(filename_source, firstPageNumber, lastPageNumber, angle, filename_target);

                return new RemovePagesResponse()
                {
                    // No Exception at this point it means Succsess
                    SourceFileName = filename_source,
                    TargetFileName = filename_target,
                    Result = "Success",
                    ErrorMessage = ""
                };
            }
            catch (Exception e)
            {
                return new RemovePagesResponse()
                {
                    SourceFileName = filename_source,
                    TargetFileName = filename_target,
                    Result = "Error",
                    ErrorMessage = e.Message
                };
            }
        }
       
        public MergePagesResponse merge_pages(string source_filename1, string source_filename2, string rotate_angle, string filename_target, string ext)
        {
            try
            {
                LeadToolsHelper helper = new LeadToolsHelper();
                source_filename1 = source_filename1 + "." + ext;
                source_filename2 = source_filename2 + "." + ext;
                filename_target = filename_target + "." + ext;
                int angle = int.Parse(rotate_angle);
                helper.PDFMergePages(source_filename1, source_filename2, angle, filename_target);

                return new MergePagesResponse()
                {
                    SourceFileName1 = source_filename1,
                    SourceFileName2 = source_filename2,
                    TargetFileName = filename_target,
                    Result = "Success",
                    ErrorMessage = ""
                };
            }
            catch (Exception e)
            {
                return new MergePagesResponse()
                {
                    SourceFileName1 = source_filename1,
                    SourceFileName2 = source_filename2,
                    TargetFileName = filename_target,
                    Result = "Error",
                    ErrorMessage = e.Message
                };
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="composite"></param>
        /// <returns></returns>
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

       
    }
}
