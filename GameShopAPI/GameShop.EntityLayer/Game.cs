﻿namespace GameShop.EntityLayer
{
    public class Game
    {
        public int GameId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int GameCompanyId { get; set; }

        public GameCompany GameCompany { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
