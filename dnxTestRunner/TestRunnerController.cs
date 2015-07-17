using System;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace TestRunner.Controllers
{

    [Route("api/[controller]")]
    public class TestRunnerController : Controller
    {
        [HttpGet]
        public void Start()
        {
	        Console.WriteLine("Running tests");
       		System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
       		System.Diagnostics.Process p = new System.Diagnostics.Process();
       		psi.FileName = "dnx";
       		psi.Arguments = "/dnxApplication test";
       		psi.UseShellExecute = false;
       		psi.RedirectStandardOutput = true;
       		p.StartInfo = psi;
       		p.Start();
       		string output = p.StandardOutput.ReadToEnd();
       		p.WaitForExit();
       		Console.WriteLine(output);

        }
    }
}
