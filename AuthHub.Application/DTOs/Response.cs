using System;
using System.Collections.Generic;
using System.Text;

namespace AuthHub.Application.DTOs
{
    public class Response
    {
        public string? Message { get; set; }
        public bool? IsSuccess { get; set; }
        public bool? IsError { get; set; }
        public object? Result { get; set; } 
    }
}
