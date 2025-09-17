namespace RateMovie.Application.UseCases.Reports.GenerateMoviesExcel
{
    public interface IGenerateMoviesExcelUseCase
    {
        Task<byte[]> Execute(byte? stars);
    }
}
