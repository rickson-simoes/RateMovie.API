using Microsoft.AspNetCore.Mvc;
using RateMovie.Application.UseCases.Reports.GenerateMoviesExcel;

namespace RateMovie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        //[HttpGet]
        //[Route("movies-pdf")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //public async Task<IActionResult> GeneratePdf([FromQuery] byte? stars)
        //{
        //    byte[] fileBytes = new byte[1];

        //    if (fileBytes.Length < 1)
        //    {
        //        return NoContent();
        //    }

        //    return File(fileBytes, MediaTypeNames.Application.Pdf, "movie-report.pdf");
        //}
    }
}
