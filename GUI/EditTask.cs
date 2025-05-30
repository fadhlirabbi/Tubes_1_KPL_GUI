using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelTask = API.Model.Task;

namespace GUI
{
    public partial class EditTask : Form
    {
        private readonly string _username;
        private readonly ModelTask _task;

        public EditTask(string username, ModelTask task)
        {
            InitializeComponent();
            _username = username;
            _task = task;
        }
    }
}
