using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data;

public class CatalogContextSeed
{
    public static void SeedData(IMongoCollection<Product> productCollection)
    {
        bool existProduct = productCollection.Find(p => true).Any();
        if (!existProduct)
        {
            productCollection.InsertManyAsync(GetMyProducts());
        }
    }

    private static IEnumerable<Product> GetMyProducts()
    {
        return new List<Product>()
        {
            new Product()
            {
                Id = "iphone15",
                Name = "Iphone XV",
                Description =
                    "O iPhone 15 traz uma combinação de design elegante, desempenho poderoso e recursos inovadores, mantendo o padrão de excelência da Apple. Com bordas arredondadas, acabamento em alumínio aeroespacial e vidro traseiro colorido com infusão, o modelo é visualmente sofisticado e confortável de segurar.",
                Image = "",
                Price = 5000.00M,
                Category = "Phones"
            },
            new Product()
            {
                Id = "samsgalaxy23",
                Name = "Samsung Galaxy S23",
                Description =
                    "O Galaxy S23 combina potência e sofisticação em um design compacto. Equipado com o processador Snapdragon 8 Gen 2, câmera de 50 MP com Nightography, e uma tela AMOLED dinâmica de 6,1'', oferece uma experiência premium em todos os aspectos.",
                Image = "",
                Price = 4499.00M,
                Category = "Phones"
            },

            new Product()
            {
                Id = "pixel8google",
                Name = "Google Pixel 8",
                Description =
                    "O Pixel 8 traz a inteligência do Google para o seu bolso. Com o chip Tensor G3, oferece recursos avançados de IA, fotografia computacional de ponta com câmera de 50 MP e atualizações garantidas por 7 anos, tudo em um design elegante e sustentável.",
                Image = "",
                Price = 3999.00M,
                Category = "Phones"
            },

            new Product()
            {
                Id = "xiaomi13pro",
                Name = "Xiaomi 13 Pro",
                Description =
                    "O Xiaomi 13 Pro entrega performance de topo com o Snapdragon 8 Gen 2 e câmeras otimizadas pela Leica. Sua tela AMOLED de 6,73'' com 120Hz e a bateria de 4.820mAh com carregamento ultrarrápido tornam este um dos flagships mais completos do mercado.",
                Image = "",
                Price = 4299.00M,
                Category = "Phones"
            },

            new Product()
            {
                Id = "nothingphone2",
                Name = "Nothing Phone (2)",
                Description =
                    "O Nothing Phone (2) se destaca pelo design transparente e interface Glyph exclusiva. Equipado com Snapdragon 8+ Gen 1, tela OLED de 6,7'' e Android puro com melhorias visuais únicas, é uma opção inovadora para quem busca algo diferente.",
                Image = "",
                Price = 3799.00M,
                Category = "Phones"
            }

        };
    }
}