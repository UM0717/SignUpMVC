using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignUpMVC.ViewModels
{
    public class DataModel
    {
        private static int _counter = 0;
        public decimal Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Birthday {get;set;}

        public DataModel()
        {
            _counter++;
            Id = _counter;
        }
    }
}