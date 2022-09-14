using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;

namespace RestSharpTest
{

    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public string salary { get; set; }
    }


    [TestClass]
    public class RestSharpCase
    {
        RestClient client;

        [TestInitialize]
        public void Setup()
        {
            client = new RestClient ("Http://localhost:4000");

        }

        private IRestResponse getEmployeeList()
        {
            //arrange
            RestRequest request = new RestRequest ("/employees", Method.GET);

            //act
            IRestResponse response = client.Execute(request);
            return response;

        }

        [TestMethod]
        public void OnCallingList_ReturnEmployeeList()
        {
            IRestResponse response = getEmployeeList();
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            List<Employee> dataResponse = JsonConvert.DeserializeObject<List<Employee>>(response.Content);
            // Assert.AreEqual(3, dataResponse.Count);
            foreach (Employee e in dataResponse)
            {
                Console.WriteLine("id : " + e.id + "Name: " + e.name + "salary : " + e.salary);

            }
        }




    }