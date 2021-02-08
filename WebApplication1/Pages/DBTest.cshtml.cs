using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace WebApplication1.Pages
{
    public class DBTestModel : PageModel
    {
        // Required property
        // the connection string will never be null
        // there is a guard in LoadFromEnvironment
        // so it will always be set to something even blank
        public string ConnectionString { get; set; } = null!;

        // Actors is always going to be a List, possibly empty, never null
        public List<Actor> Actors { get; set; } = new();

        public async Task OnGetAsync()
        {
            var connectionString = AppConfiguration.LoadFromEnvironment().ConnectionString;
            ConnectionString = connectionString;

            var actors = await Db.GetActors(connectionString);
            //var users = await Db.GetNoUsers(connectionString);

            //foreach (var actor in actors.ToList())
            //{
            //    Log.Information($"{actor}");
            //    var (id, name, sex) = actor; // record deconstruction
            //}
            Actors = actors.ToList();
        }
    }

    // positional record
    // this is nice, but for ViewModels
    // I need a class to use Attributes that razor pages can pick up
    public record Actor(int ActorID, string Name, string Sex);


    //public class UserX
    //{
    //    public Guid UserId { get; set; }
    //    public string? UserName { get; set; }
    //}
}
