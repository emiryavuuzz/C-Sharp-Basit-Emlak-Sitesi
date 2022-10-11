using Core.Results.ComplexTypes;

namespace Core.Results
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get; }
        public string Message { get; }
        public Exception Exception { get;}
    }
}
