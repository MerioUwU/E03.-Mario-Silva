using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_do_List
{
    public class Repo_to_do_list
    {
        List<Task> tasks = new List<Task>();//Creas la lista global para trabajarla donde gustes
        int count=1;//contador global, funciona para los id de las tareas y asi las enumeras
        internal void Principal() //lo primero que aparece para el usuario
        {
            Console.WriteLine("Bienvenido al programa Lista de Tareas, presiona cualquier tecla para avanzar");//saludo inicial
            Console.ReadKey();//presionar cualquier tecla para contiunar, de preferencia no apagar el pc
            Console.Clear();//limpiar despues de trabajar el metodo
            Menu();//entras al menu despues de limpiar
        }
        private void Menu() //lo que ve el usuario despues del saludo, muestra las acciones a realizar
        {
            Console.WriteLine("Numero de Tareas en existencia: [{0}] Tareas",count-1);//dejalo en blanco por ahora, aqui mostraras las tareas disponibles
            Console.WriteLine("Seleccione con un numero la accion a realizar: \n1.-Crear Tarea\n2.-Mostrar Lista de Tareas\n3.-Detallar tarea\n4.-Mostrar Lista de Estatus de Tareas\n5.-Actualizar Estatus de Tarea\n6.-Salir");//las cinco opciones, todas en la misma linea
            switch (int.Parse(Console.ReadLine())) //menu con captura directa, sin crear variable
            {
                case 1://caso 1, agregar tarea, sera la prueba para comprobar instancia global, leer resultados en el metodo add tasks
                    Console.Clear();//limpia el menu, el usuario ya eligio su accion 
                    AddTask();//comienza metodo, ve a add task a ver como le haras para llenar la info de la lista, practica breakpoints
                    break;
                case 2:
                    Console.Clear();//limpia antes de avanzar
                    Console.WriteLine("Esta es la lista de tareas a realizar: ");
                    ShowTasks();//llamas al metodo para mostrar la lista de tareas a realizar
                    break;
                case 3:
                    Console.Clear();//limpieza antes de avanzar
                    DetailTask();//llamas al metodo para detallar una de las tareas
                    break;
                case 4:
                    Console.Clear();//limpieza antes de avanzar
                    StatusList();//llamas al metodo para ver una lista especifica de status de las tareas
                    break;
                case 5:
                    Console.Clear();//limpia antes de avanzar
                    UpdateStatus();//llama al metodo para actualizar la lista, todo el jale esta en el metodo
                    break;
                case 6://salida por si el usuario termino de hacer sus actividades y busca una opcion para salir en el menu
                    System.Environment.Exit(-1);//cierra el programa directamente
                    break;
                default:
                    break;
            }
        }
        public void AddTask()//comienza prueba de uso de lista global
        {
            //el plan: capturar todo en string y meterlo a un objeto en la lista con el hack que usamos en el banco
            Console.WriteLine("Ingrse el nombre del designado a la tarea: ");//capturas nombre del usuario que hara la tarea
            string user = Console.ReadLine();
            Console.WriteLine("Ingrese la tarea a realizar: ");//capturas la tarea
            string maintask = Console.ReadLine();
            Console.WriteLine("Agregue una descripcion breve de la tarea a realizar: ");//describes la tarea
            string taskdescription = Console.ReadLine();
            Console.WriteLine("Ingrese la hora a la que la tarea esta asignada en formato de 24 horas (hh:mm): ");//dale fecha y hora a la tarea
            string deadline = Console.ReadLine();
            Console.WriteLine("Seleccione con un numero el estado de la tarea: \n1.-Pendiente\n2.-En proceso\n3.-Terminada");
            int status=int.Parse(Console.ReadLine());
            switch (status)//me parecio mas sencillo que un if con sus else if, o mas limpio, a final de cuentas es un concepto selectivo
            {
                case 1: status = 1; break;
                case 2: status = 2; break;
                case 3: status = 3; break;
                default: Console.WriteLine("Opcion no valida, captura incorrecta, presione cualquier tecla para volver al menu"); Menu(); break;//devuelve al menu si no gusta de 
            }
            tasks.Add(new Task { ID = count, User = user, MainTask = maintask, TaskDescription = taskdescription, DeadLine = Convert.ToDateTime(deadline), Status = status });//manda las variables al objeto, haciendolas atributos
            count++;//crece contador
            Console.Clear();//limpia antes de irte
            Menu();//accesa de nuevo al menu para elegir si quieres ver mas listas o no
        }//fin del experimento, si jalo todo, eskeler
        public void ShowTasks() //muestra la lista de tareas
        {
            foreach (var item in tasks)//traduccion, por cada elemento en la tarea, hacer lo que pide dentro del corchete
            {
                Console.WriteLine("{0}.-{1}",item.ID,item.MainTask);
            }
            Console.WriteLine("Presiona cualquier tecla para volver al menu");//aviso de que se volvera al menu
            Console.ReadKey();//apashurrale a lo que quieras pa seguirle
            Console.Clear();//limpieza de pantalla
            Menu();//regreso al menu para seguir trabajando
        }
        public void DetailTask() //detallaremos la tarea seleccionandola con su numero de id, usando el foreach que aplicamos en el banco con el numero de cuenta
        {
            Console.WriteLine("Escribe un numero de la lista para ver los detalles de una tarea: ");
            int number = int.Parse(Console.ReadLine());//este numero sera enlazado con el objeto buscado con la ayuda del foreach
            Task t = new Task();//instancias clase para trabajar objeto
            foreach (var task in tasks) //creas una variable de task que concuerde con los objetos de la lista tasks
            { 
                if (number == task.ID) //condicion, como el password del otro programa, o el numero de cuenta del programa bank
                {
                    t = task;//conviertes haces que el objeto buscado adiquiera todos los atributos que lelva la clase task sacando la info de la lista
                }
            }
            Console.Clear();//limpias el pedido de numero
            Console.WriteLine("Tarea numero:\t{0}\nPersona que la realizara:\t{1}\nTarea a realizar:\t{2}\nDetalles de la tarea:\t{3}\nHora asignada para la tarea:\t{4}",t.ID,t.User,t.MainTask,t.TaskDescription,t.DeadLine.Hour);//escribes la parte facil
            //usando el int del atributo status elegimos que desplegar despues con un if, por eso se uso un switch delante
            if (t.Status == 1) { Console.WriteLine("Estado de la tarea:\tPendiente"); }//condicion uno, pendiente
            else if (t.Status == 2) { Console.WriteLine("Estado de la tarea:\tEn Proceso"); }//condicion dos, realizandose o en proceso
            else if (t.Status == 3) { Console.WriteLine("Estado de la tarea:\tTerminada"); }//condicion tres, terminada
            Console.WriteLine("Presiona cualquier tecla para regresar al menu");//clasico modo para volver
            Console.ReadKey();//momento en el que se accede al menu
            Console.Clear();//limpieza de pantalla
            Menu();//momento en el que se llega al menu 
        }//despliegue exitoso, informacion desplegada correctamente
        
        public void StatusList() //en esta primero solicitare el tipo de status que busca, asi como cuando eliges al registrar un status al capturar una tarea
        {
            Console.WriteLine("Seleccione con un numero el tipo de tareas que buscas desplegar:\n1.-Tareas Pendientes\n2.-Tareas en Proceso\n3.-Tareas Terminadas");//
            int number = int.Parse(Console.ReadLine());//eliges una de las 3 opciones
            Console.Clear();//limpieza de pantalla
            if (number == 1) { Console.WriteLine("Estas son las Tareas Pendientes"); } //condicion para desplegar las tareas pendientes
            else if (number == 2) { Console.WriteLine("Estas son las Tareas en Proceso"); }//condicion para desplegar las tareas en proceso
            else if (number == 3) { Console.WriteLine("Estas son las Tareas Terminadas"); }//condicion para desplegar las tareas terminadas
            foreach (var item in tasks)
            {
                 if (number == item.Status) { Console.WriteLine("{0}",item.MainTask); }//despliega exclusivamente las tareas que son pendientes
            }
            Console.WriteLine("\nPresione cualquier tecla para volver al menu");//aviso para volver al menu
            Console.ReadKey();//presiona cualquier tecla para avanzar
            Console.Clear();//limpieza antes de regresar
            Menu();//accesando al menu de nuevo
        }
        public void UpdateStatus() //metodo para cambiar status, se elige un numero de la lista con todas las tareas y de ahi 
        {
            Console.WriteLine("Seleccione con el numero de lista la tarea con el status a cambiar: ");//solicitas un numero con base en la lista y le pides que elija una nueva de las 3 opciones
            int number = int.Parse(Console.ReadLine());//creas la variable para usar en el foreach de donde se extraera el objeto
            Task t = new Task();//instancia del objeto
            foreach (var item in tasks)//for each para buscar en la lista
            {
                if (number == item.ID) //con el numero eliges concordando con el id
                {
                    t = item;//enlazas el objeto con el item correcto encontrado para modificar su atributo
                }
            }
            Console.WriteLine("Ahora de estas tres opciones, seleccione el nuevo estado de la tarea {0}:\n\n1.-Pendiente\n2.-En proceso\n3.-Terminada",t.MainTask);//aqui confirmamos con el nombre que la tarea sea la correcta
            switch (int.Parse(Console.ReadLine())) //capturas igual que cuando capturas la informacion de la tarea completa para la seccion status, transcrito, no copiado y pegado
            {
                case 1: t.Status = 1; break;
                case 2: t.Status = 2; break;
                case 3: t.Status = 3; break;
                default: Console.WriteLine("Seleccione una opcion valida, por favor"); Menu(); ; break;//interrumpe y regresa al metodo sin sobreescribir
            }
            Console.Clear();//limpia
            Menu();//Manda al menu despues de seguir
        }
    }
}
