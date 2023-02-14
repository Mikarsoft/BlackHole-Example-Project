using BlackHole.Entities;
using TestingBlackHole.Entities.GuidEntities;
using TestingBlackHole.Entities.IntegerEntities;
using TestingBlackHole.Entities.StringEntities;
using TestingBlackHole.Interfaces;

namespace TestingBlackHole.Services
{
    public class TestDataGenerator : BlackHoleScoped , ITestDataGenerator
    {
        

        public List<CustomerG> GenerateCustomersG(int number, List<Guid> userTypes)
        {
            int index = 0;
            int rolesCount = userTypes.Count() - 1;
            List<CustomerG> result = new List<CustomerG>();

            for (int i = 0; i < number; i++)
            {
                if (index > rolesCount)
                {
                    index = 0;
                }

                CustomerG customers = new CustomerG
                {
                    FirstName = "Thanos",
                    LastName = "Tziaveleas",
                    Email = "somemail@hotmail.com",
                    UserTypeId = userTypes[index],
                    ApiId = Guid.NewGuid(),
                };

                result.Add(customers);

                index++;
            }
            return result;
        }

        public List<CustomerS> GenerateCustomersS(int number, List<string> userTypes)
        {
            int index = 0;
            int rolesCount = userTypes.Count() - 1;
            List<CustomerS> result = new List<CustomerS>();

            for (int i = 0; i < number; i++)
            {
                if (index > rolesCount)
                {
                    index = 0;
                }

                CustomerS customers = new CustomerS
                {
                    FirstName = "Thanos",
                    LastName = "Tziaveleas",
                    Email = "somemail@hotmail.com",
                    UserTypeId = userTypes[index],
                    ApiId = Guid.NewGuid(),
                };

                result.Add(customers);

                index++;
            }
            return result;
        }

        public List<CustomerI> GenerateCustomersI(int number, List<int> userTypes)
        {
            int index = 0;
            int rolesCount = userTypes.Count() - 1;
            List<CustomerI> result = new List<CustomerI>();

            for (int i = 0; i < number; i++)
            {
                if (index > rolesCount)
                {
                    index = 0;
                }

                CustomerI customers = new CustomerI
                {
                    FirstName = "Thanos",
                    LastName = "Tziaveleas",
                    Email = "somemail@hotmail.com",
                    UserTypeId = userTypes[index],
                    ApiId = new Guid(),
                };

                result.Add(customers);

                index++;
            }
            return result;
        }

        public List<UserTypeS> GenerateUserTypesS(int number, List<string> authCookies)
        {
            List<UserTypeS> result = new List<UserTypeS>();
            int index = 0;
            int rolesCount = authCookies.Count() - 1;

            for (int i = 0; i < number; i++)
            {
                if (index > rolesCount)
                {
                    index = 0;
                }

                result.Add(new UserTypeS
                {
                    UserTypeName = $"User_{i}",
                    AuthorizationCookieId = authCookies[index],
                    Permissions = $"Permission{authCookies[index]}",
                });

                index++;
            }

            return result;
        }

        public List<UserTypeG> GenerateUserTypesG(int number, List<Guid> authCookies)
        {
            List<UserTypeG> result = new List<UserTypeG>();
            int index = 0;
            int rolesCount = authCookies.Count() - 1;

            for (int i = 0; i < number; i++)
            {
                if (index > rolesCount)
                {
                    index = 0;
                }

                result.Add(new UserTypeG
                {
                    UserTypeName = $"User_{i}",
                    AuthorizationCookieId = authCookies[index],
                    Permissions = $"Permission{authCookies[index]}",
                });

                index++;
            }

            return result;
        }

        public List<UserTypeI> GenerateUserTypesI(int number, List<int> authCookies)
        {
            List<UserTypeI> result = new List<UserTypeI>();
            int index = 0;
            int rolesCount = authCookies.Count() - 1;

            for (int i = 0; i < number; i++)
            {
                if (index > rolesCount)
                {
                    index = 0;
                }

                result.Add(new UserTypeI
                {
                    UserTypeName = $"User_{i}",
                    AuthorizationCookieId = authCookies[index],
                    Permissions = $"Permission{authCookies[index]}",
                });

                index++;
            }

            return result;
        }

        public List<OrderI> GenerateOrdersI(int number, List<int> customers)
        {
            List<OrderI> result = new List<OrderI>();

            int index = 0;
            int customersCount = customers.Count() - 1;

            for (int i = 0; i < number; i++)
            {
                if (index > customersCount)
                {
                    index = 0;
                }

                result.Add(new OrderI
                {
                    CustomerId = customers[index],
                    Delivered = false,
                    DeliveryDate = DateTime.Now.AddDays(index),
                    IssueDate = DateTime.Now
                });

                index++;
            }

            return result;
        }

        public List<OrderG> GenerateOrdersG(int number, List<Guid> customers)
        {
            List<OrderG> result = new List<OrderG>();

            int index = 0;
            int customersCount = customers.Count() - 1;

            for (int i = 0; i < number; i++)
            {
                if (index > customersCount)
                {
                    index = 0;
                }

                result.Add(new OrderG
                {
                    CustomerId = customers[index],
                    Delivered = false,
                    DeliveryDate = DateTime.Now.AddDays(index),
                    IssueDate = DateTime.Now
                });

                index++;
            }

            return result;
        }

        public List<OrderS> GenerateOrdersS(int number, List<string> customers)
        {
            List<OrderS> result = new List<OrderS>();

            int index = 0;
            int customersCount = customers.Count() - 1;

            for (int i = 0; i < number; i++)
            {
                if (index > customersCount)
                {
                    index = 0;
                }

                result.Add(new OrderS
                {
                    CustomerId = customers[index],
                    Delivered = false,
                    DeliveryDate = DateTime.Now.AddDays(index),
                    IssueDate = DateTime.Now
                });

                index++;
            }

            return result;
        }

        public string GetCompanies()
        {
            string[] companies = new string[] { "Bethesda", "CDproject", "Ubisoft" };

            return companies[new Random().Next(0, 2)];
        }

        public string[] GetGames(string company)
        {
            string[] result;
            switch (company)
            {
                case "Bethesda":
                    result = new string[] { "Fallout 4", "Skyrim", "Oblivion", "Fallout 3", "Morrowind", "Fallout 2077" };
                    break;
                case "CDproject":
                    result = new string[] { "The Witcher", "Withcer 2", "Withcer 3", "CyberPunk" };
                    break;
                default:
                    result = new string[] { "FarCry 2", "FarCry 3", "Call of Duty III", "Call of Duty 2", "FarCry 5" };
                    break;
            }

            return result;
        }

        public List<BonusPointsI> GetBonusPointsI(int number)
        {
            List<BonusPointsI> result = new List<BonusPointsI>();
            decimal standard = 2.25m;
            for (int i = 0; i < number; i++)
            {
                result.Add(new BonusPointsI
                {
                    Points = standard * i,
                    OfferName = "Sales Month"
                });
            }

            return result;
        }

        public List<BonusPointsG> GetBonusPointsG(int number)
        {
            List<BonusPointsG> result = new List<BonusPointsG>();
            decimal standard = 2.25m;
            for (int i = 0; i < number; i++)
            {
                result.Add(new BonusPointsG
                {
                    Points = standard * i,
                    OfferName = "Sales Month"
                });
            }

            return result;
        }

        public List<BonusPointsS> GetBonusPointsS(int number)
        {
            List<BonusPointsS> result = new List<BonusPointsS>();
            decimal standard = 2.25m;
            for (int i = 0; i < number; i++)
            {
                result.Add(new BonusPointsS
                {
                    Points = standard * i,
                    OfferName = "Sales Month"
                });
            }

            return result;
        }

        public List<OrderLineI> GenerateOrderLinesI(string company, List<int> bonuses)
        {
            List<OrderLineI> result = new List<OrderLineI>();
            var randomInt = new Random();
            int number = randomInt.Next(1, 5);
            double min = 25.50;
            double max = 69.90;
            string[] games = GetGames(company);
            int gamesLength = games.Length;
            int index = 0;

            for (int i = 0; i < number; i++)
            {
                Random random = new Random();

                if (index == gamesLength)
                {
                    index = 0;
                }

                result.Add(new OrderLineI
                {
                    BonusPointsId = randomInt.Next(0, bonuses.Count - 1),
                    ProductCategory = "games",
                    Manufacturer = company,
                    ProductDescription = "PC game",
                    ProductName = games[index],
                    ProductPrice = random.NextDouble() * (max - min) + min,
                    Vat = 13
                });

                index++;
            }

            return result;
        }

        public List<OrderLineG> GenerateOrderLinesG(string company, List<Guid> bonuses)
        {
            List<OrderLineG> result = new List<OrderLineG>();
            var randomInt = new Random();
            int number = randomInt.Next(1, 5);
            double min = 25.50;
            double max = 69.90;
            string[] games = GetGames(company);
            int gamesLength = games.Length;
            int index = 0;

            for (int i = 0; i < number; i++)
            {
                Random random = new Random();

                if (index == gamesLength)
                {
                    index = 0;
                }

                result.Add(new OrderLineG
                {
                    BonusPointsId = bonuses[randomInt.Next(0, bonuses.Count - 1)],
                    ProductCategory = "games",
                    Manufacturer = company,
                    ProductDescription = "PC game",
                    ProductName = games[index],
                    ProductPrice = random.NextDouble() * (max - min) + min,
                    Vat = 13
                });

                index++;
            }

            return result;
        }

        public List<OrderLineS> GenerateOrderLinesS(string company, List<string> bonuses)
        {
            List<OrderLineS> result = new List<OrderLineS>();
            var randomInt = new Random();
            int number = randomInt.Next(1, 5);
            double min = 25.50;
            double max = 69.90;
            string[] games = GetGames(company);
            int gamesLength = games.Length;
            int index = 0;

            for (int i = 0; i < number; i++)
            {
                Random random = new Random();

                if (index == gamesLength)
                {
                    index = 0;
                }

                result.Add(new OrderLineS
                {
                    BonusPointsId = bonuses[randomInt.Next(0, bonuses.Count - 1)],
                    ProductCategory = "games",
                    Manufacturer = company,
                    ProductDescription = "PC game",
                    ProductName = games[index],
                    ProductPrice = random.NextDouble() * (max - min) + min,
                    Vat = 13
                });

                index++;
            }

            return result;
        }

        public List<AuthCookieI> GenerateCookieI(int number)
        {
            List<AuthCookieI> result = new List<AuthCookieI>();

            for (int i = 0; i < number; i++)
            {
                result.Add(new AuthCookieI
                {
                    RoleIndex = i,
                    TokenHash = $"AB34DEFBA349FAECBDFER881DER{i}",
                    RoleName = "User"
                });
            }

            return result;
        }

        public List<AuthCookieG> GenerateCookieG(int number)
        {
            List<AuthCookieG> result = new List<AuthCookieG>();

            for (int i = 0; i < number; i++)
            {
                result.Add(new AuthCookieG
                {
                    RoleIndex = i,
                    TokenHash = $"AB34DEFBA349FAECBDFER881DER{i}",
                    RoleName = "User"
                });
            }

            return result;
        }

        public List<AuthCookieS> GenerateCookieS(int number)
        {
            List<AuthCookieS> result = new List<AuthCookieS>();

            for (int i = 0; i < number; i++)
            {
                result.Add(new AuthCookieS
                {
                    RoleIndex = i,
                    TokenHash = $"AB34DEFBA349FAECBDFER881DER{i}",
                    RoleName = "User"
                });
            }

            return result;
        }
    }
}
