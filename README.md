# Necessary methods

1. Activate or deactivate the object, where ```true``` activates the GameObject and ```false``` deactivates the GameObject.
```
gameObject.setActive(true)
```
2. Loads the Scene by its name or index in Build Settings
```
SceneManager.LoadScene(string sceneName)
```
3. Set amount of the Image shown when the Image.type is set to Image.Type.Filled. Value is ranged from 0 to 1 with 0 being nothing shown, and 1 being the full image
```
Image.fillAmount = value
```
