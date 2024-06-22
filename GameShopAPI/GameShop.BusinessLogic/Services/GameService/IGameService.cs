﻿using GameShop.EntityLayer.Dtos;

namespace GameShop.BusinessLogic.Services
{
    public interface IGameService
    {
        List<GameResponseDto> GetAll();

        GameResponseDto GetById(int id);

        void Add(GameRequestDto game);

        void Update(int id, GameRequestDto updatedGame);

        void Delete(int id);
    }
}
