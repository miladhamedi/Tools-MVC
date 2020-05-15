using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManualAuthenticationSample.Entities;
using ManualAuthenticationSample.Common;

namespace ManualAuthenticationSample.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PermissionController : Controller
    {
        private readonly FadContext _context;

        public PermissionController(FadContext context)
        {
            _context = context;
        }

        // GET: Admin/Permission
        public async Task<IActionResult> Index()
        {
            return View(await _context.Permissions.ToListAsync());
        }

        // GET: Admin/Permission/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            int orginalId = Convert.ToInt32(EncyrptionUtility.Decrypt(id));

            var permissions = await _context.Permissions
                .FirstOrDefaultAsync(m => m.Id == orginalId);
            if (permissions == null)
            {
                return NotFound();
            }

            return View(permissions);
        }

        // GET: Admin/Permission/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Permission/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AreaName,AreaCaption,ControllerName,ControllerCaption,ActionName,ActionCaption,ActionType")] Permissions permissions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(permissions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(permissions);
        }

        // GET: Admin/Permission/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //int orginalId = Convert.ToInt32(EncyrptionUtility.Decrypt(id));


            var permissions = await _context.Permissions.FindAsync(id);
            if (permissions == null)
            {
                return NotFound();
            }
            return View(permissions);
        }

        // POST: Admin/Permission/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AreaName,AreaCaption,ControllerName,ControllerCaption,ActionName,ActionCaption,ActionType")] Permissions permissions)
        {
            //if (id != permissions.Id)
            //{
            //    return NotFound();
            //}

            var fadActionResult = new FadActionResult { IsSuccess = true };
            if (ModelState.IsValid)
            {
                try
                {
                    //int orginalId = Convert.ToInt32(EncyrptionUtility.Decrypt(id));
                    permissions.Id = id;

                    _context.Update(permissions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    fadActionResult.IsSuccess = false ;

                    return Json(fadActionResult);
                    if (!PermissionsExists(permissions.Id))
                    {
                        return Json(fadActionResult);
                    }
                    else
                    {
                        throw;
                    }
                }
                fadActionResult.Message = "با موفقیت بروزرسانی شد";
                return Json(fadActionResult);
            }

            fadActionResult.IsSuccess = false;
            fadActionResult.Message = "اطلاعات ارسالی صحیح نمی باشد";
            return Json(fadActionResult);

        }

        // GET: Admin/Permission/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            int orginalId = Convert.ToInt32(EncyrptionUtility.Decrypt(id));


            var permissions = await _context.Permissions
                .FirstOrDefaultAsync(m => m.Id == orginalId);
            if (permissions == null)
            {
                return NotFound();
            }

            return View(permissions);
        }

        // POST: Admin/Permission/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var permissions = await _context.Permissions.FindAsync(id);
            _context.Permissions.Remove(permissions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PermissionsExists(int id)
        {
            return _context.Permissions.Any(e => e.Id == id);
        }
    }
}
