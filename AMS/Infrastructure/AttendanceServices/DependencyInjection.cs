
using AttendanceServices.Services.AllowanceService;
using AttendanceServices.Services.DeductionService;
using AttendanceServices.Services.LeaveService;
using AttendanceServices.Services.ShiftManagementService;
using AttendanceServices.Services.WorkingProfileService;
using DA;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services
            .AddDALayer(configuration)
            .AddServices();
           
            





            return services;
        }
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
       

        services.TryAddScoped<IAllowanceService, AllowanceService>();
        services.TryAddScoped<IShiftService, ShiftService>();
        services.TryAddTransient<IWorkingProfileService, WorkingProfileService>();
        services.TryAddTransient<ILeaveService,LeaveService>();
        services.TryAddTransient<IDeductionService, DeductionService>();







        return services;
    }
}

