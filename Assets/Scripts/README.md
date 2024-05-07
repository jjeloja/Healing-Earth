# Unity Scripts

**IMPORTANT:** Do *not* rename script files. Unity uses the file name to create and access a MonoBehaviour class.

---------------

## CameraFollow.cs
Instructs a camera GameObject to follow a targeted GameObject. This could be a player character, vehicle, or non-player character (NPC). This script does *not* rotate the camera with the targeted GameObject. To achieve that, make the camera GameObject a child of the target GameObject in Unity's Hierarchy window and do *not* add this script.

### Usage
- Add script to any camera GameObject (usually the Main Camera) in a scene.
- Select a GameObject you want to follow as the Target parameter.
- Set the Offset position (usually a negative integer in the Z-axis).

---------------

## CollisionController.cs
Manipulate how a GameObject impacts other GameObjects or itself when the primary GameObject collides with another. Using GameObject Tags are important in order to use the destroy and push functionality. This script can be applied to primary GameObjects with a collider or Character Controller component.

This script also includes a score manager function that will increase or decrease a player's score text in a HUD canvas by a set value. The score text must be designed on a HUD Canvas GameObject within the game scene in order for this function to work.

### Usage
- Add script to any GameObject (usually the primary GameObject like a player or moving GameObject).
- When Change Color is check marked, the primary GameObject will change to any color identified on the color selector.
- Check Destroy Enemies to make any GameObject with the Tag `Enemy` disappear when the primary GameObject collides with it.
- Check Destroy Collectibles to make any GameObject with the Tag `Collectible` disappear when the primary GameObject collides with it.
- Push Power determines the force applied to any GameObject with the Tab `Object` and will push the object when they collide. Default Push Power is 2.

- Optional: Add an Audio Clip to Collision Audio parameter if you want audio to play when *any* collision occurs.
- Optional: Score Manager Properties
    - If using the score manager function, select the Score UI text GameObject where the score will be displayed.
    - Add a positive integer to the Increase Score property if you want the score value to increase when the player GameObject collides with any GameObject tagged as a `Collectible`.
    - Add a positive integer to the Decrease Score property if you want the score value to decrease by a certain amount each time the player GameObject collides with any GameObject tagged as an `Enemy`.
    - Leaving Increase Score and/or Decrease Score set to a value of 0 will not change the score in the manner with a value of 0.
    - Make sure all collectible and enemy GameObjects are tagged appropriately in order for the score manager to work properly.

**NOTE:** The Change Color feature may not work when GameObjects that have non-color or image textures applied.

**NOTE:** When destroying GameObjects with this script, it's important to tag the other GameObjects as either `Enemy` or `Collectible`. GameObject tags are case-sensitive and must be written as described in this document in order for the script to work correctly.

---------------

## LaunchProjectiles.cs
A simple script that allows the player to launch a GameObject from a defined position.

### Usage
- Create an empty GameObject that serves as a launch position. Attach this script to that empty GameObject.
- For Projectile, select a GameObject you want to launch.
- Adjust the Launch Velocity as needed.

### Player Controls
- LEFT MOUSE-CLICK = Launch Selected Projectile from Launch Position

**NOTE:** Player controls for this script can be changed in Unity under Edit > Project Settings > Input Manager > Asset > Fire1.

---------------

## MarbleControls.cs
Controls sphere GameObjects as they roll on a surface, platform, or plane - similar to the Marble Madness video game.

### Usage
- Add script to the sphere GameObject you want to control with a keyboard or other input device.
- Adjust the Speed parameter as needed. Default is 10.
- This script allows the player to control the sphere *only* if the sphere is touching a GameObject with the Tag `Ground`. Add the Tag `Ground` to any platform or plane GameObject where your sphere may roll.

### Player Controls
- ARROW UP/W = Forward
- ARROW RIGHT/D = Rotate Right
- ARROW LEFT/A = Rotate Left

**NOTE:** Player controls for this script can be changed in Unity under Edit > Project Settings > Input Manager.

---------------

## PlayerControls.cs
Controls a character with free rotation or fixed 90-degree rotation, forward running, and jump movement. This script is good for controlling a character in open or grid-based game environments. Choose either to use the script with one-player or two player keyboard controls.

### Usage
- Add script to a player character GameObject.
- Required: For Controller, select the GameObject's Character Controller component.
- Required: For Anim, select the GameObject's Animator file.
- Optional: Add an Audio Clip to Running Sound parameter if you want audio to play whenever the character is running.
- Select either Player One Controls, Player Two Controls, or both to choose which controls (listed below) are used with the script. You can also select Animal Controls to control a two-legged animal character, like a chicken. The default is Player One.
- Adjust the player GameObject's Running Speed as needed. Speed default is 4.
- Adjust Gravity as needed. Default is 8. Lesser or greater gravity will impact jump movement.
- Select Free Rotation if you want the player GameObject to rotate in both directions freely. If not selected, player GameObject will rotate in 90-degree increments.
- If Free Rotation is selected, adjust the player GameObject's rotational speed as needed. Free Rotation Speed default is 90.
- Leave Running unchecked. This will change as you control your character in Play mode.

### Animation Control Parameters
Animation Control parameters are case-sensitive and *must* be typed exactly as written below in order to work with the script. Use each parameter to control when the corresponding animations should play. Be sure to uncheck Has Exit Time on each transition in the Animator window.

Player One and Player Two:
- bool `Run Forward` --> run animation
- bool `Jump` --> jump animation

Animal:
- bool `Run Forward` --> run animation
- bool `Eat` --> eating animation
- bool `Turn Head` --> turning head animation

### Player Controls
- ARROW UP = Forward
- ARROW RIGHT = Rotate Right
- ARROW LEFT = Rotate Left
- SPACE = Jump

### Player 2 Controls
- W = Forward
- D = Rotate Right
- A = Rotate Left
- S = Jump

### Animal Controls
- W = Forward
- D = Rotate Right
- A = Rotate Left
- S = Eat
- SPACE = Turn Head

**NOTE:** The keyboard controls for these scripts are hardcoded and cannot be altered in Unity's Project Settings.

---------------

## RotateHover.cs
A simple script that rotates and hovers a GameObject. This script can be used to add movement to collectible GameObjects. The hover movement uses Unity's PingPong method.

### Usage
- Add script to a GameObject, such as a collectible item.
- Check mark Rotate if you want the object to rotate along the Y-axis.
- Adjust Rotation Speed parameter with an integer value as needed. There is no default speed.
- Adjust Hover Speed parameter with an integer value as needed. There is no default speed.
- Adjust Hover Distance with integer values as needed. There is no default distance.

---------------

## VehicleControl.cs
Controls a vehicle's wheels with rotation of wheel meshes using wheel colliders. This script also allows the player to steer the vehicle.

### Usage
- Add script to the parent vehicle GameObject.
- Be sure to set up pairs of wheel meshes (right and left for each axle of your vehicle) in one child GameObject of the parent vehicle GameObject.
- Be sure to set up pairs of wheel colliders (right and left for each axle of your vehicle) in one child GameObject of the parent vehicle GameObject.
- In the script's properties, add the number of axles your vehicle needs controlled.
- For each axle, add a wheel mesh and wheel collder for each wheel on that axle.
- Select at least 1 axle to provide power by checking Motor. (More axles connected to Motor will give your vehicle more power.)
- If you want steering, check Steering on at least one axle.

Additional script properties control the vehicles torque (motor and brake), deceleration force (how quickly the vehicle comes to a stop), and steering angle (how far the wheels can turn when steering the vehicle).

These parameters default to 0. However, here are some suggested values.

- Max Motor Torque = -800 (-/+ changes the direction of the motor)
- Max Steering Angle = 30
- Brake Torque = 400
- Deceleration Force = 200

### Player Controls
- ARROW UP/W = Drive Forward
- ARROW RIGHT/D = Steer Right
- ARROW LEFT/A = Steer Left
- SPACE = Brake

**NOTE:**
If your vehicle's wheel meshes don't align with your vehicle in Play mode, you can manually reorient them by entering additional rotation parameters for the Reorient Wheels property. Change the X, Y, and Z values (typically in increments of 90 degrees) to create additional rotation that will realign your wheel meshes during Play mode.

**NOTE:** If your vehicle tilts too much or flips over easily while turning, try adjusting the vehicle's Mass under the parent GameObject's Rigidbody component. The more mass, the less easily it will be for your vehicle to tip over. You can also adjust your vehicle's Drag in the Rigidbody component to create more or less air resistance against your vehicle.