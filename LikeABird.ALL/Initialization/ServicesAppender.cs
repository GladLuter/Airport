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
                routes.MapRoute("api", "api/users", new { controller = "AO_User", action = "Get" });
                routes.MapRoute(
                    name: "default",
                    template: "{controller=AO_User}/{action=Get}/{id?}");
            });

        }
    }
}
