using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    [Serializable]
    public class ProcessClient
    {
        public string nameProcess { get; set; }
        public int idProcess { get; set; }
        public double ram { get; set; }
        public double cpu { get; set; }
    }
}
