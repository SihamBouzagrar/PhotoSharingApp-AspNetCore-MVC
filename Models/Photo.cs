using System.ComponentModel.DataAnnotations;

namespace PhotoSharingApplication.Models;

public class Photo
{
    
    public int PhotoID { get; set; }
    [Required(ErrorMessage ="veuillez saisir un titre")]
    public String? Titre { get; set; }
    [Display (Name = "Photo")]
    public byte[]? PhotoFile { get; set; }

    public String? ImageMimeType { get; set; }
    [DataType(DataType.MultilineText)]
    public String? Description { get; set; }
    public String? NomUtilisateur { get; set; }
     public DateTime CreerDate { get; set; }

}