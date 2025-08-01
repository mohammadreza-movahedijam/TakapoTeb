using Domain.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping;

internal sealed class RouteMap : IEntityTypeConfiguration<RouteEntity>
{
    public void Configure(EntityTypeBuilder<RouteEntity> builder)
    {
        builder.ToTable("Route","dbo");


        builder.HasData(new RouteEntity()
        {
            Id = Guid.Parse("92e9b533-395f-40de-bf5c-daf5175174cf"),
            Title = "مدیریت نقش",
            Icon = "<i class=\"fa-solid fa-medal menu-icon\"></i>",
            Url = "/Admin/Role", 
            Order = 1
        });



        builder.HasData(new RouteEntity()
        {
            Id = Guid.Parse("13efcf5b-ac2a-4ea7-8dbf-00794f5c3579"),
            Title = "مدیریت کاربران",
            Icon = "<i class=\"fa-solid fa-user-tie menu-icon\"></i>",
            Url = "/Admin/User",
            Order = 2
        });




        builder.HasData(new RouteEntity()
        {
            Id = Guid.Parse("5fd23be1-e7bf-4c08-b5d7-2a5df8c41d71"),
            Title = "مدیریت محصولات",
            Icon = "<i class=\"fa-solid fa-store  menu-icon\"></i>",
            Url = "/Admin/Product",
            Order = 3
        });


        builder.HasData(new RouteEntity()
        {
            Id = Guid.Parse("69d86bce-910a-4410-ae9a-da72409d3047"),
            Title = "مدیریت مقالات",
            Icon = "<i class=\"fa-solid fa-pen-nib menu-icon\"></i>",
            Url = "/Admin/Article",
            Order = 4
        });




        builder.HasData(new RouteEntity()
        {
            Id = Guid.Parse("c3d18153-b55e-4f50-b64c-93d4f6bea161"),
            Title = "مدیریت اسلایدر",
            Icon = "<i class=\"fa-solid fa-images menu-icon\"></i>",
            Url = "/Admin/Slider",
            Order = 5
        });


        builder.HasData(new RouteEntity()
        {
            Id = Guid.Parse("20cfd69e-b34c-4f6d-9e36-d9877239b3bb"),
            Title = "مدیریت شرکای تجاری",
            Icon = "<i class=\"fa-solid fa-images menu-icon\"></i>",
            Url = "/Admin/Partner",
            Order = 6
        });


        builder.HasData(new RouteEntity()
        {
            Id = Guid.Parse("7d9a13c7-a233-4551-8b4a-61b4c162ac4a"),
            Title = "مدیریت اخبار",
            Icon = "<i class=\"fas fa-sticky-note menu-icon\"></i>",
            Url = "/Admin/News",
            Order = 7
        });


        builder.HasData(new RouteEntity()
        {
            Id = Guid.Parse("04a19910-8314-4909-8ab6-28b01f8d8612"),
            Title = "گفتگوی آنلاین",
            Icon = "<i class=\"fa-solid fa-headset menu-icon\"></i>",
            Url = "/Admin/Chat",
            Order = 8
        });


        builder.HasData(new RouteEntity()
        {
            Id = Guid.Parse("2b187594-0cd6-4103-a93e-c7ecc35df142"),
            Title = "پیام ها",
            Icon = "<i class=\"fa-solid fa-envelope menu-icon\"></i>",
            Url = "/Admin/Contact",
            Order = 9
        });

        

        builder.HasData(new RouteEntity()
        {
            Id = Guid.Parse("0063a094-6e6b-40ff-b459-9db952afa2d8"),
            Title = "واحد های اداری",
            Icon = "<i class=\"fa-solid fa-building menu-icon\"></i>",
            Url = "/Admin/Departement",
            Order = 10
        });


        builder.HasData(new RouteEntity()
        {
            Id = Guid.Parse("b8f6c352-571a-4235-9e92-c325db6d6ddf"),
            Title = "تنظیمات عمومی",
            Icon = "<i class=\"fa-solid fa-wrench  menu-icon\"></i>",
            Url = "/Admin/Setting/General",
            Order = 11
        });



         builder.HasData(new RouteEntity()
        {
            Id = Guid.Parse("8072a16c-8db7-46dd-a3e4-e41f0ece7a76"),
            Title = "آمار",
             Icon = "<i class=\"fa-solid fa-chart-bar  menu-icon\"></i>",
             Url = "/Admin/Setting/Statistic",
             Order = 12
         });



        builder.HasData(new RouteEntity()
        {
            Id = Guid.Parse("d71c15ce-8785-4abf-8f5b-d58a1a4e8ca5"),
            Title = "آمار",
            Icon = "<i class=\"fa-solid fa-star  menu-icon\"></i>",
            Url = "/Admin/Setting/Feature",
            Order = 13
        });



        builder.HasData(new RouteEntity()
        {
            Id = Guid.Parse("faf6eddd-f721-4a8b-9614-7e7223759b58"),
            Title = "ویژگی های محصول",
            Icon = string.Empty,
            Url = "/Admin/Option",
            Order = 14
        });

        builder.HasData(new RouteEntity()
        {
            Id = Guid.Parse("adb33323-9d60-4993-8299-81d37ed3c41c"),
            Title = "مستندات محصول",
            Icon = string.Empty,
            Url = "/Admin/Document",
            Order = 15
        });

        
        builder.HasData(new RouteEntity()
        {
            Id = Guid.Parse("8fe991ba-68d0-4398-8ca5-9ad25e9fd75d"),
            Title = "تصاویر محصول",
            Icon = string.Empty,
            Url = "/Admin/ProductImage",
            Order = 16
        });

        
        
        builder.HasData(new RouteEntity()
        {
            Id = Guid.Parse("b89b74ce-4017-4d02-8e9e-42a0dc4341b7"),
            Title = "مراکز",
            Icon = string.Empty,
            Url = "/Admin/TreatmentCenter",
            Order = 17
        });

        builder.HasData(new RouteEntity()
        {
            Id = Guid.Parse("e7f43df3-5a79-4d69-b1f0-bb7badae1662"),
            Title = "کاتالوگ و کتاب کار",
            Icon = "<i class=\"fa fa-folder menu-icon\"></i>\r\n",
            Url = "/Admin/Catalog",
            Order = 18
        });

        builder.HasData(new RouteEntity()
        {
            Id = Guid.Parse("\r\n4c773ebb-a00b-4eb7-b275-18e67dc12ad0\r\n"),
            Title = "درخواست آموزش",
            Icon = "<i class=\"fa fa-graduation-cap menu-icon\"></i>\r\n",
            Url = "/Admin/Request/Education",
            Order = 19
        });
        builder.HasData(new RouteEntity()
        {
            Id = Guid.Parse("3bd7c475-345a-4f0f-8b6a-8001369c9101"),
            Title = "درخواست سرویس",
            Icon = "<i class=\"fas fa-code-pull-request menu-icon\"></i>\r\n",
            Url = "/Admin/Request/Service",
            Order = 20
        });

        builder.HasData(new RouteEntity()
        {
            Id = Guid.Parse("579d113a-ca1f-409f-a50f-7581984f8fb0"),
            Title = "دیدگاه کاربران",
            Icon = "<i class=\"fa fa-comment menu-icon\"></i>",
            Url = "/Admin/Feedback",
            Order = 21
        });

         builder.HasData(new RouteEntity()
        {
            Id = Guid.Parse("3340131a-42eb-448e-87b8-be6f2cf0baed"),
            Title = "دسته بندی مقالات",
            Icon = "<i class=\"fas fa-list-alt menu-icon\"></i>\r\n",
            Url = "/Admin/BlogCategory",
            Order = 22
        });

        builder.HasData(new RouteEntity()
        {
            Id = Guid.Parse("a7a03bed-1848-4a26-b886-df2efef5271d"),
            Title = "دسته بندی اخبار",
            Icon = "<i class=\"fas fa-list-alt menu-icon\"></i>\r\n",
            Url = "/Admin/NewsCategory",
            Order = 23
        });

            builder.HasData(new RouteEntity()
        {
            Id = Guid.Parse("67d20d6a-cf73-4150-b9ce-0cb3bc83a8c8"),
            Title = "دسته بندی محصولات",
            Icon = "<i class=\"fas fa-list-alt menu-icon\"></i>\r\n",
            Url = "/Admin/ProductCategory",
            Order = 24
        });



    }
}
