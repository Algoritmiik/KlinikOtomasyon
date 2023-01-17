using KlinikOtomasyon.Shared.Utilities.ComplexTypes;

namespace KlinikOtomasyon.Shared.Utilities.Abstract
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get; }
        public string Message { get; }
        public Exception Exception { get; }
    }
}