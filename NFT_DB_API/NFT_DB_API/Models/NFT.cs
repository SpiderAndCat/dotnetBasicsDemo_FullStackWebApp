using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace NFT_DB_API.Models
{
    public class NFT
    {
        public Contract contract { get; set; }

        // The JSON passes a string, even though it's an INT
        // will assign int cast of TokenID to id
        [Required]
        [Display(Name = "Token ID")]
        public string tokenId { get; set; }

        [Required]
        [Display(Name = "NFT Name")]
        public string name { get; set; }


        // Strings can already be nullable by default
        public ImageStructure image { get; set; }


    }
    public class Contract
    {
        public string address { get; set; }
    }

    public class ImageStructure
    {
        [Display(Name = "Image URL")]
        public string originalUrl { get; set; }
    }
}
