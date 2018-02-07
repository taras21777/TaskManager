using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace TasksGet
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter Action:");
                string id = Console.ReadLine();

                GetRequest(id).Wait();
                Console.ReadKey();
                Console.Clear();
            }
        }
        static async Task GetRequest(string ID)
        {
            switch (ID)
            {
                //Get Request    
                case "Get":
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:41447/");
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        HttpResponseMessage response;
                        response = await client.GetAsync("api/taskstatus");
                            if (response.IsSuccessStatusCode)
                            {
                                TaskStatus1[] reports = await response.Content.ReadAsAsync<TaskStatus1[]>();
                                foreach (var report in reports)
                                {
                                    Console.WriteLine("\n{0} - {1}", report.TaskStatusId, report.Name);
                                }
                            }
                        
                       
                    }
                    break;
                    // Post Request
                case "Post":
                    Task1 newReport = new Task1();
                    Console.WriteLine("Enter Data:");
                    Console.WriteLine("Enter Name:");
                    newReport.Name = Console.ReadLine();
                    Console.WriteLine("Enter TaskListId:");
                    newReport.TaskListId = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter TaskStatusId:");
                    newReport.TaskStatusId = Int32.Parse(Console.ReadLine());

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:41447/");
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        HttpResponseMessage response = await client.PostAsJsonAsync("api/tasks", newReport);

                        if (response.IsSuccessStatusCode)
                        {
                            bool result = await response.Content.ReadAsAsync<bool>();
                            if (result)
                                Console.WriteLine("Report Submitted");
                            else
                                Console.WriteLine("An error has occurred");
                        }
                    }

                    break;
                case "Delete":
                    Console.WriteLine("Enter id:");
                    int delete = Convert.ToInt32(Console.ReadLine());
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:41447/");
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        HttpResponseMessage response = await client.DeleteAsync("api/tasklists/" + delete);

                        if (response.IsSuccessStatusCode)
                        {
                            bool result = await response.Content.ReadAsAsync<bool>();
                            if (result)
                                Console.WriteLine("Report Deleted");
                            else
                                Console.WriteLine("An error has occurred");
                        }
                    }
                    break;
            }

        }
    }
}