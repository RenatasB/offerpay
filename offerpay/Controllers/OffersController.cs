﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using offerpay.Models;

namespace offerpay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly offerpaydbContext _context;
        
        public OffersController(offerpaydbContext context)
        {
            _context = context;
        }

        // GET: api/Offers
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Offer>>> GetOffer()
        {
            return await _context.Offer.ToListAsync();
        }

        // GET: api/Offers/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Offer>> GetOffer(int id)
        {
            var offer = await _context.Offer.FindAsync(id);

            if (offer == null)
            {
                return NotFound();
            }

            return offer;
        }

        // PUT: api/Offers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutOffer(int id, Offer offer)
        {
            if (id != offer.Id)
            {
                return BadRequest();
            }

            _context.Entry(offer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfferExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Offers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Offer>> PostOffer(Offer offer)
        {
            _context.Offer.Add(offer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOffer", new { id = offer.Id }, offer);
        }

        // DELETE: api/Offers/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Offer>> DeleteOffer(int id)
        {
            var offer = await _context.Offer.FindAsync(id);
            if (offer == null)
            {
                return NotFound();
            }

            _context.Offer.Remove(offer);
            await _context.SaveChangesAsync();

            return offer;
        }

        private bool OfferExists(int id)
        {
            return _context.Offer.Any(e => e.Id == id);
        }
    }
}
