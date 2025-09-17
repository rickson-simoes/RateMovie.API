using ClosedXML.Excel;
using RateMovie.Domain.Entities;
using RateMovie.Domain.Repositories.Movies;
using RateMovie.Domain.Resources.Reports;
using System.Data;

namespace RateMovie.Application.UseCases.Reports.GenerateMoviesExcel
{
    internal class GenerateMoviesExcelUseCase : IGenerateMoviesExcelUseCase
    {
        private readonly IMovieReadOnlyRepository _movieReadOnlyRepository;

        public GenerateMoviesExcelUseCase(IMovieReadOnlyRepository movieReadOnlyRepository)
        {
            _movieReadOnlyRepository = movieReadOnlyRepository;
        }

        public async Task<byte[]> Execute(byte? stars)
        {
            var movies = await _movieReadOnlyRepository.GetAll(stars);

            if (movies.Count == 0)
            {
                return [];
            }

            using var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("RateMovie");

            CreateHeader(wb, ws);
            InsertMovieData(movies, ws);

            ws.Columns().AdjustToContents();

            using var file = new MemoryStream();
            wb.SaveAs(file);
            return file.ToArray();
        }

        private void CreateHeader(XLWorkbook wb, IXLWorksheet ws)
        {
            // Fonts
            ws.Cells("A1:C1").Style.Font.FontName = "Arial";
            ws.Cells("A1:C1").Style.Font.FontSize = 13;
            ws.Cells("A1:C1").Style.Font.Bold = true;
            ws.Cells("A1:B1").Style.Font.FontColor = XLColor.FromHtml("#F2F2F2");
            ws.Cell("C1").Style.Font.FontColor = XLColor.FromHtml("#404040");

            // Border Color
            ws.Cell("A1").Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws.Cell("A1").Style.Border.RightBorderColor = XLColor.FromHtml("#D9D9D9");

            // Background color
            ws.Cells("A1:B1").Style.Fill.BackgroundColor = XLColor.FromHtml("#76933C");
            ws.Cell("C1").Style.Fill.BackgroundColor = XLColor.FromHtml("#F7FAB7");

            // Column value names
            ws.Cell("A1").Value = ResourceReportMessages.COLUMN_NAME;
            ws.Cell("B1").Value = ResourceReportMessages.COLUMN_COMMENT;
            ws.Cell("C1").Value = ResourceReportMessages.COLUMN_STARS;
            ws.Column("C").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
        }

        private void InsertMovieData(List<Movie> movies, IXLWorksheet ws)
        {
            var cellLine = 2;

            foreach (var movie in movies.OrderByDescending(m => m.Stars))
            {
                // Fonts
                ws.Cells($"A{cellLine}:C{cellLine}").Style.Font.FontName = "Calibri";
                ws.Cells($"A{cellLine}:C{cellLine}").Style.Font.FontSize = 12;
                ws.Cell($"C{cellLine}").Style.Font.Bold = true;

                // Values
                ws.Cell($"A{cellLine}").Value = movie.Name;
                ws.Cell($"B{cellLine}").Value = movie.Comment;
                ws.Cell($"C{cellLine}").Value = movie.Stars;

                cellLine++;
            }
        }
    }
}
