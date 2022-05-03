using ConsoleTools;
using R7R8MW_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace R7R8MW_HFT_2021222.Client
{
    internal class Program
    {

        static RestService restService;
        #region CrudMethods

        static void List(string entity)
        {
            if (entity == "Actor")
            {
                var actors = restService.Get<Actor>("actor");
                foreach (var item in actors)
                {
                    Console.WriteLine(item.Name);
                }
            }
            else if (entity == "Director")
            {
                var directors = restService.Get<Director>("director");
                foreach (var item in directors)
                {
                    Console.WriteLine(item.Name);
                }
            }
            else if (entity == "Movie")
            {
                var movies = restService.Get<Movie>("movie");
                foreach (var item in movies)
                {
                    Console.WriteLine(item.Title);
                }
            }
            else if (entity == "Role")
            {
                var roles = restService.Get<Role>("role");
                foreach (var item in roles)
                {
                    Console.WriteLine(item.RoleName);
                }
            }
            Console.ReadLine();
        }
        static void Create(string entity)
        {
            if (entity == "Actor")
            {
                Console.Write("Enter a new actor name: ");
                string name = Console.ReadLine();
                restService.Post(new Actor() { Name = name }, "actor");
            }
            if (entity == "Director")
            {
                Console.Write("Enter a new director name: ");
                string name = Console.ReadLine();
                restService.Post(new Director() { Name = name }, "director");
            }
            if (entity == "Role")
            {
                Console.Write("Enter a new role name: ");
                string name = Console.ReadLine();
                restService.Post(new Role() { RoleName = name }, "role");
            }
            if (entity == "Movie")
            {
                Console.Write("Enter a new movie name: ");
                string name = Console.ReadLine();
                restService.Post(new Movie() { Title = name }, "movie");
            }
        }
        static void Update(string entity)
        {
            if (entity == "Actor")
            {
                int id = -1;
                Actor old=null;
                bool accepted = false;
                while (!accepted)
                {
                    try
                    {
                        Console.Write("Which actor do you want to update? Type actor's id:");
                        id = int.Parse(Console.ReadLine());
                        old = restService.Get<Actor>(id, "actor"); 
                        accepted = true;
                    }
                    catch(NullReferenceException n)
                    {
                        Console.WriteLine(n.Message);
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                    }
                    catch (KeyNotFoundException e)
                    {
                        Console.WriteLine(e.Message);
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Type a valid ID!");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                    }
                }

                Console.Write($"Type a new name for [{old.Name}] : ");
                string name = Console.ReadLine();
                old.Name = name;
                restService.Put(old, "actor");
            }
            else if (entity == "Director")
            {
                int id = -1;
                bool accepted = false;
                while (!accepted)
                {
                    try
                    {
                        Console.Write("Which director do you want to update? Type director's id:");
                        id = int.Parse(Console.ReadLine());
                        accepted = true;
                    }
                    catch (KeyNotFoundException e)
                    {
                        Console.WriteLine(e.Message);
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Type a valid ID!");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                    }
                }

                Director old = restService.Get<Director>(id, "director");
                Console.Write($"Type a new name for [{old.Name}] : ");
                string name = Console.ReadLine();
                old.Name = name;
                restService.Put(old, "director");
            }
            else if (entity == "Role")
            {
                int id = -1;
                bool accepted = false;
                while (!accepted)
                {
                    try
                    {
                        Console.Write("Which role do you want to update? Type role's id:");
                        id = int.Parse(Console.ReadLine());
                        accepted = true;
                    }
                    catch (KeyNotFoundException e)
                    {
                        Console.WriteLine(e.Message);
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Type a valid ID!");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                    }
                }

                Role old = restService.Get<Role>(id, "role");
                Console.Write($"Type a new name for [{old.RoleName}] : ");
                string name = Console.ReadLine();
                old.RoleName = name;
                restService.Put(old, "role");
            }
            else if (entity == "Movie")
            {
                int id = -1;
                bool accepted = false;
                while (!accepted)
                {
                    try
                    {
                        Console.Write("Which movie do you want to update? Type movie's id:");
                        id = int.Parse(Console.ReadLine());
                        accepted = true;
                    }
                    catch (KeyNotFoundException e)
                    {
                        Console.WriteLine(e.Message);
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Type a valid ID!");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                    }
                }

                Movie old = restService.Get<Movie>(id, "movie");
                Console.Write($"Type a new name for [{old.Title}] : ");
                string title = Console.ReadLine();
                old.Title = title;
                restService.Put(old, "movie");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Actor")
            {
                int id = -1;
                bool accepted=false;
                while (!accepted)
                {
                    try
                    {
                        Console.Write("Which actor do you want to delete? Type actor's id:");
                        id = int.Parse(Console.ReadLine());
                        restService.Delete(id, "actor");
                        accepted = true;
                    }
                    catch (NullReferenceException n)
                    {
                        Console.WriteLine(n.Message);
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                    }
                    catch (KeyNotFoundException e)
                    {
                        Console.WriteLine(e.Message);
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Type a valid ID!");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                    }
                }  
            }
            else if (entity == "Director")
            {
                int id = -1;
                bool accepted = false;
                while (!accepted)
                {
                    try
                    {
                        Console.Write("Which director do you want to delete? Type director's id:");
                        id = int.Parse(Console.ReadLine());
                        accepted = true;
                    }
                    catch (KeyNotFoundException e)
                    {
                        Console.WriteLine(e.Message);
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Type a valid ID!");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                    }
                }
                restService.Delete(id, "director");
            }
            else if (entity == "Role")
            {
                int id = -1;
                bool accepted = false;
                while (!accepted)
                {
                    try
                    {
                        Console.Write("Which role do you want to delete? Type role's id:");
                        id = int.Parse(Console.ReadLine());
                        accepted = true;
                    }
                    catch (KeyNotFoundException e)
                    {
                        Console.WriteLine(e.Message);
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Type a valid ID!");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                    }
                }
                restService.Delete(id, "role");
            }
            else if (entity == "Movie")
            {
                int id = -1;
                bool accepted = false;
                while (!accepted)
                {
                    try
                    {
                        Console.Write("Which movie do you want to delete? Type movie's id:");
                        id = int.Parse(Console.ReadLine());
                        accepted = true;
                    }
                    catch (KeyNotFoundException e)
                    {
                        Console.WriteLine(e.Message);
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Type a valid ID!");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                    }
                }
                restService.Delete(id, "movie");
            }
        }
        #endregion
        #region MovieNonCruds
        static void ListOldestMovies()
        {
            var result = restService.Get<Movie>("movienoncruds/oldestmovie");
            foreach (var item in result)
                Console.WriteLine(item.Title+" "+ item.Release);

            Console.ReadLine();
        }
        static void ListTopRatedMovies()
        {
            var result = restService.Get<Movie>("movienoncruds/topratedmovie");
            foreach (var item in result)
                Console.WriteLine(item.Title + " " + item.Rating);

            Console.ReadLine();
        }
        static void ListMoviesWithLargestIncome()
        {
            var result = restService.Get<Movie>("movienoncruds/moviewithlargestincome");
            foreach (var item in result)
                Console.WriteLine(item.Title+" Income:"+ item.Income);

            Console.ReadLine();
        }
        static void ListMoviesPerYear()
        {
            var result = restService.Get<KeyValuePair<int, IEnumerable<Movie>>>("movienoncruds/MoviesPerYear");
            foreach (var item in result)
            {
                Console.WriteLine("Year: " + item.Key);
                foreach(var movie in item.Value)
                    Console.WriteLine("Title: " + movie.Title);
            }

            Console.ReadLine();
        }
        static void ListMoviesWithMostActors()
        {
            var result = restService.Get<Movie>("MovieNonCruds/MoviesWithMostActors");
            foreach (var item in result)
            {
                Console.WriteLine(item.Title);
            }

            Console.ReadLine();
        }
        #endregion
        #region PersonNonCruds
        static void ListAllActorsFromAvengers()
        {
            var result = restService.Get<Actor>("PersonNonCruds/AllActorsFromAvengers");
            foreach (var item in result)
                Console.WriteLine(item.Name);

            Console.ReadLine();
        }
        static void ListDirectorWithMostFilms()
        {
            var result = restService.Get<Actor>("PersonNonCruds/DirectorWithMostFilms");
            foreach (var item in result)
            {
                Console.WriteLine("Director name: "+item.Name);
            }
            Console.ReadLine();
        }
        static void ListMostCommonActors()
        {
            var result = restService.Get<Actor>("PersonNonCruds/MostCommonActor");
            foreach (var item in result)
            {
                Console.WriteLine("Actor name: " + item.Name);
            }
            Console.ReadLine();
        }
        static void ListGetAllPersonWithStarting()
        {
            Console.WriteLine("Type a letter: ");
            bool accepted = false;
            char letter=(char)0;
            while (!accepted)
            {
                try
                {
                    letter = Console.ReadLine()[0];
                    if(letter!=0 || letter!=' ')
                        accepted = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Try again!");
                }
            }
            var result = restService.Get<IPerson>("PersonNonCruds/GetAllPersonWithStarting/"+letter);
            foreach(var person in result)
                Console.WriteLine(person.Name);

            Console.ReadLine();
        }
        static void ListMostSuccesfulDirector()
        {
            var result = restService.Get<IPerson>("PersonNonCruds/GetMostSuccesfulDirector");
            foreach(var director in result)
                Console.WriteLine(director.Name);

            Console.ReadLine();
        }
        static void ListActorsWithTheirMovieRoles()
        {
            var result = restService.Get<KeyValuePair<string, IEnumerable<KeyValuePair<string, string>>>>("PersonNonCruds/ActorInfo");
            foreach (var item in result)
            {
                Console.WriteLine("Actor name: "+item.Key);
                Console.WriteLine("--------------Films----------------");
                foreach (var film in item.Value)
                {
                    Console.WriteLine(film.Key+" Role: "+film.Value);
                }
                Console.WriteLine("***********************************");
            }
            Console.ReadLine();
        }
        #endregion
        #region RoleNonCruds
        static void ListMostCommonRoleNames()
        {
            var roleNames = restService.Get<string>("RoleNonCruds/GetMostCommonRoleName");
            foreach (var item in roleNames)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
        #endregion

        static void Main(string[] args)
        {
            restService = new RestService("http://localhost:60038/");
            #region Menu
            var actorSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Actor"))
                .Add("Create", () => Create("Actor"))
                .Add("Delete", () => Delete("Actor"))
                .Add("Update", () => Update("Actor"))
                .Add("List most common actors",()=> ListMostCommonActors())
                .Add("List all actors from Avengers",()=> ListAllActorsFromAvengers())
                .Add("List All Person Starting With: ", () => ListGetAllPersonWithStarting())
                .Add("List Actors With Their Movie Roles",()=> ListActorsWithTheirMovieRoles())
                .Add("Exit", ConsoleMenu.Close);

            var roleSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Role"))
                .Add("Create", () => Create("Role"))
                .Add("Delete", () => Delete("Role"))
                .Add("Update", () => Update("Role"))
                .Add("List most common role names", () => ListMostCommonRoleNames())
                .Add("Exit", ConsoleMenu.Close);

            var directorSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Director"))
                .Add("Create", () => Create("Director"))
                .Add("Delete", () => Delete("Director"))
                .Add("Update", () => Update("Director"))
                .Add("List directors with most films",()=> ListDirectorWithMostFilms())
                .Add("List All Person Starting With: ",()=> ListGetAllPersonWithStarting())
                .Add("List Most Succesful Directors",()=> ListMostSuccesfulDirector())
                .Add("Exit", ConsoleMenu.Close);

            var movieSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Movie"))
                .Add("Create", () => Create("Movie"))
                .Add("Delete", () => Delete("Movie"))
                .Add("Update", () => Update("Movie"))
                .Add("List oldest movies", () => ListOldestMovies())
                .Add("List top rated movies",() => ListTopRatedMovies())
                .Add("List movies with largest income", () => ListMoviesWithLargestIncome())
                .Add("List movies per year",()=> ListMoviesPerYear())
                .Add("List Movies With Most Actors",()=> ListMoviesWithMostActors())
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Movies", () => movieSubMenu.Show())
                .Add("Actors", () => actorSubMenu.Show())
                .Add("Roles", () => roleSubMenu.Show())
                .Add("Directors", () => directorSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
            #endregion
        }
    }
}
