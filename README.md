# SugarRush Vertical Slice Overview

## Advance Techniques Used

### Advanced Physics:
- Allows the player to jump only when on the ground, thus keeping a check on the player's interactions with the environment (platform). To achieve this feature `LayerMask` and `Physics2D.BoxCast` are used (PlayerMovement script).
- Realistic movement behaviors are added to the player and SugarGlob game objects.
- Implemented bouncing behavior to the player, affected by gravity when jumping on SugarGlobs (OnTriggerEnter2D, GlobMovement script).
- To achieve a realistic collision impact, the player and SugarGlob are pushed away from each other with force in the opposite direction. `ForceMode2D` is used to simulate impact (MoveAway, GlobMovement script).

### Artificial Intelligence:
- A smart detection behavior feature is added to the SugarGlob. Whenever it is on the ground, SugarGlob looks for the player and moves towards it (FixedUpdate, GlobMovement script).

## Graphics:
- The player and sugarglob sprites were sliced manually (MyCharactersSprites).
- Level1 and Level2 were created using tilemap (Assets- Pixel Adventure 1, the tiles used were sliced in grid by cell size format-16x16).
- Animated Player and SugarGlob.

## Audio:
- 1 Background Music
- 7 sound effects

## Basic Accessibility Considerations Addressed:
- Easy control movements.
- Instructions are given in simple understandable language.
- Readable font size maintained throughout the game.
- Options to customize resolution and graphics quality (Settings menu).
- Option to customize music volume control (Settings menu).
- Pause menu provided.

## Credits and References:
- Unity Asset Store [Unity Asset Store](https://assetstore.unity.com/)
- mystic_woods_free_2.1 [Mystic Woods Free](https://game-endeavor.itch.io/mystic-woods) (Free version), itch.io
- Dessertmatch3 [Neapolitan Dessert Game Kit UI](https://opengameart.org/content/neapolitan-dessert-game-kit-ui) (Free version), OpenGameArt.org

- [Unity Manual](https://docs.unity3d.com/Manual/index.html)
- [Unity Scripting API](https://docs.unity3d.com/ScriptReference/index.html)
- [Accessibility Guidelines](https://gameaccessibilityguidelines.com/basic/)
- [Gameplay Video](https://dmail-my.sharepoint.com/:v:/g/personal/2616436_dundee_ac_uk/EWAwwQtqfh5FluMDCSjxnewBN9y-eKWa2XDK6n-A_S-z7g?nav=eyJyZWZlcnJhbEluZm8iOnsicmVmZXJyYWxBcHAiOiJPbmVEcml2ZUZvckJ1c2luZXNzIiwicmVmZXJyYWxBcHBQbGF0Zm9ybSI6IldlYiIsInJlZmVycmFsTW9kZSI6InZpZXciLCJyZWZlcnJhbFZpZXciOiJNeUZpbGVzTGlua0NvcHkifX0&e=0VLj0s)
