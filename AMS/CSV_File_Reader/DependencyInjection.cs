using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvUtility;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CSV_File_Reader
{
    public static class DependencyInjection
    {
        

        public static IServiceCollection AddCsvReader(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICsvService, CsvService>();
            return services;
        }
    }
}
