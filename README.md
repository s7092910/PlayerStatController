# PlayerStatController

This is a modder utility for the game 7 Days to Die. This utility allows modders to get
the player stats as xml bindings.

## Features

* `XUiC_PlayerStats` is a XUiC_Controller allowing it to be used as a controller in the
7 Days to Die xml.
* Allows a modder to easily bind certain player stats to xml that can be used to show the stats in the UI.
* Easy to add to a mod, as simple as adding as little as 1 line of xml and popping in the required files
to the mod
* Supports up to 43 XML bindings related to the Player's stats
* Allows easy access to add new custom bindings without touching the the `XUiC_PlayerStats` controller

## Include in your mod

There are two ways to include this utility in your mod.

First you have to download one of the [releases](https://github.com/s7092910/PlayerStatController/releases/).
In the download, there are 3 files in a folder called PlayerStatController, the 3 files included are:

* Modinfo.xml
* LICENSE.md
* PlayerStatController.dll

#### As a seperate mod

To add the utility as a seperate mod, extract the PlayerStatController folder and add it to the
7 Days to Die Mods folder. From there, 7 Days to Die will load it as a seperate mod which will allow you
to access the `XUiC_PlayerStats` from your own mod in a seperate mod folder.

Make sure that the PlayerStatController folder is included in the download of your mod or include
instructions for users of your mod on how to download and install the PlayerStatController standalone mod.

#### Include in your mod's folder

To add the utility as part of your mod, extract both the PlayerStatController.dll and the LICENSE.md
into your mods folder. 7 Days to Die will load the PlayerStatController.dll from your mod's folder when
the game is started.

When you bundle up your mod, make sure that the PlayerStatController.dll and LICENSE.md are in your mod's
folder. Your users will not need to download any additional files.

#### Additonal Steps

After you have picked one of the two options above, there are a few additional steps that must be taken. As
the PlayerStatController adds additional code to 7 Days to Die, Easy Anti Cheat must be turned off on the client
if someone is using a mod that includes the PlayerStatController.

[How to turn off East Anti Cheat on 7 Days to Die](https://www.youtube.com/watch?v=752cb_A9Leg)

#### Caveats

For a mod using the PlayerStatController to work on multiplayer, the mod must also be installed on the
server and the server must have Easy Anti Cheat turned off.

## Usage

[Using the Controller in your mod](Tutorials/ControllerUsage.md)

[Adding a new XML binding](Tutorials/CustomXMLBindings.md)

[Examples of the Controller in Action and custom XML bindings](PlayerStatControllerExample/)

## Changelog

[Changelog](CHANGELOG.md)

## License

    Copyright 2021 Christopher Beda

    Licensed under the Apache License, Version 2.0 (the "License");
    you may not use this file except in compliance with the License.
    You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

    Unless required by applicable law or agreed to in writing, software
    distributed under the License is distributed on an "AS IS" BASIS,
    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    See the License for the specific language governing permissions and
    limitations under the License.
