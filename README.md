# Conan-Exiles-Character-Transferer-Csharp
A character trasferer for Conan Exiles to allow moving inventory and skills from Exiles to Siptah and back.

# Steps
- Download the files or install Godot 4.6 .Net version (or at least 4.6 however compatibility may break for future versions)
- Copy over the game.db and dlc_siptah.db files from your Conan Exiles server into the main folder next to
- You should now see 3 .cs files and your 2 .db files in the same folder
- Run
- Follow the onscreen info to select accounts and transfer their data

Some of the screens contain debug info that is just shown to show the account is not empty, for example inventory items have weird names in the database with Ids based on their blueprints in Unreal Engine. You can ignore this info as it's mostly unreadable and just continue to the next screen.

**Backups** of the files will be made in the Backup folder, use that to restore characters if there is any issue. It will also contain the entire world so it will reset the world to that point as well. Consider it a checkpoint of the entire server at the moment in time you moved it.

# Important
The important choices are the accounts at the first screen and the final screen where you choose to which database to copy to. By default it will choose the opposite of your choice to copy from, so for example if you select Siptah on the final screen it will copy from Exiles -> Siptah and not sync the other way. If you want to transfer back, choose Exiles and it will copy your progress from Siptah -> Exiles.

I recommend just going through the screens with next until the final screen, only change things if you know what you are changing. Most screens don't allow you to change things just to avoid losing items.
