# JuniorFullStackWebDev_ASPdotNET_Demo

MVC structuring, API calls, form entry, and layout are all successfully integrated together, bringing the basic demo to life! Try it for yourself! Just clone and open the .sln on main branch (the stable release), and run the VS project (http on localhost).

Also feel free to explore the different branches, commits (and comments!), and chronology of each, to see the development journey and breakdown.

## User Experience
`url/`
The landing Index will greet you with a form to enter a number. This number will be used to set the query size for the Alchemy API call to query your requested number of Pudgy Penguin NFT images and names.

This landing view uses an `@Html` form element, binding the Limit number data to a ViewModel, passing said model to the NFTGalley controller. This controller calls the Alchemy API URL, with your inputted limit parameter. Then, it dynamically populates a table in the Razor view, NFTGallery (accessed at `url/nftgallery`, with a default Limit of `2`).

By clicking the `Click to Add NFT`, you are brought to the `AddNFT` view. Here is a form (using standard HTML, with an onclick JS trigger buton) prompting you to enter your NFT Name (Required) and Image URL (Optional). If your NFT is saved, then a message will appear indicating so. If your NFT is not saved (due to the Name field being empty), an alert will appear. 

The Green and Lightcoral label styling is also universal across views, as the styling code is in the `Layout.cshtml`, which, in this project's case, all Views share. Therefore, each view can reference the `title` and `subtitle` class to get these CSS properties.

## Improvements:
In `AddNFTs`, the NFt actually isn't "saved". To actually be saved, what could further be coded is integrating Entity migrations, to store the actual API NFTList model data into a local realtional DB. Then, when an NFT is "saved", it could be written to the NFTs table (based on the NFT.cs object model). Where the NFTGallery view would then display all NFTs from the local DB (what was originally quried, plus any the user adds afterwards)
