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
        public string DueDate { get; set; }
        public bool isComplete { get; set; }
        public TodoTask(string taskText, string dueDate, bool isDone)
        {
            task = taskText;
            DueDate = dueDate;
            isComplete = isDone;
        }
    }
}
