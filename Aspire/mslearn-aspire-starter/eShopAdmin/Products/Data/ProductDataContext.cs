using DataEntities;
using Microsoft.EntityFrameworkCore;

namespace Products.Data;

public class ProductDataContext : DbContext
{
    public ProductDataContext (DbContextOptions<ProductDataContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Product { get; set; } = default!;
}

public static class Extensions
{
    public static void CreateDbIfNotExists(this IHost host)
    {
        using var scope = host.Services.CreateScope();

        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<ProductDataContext>();
        context.Database.EnsureCreated();
        DbInitializer.Initialize(context);
    }
}


public static class DbInitializer
{
  public static void Initialize(ProductDataContext context)
  {
    if (context.Product.Any())
      return;

    var products = new List<Product>
    {
        new Product { Name = "Wanderer Black Hiking Boots", Description = "Daybird's Wanderer Hiking Boots in sleek black are perfect for all your outdoor adventures. These boots are made with a waterproof leather upper and a durable rubber sole for superior traction. With their cushioned insole and padded collar, these boots will keep you comfortable all day long.", Price = 109.99m, ImageUrl = "1.webp" },
        new Product { Name = "Summit Pro Harness", Description = "Conquer new heights with the Summit Pro Harness by Gravitator. This lightweight and durable climbing harness features adjustable leg loops and waist belt for a customized fit. With its vibrant blue color, you'll look stylish while maneuvering difficult routes. Safety is a top priority with a reinforced tie-in point and strong webbing loops.", Price = 89.99m, ImageUrl = "2.webp" },
        new Product { Name = "Alpine Fusion Goggles", Description = "Enhance your skiing experience with the Alpine Fusion Goggles from WildRunner. These goggles offer full UV protection and anti-fog lenses to keep your vision clear on the slopes. With their stylish silver frame and orange lenses, you'll stand out from the crowd. Adjustable straps ensure a secure fit, while the soft foam padding provides comfort all day long.", Price = 79.99m, ImageUrl = "3.webp" },
        new Product { Name = "Expedition Backpack", Description = "The Expedition Backpack by Quester is a must-have for every outdoor enthusiast. With its spacious interior and multiple pockets, you can easily carry all your gear and essentials. Made with durable nylon fabric, this backpack is built to withstand the toughest conditions. The orange accents add a touch of style to this functional backpack.", Price = 129.99m, ImageUrl = "4.webp" },
        new Product { Name = "Blizzard Rider Snowboard", Description = "Get ready to ride the slopes with the Blizzard Rider Snowboard by B&R. This versatile snowboard is perfect for riders of all levels with its medium flex and twin shape. Its black and blue color scheme gives it a sleek and cool look. Whether you're carving turns or hitting the terrain park, this snowboard will help you shred with confidence.", Price = 299.99m, ImageUrl = "5.webp" },
        new Product { Name = "Carbon Fiber Trekking Poles", Description = "The Carbon Fiber Trekking Poles by Raptor Elite are the ultimate companion for your hiking adventures. Designed with lightweight carbon fiber shafts, these poles provide excellent support and durability. The comfortable and adjustable cork grips ensure a secure hold, while the blue accents add a stylish touch. Compact and collapsible, these trekking poles are easy to transport and store.", Price = 69.99m, ImageUrl = "6.webp" },
        new Product { Name = "Explorer 45L Backpack", Description = "The Explorer 45L Backpack by Solstix is perfect for your next outdoor expedition. Made with waterproof and tear-resistant materials, this backpack can withstand even the harshest weather conditions. With its spacious main compartment and multiple pockets, you can easily organize your gear. The green and black color scheme adds a rugged and adventurous edge.", Price = 149.99m, ImageUrl = "7.webp" },
        new Product { Name = "Frostbite Insulated Jacket", Description = "Stay warm and stylish with the Frostbite Insulated Jacket by Grolltex. Featuring a water-resistant outer shell and lightweight insulation, this jacket is perfect for cold weather adventures. The black and gray color combination and Grolltex logo add a touch of sophistication. With its adjustable hood and multiple pockets, this jacket offers both style and functionality.", Price = 179.99m, ImageUrl = "8.webp" },
        new Product { Name = "VenturePro GPS Watch", Description = "Navigate with confidence using the VenturePro GPS Watch by AirStrider. This rugged and durable watch features a built-in GPS, altimeter, and compass, allowing you to track your progress and find your way in any terrain. With its sleek black design and easy-to-read display, this watch is both stylish and practical. The VenturePro GPS Watch is a must-have for every adventurer.", Price = 199.99m, ImageUrl = "9.webp" },
        new Product { Name = "Trailblazer Bike Helmet", Description = "Stay safe on your cycling adventures with the Trailblazer Bike Helmet by Green Equipment. This lightweight and durable helmet features an adjustable fit system and ventilation for added comfort. With its vibrant green color and sleek design, you'll stand out on the road. The Trailblazer Bike Helmet is perfect for all types of cycling, from mountain biking to road cycling.", Price = 59.99m, ImageUrl = "10.webp" },
        new Product { Name = "Vertical Journey Climbing Shoes", Description = "The Vertical Journey Climbing Shoes from WildRunner in sleek black are the perfect companion for any climbing enthusiast. With an aggressive down-turned toe, sticky rubber outsole, and reinforced heel cup for added support, these shoes offer ultimate performance on even the most challenging routes.", Price = 129.99m, ImageUrl = "11.webp" },
        new Product { Name = "Powder Pro Snowboard", Description = "The Powder Pro Snowboard by Zephyr is designed for the ultimate ride through deep snow. Its floating camber allows for effortless turns and smooth maneuverability, while the lightweight carbon fiber construction ensures maximum control at high speeds. This board, available in vibrant turquoise, is a must-have for any backcountry shredder.", Price = 399.00m, ImageUrl = "12.webp" },
        new Product { Name = "Trailblaze hiking backpack", Description = "The Daybird Trailblaze backpack in forest green is a reliable and spacious bag for all your outdoor adventures. With a 40-liter capacity and durable ripstop fabric, this backpack provides ample storage and protection for your gear. Its ergonomic design and adjustable straps ensure a comfortable fit no matter the length of the hike.", Price = 89.99m, ImageUrl = "13.webp" },
        new Product { Name = "Stellar Duffle Bag", Description = "The Stellar Duffle Bag from Gravitator is perfect for weekend getaways or short trips. Made from waterproof nylon and available in sleek black, it features multiple internal pockets and a separate shoe compartment to keep your belongings organized. With its adjustable shoulder strap and reinforced handles, this bag is as functional as it is stylish.", Price = 59.99m, ImageUrl = "14.webp" },
        new Product { Name = "Summit Pro Insulated Jacket", Description = "The Summit Pro Insulated Jacket by Raptor Elite is designed to keep you warm and dry in extreme conditions. With its waterproof and breathable construction, heat-sealed seams, and insulation made from recycled materials, this jacket is both eco-friendly and high-performance. Available in vibrant red, it also features a removable hood and plenty of storage pockets.", Price = 249.99m, ImageUrl = "15.webp" }
    };


    context.AddRange(products);

    context.SaveChanges();
  }
}
