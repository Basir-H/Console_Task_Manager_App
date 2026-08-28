using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager
{
    internal interface ITaskRepository
    {
        void Add(TaskItem task);
        bool Update(TaskItem task);
        bool Delete(int id);
        IReadOnlyList<TaskItem> GetAll();
        bool SaveMarkAsComplete();
    }
}
