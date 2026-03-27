using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhotoSharingApplication.Data;
using PhotoSharingApplication.Models;

namespace PhotoSharingApplication.Controllers
{
    public class PhotoController : Controller
    {
        private readonly PhotoSharingContext _context;

        public PhotoController(PhotoSharingContext context)
        {
            _context = context;
        }

        // ─── INDEX 
        public async Task<IActionResult> Index()
        {
            var photos = await _context.photos.ToListAsync();
            return View(photos);
        }

        // ─── AFFICHER 
        public async Task<IActionResult> Afficher(int id)
        {
            Photo? photo = await _context.photos.FindAsync(id);

            if (photo == null)
                return NotFound();

            return View(photo);
        }

        // ─── CREER GET
        [HttpGet]
        public IActionResult Creer()
        {
            ViewData["Title"] = "Create new Photo";
            return View();
        }

        // ─── CREER POST 
        [HttpPost]
        public IActionResult Creer(Photo photo, IFormFile? PhotoUpload)
        {
            if (!ModelState.IsValid)
                return View(photo);

            if (PhotoUpload != null && PhotoUpload.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    PhotoUpload.CopyTo(memoryStream);
                    photo.PhotoFile = memoryStream.ToArray();
                    photo.ImageMimeType = PhotoUpload.ContentType;
                }
            }

            if (photo.CreerDate == default)
                photo.CreerDate = DateTime.Now;

            _context.photos.Add(photo);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // ─── DELETE GET 
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Photo? photo = await _context.photos.FindAsync(id);

            if (photo == null)
                return NotFound();

            return View(photo);
        }

        //  DELETE POST 
              [HttpPost]
        [ActionName("Delete")] 
        public IActionResult DeleteConfirmed(int id)
        {
            // CORRECTION — une seule variable photo
            var photo = _context.photos.FirstOrDefault(p => p.PhotoID == id);

            if (photo != null)
            {
                _context.photos.Remove(photo);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // GETIMAGE 
        public async Task<IActionResult> GetImage(int id)
        {
            Photo? photo = await _context.photos.FindAsync(id);

            if (photo != null && photo.PhotoFile != null)
                return File(photo.PhotoFile, photo.ImageMimeType!);

            return NotFound();
        }

    }  
}     