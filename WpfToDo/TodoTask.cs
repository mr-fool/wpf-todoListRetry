using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfToDo
{
    [Serializable]
    public class TodoTask
    {
        public string task { get; set; }
        public DateTime DueDate { get; set; }
        public bool isComplete { get; set; }
 
    }
}
