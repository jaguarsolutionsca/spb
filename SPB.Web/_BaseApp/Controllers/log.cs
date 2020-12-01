using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApp.Web.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class LogController : _CoreController
    {
        [HttpGet("zip")]
        public FileResult GetZip()
        {
            var memoryStream = new MemoryStream();

            using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
            {
                var fileNames = Directory.GetFiles(Path.Combine(hosting.ContentRootPath, "log"));

                foreach (var fileName in fileNames)
                {
                    byte[] bytes = null;
                    using (var fs = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        bytes = new byte[fs.Length];
                        fs.Read(bytes, 0, (int)fs.Length);
                    }

                    var entry = archive.CreateEntry(Path.GetFileName(fileName) + ".txt");

                    using (var zipStream = entry.Open())
                        zipStream.Write(bytes, 0, bytes.Length);
                }
            }

            memoryStream.Seek(0, SeekOrigin.Begin);

            return File(memoryStream, "application/zip", "log.zip");
        }

        [HttpGet("latest")]
        public IActionResult GetLatest()
        {
            var info = new DirectoryInfo(Path.Combine(hosting.ContentRootPath, "log"));
            var files = info.GetFiles().OrderByDescending(p => p.CreationTime).FirstOrDefault();
            if (files != null)
            {
                return PhysicalFile(files.FullName, "text/plain");
            }
            return NoContent();
        }
    }
}
