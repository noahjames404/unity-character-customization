# unity-character-customization

Demonstration for character customization with Skin Mesh Renderer. 

The general idea here is that we have an existing character with a standardized set of bones and clothing parts. We pick a character to customize and pick a mesh (let's say a glove) from character B, create a new instance from that glove, and finally attach that glove to our customizable character. 

**Common Issues**
 - Skin Mesh Renderer is invisible - bone structure must be the same for it to be visible. 
