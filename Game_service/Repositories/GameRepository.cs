using Game_service.Data;
using Game_service.Interfaces;
using Game_service.Models;
using Game_service.ProtoModels.Game;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Collections.Generic;
using Game_service.Services.Mapper;
using Game_service.Services.Paginator;

namespace Game_service.Repositories
{
    public class GameRepository : IGame
    {
        private readonly ServiceDbContext dbContext;
        private readonly Mapper mapper;

        public GameRepository(ServiceDbContext dbContext, Mapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        /// <summary>
        /// Game list without paginator.
        /// </summary>
        /// <returns></returns>
        public async Task<GameListResponse> GetGameListAsync()
        {

            var gamesModel = dbContext.Games.OrderByDescending( x => x.Id).ToList();

            GameListResponse gameListResponse = new GameListResponse();
            List<GameSimpleProto> simpleProtos = new List<GameSimpleProto>();

            foreach (var game in gamesModel)
            {
                simpleProtos.Add(new GameSimpleProto()
                {
                    Id = game.Id,
                    Url = game.Url,
                    Name = game.Name,
                    ShortDescription = game.ShortDescription,
                    SmallLogo = game.SmallLogo,
                    RealeseDate = game.RealeseDate.ToString(),
                });
            }

            gameListResponse.Games.Add(simpleProtos);

            return gameListResponse;
        }

        public async Task<GameListResponse> GetGameListPagedAsync(PaginatorGameProto paginator)
        {
            // = = = = = = = = DATA = = = = = = = = \\
            int gamesTotal = dbContext.Games.Count();
            int pagesTotal = (int)Math.Ceiling((double)gamesTotal / paginator.PageSize);
            var pagedGames = dbContext.Games.Skip((paginator.CurrentPage - 1) * paginator.PageSize).Take(paginator.PageSize).ToList();

            // = = = = = = = = MAKE PAGES COUNT = = = = = = = = \\
            List<int> intList = new List<int>();
            for (int i = paginator.CurrentPage - 3; i < paginator.CurrentPage + 4; i++)
            {
                if (i <= 0) { continue; }
                else if (i > pagesTotal) { break; }
                else { intList.Add(i); }
            }
            if (intList.Count == 0) { intList.Add(1); }

            // = = = = = = = = MAP TO PROTO = = = = = = = = \\
            GameListResponse gameListResponse = new GameListResponse();
            paginator.PageList.Add(intList);
            gameListResponse.Paginator = paginator;
            var pagedGamesProto = mapper.MapToProto(new List<GameSimpleProto>(), pagedGames);
            gameListResponse.Games.Add(pagedGamesProto);

            return gameListResponse;
        }

        public async Task<GameByIdResponse> GetGameByIdAsync(GameByIdRequest request)
        {
            var gameModel = await dbContext.Games.FirstOrDefaultAsync(x => x.Id == request.Id);

            GameByIdResponse gameByIdResponse = new GameByIdResponse();

            gameByIdResponse.Game = mapper.MapToProto(new GameProto(), gameModel);
       
            return gameByIdResponse;
        }

        public async Task<CreateGameResponse> CreateGameAsync(CreateGameRequest request)
        {
            
            GameModel model = new GameModel
            {
                Id = request.Game.Id,
                Url = request.Game.Url,
                Name = request.Game.Name,
                Description = request.Game.Description,
                ShortDescription = request.Game.ShortDescription,
                BigLogo = request.Game.BigLogo,
                SmallLogo = request.Game.SmallLogo,
                OwnerId = request.Game.OwnerId,
                RealeseDate = DateTime.ParseExact(request.Game.RealeseDate, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture)
            };

            dbContext.Games.Add(model);
            dbContext.SaveChanges();

            CreateGameResponse response = new CreateGameResponse();
            response.GameId = model.Id;

            return response;
        }

        public async Task<UpdateGameResponse> UpdateGameAsync(UpdateGameRequest request)
        {
            GameModel model = new GameModel
            {
                Id = request.Game.Id,
                Url = request.Game.Url,
                Name = request.Game.Name,
                Description = request.Game.Description,
                ShortDescription = request.Game.ShortDescription,
                BigLogo = request.Game.BigLogo,
                SmallLogo = request.Game.SmallLogo,
                OwnerId = request.Game.OwnerId,
                RealeseDate = DateTime.ParseExact(request.Game.RealeseDate, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture)
            };

            dbContext.Games.Update(model);
            dbContext.SaveChanges();

            UpdateGameResponse response = new UpdateGameResponse();
            GameProto gameProto = new GameProto
            {
            Id = model.Id,
            Url = model.Url,
            Name = model.Name,
            Description = model.Description,
            ShortDescription = model.ShortDescription,
            BigLogo = model.BigLogo,
            SmallLogo = model.SmallLogo,
            OwnerId = model.OwnerId,
            RealeseDate = model.RealeseDate.ToString()
            };

            response.Game = gameProto;

            return response;
        }

    
    }
}
