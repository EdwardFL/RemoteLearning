** Geometry without Open Closed Principle **

* The following classes were changed in the process of adding the triangle shape: 
    - Triangle.cs (Added)
    - GeometricShape.cs (Modified)
    - Program.cs (Modified)

** Geometry with Open Closed Principle **

* The following classes were changed in the process of adding the triangle shape: 
    - Triangle.cs (Added)
    - Program.cs (Modified)


# Advantages of Open Closed Principle based on Geometrix App

- The use of IShape interface which contains the CalculateArea() method used by every shape class to calculate the area.
-  Being open for extension and closed for modification, it reduces the amount of work that must be done to add extra functionality to the application. (More exactly the classes that need to be changed in order to add new funtionality)
- Code is cleaner 

# Disadvantages of Open Closed Principle based on Geometrix App

- Even if we design the application corectly and the code is prepared for possible future requirements changes, nobody can predict the future perfectly and everyone makes mistakes, so probably, there will be a time when we'll need to change a class and violate OCP.