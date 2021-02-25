# Adventure of Colors
## Table of Contents

- [Game Controls](#game-controls)
- [WebGL Link](#webgl-link)
- [Purpose of the prototype](#purpose-of-the-prototype)
- [Unity Version](#unity-version)
- [Scenes](#scenes)
- [How to add new feature](#How-to-add-new-feature)
- [How to modify the build on our WebGL link](#How-to-modify-the-build-on-our-WebGL-link)
<!-- - [Prefabs](#prefabs) -->

## Game Controls
- Press C to change color  
- Circle mode: Press SPACE to jump
- Square mode: Press ⬅ and ➡ to move 

## WebGL Link
[WebGL](https://zekaicai.github.io/AdventureOfColors/WebBuild/index.html)

## Purpose of the prototype

The purpose of this prototype is to provide you a sense of the idea of the game we are trying to accomplish, which is simple and fun to play. You, the player, is controlling the ball to either jump or switch color. Jump to avoid a collision and switch color to not fall over the color brick(Happens when ball and brick are the same color!).  Whether you reach the end or vise versa ultimately determines the outcomes of this game. Currently, the game has some features that provide you with sound effects, such as (not limited to) when the ball hits a needle on the ground. This serves as the base for future generations of development. Our developers are enthusiastic about bringing the pure joy of gameplay in this game by combining an BGM that fits into the gameplay while providing you the control of the ball. We also brought another shape (Square) into the gameplay. This adds a flavor into our current game where the physical shape of the ground will be altered accordingly. Hence, play it!

## Unity Version
[Unity 2020.2.1 f1](https://unity3d.com/get-unity/download?thank-you=update&download_nid=64387&os=Mac) or newer

## Scenes
- CircleScene: Prototype circle scene by Zekai
- SquareScene: Prototype square scene by Zekai
- VodkaDance: (In Development) Circle music scene by Zekai
- Ball With BGM: 

## How to add new feature
1. Checkout a branch from main branch
    ```sh
    $ git checkout main # Make sure you start on main branch
    $ git checkout -b [yourBranchName] # Create a new branch
    ```
2. Develop your new feature on the new branch
3. Remember to modify the README.md file
4. Push your new branch to remote github repo
    ```sh
    $ git push origin [yourBranchName]
    ```
5. Create pull request on github and merge your new branch to main branch

## How to modify the build on our WebGL link
1. Build a WebGL application on your local machine and save it in ```/WebBuild ``` repository
2. Push your change to ```main``` branch
3. Wait a few seconds and it should work
