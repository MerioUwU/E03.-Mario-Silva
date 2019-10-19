using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_do_List
{
    public class Task
    {
        public int ID { get; set; }//id para enlistar
        public string User { get; set; }//nombre de quien hara la tarea
        public string MainTask { get; set; }//la tarea en si para hacer
        public string TaskDescription { get; set; }//descripcion extensa de la tarea a realizar
        public DateTime DeadLine { get; set; }//datetime donde solo pediras hora
        public int Status { get; set; }////usas un int, en el repo solo podran usar 1 2 y 3

    }
}
