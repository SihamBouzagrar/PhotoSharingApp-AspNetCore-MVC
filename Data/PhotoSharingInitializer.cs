using Microsoft.EntityFrameworkCore;
using PhotoSharingApplication.Models;

namespace PhotoSharingApplication.Data
{
    public static class PhotoSharingInitializer
    {
        public static void Initialize(PhotoSharingContext context)
        {
            // 1. Créer BD si elle n'existe pas
            context.Database.EnsureCreated();
            // 2. Vérifier si données existent
            if (context.photos.Any())
            {
                return;
            }

           // 3. Insérer données initiales
            var photoListe = new List<Photo>
            {
                new Photo
                {
                    Titre = "Photo Test",
                    Description = "Description de la photo",
                    NomUtilisateur = "Ali",
                    ImageMimeType = "image/jpeg",
                    PhotoFile = GetFileBytes("Images\\Flower.jpeg"),
                    CreerDate = DateTime.Now
                }
            };

         
            photoListe.ForEach(p => context.photos.Add(p));
            context.SaveChanges();

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

           
            commentaireListe.ForEach(c => context.commentaires.Add(c));
            context.SaveChanges();
        }
private static byte[] GetFileBytes(string path)
{
    // Chemin correct pour .NET Core
    string fullPath = Path.Combine(
        Directory.GetCurrentDirectory(), 
        
        "Images", 
        "Flower.jpeg"
    );
    return File.ReadAllBytes(fullPath);
}
    }
}