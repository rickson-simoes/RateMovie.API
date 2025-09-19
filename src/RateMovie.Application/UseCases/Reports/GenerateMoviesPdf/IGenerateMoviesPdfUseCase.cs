namespace RateMovie.Application.UseCases.Reports.GenerateMoviesPdf
{
    public interface IGenerateMoviesPdfUseCase
    {
        Task<byte[]> Execute(byte? stars);
    }
}
