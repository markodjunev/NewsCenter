using Microsoft.AspNetCore.Http;
using NewsCenter.Services.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace NewsCenterWebAPI.Middlewares
{
    public class SeedCategoriesMiddleware
    {
        private readonly RequestDelegate next;

        public SeedCategoriesMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, IServiceProvider provider)
        {
            var categoriesService = provider.GetService<ICategoriesService>();
            if (!categoriesService.Any())
            {
                var categories = new List<(string Name, string ImageUrl)>
            {
                ("Sport", "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0c/Sport_balls.svg/1200px-Sport_balls.svg.png"),
                ("Coronavirus", "https://cdn.wccftech.com/wp-content/uploads/2020/01/https___cdn.cnn_.com_cnnnext_dam_assets_200108214800-coronavirus.jpg"),
                ("USA", "https://upload.wikimedia.org/wikipedia/en/thumb/a/a4/Flag_of_the_United_States.svg/1200px-Flag_of_the_United_States.svg.png"),
                ("Music", "https://www.bensound.com/bensound-img/happyrock.jpg"),
                ("Programming", "https://learnworthy.net/wp-content/uploads/2019/12/Why-programming-is-the-skill-you-have-to-learn.jpg"),
                ("Criminal", "https://bloximages.chicago2.vip.townnews.com/tucson.com/content/tncms/assets/v3/editorial/9/63/963df220-c3a4-58aa-95b4-30a11d2edd55/5c4266721bbf0.image.jpg"),
                ("Politics", "https://ugc.futurelearn.com/uploads/images/f4/ec/f4ec13af-2d48-426d-b48a-7cb362240feb.jpg"),
                ("World", "https://world-geography-games.com/img/home-america1.png"),
            };

                foreach (var category in categories)
                {
                    await categoriesService.CreateAsync(category.Name, category.ImageUrl);
                }
            }

            await this.next(context);
        }

    }
}
