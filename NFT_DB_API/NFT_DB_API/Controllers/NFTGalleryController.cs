using Microsoft.AspNetCore.Mvc;
using NFT_DB_API.Models;

namespace NFT_DB_API.Controllers
{
    public class NFTGalleryController : Controller
    {
        public ViewResult Index()
        {
            List<NFT> nfts = new List<NFT>
            {
                new NFT {
                    id = 0,
                    TokenID = "0",
                    Name = "Pudgy 1",
                    Image = new ImageStructure
                    {
                        URL = ""
                    }
                },

                new NFT {
                    id = 1,
                    TokenID = "1",
                    Name = "Pudgy 2",
                    Image = new ImageStructure
                    {
                        URL = "url2"
                    }
                },
            };
            return View(nfts);
        }
    }
}
