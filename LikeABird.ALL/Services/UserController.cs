using System;
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
using LikeABird.DAL.EF;
using LikeABird.DAL.Interfaces;
using LikeABird.DAL.Models.System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LikeABird.ALL.Services;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IDataContext ObjDB;
    private readonly IMapper ObjMapper;

    public UserController(IDataContext Db, IMapper mapper)
    {
        //var mapperConfig = new MapperConfiguration(mc => {
        //    mc.AddProfile(new DAL_to_ALL());
        //});

        //var mapper = mapperConfig.CreateMapper();
        DataContext.DBConnection = Db;
        ObjDB = Db;
        ObjMapper = mapper;
    }

    /// <returns>Certain user model by id</returns>
    /// <param name="id"></param>
    /// <response code="200">Returns succeeded created model</response>
    /// <response code="404">Model with such id was not found</response>
    [ProducesResponseType(typeof(AO_User<User>), 200)]
    [ProducesResponseType(404)]
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var DOuser = new User();
        AO_User<User> CurUsr = new(ObjMapper);
        ObjMapper.Map<User, AO_User<User>>(DOuser, CurUsr);

        CurUsr = await CurUsr.SelectByIdAsync(id);
        if (CurUsr?.Name == null)
            return NotFound();
        else
            return Ok(CurUsr);
    }
    [ProducesResponseType(typeof(AO_Role<Role>), 200)]
    [ProducesResponseType(404)]
    [HttpGet]
    [Route("{id}/Role")]
    public async Task<IActionResult> GetRoleByUserId(int id)
    {

        var DOuser = new User();
        AO_User<User> CurUsr = new(ObjMapper);
        ObjMapper.Map<User, AO_User<User>>(DOuser, CurUsr);

        CurUsr = await CurUsr.SelectByIdAsync(id);
        if (CurUsr?.Name == null)
            return NotFound();

        var DOrole = CurUsr.DataObject.CurrentObject.UserRole;

        AO_Role<Role> CurRole = new(ObjMapper);
        ObjMapper.Map<Role, AO_Role<Role>>(DOrole, CurRole);

        if (CurRole?.Name == null)
            return NotFound();
        else
            return Ok(CurRole);

    }


}
