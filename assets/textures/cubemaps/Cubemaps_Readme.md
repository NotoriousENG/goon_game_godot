# Creating Cubemap Textures for Bevy

1. https://matheowis.github.io/HDRI-to-CubeMap/

2. Install [ImageMagic](https://imagemagick.org/script/download.php#windows) Binary for your system with legacy tools like convert

3. Run The Following:
   * ``` zsh
     convert px.png nx.png py.png ny.png pz.png nz.png -gravity center -append cubemap.png
     ```