using System.ComponentModel.DataAnnotations;

namespace PhotoSharingApplication.Models;

public class Commentaire
{
    public int CommentaireID { get; set; }
    public String? NomUtilisateur { get; set; }

    public int PhotoID { get; set; }
    [Required(ErrorMessage = "veuillez saisir un titre")]
    [StringLength(250)]
    public String? Sujet { get; set; }
    [DataType(DataType.MultilineText)]
    public String? CorpsMessage { get; set; }

}