# P5_Group502

An interface for mixing 3D sound in virtual reality—using dynamic binaural audio.

The idea is to create an environment in virtual reality through Unity, where tracks from Ableton live are represented as objects. The objects will send information to Ableton Live through UDP, using Open Sound Control. This way the user is able to create a spatial audio mix in VR, using an Oculus Quest.

The spatial algorithms are implemented in Max for Live, using impulse responses. The environment is implemented in Unity, using various shaders to serve as signifiers for the different tracks and statuses.
