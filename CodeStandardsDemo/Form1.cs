using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Owin;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Hosting;

namespace CodeStandardsDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string baseAddress = "http://localhost:9000/";

            // Start OWIN host 
            WebApp.Start<Startup>(url: baseAddress);
            

            // Create HttpCient and make a request to api/values 
            HttpClient client = new HttpClient();

            var response = client.GetAsync(baseAddress + "api/values").Result;

            textBox1.Text = response.ToString();
            textBox1.Text += response.Content.ReadAsStringAsync().Result;





        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create HttpCient and make a request to api/values 
            HttpClient client = new HttpClient();

            var response = client.GetAsync(textBox2.Text).Result;


            textBox1.Text = response.ToString();
            textBox1.Text += response.Content.ReadAsStringAsync().Result;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.UseWebApi(config);
        }
    }

    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5 
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values 
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5 
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5 
        public void Delete(int id)
        {
        }
    }


}
