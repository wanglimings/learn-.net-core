using System;

namespace IdentitySample.Models
{
    public class ErrorViewModel
    {
        public int Id{get;set;}
        public string RequestId { get; set; }

        public string ErrorMessage {get;set;}
        public string messages{get;set;}


        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}