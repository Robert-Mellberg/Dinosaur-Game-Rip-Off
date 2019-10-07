# Dinosaur-Game-Rip-Off

## About the game

The game is a windows game loosely inspired by the popular google chrome dinosaur game that appears when you are unable to connect to a website.

The game is very simple, all you have to do is jump over or duck under objects. You can jump and duck with either the up-arrow or the down-arrow respectively or use the voice recognition and just say "jump" or "duck". Furthermore, if you do not like the color of your character, just yell out another color to change it's appearance.

![](Media/DinoGif.gif)

## About the project

The purpose of this project was to learn more about Unity's built in animations and voice recognition. During the developement i came across a few problems:

Delay when transitioning between the default state and duck- or jump animation. This was solved by increasing the speed of the default state. This did not solve the problem completely, it only minimized it so it is not noticeable.

The second problem was that the voice recognition is too slow to pick up any commands. Often the voice recognition didn't recognize the command before crashing into an object, making it useless. The only thing you can efficiently use it for in this game currently is to change the color of your character. To solve this problem you have to write your own voice recognition, which should not be too hard since it only needs to be able to differentiate "jump" from "duck".

Another problem is that the game is platform dependent, it can only run on windows. The problem lies within that each platform has their own voice recognition. The [speech recognition for android](https://github.com/gsssrao/UnityAndroidSpeechRecognition) can not run in the background which was a problem for this game. The advantages of Unity being platform independent also diminished, the game could just as well have been made in visual studio.

**Note** that the scripts do not have any documentations.

## How to install the game

**Note** that the game can only run on windows.

1. Go to the latest [release](https://github.com/Robert-Mellberg/Dinosaur-Game-Rip-Off/releases/tag/v1.1)
2. Download the compressed folder HQ-Dinosaur.zip under "Assets"
3. Right click the folder and choose "Extract All"
4. Start the game by launching HQ-Dinosaur.exe

## How to install the Unity project

1. Download the [Unity package](https://github.com/Robert-Mellberg/Dinosaur-Game-Rip-Off/blob/master/DinosaurGameRip-Off.unitypackage)
2. Create a new project in Unity
3. Go to Assets -> Import Package -> Custom Package... and select the Unity package

## Contact information
Robert Mellberg

robmel@kth.se
