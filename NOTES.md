
## Basics

1.	In any script, `Start` function is called only once at the start of the game while the `Update` function will be called once for each frame.
2.	On faster devices, update function will be called more often than on slower devices.
3.	`AddForce` function of rigid body component is used for push objects or move stuff around. Values must be multiplied by `Time.deltaTime` to avoid different speeds on different frame rate devices. `Time.deltaTime` is inversely proportional to the frame rate.
4.	When adding force on button press, it might feel unresponsive. This is because the object builds momentum as force keeps getting added. To fix this, we must use a 4th parameter to the `AddForce` function called `ForceMode`. We set this to `VelocityChange`. Your final code should look like this `rb.AddForce(0, 0, 100 * Time.deltaTime, ForceMode.VelocityChange);`
6.	There is also a `FixedUpdate` function. It should be preferred instead of the `Update` function when you're making any physics related update (i.e. adding forces, torques, etc). `FixedUpdate` is more in sync with the physics engine of unity instead of the frame rate.
7.	In Unity, we have a data type called `Vector3`. This is useful for storing X, Y and Z axis values in a 3D world. We can also add two `Vector3` values by using the + operator and their respective values will get added.

## User Input

1. To execute some code after user presses a button, we can use the `Input.GetKey` function. For example
	 ```C#
	if (Input.GetKey("d")) {
		// Code will be executed after pressing "D"
	}
	```

2.  This should ideally be done in the `Update` method and not the `FixedUpdate`. As `FixedUpdate` is called in sync with the physics engine. If the physics engine is not rendering something, you may miss the user input. 

## Handling Collision

Whenever an object collides with another in Unity, it runs a function called `OnCollisionEnter`.  It also gives us the other object as a parameter.

```C#
void OnCollisionEnter(Collision collision) 
{
	// Here the 'collision' variable will have extra info we need
	// You can use collision.contacts to get contact points of the collision
	// Similarly collision.collider will give an instance the object we collided with
	
	if (collision.collider.name == "Obstacle")
	{
		// This will run if we collider with an object with the name "Obstacle"
	}
}
```

In the above example, we are comparing with name. Which can be slow and also become impossible to manage if you have 1000s of objects in the map. Hence we can use something called `tags`.  It's like classes in HTML/CSS. Now your code will become:

```C#
if (collision.collider.tag == "Obstacle")
{
	// Do something here
}
```

## Trigger vs Collision

**`OnCollisionEnter()`** is used to detect Collisions between objects. To use this method, a `Collider` must be attached to the `GameObject` and it's `IsTrigger` property should unchecked. Note: In order to receive a physical collision event, one of the colliding `GameObjects` must have `RigidBody` attached to itself.  

**`OnTriggerEnter()`** is used to detect collision but it does not act as solid body , rather allows the `GameObjects` to pass through them. To use this method, the `IsTrigger` property of the collider should be checked. Note: To get trigger event to work properly a `RigidBody` must be attached to one of the colliding `GameObjects`.

## Finding Stuff

1. To do a local search within a single game object, you can use the `GetComponent` function.
2. To do a scene wide search, you can run `FindObjectOfType` function. This is slower but you can do this if you don't know where your component lies.

For example, if you need access to the `PlayerMovement` script:
```C#
// The GetComponent Way
someObject.GetComponent<PlayerMovement>().SomeFunction();
GetComponent<PlayerMovement>().SomeFunction();	// For current object

// The FindObjectOfType Way
FindObjectOfType<PlayerMovement>().SomeFunction();
```
