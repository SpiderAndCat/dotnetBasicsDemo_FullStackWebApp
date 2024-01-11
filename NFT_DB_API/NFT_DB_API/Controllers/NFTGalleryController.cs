﻿using Microsoft.AspNetCore.Mvc;
using NFT_DB_API.Models;
using System.IO.MemoryMappedFiles;
using System.Runtime.ExceptionServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NFT_DB_API.Controllers
{
    public class NFTGalleryController : Controller
    {
        public async Task<ViewResult> Index(int limit=2)
        {
            // For this use case, the HttpClient is only used once
            // To to clean resources, using{} is utilized, to clear the HttpClient when out of scope
            using (var httpClient = new HttpClient())
            {
                const string API_URL = "https://eth-mainnet.g.alchemy.com/nft/v3/WwNubjj7sBMCmY53SIbT7Y3415W6MwbJ/getNFTsForContract?contractAddress=0xBd3531dA5CF5857e7CfAA92426877b022e612cf8&withMetadata=true&limit=";

                try
                {
                    // For ease of use and time, there will be 1 independant calls, and the rest will be manually generated
                    var response = await httpClient.GetStringAsync(API_URL + limit.ToString());
                    //NFT firstnft = JsonSerializer.Deserialize<NFT>(response);


                    NFTList nfts = JsonSerializer.Deserialize<NFTList>(response);



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
