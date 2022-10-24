using System;
using System.Collections.Generic;
using System.Text;

namespace JustTestAPIAssignment.Model
{
    public class RegisterRequest
    {
        public string username { get; set; }
        public string firstName { get; set; }
        public string lastname { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
    }
}
