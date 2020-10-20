using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerUi.Data
{
    public class PersonCrud
    {
        private readonly IConfiguration _configuration;

        public PersonCrud(IConfiguration configuration)
        {
            _configuration = configuration;
        }


    }
}
