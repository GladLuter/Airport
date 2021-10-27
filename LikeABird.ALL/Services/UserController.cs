﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using LikeABird.ALL.Mapper;
using LikeABird.ALL.Repositories.System;
using LikeABird.DAL.Interfaces;
using LikeABird.DAL.Models.System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LikeABird.ALL.Services {

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase {
        private readonly AO_User<User> _user;

        public UserController(IDataContext Db, IMapper mapper) {
            //var mapperConfig = new MapperConfiguration(mc => {
            //    mc.AddProfile(new DAL_to_ALL());
            //});

            //var mapper = mapperConfig.CreateMapper();
            var DOuser = new User(Db);
            _user = new(mapper);
            mapper.Map<User, AO_User<User>>(DOuser, _user);
        }

        ///// <returns>Added game model and result of adding</returns>
        ///// <param name="game"></param>
        ///// <response code="201">Returns succeeded created model</response>
        ///// <response code="400">Received model is not valid</response>
        //[ProducesResponseType(typeof(BLGame), 201)]
        //[ProducesResponseType(400)]
        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] BLGame game) {
        //    if (game == null || game.PublisherId <= 0 || game.Name.Length == 0)
        //        return BadRequest("Wrong game model");

        //    await _gameService.AddAsync(game);
        //    return Created("api/games/", game);
        //}

        ///// <returns>Updated game model and result of adding</returns>
        ///// <param name="id"></param>
        ///// <param name="game"></param>
        ///// <response code="200">Returns succeeded updated model</response>
        ///// <response code="404">Received model is not found in database</response>
        ///// <response code="400">Received model is not valid</response>
        //[ProducesResponseType(typeof(BLGame), 200)]
        //[ProducesResponseType(404)]
        //[ProducesResponseType(400)]
        //[HttpPut]
        //[Route("{id}")]
        //public async Task<IActionResult> Put(int id, [FromBody] BLGame game) {
        //    if (id <= 0)
        //        return NotFound();
        //    if (game == null || game.PublisherId <= 0 || game.Name.Length == 0)
        //        return NoContent();
        //    if (game.Id == 0 && id != 0)
        //        game.Id = id;

        //    await _gameService.UpdateAsync(game);
        //    return Ok();
        //}

        /// <returns>Certain game model by id</returns>
        /// <param name="id"></param>
        /// <response code="200">Returns succeeded created model</response>
        /// <response code="404">Model with such id was not found</response>
        [ProducesResponseType(typeof(AO_User<User>), 200)]
        [ProducesResponseType(404)]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id) {
            AO_User<User> CurUsr = await _user.SelectByIdAsync(id);
            if (CurUsr?.Name == null)
                return NotFound();
            else 
                return Ok(CurUsr);//AutoMapper.Mapper.Map<BLGame, GameViewModel>(game));
        }

        ///// <returns>All game models</returns>
        ///// <response code="200">Returns collection of all game models </response>
        ///// <response code="404">Game models was not found in the database</response>
        //[ProducesResponseType(typeof(IEnumerable<BLGame>), 200)]
        //[ProducesResponseType(404)]
        //[HttpGet]
        //public async Task<IActionResult> GetAll() {
        //    IEnumerable<BLGame> games = await _gameService.GetAllAsync();
        //    if (games?.Count() == 0)
        //        return NotFound();
        //    else
        //        return Ok(AutoMapper.Mapper.Map<IEnumerable<BLGame>, IEnumerable<GameViewModel>>(games));
        //}

        ///// <returns>Result of deleting game model by id</returns>
        ///// <response code="200">Game model was removed from database</response>
        ///// <response code="404">Game with such id was not found</response>
        //[ProducesResponseType(200)]
        //[ProducesResponseType(404)]
        //[HttpDelete]
        //[Route("{id}")]
        //public async Task<IActionResult> Delete(int id) {
        //    if (id <= 0 || await _gameService.GetAsync(id) == null)
        //        return NotFound();

        //    await _gameService.DeleteAsync(id);
        //    return Ok();
        //}

        ///// <returns>Genres of certain game</returns>
        ///// <response code="200">Genres of certain game exist</response>
        ///// <response code="404">Game has no genres</response>
        //[ProducesResponseType(typeof(IEnumerable<BLGenre>), 200)]
        //[ProducesResponseType(404)]
        //[HttpGet]
        //[Route("{id}/genres")]
        //public async Task<IActionResult> GetGenres(int id) {
        //    IEnumerable<BLGenre> genres = await _gameService.GetGenresByGameAsync(id);
        //    if (genres?.Count() == 0)
        //        return NotFound();
        //    else
        //        return Ok(AutoMapper.Mapper.Map<IEnumerable<BLGenre>, IEnumerable<GenreViewModel>>(genres));
        //}

        ///// <returns>Game models witch has chose platform</returns>
        ///// <response code="200">Games with such platform id exist</response>
        ///// <response code="404">Games with such platform id was not found</response>
        //[ProducesResponseType(typeof(IEnumerable<BLGame>), 200)]
        //[ProducesResponseType(404)]
        //[HttpGet]
        //[Route("platform/{platformId}")]
        //public async Task<IActionResult> GetByPlatform(int platformId) {
        //    IEnumerable<BLGame> games = await _gameService.GetGamesByPlatformAsync(platformId);
        //    if (games?.Count() == 0)
        //        return NotFound();
        //    else
        //        return Ok(AutoMapper.Mapper.Map<IEnumerable<BLGame>, IEnumerable<GameViewModel>>(games));
        //}

        ///// <returns>Game models witch has chose platform</returns>
        ///// <response code="200">Games with such platform id exist</response>
        ///// <response code="404">Games with such id was not found</response>
        //[ProducesResponseType(typeof(HttpResponse), 200)]
        //[ProducesResponseType(404)]
        //[HttpGet]
        //[Route("{id}/download")]
        //public async Task<IActionResult> DownloadGame(int id) {
        //    HttpResponse response = HttpContext.Response;
        //    string gameName = await _gameService.DownloadGame(id);
        //    if (gameName == null || gameName.Length < 3)
        //        return NotFound();
        //    response.Clear();
        //    response.ContentType = "application/octet-stream";
        //    response.Headers.Add("content-disposition", "attachment;filename=" + $"{gameName}.bin");
        //    await response.SendFileAsync("Files/Game.bin");
        //    return Ok(response);
        //}


        ///// <returns>Navigation model with chosen games</returns>
        ///// <response code="200">Returns navigation model according passed params with collection of chosen game models</response>
        ///// <response code="400">Navigation parameters is invalid</response>
        //[ProducesResponseType(typeof(GamesNavViewModel), 200)]
        //[ProducesResponseType(400)]
        //[HttpPost]
        //[Route("navigation")]
        //public IActionResult NavigateByGames([FromBody] GamesNavBind navigationBind) {
        //    GamesNavigationModel navigationModel = ValidationNavParams.ValidateNavigationBind(navigationBind, ModelState);

        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    navigationModel = _gameService.NavigateByGames(navigationModel);

        //    GamesNavViewModel gamesNavViewModel = new GamesNavViewModel {
        //        Pages = navigationModel.PagesInfo,
        //        Filters = navigationModel.Filters,
        //        Games = AutoMapper.Mapper.Map<IEnumerable<BLGame>, IEnumerable<GameViewModel>>(navigationModel
        //            .SelectedGames)
        //    };

        //    return Ok(gamesNavViewModel);
        //}
    }
}