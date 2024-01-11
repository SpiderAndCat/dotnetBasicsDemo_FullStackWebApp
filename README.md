# JuniorFullStackWebDev_ASPdotNET_Demo

MVC structuring, API calls, form entry, and layout are all successfully integrated together, bringing the basic demo to life! Try it for yourself! Just clone and open the .sln on main branch (the stable release), and run the VS project (http on localhost).

Also feel free to explore the different branches, commits (and comments!), and chronology of each, to see the development journey and breakdown.
<img width="1078" alt="Screenshot 2024-01-10 at 10 12 18 PM" src="https://github.com/SpiderAndCat/JuniorFullStackWebDev_ASPdotNET_Demo/assets/130514366/03ef6b31-851f-4a1a-a675-973b976d9004">

***

<img width="1079" alt="Screenshot 2024-01-10 at 10 12 29 PM" src="https://github.com/SpiderAndCat/JuniorFullStackWebDev_ASPdotNET_Demo/assets/130514366/d0b8d490-3cf9-45f6-8064-cc9a2927da4f">

***

<img width="1080" alt="Screenshot 2024-01-10 at 10 12 48 PM" src="https://github.com/SpiderAndCat/JuniorFullStackWebDev_ASPdotNET_Demo/assets/130514366/77913102-379b-4069-aa6b-7f6b49abb90d">

***

<img width="1078" alt="Screenshot 2024-01-10 at 10 13 04 PM" src="https://github.com/SpiderAndCat/JuniorFullStackWebDev_ASPdotNET_Demo/assets/130514366/d0d11248-b77c-4939-a755-fee9fb4acafb">

## User Experience
`url/`
The landing Index will greet you with a form to enter a number. This number will be used to set the query size for the Alchemy API call to query your requested number of Pudgy Penguin NFT images and names.

This landing view uses an `@Html` form element, binding the Limit number data to a ViewModel, passing said model to the NFTGalley controller. This controller calls the Alchemy API URL, with your inputted limit parameter. Then, it dynamically populates a table in the Razor view, NFTGallery (accessed at `url/nftgallery`, with a default Limit of `2`).

By clicking the `Click to Add NFT`, you are brought to the `AddNFT` view. Here is a form (using standard HTML, with an onclick JS trigger buton) prompting you to enter your NFT Name (Required) and Image URL (Optional). If your NFT is saved, then a message will appear indicating so. If your NFT is not saved (due to the Name field being empty), an alert will appear. 

## Under the Hood
The Green and Lightcoral label styling is also universal across views, as the styling code is in the `Layout.cshtml`, which, in this project's case, all Views share. Therefore, each view can reference the `title` and `subtitle` class to get these CSS properties.

`Models > NFT.cs`
NFT is the main Model, for which the NFT objects are organized. The Alchemy API call returns a JSON string, which is then mapped as to the NFTList model (which is -- you guessed it -- a list of NFT models). The NFT model was designed specifically to match the API JSON format, which is an array of NFT objects, looking something like this:
```
{
            "nfts": [
                {
                    "contract": {<more stuff>}
                    "tokenId": "<value>",
                    "name": "<value>",
                    <more stuff>
                    "image": {
                        "originalUrl": "<https IPFS URL>",
                        <more stuff>
                    }
                }
            ]
        }
```


`ImageStructure` and `Contract` -- while essential elements from the API call -- were coded in the `NFT.cs` model as optional, to demonstrate that even if those elements in the payload were empty, the code would still function. 

The HttpRequest for the API call is also an `async` function, with error handling for a `JsonException` or `HttpRequestException`

## Improvements:
In `AddNFTs`, the NFt actually isn't "saved". To actually be saved, what could further be coded is integrating Entity migrations, to store the actual API NFTList model data into a local realtional DB. Then, when an NFT is "saved", it could be written to the NFTs table (based on the NFT.cs object model). Where the NFTGallery view would then display all NFTs from the local DB (what was originally quried, plus any the user adds afterwards)

Better styling could be applied to. And some elements like the buttons are not universally styled due to time constraints, but the `title` and `subtitle` elements on each page are common, to demonstrate some styling logic. Furthermore, the layouts being dynamic (although fairly simple) to fit on desktop and mobile screens.

Also ensuring that text field entries (on Home and AddNFTs) recieve valid input types, and integer ranges where applicable, are an important addition to be made for not only UX, but also fault tolerance and error handling. And considering the API call has an upper limit of 100 elements to be queried, an input larger than that should be prohibited. 
