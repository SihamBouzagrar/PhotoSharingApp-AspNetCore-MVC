using Microsoft.EntityFrameworkCore;
using PhotoSharingApplication.Models;

namespace PhotoSharingApplication.Data
{
    public static class PhotoSharingInitializer
    {
        public static void Initialize(PhotoSharingContext context)
        {
            context.Database.EnsureCreated();

            if (context.photos.Any())
            {
                return;
            }

            // Q7 — Liste de photos
            var photoListe = new List<Photo>
            {
                new Photo
                {
                    Titre = "Photo Test",
                    Description = "Description de la photo",
                    NomUtilisateur = "Ali",
                    ImageMimeType = "image/jpeg",
                    PhotoFile = GetFileBytes("wwwroot\\Images\\flower.jpg")
                }
            };

            // Q8 — Ajouter les photos au contexte
            photoListe.ForEach(p => context.photos.Add(p));
            context.SaveChanges();

            // Q9 — Liste de commentaires
            var commentaireListe = new List<Commentaire>
            {
                new Commentaire
                {
                    PhotoID = 1,
                    NomUtilisateur = "Ahmed",
                    Sujet = "Test Commentaire",
                    CorpsMessage = "Le commentaire de la photo doit être inséré ici"
                }
            };

            // Q10 — Ajouter les commentaires au contexte
            commentaireListe.ForEach(c => context.commentaires.Add(c));
            context.SaveChanges();
        }

        // Q12 — Méthode pour lire les images
        private static byte[] GetFileBytes(string path)
        {
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), path);
            return File.ReadAllBytes(fullPath);
        }
    }
}