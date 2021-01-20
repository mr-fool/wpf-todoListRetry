using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfToDo
{
    [Serializable]
    public class Name
    {
        public string task { get; set; }
        public string DueDate { get; set; }
        public bool isComplete { get; set; }
        public Name(string taskText, string dueDate, bool isDone)
        {
            task = taskText;
            DueDate = dueDate;
            isComplete = isDone;
        }
    }
}
