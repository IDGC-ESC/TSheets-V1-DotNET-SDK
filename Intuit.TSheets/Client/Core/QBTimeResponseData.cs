using System.Collections.Generic;
using System.Linq;
using Intuit.TSheets.Api;
using Intuit.TSheets.Client.Extensions;
using Intuit.TSheets.Client.RequestFlow;

namespace Intuit.TSheets.Client.Core
{
    public class QBTimeResponseData<T>
    {
        public IEnumerable<T> Results { get; set; }
        public ResultsMeta ResultsMeta { get; set; }

        public static implicit operator QBTimeResponseData<T>((T, ResultsMeta) apiResponse)
        {
            List<T> items = new();
            if (typeof(T).IsAssignableTo(typeof(IEnumerable<T>)))
            {
                items = ((IEnumerable<T>)apiResponse.Item1).ToList();
            }
            else
            {
                items.Add(apiResponse.Item1);
            }
            return new()
            {
                Results = items,
                ResultsMeta = apiResponse.Item2
            };
        }

        public static QBTimeResponseData<TResult> FromResponse<TResult>((TResult, ResultsMeta) response) => (QBTimeResponseData<TResult>)response;
    }
}
