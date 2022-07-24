using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using deila.backend.Entities;
using deila.backend.Services;
using deila.backend.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Diagnostics;

namespace deila.backend.Controllers
{
    [Route("api/basiss")]
    [ApiController]
    public class BasisController : ControllerBase
    {
        private readonly IBasisRepo _basisRepo;
        private readonly IMapper _mapper;

        public BasisController(IBasisRepo basisRepo, IMapper mapper)
        {
            _basisRepo = basisRepo ?? throw new ArgumentNullException(nameof(basisRepo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/basis
        [HttpGet]
        public async Task<ActionResult<Basis>> GetBasiss()
        {
            var basisEntities = await _basisRepo.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<BasisDto>>(basisEntities));
        }

        // GET: api/basis/<id>
        [HttpGet("{id}")]
        public async Task<ActionResult<Basis>> GetBasis(int id)
        {
            var basis = await _basisRepo.GetByIdAsync(id);

            if (basis == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BasisDto>(basis));
        }

        //PUT: api/basis/<id>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBasis(int id, [FromBody] BasisUpdateDto basisIn)
        {
            var basis = await _basisRepo.GetByIdAsync(id);

            if (basis == null)
            {
                return BadRequest();
            }

            _mapper.Map(basisIn, basis);
            await _basisRepo.Update(basis);

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialUpdateBasis(int id, [FromBody] JsonPatchDocument<BasisUpdateDto> patchDoc)
        {
            var basis = await _basisRepo.GetByIdAsync(id);

            if (basis == null)
            {
                return BadRequest();
            }

            var basisToPatch = _mapper.Map<BasisUpdateDto>(basis);

            patchDoc.ApplyTo(basisToPatch, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _mapper.Map(basisToPatch, basis);
            await _basisRepo.Update(basis);

            return NoContent();
        }

        // POST: api/basis
        [HttpPost]
        public async Task<ActionResult<Basis>> CreateBasis([FromBody] BasisCreateDto basis)
        {
            var basisIn = _mapper.Map<Basis>(basis);
            _basisRepo.Add(basisIn);
            await _basisRepo.SaveAsync();
            return CreatedAtAction("GetBasis", new { id = basisIn.Id }, basisIn);
        }

        //// DELETE: api/basis/<id>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBasis(int id)
        {
            var basis = await _basisRepo.GetByIdAsync(id);
            if (basis == null)
            {
                return NotFound();
            }

            _basisRepo.Remove(basis);

            return NoContent();
        }
    }
}
