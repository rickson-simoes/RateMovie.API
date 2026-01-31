using System.Collections;

namespace RateMovie.CommonUtilities.InlineClassData
{
    public class InlineCultureClassData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var cultures = new[] { "pt-BR", "en" };

            foreach (var culture in cultures)
            {
               yield return new object[] { culture };
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
