using System.Collections.Generic;

namespace CinemaManagement.DTOs
{
    public class WebEndUserDto<T>
    {
        public bool Status { get; set; }
        public T Data { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
    }
}
