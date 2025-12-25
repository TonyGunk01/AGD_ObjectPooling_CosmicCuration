# Cosmic-Curation

This is a space battle game designed in Unity2D and programmed in C#. Here the objective is stay alive as long as possible and attain a high score by shooting other enemy space ships.

Due to the nature of the game where the player can shoot infinite number of bullets, spawning multiple enemies and pickups, creating and destroying these assets can be extremely resource intensive for the CPU and result in sub optimal performance. Hence I have implemented object pooling for these game objects.

Object pools keep a finite number of such objects in memory and instantiate them when needed. If an object is destroyed in game or not in use, then it is returned back to the pool. This saves a lot of CPU resources and power which can be allocated for more important mechanisms. 

Video demo:
