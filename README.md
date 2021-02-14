# About
OpenDiscordHaxx is an opensource version of iLinked's raidbot 'DiscordHaxx' that was released about 2 years ago.<br>

iLinked started this project around a year ago and stopped maintaining it after some time, so I decided to step in and start maintaining it and bring it back to life.<br>

This raidbot is powered by Anarchy (https://github.com/not-ilinked/Anarchy), which is a powerful API wrapper that specializes in selfbots of all sorts.<br>

If you find any errors, please open a GitHub issue, but check [known bugs](https://github.com/mb-1337/OpenDiscordHaxx#known-bugs) first to see if I am aware of the issue, or if it is being fixed already.<br>

# Features
### Bots
- Joiner
- Leaver
- Flooder (includes DM flooding)
- Friender
- Reactions

### Tools
- Checker
- Cleaner
- Server recon (server info)

### Other
- Dashboard
- Bot list (allows you to modify bots, get their profile etc.)
- Bot cancelling (for stopping flooders and stuff)

# How to set it up
First you must find the directory containg 'OpenDHBackend.exe' (in releases that's Backend).<br>
In this directory you create a file called Tokens.txt, which is where you put your tokens.<br>
Optionally you can also enable gateway clients by going to Config.json, which will give u more responsive bots. (currently a bit broken, see known issues)<br>
Then to start it up open OpenDHBackend.exe.<br><br>

Next find index.html (Frontend in releases), and open it in your preferred browser.<br><br>

Now you should be ready to raid! :)<br>

## To use it on mobile devices head over to [here](UsingODHOnOtherDevices.md)


# Accounts
When the server is starting up the accounts will be loaded, while this is going on the server's status will be set as 'LOADING BOTS'.<br>
Whenever the contents of Tokens.txt are changed, the server will remove all current bots and load in the new ones.<br>
If you remove Tokens.txt the server will wait until you have a new Tokens.txt file.<br>
Furthermore, if less accounts are loaded than tokens in the file there will be written a new file (Tokens-valid.txt), with all the accounts that were loaded successfully.<br>
If your accounts are not working, try putting them through the account checker, which will automatically remove invalid accounts (once again valid ones are wittent to 'Tokens-checked'.txt).<br>


# Gateway clients
When your accounts are being loaded, all clients below 50 (or whatever your cap is) will be set as 'socket clients' (makes them more responsive).<br>
If you are having some memory issues, try turning the limit down in the config fileˇˇ.<br>
For enabling this, edit Config.json, located in the backend directory.

# Known bugs
- none right now, please create an issue if you encounter one :)

# TODOS
- better token checking method
- (maybe) stop using ws endpoints and use opcodes entirely
