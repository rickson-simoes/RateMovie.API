using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using RateMovie.Application.Assets.Fonts;
using RateMovie.Application.Assets.PdfColors;
using RateMovie.Domain.Entities;
using RateMovie.Domain.Repositories.Movies;
using RateMovie.Domain.Resources.Reports;
using System.Reflection;

namespace RateMovie.Application.UseCases.Reports.GenerateMoviesPdf
{
    internal class GenerateMoviesPdfUseCase : IGenerateMoviesPdfUseCase
    {
        private readonly IMovieReadOnlyRepository _movieReadOnlyRepository;

        public GenerateMoviesPdfUseCase(IMovieReadOnlyRepository movieReadOnlyRepository)
        {
            _movieReadOnlyRepository = movieReadOnlyRepository;
        }

        public async Task<byte[]> Execute(byte? stars)
        {
            var movies = await _movieReadOnlyRepository.GetAll(stars);

            if (movies.Count is 0)
            {
                return [];
            }

            var doc = Document.Create(document =>
            {
                document.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(1, Unit.Centimetre);
                    page.PageColor(Colors.White);

                    var assembly = Assembly.GetExecutingAssembly();
                    var directoryName = Path.GetDirectoryName(assembly.Location);
                    var rateMovieIcon = Path.Combine(directoryName!, "Assets", "icons", "ratemovie_icon.png");
                    var starIcon = Path.Combine(directoryName!, "Assets", "icons", "star.png");

                    GenerateHeader(page, rateMovieIcon);
                    GenerateContent(page, movies, starIcon);
                });
            });

            return doc.GeneratePdf();
        }

        private void GenerateHeader(PageDescriptor page, string icon)
        {
            page.Header()
                .ShowOnce()
                .PaddingBottom(30).Table(t =>
                {
                    t.ColumnsDefinition(column =>
                    {
                        column.ConstantColumn(89);
                        column.RelativeColumn();
                    });

                    t.Cell()
                    .Image(icon);

                    t.Cell()
                    .PaddingTop(30)
                    .AlignCenter()
                    .AlignMiddle()
                    .Text(ResourceReportMessages.PDF_HEADER_TITLE)
                    .FontSize(26)
                    .FontFamily(FontFamilyName.EXO)
                    .Medium();
                });
        }

        private void GenerateContent(PageDescriptor page, List<Movie> movies, string icon)
        {
            page.Content().Table(t =>
            {
                t.ColumnsDefinition(column =>
                {
                    column.RelativeColumn();
                });

                foreach (var movie in movies)
                {
                    t.Cell()
                    .Background(GenerateMoviesColors.GRAY_LIGHT)
                    .Height(50)
                    .AlignMiddle()
                    .AlignCenter()
                    .PaddingHorizontal(10)
                    .Row(r =>
                    {
                        // Movie Name
                        r.RelativeItem()
                        .AlignMiddle()
                        .Text(movie.Name)
                        .FontFamily(FontFamilyName.EXO)
                        .SemiBold()
                        .FontSize(18);

                        // Star Image
                        r.ConstantItem(30)
                        .AlignRight()
                        .AlignMiddle().Text(txt =>
                        {
                            txt
                            .Element()
                            .Height(28)
                            .Image(icon);
                        });

                        // Movie Star rate
                        r.ConstantItem(30).Text(txt =>
                        {
                            txt
                            .Element()
                            .PaddingTop(5)
                            .PaddingLeft(5)
                            .Text(movie.Stars.ToString())
                            .FontFamily(FontFamilyName.EXO)
                            .Light()
                            .FontSize(28);
                        });
                    });

                    // Movie Comment
                    t.Cell()
                    .Background(GenerateMoviesColors.YELLOW_LIGHT)
                    .Padding(10)
                    .Row(r =>
                    {
                        r.RelativeItem()
                        .Text(movie.Comment)
                        .FontFamily(FontFamilyName.OVERLOCK)
                        .FontSize(15);
                    });

                    t.Cell().PaddingTop(20);
                }
            });
        }
    }
}
