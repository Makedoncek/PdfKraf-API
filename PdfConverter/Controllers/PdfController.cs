using Microsoft.AspNetCore.Mvc;
using PdfConverter.DTO;
using PdfConverter.Service;
namespace PdfConverter.Controllers;

    /// <summary>
    /// Controller for handling PDF-related actions.
    /// </summary>
    [ApiController]
    [Route("api/pdf")]
    public class PdfController : ControllerBase
    {
        private readonly PdfManipulationService _pdfManipulationService;

        /// <summary>
    /// Initializes a new instance of the <see cref="PdfController"/> class.
        /// </summary>
        /// <param name="pdfManipulationService">Service for manipulating PDFs.</param>
        public PdfController(PdfManipulationService pdfManipulationService)
        {
            _pdfManipulationService = pdfManipulationService;
        }
        /// <summary>
        /// Merges multiple PDFs into a single PDF.
        /// </summary>
        /// <param name="pdfFiles">List of PDF files to be merged.</param>
        /// <returns>Action result containing the merged PDF.</returns>
        [HttpPost("merge")]
        public IActionResult MergePdfs([FromForm]MergePdfDTO mergePdfDto)
        {
            byte[] mergedPdf = _pdfManipulationService.MergePdfs(mergePdfDto);
            return File(mergedPdf, "application/pdf", "merged.pdf");
        }


        
        /// <summary>
        /// Adds a watermark to a PDF file.
        /// </summary>
        /// <param name="pdfFile">Input PDF file.</param>
        /// <param name="watermarkText">Text for the watermark.</param>
        /// <returns>Action result containing the watermarked PDF.</returns>
        [HttpPost("watermark")]
        public IActionResult WatermarkPdf([FromForm] WatermarkPdfDTO watermarkPdfDto)
        {
            byte[] watermarkedPdf = _pdfManipulationService.WatermarkPdf(watermarkPdfDto);
            return File(watermarkedPdf, "application/pdf", "watermarked.pdf");
        }

        
        
        /// <summary>
        /// Compresses a PDF file at the specified compression level.
        /// </summary>
        /// <param name="pdfFile">Input PDF file.</param>
        /// <param name="compressionLevel">Compression level (from 0-9) 9 high compression 0 without.</param>
        /// <returns>Action result containing the compressed PDF.</returns>
        [HttpPost("compress")]
        public IActionResult CompressPdf([FromForm] CompressPdfDTO compressPdfDto)
        {
            byte[] pdfBytes = _pdfManipulationService.ConvertToByteArray(compressPdfDto.pdfFile);
            byte[] compressedPdf = _pdfManipulationService.CompressPdf(pdfBytes, compressPdfDto.compressionLevel);
            return File(compressedPdf, "application/pdf", "compressed.pdf");
        }
        /// <summary>
        /// Extracts pages from a PDF file.
        /// </summary>
        /// <param name="pdfFile">Input PDF file.</param>
        /// <param name="startPage">Starting page number.</param>
        /// <param name="endPage">Ending page number.</param>
        /// <returns>Action result containing the extracted PDF.</returns>
        [HttpPost("split")]
        public IActionResult SplitPdf([FromForm] SplitPdfDto splitPdfDto)
        {
            byte[] extractedPdf = _pdfManipulationService.SplitPdf(splitPdfDto);
            return File(extractedPdf, "application/pdf", "splited.pdf");
        }
    }
