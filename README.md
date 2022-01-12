# NeosTrackerIdStabilizer

A [NeosModLoader](https://github.com/zkxs/NeosModLoader) mod for [Neos VR](https://neos.com/) that restores your Vive tracker names to their old LHR-whatever IDs. This allows you to make LogiX using trackers that won't break if your local database is reset.

Note that this has minor privacy implications, in that if you were to fake your own death and your trackers continued being used in Neos your elaborate ruse could be revealed.

## Installation
1. Install [NeosModLoader](https://github.com/zkxs/NeosModLoader).
1. Place [NeosTrackerIdStabilizer.dll](https://github.com/zkxs/NeosTrackerIdStabilizer/releases/latest/download/NeosTrackerIdStabilizer.dll) into your `nml_mods` folder. This folder should be at `C:\Program Files (x86)\Steam\steamapps\common\NeosVR\nml_mods` for a default install. You can create it if it's missing, or if you launch the game once with NeosModLoader installed it will create the folder for you.
1. Start the game. If you want to verify that the mod is working you can check your Neos logs.
