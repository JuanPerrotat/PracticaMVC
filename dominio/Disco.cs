using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Disco
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Completar el campo.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage ="Máximo de caracteres.")]
        public string? Titulo { get; set; }
        [Required (ErrorMessage ="Completar el campo.")]
        [DisplayName("Fecha de lanzamiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]

        public DateTime FechaLanzamiento { get; set; }
        [RegularExpression(@"^\d+$", ErrorMessage = "Solo se permiten números enteros.")]
        [DisplayName("Cantidad de canciones")]
        [Required(ErrorMessage = "Completar el campo.")]
        public int CantidadCanciones { get; set; }
        [Required(ErrorMessage = "Completar el campo.")]
        [Url(ErrorMessage = "Ingresar una URL válida.")]
        public string? UrlTapa { get; set; }
        [Required(ErrorMessage = "Completar el campo.")]
        public Estilo? Estilo { get; set; }
        [Required(ErrorMessage = "Completar el campo.")]
        public TipoEdicion? TipoEdicion { get; set; }
    }
}
