using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tab30.ViewModels
{
    public class AssignedProblemAreas
    {
        public int ProblemAreaID { get; set; }
        public string ProblemDescription { get; set; }
        public bool Assigned { get; set; }
    }
}