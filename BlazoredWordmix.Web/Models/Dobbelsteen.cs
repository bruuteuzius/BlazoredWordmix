using System;
using System.Collections.Generic;

namespace BlazoredWordmix.Web.Models
{
    public class Dobbelsteen
    {
        public Kant SpeelbareKant { get; }
        public Dobbelsteen(Kant kant)
        {
            SpeelbareKant = kant;
        }
    }
}