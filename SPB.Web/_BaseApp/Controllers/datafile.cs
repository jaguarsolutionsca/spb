using BaseApp.Common;
using BaseApp.DTO;
using BaseApp.Service;
using BaseApp.UTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApp.Web.Controllers
{
    public class MyDataFile_Model : DataFile_Model
    {
        public IFormFile file { get; set; }
    }

    [Route("api/[controller]")]
    [Authorize]
    public partial class DataFileController : _CoreController
    {
        [HttpGet("{tableName}/{tableID}")]
        public PagedList<DataFile_Search, DataFile_Search_Filter> Search(string tableName, int tableID, int pn, int ps, string sc, string sd, string st)
        {
            var pager = new Pager<DataFile_Search_Filter>(pn, ps, sc, sd, st);
            pager.filter.tableName = tableName;
            pager.filter.tableID = tableID;
            return app.Search_DataFile(pager);
        }

        [HttpGet("{tableName}/{tableID}/{id}")]
        public DataFile_Detail Get(string tableName, int tableID, int id)
        {
            return app.Get_DataFile(tableName, tableID, id);
        }

        [HttpGet("{tableName}/{tableID}/new")]
        public DataFile_Detail GetNew(string tableName, int tableID)
        {
            return app.GetNew_DataFile(tableName, tableID);
        }

        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task<DataFile_Detail_PK> Create(MyDataFile_Model model)
        {
            var file = model.file;
            model.name = file.FileName;
            model.size = file.Length;
            model.mime = file.ContentType;

            var pk = app.Create_DataFile(model);
            var id = pk.fileID;

            var ext = Path.GetExtension(file.FileName.Replace("\"", ""));
            var filename = $"{model.tableName}_{id}{ext}";

            var path = Path.Combine(app.DataFileFolder, filename);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return pk;
        }

        [HttpPut]
        public ActionResult Update([FromBody] DataFile_Model model)
        {
            app.Update_DataFile(model);
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] DataFile_Detail_PK key)
        {
            app.Delete_DataFile(key.fileID, key.updatedUtc);
            return NoContent();
        }

        [HttpGet("{id}")]
        public FileResult GetFile(int id)
        {
            var datafile = app.Get_DataFile(id);

            var ext = Path.GetExtension(datafile.name.Replace("\"", ""));
            var filename = $"{datafile.tableName}_{id}{ext}";

            var path = Path.Combine(app.DataFileFolder, filename);
            return PhysicalFile(path, datafile.mime);
        }
    }
}
