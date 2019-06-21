using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using  Microsoft.AspNetCore.Authentication.JwtBearer;

namespace JwtAuthSample
{
    public class JwtSettings
    {
        public string Issuer{get;set;}
        public string Audience{get;set;}
        public string Secretkey{get;set;}


         
    }
}
