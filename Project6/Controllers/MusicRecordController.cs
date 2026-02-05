using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Project6.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project6.Models;
using Microsoft.EntityFrameworkCore;

namespace Project6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusicRecordController : ControllerBase
    {
        public ApplicationDbContext cont;

        public MusicRecordController(ApplicationDbContext context)
        {
            cont = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetMusicRecords()
        {
            var list = cont.MusicRecords.ToList();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMusicRecord(int id)
        {
            var item = cont.MusicRecords.Find(id);
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMusicRecord([FromBody] MusicRecord mr)
        {
            cont.MusicRecords.Add(mr);
            cont.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMusicRecord), new { id = mr.MusicRecordId }, mr);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMusicRecord(int id, [FromBody] MusicRecord mr)
        {
            var res = cont.MusicRecords.Find(id);
            
            res.Artist = mr.Artist;
            res.Album = mr.Album;
            res.Genre = mr.Genre;
            res.Price = mr.Price;
            res.StockQuantity = mr.StockQuantity;
            res.OrderId = mr.OrderId;
            cont.SaveChangesAsync();
            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusicRecord(int id)
        {
            var res = cont.MusicRecords.Find(id);
            cont.MusicRecords.Remove(res);
            cont.SaveChangesAsync();
            return Ok(res);
        }
    }
}