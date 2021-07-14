# Universal Render Pipeline Visualizer

## Info

This project is a quick and easy way to visualize different 3D objects on a mobile device utilizing Unity's Universal Rendering Pipeline. You can move, rotate and scale the figure. You are provided with a dropdown of available gameobjects to manipulate. If you open the project and add objects to Resources/Prefabs, the dropdown will auto update to the correct length. Same goes for the material dropdown picker. In this demo you are able to select 4 in game lights and 5 mobile friendly URP Volumes.

A lot of the code is dynamic and can easily be applied to different types of scenes for testing all types of different art styles.

This application was tested on iPhone 8+ and iPhone 12 running Unity 2020.3.2f1.

These consists of:
1. Bloom
2. Chromatic Aberration
3. Color Adjustments
4. Lens Distortion
5. Vignette

### Controls
1. Single finger move object around on x and y.
2. Single finger touch the bottom turntable to rotate object around.
3. Two finger pinch for scale.

### Buttons
1. Light button on the left will open a drawer with 4 buttons to select.
      1. Left Spotlight
      2. Right Spotlight
      3. Center Spotlight
      4. Point Light
2. Camera button on the right will open a drawer with 4 buttons to select.
      1. These are the buttons listed above. If you click one, you will get all the opens for that specific post processing effect to manipulate.
3. Reset button bottom left will open a drawer with 4 buttons to select.
      1. Reset Position
      2. Reset Rotation
      3. Reset Scale
      4. Reset All
### Other Features
1. Dropdown in the top left corner allows you to switch between different game objects available inside of the Resources/Prefabs folder.
2. If you enable Change Material in the bottom right, you will have another dropdown appear below the other and you can switch materials of the gameobject but tapping the subject.
