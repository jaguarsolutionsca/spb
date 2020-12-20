using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SPB.Test
{
    public class ExcelReport
    {
        public static void InsertDataSet(string destination, DataSet ds)
        {
            using (var workbook = SpreadsheetDocument.Create(destination, SpreadsheetDocumentType.Workbook))
            {
                workbook.AddWorkbookPart();
                workbook.WorkbookPart.Workbook = new Workbook();
                workbook.WorkbookPart.Workbook.Sheets = new Sheets();

                foreach (DataTable table in ds.Tables)
                {
                    var sheetPart = workbook.WorkbookPart.AddNewPart<WorksheetPart>();
                    var sheetData = new SheetData();
                    sheetPart.Worksheet = new Worksheet(sheetData);

                    var sheets = workbook.WorkbookPart.Workbook.GetFirstChild<Sheets>();
                    var id = workbook.WorkbookPart.GetIdOfPart(sheetPart);

                    uint sheetId = 1;
                    if (sheets.Elements<Sheet>().Count() > 0)
                    {
                        sheetId = sheets.Elements<Sheet>().Select(s => s.SheetId.Value).Max() + 1;
                    }

                    var sheet = new Sheet { Id = id, SheetId = sheetId, Name = table.TableName };
                    sheets.Append(sheet);


                    var headerRow = new Row();
                    var columns = new List<string>();
                    foreach (DataColumn column in table.Columns)
                    {
                        columns.Add(column.ColumnName);
                        var cell = new Cell { DataType = CellValues.String, CellValue = new CellValue(column.ColumnName) };
                        headerRow.AppendChild(cell);
                    }
                    sheetData.AppendChild(headerRow);


                    foreach (DataRow dsrow in table.Rows)
                    {
                        var newRow = new Row();
                        foreach (var col in columns)
                        {
                            var cell = new Cell { DataType = CellValues.String, CellValue = new CellValue(dsrow[col].ToString()) };
                            newRow.AppendChild(cell);
                        }
                        sheetData.AppendChild(newRow);
                    }
                }
            }
        }

        public static void InsertIntoTemplate(string templateFilename, DataSet ds, uint rowIndex)
        {
            var byteArray = File.ReadAllBytes(templateFilename);
            using (var ms = new MemoryStream())
            {
                ms.Write(byteArray, 0, byteArray.Length);

                using (var spreadsheet = SpreadsheetDocument.Open(ms, true))
                {
                    var sheet = spreadsheet.WorkbookPart.Workbook.Descendants<Sheet>().First();
                    var worksheet = ((WorksheetPart)(spreadsheet.WorkbookPart.GetPartById(sheet.Id))).Worksheet;
                    var sheetData = worksheet.WorksheetPart.Worksheet.GetFirstChild<SheetData>();

                    uint shift = 1;
                    var rowCount = sheetData.Elements<Row>().Count();
                    for (var i = rowCount; i > rowIndex; i--)
                    {
                        var row = sheetData.Elements<Row>().Where(r => r.RowIndex.Value == i).First();
                        row.RowIndex += shift;
                        foreach (var cell in row.Elements<Cell>())
                        {
                            var refer = cell.CellReference.Value;
                            var letters = Regex.Replace(refer, @"[^A-Z]*", "");
                            var num = Convert.ToInt32(Regex.Replace(refer, @"[^\d]*", ""));
                            cell.CellReference.Value = letters + (num + shift);
                            //if (cell.CellFormula != null)
                            //{
                            //    cell.CellFormula = new CellFormula("SUM(A1:A3)");
                            //}
                        }
                    }

                    var refRow = sheetData.Elements<Row>().Where(r => r.RowIndex.Value == rowIndex).FirstOrDefault();
                    rowIndex++;

                    var new_row = new Row { RowIndex = rowIndex };
                    var new_cell = new Cell { CellReference = "A" + rowIndex };
                    new_cell.Append(new CellValue { Text = "9999" });
                    new_row.Append(new_cell);

                    sheetData.InsertAfter(new_row, refRow);

                    worksheet.Save();

                    // for recacluation of formula
                    spreadsheet.WorkbookPart.Workbook.CalculationProperties.ForceFullCalculation = true;
                    spreadsheet.WorkbookPart.Workbook.CalculationProperties.FullCalculationOnLoad = true;
                }

                // save to file
                using (var fs = new FileStream("./output.xlsx", FileMode.Create))
                {
                    ms.WriteTo(fs);
                }
            }
        }

        public static void fixme_InsertIntoTemplate(string templateFilename, DataSet ds, uint rowIndex)
        {
            using (var ms = new MemoryStream())
            {
                using (var fs = new FileStream(templateFilename, FileMode.Open, FileAccess.Read))
                    fs.CopyTo(ms);

                ms.Position = 0;

                var spreadsheetDocument = SpreadsheetDocument.Open(ms, true);
                var wbPart = spreadsheetDocument.WorkbookPart;
                var sheet = wbPart.Workbook.Descendants<Sheet>().First();
                var ws = ((WorksheetPart)(wbPart.GetPartById(sheet.Id))).Worksheet;
                var sheetData = ws.WorksheetPart.Worksheet.GetFirstChild<SheetData>();

                var refRow = sheetData.Elements<Row>().Where(r => r.RowIndex.Value == rowIndex).FirstOrDefault();
                if (refRow == null)
                {
                    refRow = new Row();
                    refRow.RowIndex = rowIndex;
                    sheetData.Append(refRow);
                }

                ++rowIndex;

                var cell1 = new Cell() { CellReference = "A" + rowIndex };
                var cellValue1 = new CellValue();
                cellValue1.Text = "LOL";
                cell1.Append(cellValue1);

                var newRow = new Row() { RowIndex = rowIndex };
                newRow.Append(cell1);

                var rowCount = sheetData.Elements<Row>().Count();

                for (int i = (int)rowIndex; i <= rowCount; i++)
                {
                    var row = sheetData.Elements<Row>().Where(r => r.RowIndex.Value == i).FirstOrDefault();
                    row.RowIndex++;
                    foreach (Cell c in row.Elements<Cell>())
                    {
                        var refer = c.CellReference.Value;
                        var num = Convert.ToInt32(Regex.Replace(refer, @"[^\d]*", ""));
                        num++;
                        var letters = Regex.Replace(refer, @"[^A-Z]*", "");
                        c.CellReference.Value = letters + num;
                    }
                }
                sheetData.InsertAfter(newRow, refRow);
                ws.Save();


                // save to file
                using (var fs = new FileStream("./output.xlsx", FileMode.Create))
                {
                    ms.Position = 0;
                    ms.CopyTo(fs);
                    fs.Flush();
                }
            }
        }

        public static DataTable ToDataTable<T>(IList<T> data)
        {
            var properties = TypeDescriptor.GetProperties(typeof(T));
            var table = new DataTable();

            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            foreach (T item in data)
            {
                var row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }

            return table;
        }
    }
}
