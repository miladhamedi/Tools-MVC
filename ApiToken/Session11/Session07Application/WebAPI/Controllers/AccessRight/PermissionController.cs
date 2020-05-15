using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using WebAPI.Entities;

namespace WebAPI.Controllers.AccessRight
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private FadContext _context;
        private IMemoryCache _cache;
        private string _cacheGetAllKey = "Permission-Get-All";
        private string _cacheGetWithPagination = "Permission-Get-Page-{0}";
        public PermissionController(FadContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Permissions> permissionList;
                if (!_cache.TryGetValue(_cacheGetAllKey, out permissionList))
                {
                    permissionList = await _context.Permissions.ToListAsync();
                    _cache.Set(_cacheGetAllKey, permissionList);
                }

                return Ok(permissionList);
            }
            catch (Exception ex)
            {
                //write ex info to log file
                return BadRequest();
            }
        }

        [HttpGet("GetWithPagination")]
        //[HttpGet("GetWithPagination/{page}")]
        public async Task<IActionResult> GetWithPagination(int page, int pageItem = 5)
        {
            try
            {
                int skip = (page - 1) * pageItem;
                _cacheGetWithPagination = string.Format(_cacheGetWithPagination, page);

                List<Permissions> permissionList;
                if (!_cache.TryGetValue(_cacheGetWithPagination, out permissionList))
                {
                    permissionList = await _context.Permissions.OrderBy(q => q.ActionName).
                        Skip(skip).Take(pageItem).ToListAsync();
                    _cache.Set(_cacheGetWithPagination, permissionList);
                }

                return Ok(permissionList);
            }
            catch (Exception ex)
            {
                //write ex info to log file
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _context.Permissions.FindAsync(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                //write ex info to log file
                return BadRequest();
            }
        }


    }
}