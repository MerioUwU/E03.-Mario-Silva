using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_do_List
{
    class Program
    {
        static void Main(string[] args)
        {
            Repo_to_do_list repo = new Repo_to_do_list();//instancias el repo para llamar el metodo principal
            repo.Principal();//la bienvenida es llamada
        }
    }
}
