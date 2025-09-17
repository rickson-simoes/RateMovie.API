using ClosedXML.Excel;
using System.Data;

namespace RateMovie.Application.UseCases.Reports.GenerateMoviesExcel
{
    internal class GenerateMoviesExcelUseCase : IGenerateMoviesExcelUseCase
    {
        public async Task<byte[]> Execute(byte? stars)
        {
            // repo await

            //if (movies.Count == 0)
            //{
            //    return [];
            //}


            var dataTable = new DataTable();
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Stars");

            dataTable.Rows.Add("teste1", stars);
            dataTable.Rows.Add("teste2", stars);

            using var wb = new XLWorkbook();
            wb.Style.Font.FontName = "Arial";
            wb.Style.Font.FontSize = 14;

            var ws = wb.AddWorksheet();

            ws.Cell("A2").InsertData(dataTable);

            using var file = new MemoryStream();
            wb.SaveAs(file);

            return file.ToArray();
        }
    }
}
