# A .NET Discord Chat Bot
### This project was my first solid jump into the .NET/C# Realm. 
#### The idea behind this project was to create a simple Discord Bot that was able to hit a various number of API endpoints based on a given command and parameters, and provide the Discord Server with the information received from the endpoints.
#### While the project was never considered "complete", the main goals of the discord bot were achieved. It is also worth noting that the server in mind during the creation of this bot was a server dedicated to friends who spent the majority of their time playing Fortnite, thus the many Fortnite related commands.
Some of the main functions of the bot are:

* **!lookup**: Looks up Fortnite Stats of specified fortnite name via the Fortnite TRN API. Takes in a string after the initial command for the lookup.

  ![lookup](https://i.imgur.com/waZWVGy.png)

* **!shop**: Retrieves all items in the current daily item shop via the Fortnite TRN API.

  ![shop](https://i.imgur.com/KhmolV6.png?1)
  
* **!meme**: Grab a random GIF based on search via the Tenor API. Takes in a string after the initial command for the lookup.

  ![Imgur](https://i.imgur.com/0vYIKQ4.png)

* **!youtube**: Utilizes Google's YouTube API to search for and return the first video result based on a string query. 

  ![youtube](https://i.imgur.com/AxC4gPt.png)

* **!help**: Lists all available commands in a formatted string response.

  ![Imgur](https://i.imgur.com/TKph7wV.png)
