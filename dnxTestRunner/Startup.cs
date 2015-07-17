using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using System.Diagnostics;
namespace TestRunner
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            RestoreApplicationUnderTest();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
        private void RestoreApplicationUnderTest()
        {
            Console.WriteLine("Restoring application to test");
            ProcessStartInfo psi = new ProcessStartInfo();
            Process p = new Process();
            psi.FileName = "dnu";
            psi.Arguments = "restore /dnxApplication";
            psi.UseShellExecute = false;
            p.StartInfo = psi;
            p.Start();
            p.WaitForExit();
        }
    }
}