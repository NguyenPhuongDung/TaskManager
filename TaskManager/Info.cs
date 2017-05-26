using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    [Serializable]
    public class Info
    {
        public double totalCPU { get; set; }
        public double totalMemory { get; set; }
        public ProcessClient[] process { get; set; }

        public Info() { }

        public Info(double totalCPU, double totalMemory, ProcessClient[] listProcess)
        {
            this.totalCPU = totalCPU;
            this.totalMemory = totalMemory;
            this.process = listProcess;
        }

    }
}
