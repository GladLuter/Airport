using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.ALL.Initialization {
    public class ServicesAppender {
        public static void AddServicesMVC(IApplicationBuilder app) {
            app.UseMvc(routes => {
                routes.MapRoute("api", "api/users", new { controller = "users", action = "Get" });
                routes.MapRoute(
                    name: "default",
                    template: "{controller=users}/{action=Get}/{id?}");
            });
            app.UseMvc(routes => {
                routes.MapRoute("api", "api/users", new { controller = "users", action = "Get" });
                routes.MapRoute(
                    name: "default",
                    template: "{controller=users}/{action=Get}/{id?}/Role");
            });

        }
    }
}
