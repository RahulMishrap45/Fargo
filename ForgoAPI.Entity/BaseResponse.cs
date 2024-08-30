namespace ForgoAPI.Entity
{
    public class BaseResponse
    { 
        public int ResponseCode { get; set; }
        public string? ResponseMessage { get; set; }
        public bool ResponseStatus => ResponseCode >= 0;
    }
}
