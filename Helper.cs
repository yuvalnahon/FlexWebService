using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Leadtools;
using Leadtools.Codecs;
using Leadtools.ImageProcessing;
using Leadtools.Pdf;

namespace FlexWebService
{
    public class LeadToolsHelper
    {
        RasterCodecs _codecs = null;
        public LeadToolsHelper()
        {
            if ((WSConfig.Instance.LicFileLocation != "") && (WSConfig.Instance.DeveloperKey != ""))
            {
                RasterSupport.SetLicense(WSConfig.Instance.LicFileLocation, WSConfig.Instance.DeveloperKey);
            }
            if (_codecs == null)
            {
                _codecs = new RasterCodecs();
            }

            if (!_codecs.Options.Pdf.IsEngineInstalled)
            {
                _codecs.Options.Pdf.InitialPath = WSConfig.Instance.PdfEngineDir;
                _codecs.Options.Pdf.Load.UsePdfEngine = true;
            }
        }

        public int PDFFilePageCount(string filename)
        {
            int pageCount = -1;
            string pdfFileName = Path.Combine(WSConfig.Instance.ImagesDir, @filename);
            // Show the number of pages
            PDFFile file = new PDFFile(pdfFileName);
            file.Load();
            pageCount = file.GetPageCount();
            return pageCount;
        }

        public void PDFDeletePages(string filename_source, int firstPageNumber, int lastPageNumber, int rotate_angle, string filename_target)
        {
            string sourceFileName = Path.Combine(WSConfig.Instance.ImagesDir, @filename_source);
            string destinationFileName = Path.Combine(WSConfig.Instance.ImagesDir, @filename_target);

            // Get the number of pages in the source file
            PDFFile file = new PDFFile(sourceFileName);

            // If the file has more than 1 page, delete all except the first page
            // -1 is (up to and including last page)
            file.DeletePages(firstPageNumber, lastPageNumber, destinationFileName);
        }

        public void PDFMergePages(string source_filename1, string source_filename2, int rotate_angle, string filename_target)
        {
            string sourceFileName1 = Path.Combine(WSConfig.Instance.ImagesDir, @source_filename1);
            string sourceFileName2 = Path.Combine(WSConfig.Instance.ImagesDir, @source_filename2);
            string destinationFileName = Path.Combine(WSConfig.Instance.ImagesDir, @filename_target);

            // Merge 1 with (2) and form destination
            // It's possible to merge 1 with any number of files . At this point , the WS supports only 2 files . 
            PDFFile pdfFile = new PDFFile(sourceFileName1);
            pdfFile.MergeWith(new string[] { sourceFileName2 }, destinationFileName);
        }
    }
}