using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DylanDeSouzaTaskManager
{
    internal class RepetitiveTask : Task
    {
        public RepetitiveTask(string description, string notes) : base(description, notes)
        {

        }

        public DateTime DateTimeRepeate {  get; set; }

        public void SetWeekly()
        {
            // if (Completed)
            //{
            //  DateTimeRepeate = DateTime.Now.AddDays(7);
            //}

        }


        public void SetDaily()
        {
            // if (Completed)
            //{
            //  DateTimeRepeate = DateTime.Now.AddDays(1);
            //}
        }
    }
}
