using System.ComponentModel.DataAnnotations;

namespace NFT_DB_API.Models
{
    public class NFT
    {
        /* Expect this format:
         
        {
            "nfts": [
                {
                    "tokenId": "<value>",
                    "name": "<value>",
                    "image": {
                        "originalUrl": "<https IPFS URL>"
                    }
                }
            ]
        }

         */

        [Required]
        [Display(Name = "ID")]
        public int id { get; set; }

        // The JSON passes a string, even though it's an INT
        // will assign int cast of TokenID to id
        [Required]
        [Display(Name = "Token ID")]
        public string TokenID { get; set; }

        [Required]
        [Display(Name = "NFT Name")]
        public string Name { get; set; }


        // Strings can already be nullable by default
        public ImageStructure Image { get; set; }


    }

    public class ImageStructure
    {
        [Display(Name = "Image URL")]
        public string URL { get; set; }
    }
}
