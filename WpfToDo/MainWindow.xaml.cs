using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;

namespace WpfToDo
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        #region Static Resources
        public static string fileName = "tasks.bin";
        #endregion

        #region Attributes
        private ObservableCollection<TodoTask> tasks;
        public ObservableCollection<TodoTask> Tasks
        {
            get { return tasks; }
            set
            {
                if (value != tasks)
                {
                    tasks = value;
                    OnPropertyChanged("Tasks");
                }
            }
        }

        private TodoTask selectedTask;
        public TodoTask SelectedTask
        {
            get { return selectedTask; }
            set
            {
                if (value != selectedTask)
                {
                    selectedTask = value;
                    OnPropertyChanged("SelectedTask");
                }
            }
        }
        #endregion

        #region Constructors
        public MainWindow()
        {
            InitializeComponent();

            Tasks = new ObservableCollection<TodoTask>();
            SelectedTask = null;
            DataContext = this;
            deserializeTasks();
        }
        #endregion

        #region Event Handling
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            //Tasks.Add(new Task(textBox.Text));
            Tasks.Add(new TodoTask()
            {
                Name = textBox.Text,
                DueDate = dueDate.SelectedDate.Value,
                IsCompleted = false
            } );
            serializeTasks();
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedTask != null)
            {
                int index = -1;
                for (int i = 0; i < Tasks.Count; i++)
                {
                    if (Tasks[i].Name.Equals(SelectedTask.Name))
                    {
                        index = i;
                    }
                }
                if (index != -1)
                {
                    Tasks.RemoveAt(index);
                    //OnPropertyChanged("Tasks");
                }
            }
        }
        #endregion

        #region PropertyChangedNotifier
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion

        #region Serialization
        public void serializeTasks()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            try
            {
                stream = File.Open("tasks.bin", FileMode.OpenOrCreate);
                formatter.Serialize(stream, Tasks);
            }
            catch
            {
                throw new DriveNotFoundException();
            }
            finally
            {
                if (stream != null)
                    stream.Dispose();
            }
        }

        public void deserializeTasks()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            if (File.Exists(fileName))
            {
                try
                {
                    stream = File.Open(fileName, FileMode.Open);
                    Tasks = (ObservableCollection<TodoTask>)formatter.Deserialize(stream);
                }
                catch
                {
                    throw new FileNotFoundException();
                }
                finally
                {
                    if (stream != null)
                        stream.Dispose();
                }

            }
        }
        #endregion

       
    }
}
