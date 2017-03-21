using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PissanoApp.ViewModels
{
    public class StatesDictionary
    {

        public static SelectList StateSelectList
        {
            get { return new SelectList(StateDictionary, "Value", "Key"); }
        }
        public static readonly IDictionary<string, string>
            StateDictionary = new Dictionary<string, string> { 
          {"Choose...",""}
        , { "Alabama", "AL" }
        , { "Alaska", "AK" }
        , { "Arizona", "AZ" }
        , { "Arkansas", "AR" }
        , { "California", "CA" }
        // code continues to add states...
    }; 

    }
}