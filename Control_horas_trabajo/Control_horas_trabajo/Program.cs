using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_horas_trabajo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int seqIdDev = 1;
            int seqIdProject = 1;
            int op = -1;
            int idDev;
            int idAssi;
            int indexDev;
            int indexProject;

            Proyecto project = new Proyecto();
            Desarrollador dev = new Desarrollador();

            List<Desarrollador> Developers = new List<Desarrollador>();
            List<Proyecto> Projects = new List<Proyecto>();
            List<Registro_Horas> TimeRecord = new List<Registro_Horas>();

            DateTime d = new DateTime(2023, 05, 22);
            dev = new Desarrollador(seqIdDev, "Mario Andres Basilio Lopez", d, "andres.basilio@outlook.es", 1);
            project = new Proyecto(seqIdProject, "Tesis New Talents", 1, 400, d);
            Developers.Add(dev);
            Projects.Add(project);

            do
            {
                Console.Clear();

                Console.WriteLine("¡A que sistema desea entrar?");
                Console.WriteLine("1\t Sistema de registro desarrollador/proyecto");
                Console.WriteLine("2\t Sistema de control de horas de trabajador");
                Console.WriteLine("3\t Lista de Desarrolladores con Proyectos");
                Console.WriteLine("0\t Salir");
                Console.WriteLine();

                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:

                        do
                        {
                            Console.Clear();

                            Console.WriteLine("Sistema de registro desarrollador/proyecto");
                            Console.WriteLine("¿Qué desea realizar?");
                            Console.WriteLine("1\t Registrar trabajador");
                            Console.WriteLine("2\t Registrar proyecto");
                            Console.WriteLine("3\t Asignar proyecto a trabajador");
                            Console.WriteLine("4\t Salir");
                            Console.WriteLine();

                            op = int.Parse(Console.ReadLine());
                            switch (op)
                            {
                                case 1:
                                    Console.Clear();

                                    Console.WriteLine("Ingrese nombre del desarrollador");
                                    string name = Console.ReadLine();
                                    Console.WriteLine("Ingrese categoria del desarrollador (1, 2 o 3)");
                                    int category = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Ingrese email");
                                    string email = Console.ReadLine();
                                    Console.WriteLine("Ingrese fecha de ingreso (formato YYYY/MM/DD)");
                                    string dateAdmission = Console.ReadLine();
                                    string[] dateAd = dateAdmission.Split('/');
                                    DateTime date = new DateTime(int.Parse(dateAd[0]), int.Parse(dateAd[1]), int.Parse(dateAd[2]));
                                   
                                    ++seqIdDev;
                                    dev = new Desarrollador(seqIdDev, name, date, email, category);
                                    Developers.Add(dev);

                                    Console.WriteLine("Registro Exitoso");
                                    Console.ReadKey();

                                    break;

                                case 2:
                                    Console.Clear();

                                    Console.WriteLine("Ingrese nombre del proyecto");
                                    string nameProject = Console.ReadLine();
                                    Console.WriteLine("Ingrese categoria del proyecto (1, 2 o 3)");
                                    int categoryProject = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Ingrese duración en horas");
                                    int duration = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Ingrese fecha de inicio (formato YYYY/MM/DD)");
                                    string startDate = Console.ReadLine();
                                    string[] startD = startDate.Split('/');
                                    DateTime start = new DateTime(int.Parse(startD[0]), int.Parse(startD[1]), int.Parse(startD[2]));

                                    ++seqIdProject;
                                    project = new Proyecto(seqIdProject, nameProject, categoryProject, duration, start);
                                    Projects.Add(project);

                                    Console.WriteLine("Registro Exitoso");
                                    Console.ReadKey();

                                    break;

                                case 3:
                                    Console.Clear();
                                    if (Projects.Count > 0 && Developers.Count > 0)
                                    {
                                        Console.WriteLine("Proyectos disponibles");
                                        Console.WriteLine();

                                        project.listProjects(Projects, false,2);

                                        Console.WriteLine();
                                        Console.WriteLine("Ingrese Id del proyecto a asignar");
                                        idAssi = int.Parse(Console.ReadLine());

                                        project = project.listProjects(Projects, idAssi);

                                        Console.Clear();
                                        project.detailsProject();

                                        Console.WriteLine();
                                        Console.WriteLine("Desarrolladores disponibles:");
                                        Console.WriteLine();
                                        dev.listDevelopers(Developers);

                                        Console.WriteLine();

                                        Console.WriteLine("Ingrese Id del desarrollador elegido");
                                        idDev = int.Parse(Console.ReadLine());

                                        dev = dev.listDevelopers(Developers, idDev);

                                        indexProject = Projects.IndexOf(project);
                                        Projects.Remove(project);
                                        project.AssignDeveloper(dev.idDeveloper);
                                        Projects.Insert(indexProject, project);

                                        indexDev = Developers.IndexOf(dev);
                                        Developers.Remove(dev);
                                        dev.AssignProject(project);
                                        Developers.Insert(indexDev, dev);
                     
                                    }
                                    else
                                    {
                                        Console.WriteLine("No hay proyectos o desarrolladores disponibles");
                                    }

                                    Console.ReadKey();
                                    break;

                                default: Console.WriteLine("Ingrese una opció valida");
                                    break;

                            }
                        } while (op != 4);
                        break;

                    case 2:
                        Console.Clear();

                        Console.WriteLine("Sistema de control de horas de trabajador");
                        Console.WriteLine("Ingresa tu id");
                        idDev = int.Parse(Console.ReadLine());

                        dev = dev.listDevelopers(Developers, idDev);
                                               
                        dev.Presentacion();
                        Console.WriteLine();
                        Console.WriteLine("Proyectos Asignados");
                        project.listProjects(dev.projects, false, 1);
                        Console.WriteLine();

                        Console.WriteLine("Ingrese id de proyecto para registrar horas");
                        idAssi = int.Parse(Console.ReadLine());

                        project = project.listProjects(dev.projects,idAssi);
                        Console.Clear();

                        dev.Presentacion();
                        project.detailsProject();

                        indexDev = Developers.IndexOf(dev);
                        Developers.Remove(dev);
                        dev.TimeRecords(dev.idDeveloper, project.idProject);
                        Developers.Add(dev);
                        Console.WriteLine("Registro exitoso");
                        Console.ReadKey();

                        break;

                    case 3:
                        Console.Clear();
                        foreach(Desarrollador deve in Developers)
                        {
                            deve.Presentacion();
                            Console.WriteLine("------------------------------------------------------------");
                            deve.ProjectsAssig();
                            Console.WriteLine("------------------------------------------------------------");
                            Console.WriteLine();
                           
                        }
                        Console.ReadLine();
                        break; 

                    case 4:

                        break;

                }
            } while (op != 0);
        }

    }
}
