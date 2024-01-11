using Microsoft.AspNetCore.Mvc;
using NFT_DB_API.Models;
using System.IO.MemoryMappedFiles;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NFT_DB_API.Controllers
{
    public class NFTGalleryController : Controller
    {
        public async Task<ViewResult> Index()
        {
            // For this use case, the HttpClient is only used once
            // To to clean resources, using{} is utilized, to clear the HttpClient when out of scope
            using (var httpClient = new HttpClient())
            {
                const string API_URL = "https://eth-mainnet.g.alchemy.com/nft/v3/WwNubjj7sBMCmY53SIbT7Y3415W6MwbJ/getNFTMetadata?contractAddress=0xBd3531dA5CF5857e7CfAA92426877b022e612cf8&tokenId=0&refreshCache=false";
                try
                {
                    var response = await httpClient.GetStringAsync(API_URL);
                    NFT nfts = JsonSerializer.Deserialize<NFT>(response);
                    return View(nfts);
                }

                catch (JsonException ex)
                {
                    return View(ex.Message);
                }

                catch (HttpRequestException ex)
                {
                    return View(ex.Message);
                }
            }






            /*
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
            */
        }
    }
}
