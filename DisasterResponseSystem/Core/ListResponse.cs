
namespace DisasterResponseSystem.Core
{
    public class ListResponse<T> 
    {
        public List<T> Result { set; get; }
        public int Total{ set; get; }
    }
}
