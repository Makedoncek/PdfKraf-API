using Microsoft.AspNetCore.Http;

namespace PdfConverter.DTO;

public class MergePdfDTO
{
    public List<IFormFile> pdfFiles{ get; set; }
}