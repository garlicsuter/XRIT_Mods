# XR Interaction Toolkit Modifications of Examples - Version 2.3.2

## Quick Start
After opening this project in Unity, open the scene called "SnapEase" located in SuterAssets > SuterScenes

It uses a smooth transition (a LERP) to move an object into it's socket. It's hacky. It hides the real dropped object, shows the fake imposter, LERP's the imposter into position, then reverses the show/hide of the real/fake objects.

You can also get controller data like the float value of grip and trigger (and boolean!) and booleans of X,Y,A,B for easy VR development of actions that respond to button presses.
