using PokemonCadastro.Context;
using PokemonCadastro.Model;

namespace PokemonCadastro
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.PokemonOwners.Any())
            {
                var pokemonOwners = new List<PokemonOwnerJoin>()
                {
                    new PokemonOwnerJoin()
                    {
                        Pokemon = new PokemonModel()
                        {
                            PokemonName = "Pikachu",
                            BirthDate = new DateTime(1903,1,1),
                            PokemonCategories = new List<PokemonCategoryJoin>()
                            {
                                new PokemonCategoryJoin { Category = new Category() { Name = "Electric"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { ReviewTitle ="Pikachu",ReviewText = "Pickahu is the best pokemon, because it is electric", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                                new Review { ReviewTitle="Pikachu", ReviewText = "Pickachu is the best a killing rocks", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Review { ReviewTitle="Pikachu",ReviewText = "Pickchu, pickachu, pikachu", Rating = 1,
                                Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        Owners = new Owner()
                        {
                            FirstName = "Jack",
                            LastName = "London",
                            Gym = "Brocks Gym",
                            Country = new Country()
                            {
                                CountryName = "Kanto"
                            }
                        }
                    },
                    new PokemonOwnerJoin()
                    {
                        Pokemon = new PokemonModel()
                        {
                            PokemonName = "Squirtle",
                            BirthDate = new DateTime(1903,1,1),
                            PokemonCategories = new List<PokemonCategoryJoin>()
                            {
                                new PokemonCategoryJoin { Category = new Category() { Name = "Water"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { ReviewTitle= "Squirtle", ReviewText = "squirtle is the best pokemon, because it is electric", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                                new Review { ReviewTitle= "Squirtle",ReviewText = "Squirtle is the best a killing rocks", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Review { ReviewTitle= "Squirtle", ReviewText = "squirtle, squirtle, squirtle", Rating = 1,
                                Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        Owners = new Owner()
                        {
                            FirstName = "Harry",
                            LastName = "Potter",
                            Gym = "Mistys Gym",
                            Country = new Country()
                            {
                                CountryName = "Saffron City"
                            }
                        }
                    },
                                    new PokemonOwnerJoin()
                    {
                        Pokemon = new PokemonModel()
                        {
                            PokemonName = "Venasuar",
                            BirthDate = new DateTime(1903,1,1),
                            PokemonCategories = new List<PokemonCategoryJoin>()
                            {
                                new PokemonCategoryJoin { Category = new Category() { Name = "Leaf"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { ReviewTitle="Veasaur",ReviewText = "Venasuar is the best pokemon, because it is electric", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                                new Review { ReviewTitle="Veasaur",ReviewText = "Venasuar is the best a killing rocks", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Review { ReviewTitle="Veasaur",ReviewText = "Venasuar, Venasuar, Venasuar", Rating = 1,
                                Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        Owners = new Owner()
                        {
                            FirstName = "Ash",
                            LastName = "Ketchum",
                            Gym = "Ashs Gym",
                            Country = new Country()
                            {
                                CountryName = "Millet Town"
                            }
                        }
                    }
                };
                dataContext.PokemonOwners.AddRange(pokemonOwners);
                dataContext.SaveChanges();
            }
        }
    }
}
