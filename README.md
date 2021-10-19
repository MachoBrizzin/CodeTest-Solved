# CodeTest Solved
<h3>Code Test for Edge-Sweets</h3>

<span>This was solved by creating a 2D grid and interating so long as there was enough room on either axis to fit a shape.</span>

<span>The first shape is spawned at 0,0 + the spacing/padding. Then the program evaluates how many spaces/units in the grid on either axis the next shape would need if it were to be created. We then subtract the position index of the previous shape (if there is one) from the total dimension of the grid on that axis. If we have sufficient space for a new shape and its spacings, we add it, otherwise, we don't. The image below compares Edge-Sweets' populated grid with my own (as seen in the Unity engine).</span><br />
<img src="https://raw.githubusercontent.com/Edge-Sweets/CodeTest/master/images/Rectangles_Filled.PNG" width=250 ></img>
<img src="https://github.com/MachoBrizzin/CodeTest-Solved/blob/e00f271c0a72229018996daa1b69e2b157b059d6/images/5x5.png" width=250 ></img>


<span>Then we have the 4x4 and the triangle grids which were not shown in the CodeTest, so I'm unsure if its correct (although I'm fairly confident it is): </span><br />
<img src="https://github.com/MachoBrizzin/CodeTest-Solved/blob/2d8120718272a6f38f7ee5c5ce69b21284266ab3/images/4x4.png" width=250 ></img>
<img src="https://github.com/MachoBrizzin/CodeTest-Solved/blob/2d8120718272a6f38f7ee5c5ce69b21284266ab3/images/tri.png" width=250 ></img>
<br /><span>Notice the spacing on the triangle grid. The rightmost column appears offset due to the lack of space to fit additional triangle shapes.</span>

This test definitely had me scratching my head at times, but all-in-all it was a great exercise and I'm glad to have been given the opportunity to give it a shot.

It was a great feeling to finish this, and even better to have it visualized.

NOTE: When running the command prompt build of the program, the console displays the output in reverse order to what was originally shown in the Edge-Sweets git repository. Specifically, the order of the axes printed is reversed. They showed Y:X. whereas I show X:Y.
