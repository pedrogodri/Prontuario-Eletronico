using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProntuarioEletronico.Web.Models.DTO
{
    public class ImageField
    {
        public int IdImageField { get; set; }
        [DataType(DataType.Upload)]
        [DisplayName("Upload Image")]
        public string? image { get; set; }
    }
}
