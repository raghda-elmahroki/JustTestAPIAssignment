using JustTestAPIAssignment.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustTestAPIAssignment.Helper
{
    public class Utilities
    {
        public RestResponse CreateUser(RegisterRequest requestBody)
        {
            RestClient client = new RestClient("https://k51qryqov3.execute-api.ap-southeast-2.amazonaws.com/");
            RestRequest request = new RestRequest("prod/users", Method.Post);
            if (requestBody != null)
            {
                request.AddJsonBody(requestBody);
            }

            return client.Execute(request); 
        }
    }
}
