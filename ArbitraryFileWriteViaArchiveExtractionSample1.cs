using System;
using System.IO;
using System.IO.Compression;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace myApp.Controllers
{
    public class ZipController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Extract(IFormFile zipFile, string extractPath)
        {
            if (zipFile != null && zipFile.Length > 0 && !string.IsNullOrEmpty(extractPath))
            {
                try
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        zipFile.CopyTo(memoryStream);
                        using (ZipArchive archive = new ZipArchive(memoryStream))
                        {
                            foreach (ZipArchiveEntry entry in archive.Entries)
                            {
                                entry.ExtractToFile(Path.Combine(extractPath, entry.FullName), true);
                                Console.WriteLine($"Extracted: {entry.FullName}");
                            }
                        }
                    }
                    ViewBag.Message = "Extraction completed successfully.";
                }
                catch (Exception e)
                {
                    ViewBag.Message = $"Error: {e.Message}";
                }
            }
            else
            {
                ViewBag.Message = "Invalid file or directory path.";
            }

            return View("Index");
        }
    }
}
