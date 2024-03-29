﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab1;
using Lab1.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Lab1.Services.Interfaces;
using Lab1.DTO;
using Lab1.DTO.Interface;

namespace Lab1.Controllers
{
    [ApiController]
    [Route("/api/v1.0/creators")]
    public class CreatorController(ICreatorService CreatorService) : Controller
    {
        [HttpGet]
        public JsonResult GetCreators()
        {
            try
            {
                var Creators = CreatorService.GetAllEnt();
                return Json(Creators);
            }
            catch 
            {
                Response.StatusCode = 400;

                return Json(BadRequest());

            }

        }

        [HttpGet]
        [Route("{CreatorId:int}")]
        public async Task<JsonResult> GetCreatorById( int CreatorId) 
        {
            try
            {
                var Creator = await CreatorService.GetEntById(CreatorId);
                return Json(Creator);
            }
            catch 
            {
                Response.StatusCode = 400;
                return Json(BadRequest());
            }
            

        }

        [HttpPost]
        public async Task<JsonResult> CreateCreator(CreatorRequestTo CreatorTo)
        {
            try
            {
                Response.StatusCode = 201;
                var Creator = await CreatorService.CreateEnt(CreatorTo);
                return Json(Creator);
            }
            catch
            {
                Response.StatusCode = 403;
                return Json(BadRequest());
            }
           
        }

        [HttpPut]
        public async Task<JsonResult> UpdateCreator(CreatorRequestTo CreatorTo)
        {
            IResponseTo newCreator;
            try
            {
                newCreator = await CreatorService.UpdateEnt(CreatorTo);
                Response.StatusCode = 200;
                return Json(newCreator);

            }
            catch
            {
                Response.StatusCode = 400;
                return Json(BadRequest());
            }
        }

        [HttpDelete("{CreatorId}")]
        public  async Task<IActionResult> DeleteCreator(int CreatorId)
        {
            try
            {
                Response.StatusCode = 204;
                await CreatorService.DeleteEnt(CreatorId);
            }
            catch
            {
                Response.StatusCode = 401;
                return BadRequest();
            }

            return NoContent();
           
            
        }

    }
}
