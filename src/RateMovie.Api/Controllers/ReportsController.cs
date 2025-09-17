using Microsoft.AspNetCore.Mvc;

namespace RateMovie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        [HttpGet]
        [Route("export-excel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GenerateExcel([FromQuery] byte? rating)
        {
            byte[] fileBytes = new byte[1];

            if(fileBytes.Length < 1)
            {
                return NoContent();
            }

            return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "movie-report.xlsx");
        }

        //[HttpGet]
        //[Route("export-pdf")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //public async Task<IActionResult> GeneratePdf([FromQuery] byte? rating)
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
