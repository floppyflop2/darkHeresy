using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(darkHeresyBack.Startup))]

namespace darkHeresyBack
{
    public partial class Startup
    {
        public static void main()
        {
                    
        }

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

    }
}
