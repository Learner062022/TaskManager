using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DylanDeSouzaTaskManager
{
    internal class Habit : RepetitiveTask
    {
        public int TimesCompled { get; set; }
        public Habit(string description, string notes) : base(description, notes)
        {

        }

        // no implementation provided to handle the streak calculation
    }
}
