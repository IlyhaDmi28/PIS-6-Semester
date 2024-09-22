var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TMResearch}/{action=M01}");

app.MapControllerRoute(
    name: "r01_1",
    pattern: "/{cntrl}/{M01?}/{One?}",
    defaults: new
    {
        controller = "TMResearch",
        action = "M01"
    },
    constraints: new
    {
        cntrl = "MResearch",
        M01 = "M01",
        One = "1"
    }
);

app.MapControllerRoute(
   name: "r01_2",
   pattern: "/{version}/{cntrl}/{str}/{a}",
   defaults: new
   {
       controller = "TMResearch",
       action = "M01"
   },
   constraints: new
   {
       cntrl = "MResearch",
       version = "V3",
       a = "M01"
   }
);

app.MapControllerRoute(
    name: "r01_3",
    pattern: "/{version}/{cntrl}/{a}",
    defaults: new
    {
        controller = "TMResearch",
        action = "M01"
    },
    constraints: new
    {
        cntrl = "MResearch",
        version = "V2",
        a = "M01"
    }
);

app.MapControllerRoute(
    name: "r02_1",
    pattern: "/{version}/{cntrl?}/{M02?}",
    defaults: new
    {
        controller = "TMResearch",
        action = "M02"
    },
    constraints: new
    {
        cntrl = "MResearch",
        version = "V2",
        M02 = "M02"
    }
);

app.MapControllerRoute(
    name: "r02_2",
    pattern: "/{cntrl}/{M02}",
    defaults: new
    {
        controller = "TMResearch",
        action = "M02"
    },
    constraints: new
    {
        cntrl = "MResearch",
        M02 = "M02"
    }
);

app.MapControllerRoute(
    name: "r02_3",
    pattern: "/{version}/{cntrl}/{str}/{M02}",
    defaults: new
    {
        controller = "TMResearch",
        action = "M02"
    },
    constraints: new
    {
        cntrl = "MResearch",
        M02 = "M02",
        version = "V3"
    }
);

app.MapControllerRoute(
    name: "r03_1",
    pattern: "/{version}",
    defaults: new
    {
        controller = "TMResearch",
        action = "M03"
    },
    constraints: new
    {
        version = "V3"
    }
);

app.MapControllerRoute(
    name: "r03_2",
    pattern: "/{version}/{cntrl}/{str}/{M03?}",
    defaults: new
    {
        controller = "TMResearch",
        action = "M03"
    },
    constraints: new
    {
        cntrl = "MResearch",
        M03 = "M03",
        version = "V3"
    }
);

app.MapControllerRoute(
   name: "r_xxx",
   pattern: "{*suffix}",
   defaults: new
   {
       controller = "TMResearch",
       action = "MXX"
   }
);


app.Run();
