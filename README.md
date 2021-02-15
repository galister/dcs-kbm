
# DCS Kneeboard Manager
Only take the pages you need.

Download here: [[Releases]](https://github.com/galister/dcs-kbm/releases)



![Screenshot](https://i.imgur.com/yF6SYLe.png)

Built for those who use a large number of kneeboard pages, this tool allows you to pick which kneeboard categories you will need, and install those in your DCS's Kneeboard folder for you.

This can greatly cut down the number of kneeboards you will need to flick through.

It can be used as a "launcher" for DCS, as well as just a simple tool to save your kneeboard selection whenever.


## 1. First run

Windows might warn you about untrusted software. Click `Details` then `Run Anyway` if that is the case.

After launching the program, select your DCS instance, a map and an aircraft.

## 2. Set up your categories!

Let's add a new KB category for this selected map by right-clicking the background of `Map Kneeboards`.

![Quick Start](https://i.imgur.com/6RwBvxm.png)

Once the category is created, right click it to open the folder.

![Quick Start 2](https://i.imgur.com/GH7hQY5.png)

You can put the actual kneeboard page images for this category in there now.

You can also manually create these folders under `Saved Games/DCS.openbeta/KneeboardManager/`.

#### Map kneeboard categories

These are kneeboard categories that are specific to a single map / theatre.

Right-click the background of `Map Kneeboards` to add a new category for your selected map.

#### Airframe kneeboard categories

Each aircraft has its own set of kneeboard categories.

Right-click the background of `Airframe Kneeboards` to add a new category for your selected airframe.

#### Common kneeboard categories

These categories are shared across all maps and all airframes.

Right-click the background of `Common Kneeboards` to add a new category.

### Example structure

Once done, your folders should look something like this.

![Example Folder Structure](https://i.imgur.com/W0rjiAT.png)

## 3. Apply selected pages before flight!

Ready to fly?

1. Launch the KBM tool.
2. Select your map and aircraft, and then check the kneeboard categories your will need.
3. (Optional) Set your callsign. You can of course also change it within DCS. I personally forget to change it before connecting to a server.
4. Click `Launch` or `Apply Without Launch`

KBM will copy your selections into your aircraft's DCS kneeboard folder. If there are existing pages in there, you will be notified.

After applying the selections, KBM will exit and DCS will launch (unless you chose `Apply Without Launch`).

To launch again, simply run KBM again.

## Notes

Due to the sheer number of kneeboards that come with Caucasus, I recommend disabling the built-in list by renaming your `DCS World\Mods\terrains\Caucasus\Kneeboard` folder to something like `Kneeboard-old`

You can use categorized pages for Caucasus instead - simply unzip [this package](https://github.com/galister/dcs-kbm/raw/caucasus-pack/Caucasus.zip) into your `Saved Games\DCS.openbeta\KneeboardManager\Maps` folder.
