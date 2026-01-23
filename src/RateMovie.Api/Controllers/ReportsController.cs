using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RateMovie.Application.UseCases.Reports.GenerateMoviesExcel;
using RateMovie.Application.UseCases.Reports.GenerateMoviesPdf;
using RateMovie.Communication.Enum;
using System.Net.Mime;

namespace RateMovie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = nameof(UserRole.Vip))]
    public class ReportsController : ControllerBase
    {
        [HttpGet]
        [Route("movies-excel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GenerateExcel(
            [FromServices] IGenerateMoviesExcelUseCase moviesExcelUseCase,
            [FromQuery] byte? stars)
        {
            byte[] fileBytes = await moviesExcelUseCase.Execute(stars);

            if(fileBytes.Length < 1)
            {
                return NoContent();
            }

            return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "movie-report.xlsx");
        }

        [HttpGet]
        [Route("movies-pdf")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GeneratePdf(
            [FromServices] IGenerateMoviesPdfUseCase moviesPdfUseCase,
            [FromQuery] byte? stars)
        {
            byte[] fileBytes = await moviesPdfUseCase.Execute(stars);

            if (fileBytes.Length < 1)
            {
                return NoContent();
            }

            return File(fileBytes, MediaTypeNames.Application.Pdf, "movie-report.pdf");
        }
    }
}
