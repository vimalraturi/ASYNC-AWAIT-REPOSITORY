using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WcfService1;

namespace ASYC_AWAT_TEST.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private string getResultStringByTask(string parameter)
        {
            var service = new Service1();
            return service.GetStringData(parameter);
        }
        //public async Task<JsonResult> without_async_awat(string values)
        //{
        //    Stopwatch sw = new Stopwatch();
        //    sw.Start();
        //    string result = values;
        //    var resultArray = values.Split(';');
        //    List<string> returnresultArray = new List<string>();
        //    Debug.WriteLine("starting 1     " + sw.Elapsed);

        //    Task<string> task1 = new Task<string>(()=>getResultStringByTask("vimal"));
        //    task1.Start();
        //    Task<string> task2 = new Task<string>(() => getResultStringByTask("raturi"));
        //    task2.Start();
        //    Task<string> task3 = new Task<string>(() => getResultStringByTask("Nainital"));
        //    task3.Start();


        //    Debug.WriteLine("calling  task1    " + sw.Elapsed);
        //    returnresultArray.Add(await task1);
        //    Debug.WriteLine("calling  task2    " + sw.Elapsed);
        //    returnresultArray.Add(await task2);
        //    Debug.WriteLine("calling  task3    " + sw.Elapsed);
        //    returnresultArray.Add(await task3);

        //    Debug.WriteLine("end      " + sw.Elapsed);
        //    sw.Stop();
        //    return Json(string.Join(";", returnresultArray, JsonRequestBehavior.AllowGet);
        //}




        //public async Task<JsonResult> without_async_awat(string values)
        //{
        //    Stopwatch sw = new Stopwatch();         sw.Start();
        //    List<string> returnresultArray = new List<string>();
        //    List<Task<string>> taskList = new List<Task<string>>();
        //    Debug.WriteLine("starting 1     " + sw.Elapsed);

        //    var resultArray = values.Split(';');

        //    for (int i = 0; i < resultArray.Length; i++)
        //    {
        //        string param = resultArray[i];
        //        Task<string> task = new Task<string>(() => getResultStringByTask(param));
        //        task.Start();
        //        taskList.Add(task);
        //    }

        //    foreach (Task<string> taskitem in taskList)
        //    {
        //        Debug.WriteLine("calling  task    " + sw.Elapsed);
        //        string val = await taskitem;
        //        returnresultArray.Add(val);
        //    }

        //    Debug.WriteLine("end      " + sw.Elapsed);
        //    sw.Stop();
        //    return Json(string.Join(";", returnresultArray), JsonRequestBehavior.AllowGet);
        //}
        public async Task<JsonResult> without_async_awat(string values)
        {
            Stopwatch sw = new Stopwatch(); sw.Start();
            List<string> returnresultArray = new List<string>();
            List<Task<string>> taskList = new List<Task<string>>();
            Debug.WriteLine("starting 1     " + sw.Elapsed);

            var resultArray = values.Split(';');

            for (int i = 0; i < resultArray.Length; i++)
            {
                string param = resultArray[i];
                Task<string> task = new Task<string>(() => getResultStringByTask(param));
                task.Start();
                taskList.Add(task);
            }
            ////////////Debug.WriteLine("waitall start    " + sw.Elapsed);
            ////////////Task.WaitAll(taskList.ToArray());
            ////////////Debug.WriteLine("waitall end    " + sw.Elapsed);
            foreach (Task<string> taskitem in taskList)
            {
                try
                { 
                    Debug.WriteLine("calling  task    " + sw.Elapsed);
                    string val = await taskitem;
                    returnresultArray.Add(val);
                }
                catch (Exception ex)
                {
                    returnresultArray.Add(ex.Message);
                }
            }

            Debug.WriteLine("end      " + sw.Elapsed);
            sw.Stop();
            return Json(string.Join(";", returnresultArray), JsonRequestBehavior.AllowGet);
        }



    }
}