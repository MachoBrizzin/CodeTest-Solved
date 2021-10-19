# CodeTest
<h3>Code Test for Edge-Sweets</h3>

<span>Given a list of points that make up a shape (all points inside the list are part of the shape), determine how many shapes you can fit inside a given size rectangle with a given amount of space inbetween each shape.</span>

<span>Example: The image below shows a rectangle (green) 50x50. The white shape next to it is a 5x5 rectangle You will be given the list of points for the shape, and the size for the green rectangle.</span><br />
<img src="https://raw.githubusercontent.com/Edge-Sweets/CodeTest/master/images/Rectangles.PNG" width=250 ></img>


<span>The first shape should go in the bottom-left corner, as so: </span><br />
<img src="https://raw.githubusercontent.com/Edge-Sweets/CodeTest/master/images/Rectangles_inside.PNG" width=250 ></img>
<br /><span>Note: You will also be given spacing between squares</span>

<span>Determine how many shapes can fit inside the large rectangle, and set their starting points where they need to be, like so: </span><br />
<img src="https://raw.githubusercontent.com/Edge-Sweets/CodeTest/master/images/Rectangles_Filled.PNG" width=250 ></img>


The code test is the backend logic that would determine how to do the above example. There are sample shapes in the code test to work with. You should:

1. Determine how many shapes can fit.
2. Return a list of shapes complete with their starting points
3. Confirm that your method works for any variety of shape.

Information you're given:
1. Size of the square
2. Spacing between squares
3. Size of the sheet to fill in

Notes:
- Assume shapes will be "rectangular". That is, no overlapping of shapes need to occur.
- Spacing includes spacing from the sides of the rectangle
- Bottom-left corner is 0,0
- Not all parts will fit exactly in the rectangle. Side spacing is minimum required spacing


Example:
   
    Shape fiveUnitRectangle = CreateFiveUnitRectangle(); //this creates the shape. This will be done by us.

    //TestModel takes in spacing, shape coordinates (list generated by us), and sheet size
    TestModel test1 = new TestModel(1, fiveUnitRectangle, new Size(50, 50));
    List<Shape> placedShapes1 = GetInsertedShapePositions(test1); //main call to call into your code. This returns a list of shapes in their proper positions

test1 correct output: 

<i>Note</i> Numbering can also be incremented opposite way (x incrementing first, then y)

Test1:

1,1

1,7

1,13

1,19

1,25

1,31

1,37

1,43

7,1

7,7

7,13

7,19

7,25

7,31

7,37

7,43

13,1


13,7

13,13

13,19

13,25

13,31

13,37

13,43

19,1

19,7

19,13

19,19

19,25

19,31

19,37

19,43

25,1

25,7

25,13

25,19

25,25

25,31

25,37

25,43

31,1

31,7

31,13

31,19

31,25

31,31

31,37

31,43

37,1

37,7

37,13

37,19

37,25

37,31

37,37

37,43

43,1

43,7

43,13

43,19

43,25

43,31

43,37

43,43