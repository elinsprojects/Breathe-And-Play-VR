# Breathe-And-Play-VR
Some Code Examples from my thesis project built in Unity VR, designed to aid individuals with chronic pain with breathe work and distraction therapy.


# Breathe-And-Play-VR Game Logic
The main menu has 3 scenes the user can enter. The onboarding scene is where the user is given instructions on how to play.

Water Scene is a game where the user puts out fires and then waters flowers in a 3D natural environment where the user can teleport around. The game object is a water pistol that has a particle system that triggers when the primary button on the VR controller is pressed. See "WaterTrigger" script. The "DestroyOnCollision" script handles the collision of particle systems from the water pistol to the fires. After the all fires have been put out, the "AppearFlowerGL" script triggers. and when the collision happens with the water particle system to the flowers, they grow, triggered by the "GrowFlower" script. The score counting is handled by "FireScoreScript", which also handles the sunflower score counting. Once completed, the user is directed to the Main Menu Scene.  

The Flying Scene is the second mindful experience. Here the user is guided by UI to breathe in and out, "Breathing" script,  before being given free (somewhat constrained) reign over the 3D virtual mountain environment. The direction of the eagle follows the gaze of the user, and a button on the controller allows for flying up and forward. This is handled by the "FlyEagle" script. Once the user lands in the landing pad the "ExitFlying" triggers and the user is redirected to the Main Menu Scene.

These scripts are attached to relevant game objects within Unity. 
