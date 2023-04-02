using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_4
{
    internal class Counter
    {
        public delegate void Notifier();
        public event Notifier Action;

        public void Count()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i == 77)
                {
                    if (Action != null)
                    {
                        Action();
                    }
                }
            }
        }
    }
}
