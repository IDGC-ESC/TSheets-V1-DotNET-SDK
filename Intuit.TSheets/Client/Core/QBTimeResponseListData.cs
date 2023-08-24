using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intuit.TSheets.Api;
using Intuit.TSheets.Client.Extensions;

namespace Intuit.TSheets.Client.Core
{
    public class QBTimeResponseListData<T>
    {
        public IEnumerable<T> Results { get; set; }
        public ResultsMeta ResultsMeta { get; set; }

        public static implicit operator QBTimeResponseListData<T>((IEnumerable<T>, ResultsMeta) apiResponse)
        {
            return new()
            {
                Results = apiResponse.Item1.ToList(),
                ResultsMeta = apiResponse.Item2
            };
        }

        public static QBTimeResponseListData<TResult> FromResponse<TResult>((IEnumerable<TResult>, ResultsMeta) response) => (QBTimeResponseListData<TResult>)response;
    }
}
