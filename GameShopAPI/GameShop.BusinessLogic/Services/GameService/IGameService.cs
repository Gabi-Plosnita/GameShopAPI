﻿using GameShop.EntityLayer.Dtos;

namespace GameShop.BusinessLogic.Services
{
    public interface IGameService
    {
        List<GameResponseDto> GetAll();

        GameResponseDto GetById(int id);

        void Create(GameRequestDto gameDto);

        void Update(int id, GameRequestDto updatedGameDto);

        void Delete(int id);
    }
}
