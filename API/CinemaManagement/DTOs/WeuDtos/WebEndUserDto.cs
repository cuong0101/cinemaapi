using System.Collections.Generic;

namespace CinemaManagement.DTOs
{
    public class WebEndUserDto<T>
    {
        public bool Status { get; set; }//0|1 lỗi hoặc k
        public T Data { get; set; } // Dữ liệu trả về
        public int Code { get; set; }//200 | 500
        public string Message { get; set; }//

        public WebEndUserDto(bool status, T data, int code, string message)
        {
            Status = status;
            Data = data;
            Code = code;
            Message = message;
        }


    }
}
