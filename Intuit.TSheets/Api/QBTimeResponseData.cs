namespace Intuit.TSheets.Api
{
    public class QBTimeResponseData<T>
    {
        public T Value { get; set; }
        public ResultsMeta ResultsMeta { get; set; }

        public static explicit operator QBTimeResponseData<T>((T, ResultsMeta) apiResponse)
        {
            return new()
            {
                Value = apiResponse.Item1,
                ResultsMeta = apiResponse.Item2
            };
        }

        public static QBTimeResponseData<TResult> FromResponse<TResult>((TResult, ResultsMeta) response) => new()
        {
            Value = response.Item1,
            ResultsMeta = response.Item2
        };
    }
}
