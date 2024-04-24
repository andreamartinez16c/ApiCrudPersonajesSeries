using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCrudPersonajesSeries.Models
{
    [Table("PERSONAJESSERIES")]
    public class Personaje
    {
        [Key]
        [Column("IDPERSONAJE")]
        public int Id { get; set; }
        [Column("NOMBRE")]
        public string Nombre { get; set; }
        [Column("IMAGEN")]
        public string Imagen { get; set; }
        [Column("SERIE")]
        public string Serie { get; set; }
    }
}
