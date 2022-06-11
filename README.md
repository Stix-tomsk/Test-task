# About task
The main task is to develop a WPF application that is a single window.

The window should contain the following elements:

1. List filled with elements: "linear", "quadratic", "cubic", "4th degree", "5th degree";
2. Text fields for entering coefficients a and b.
3. Drop-down list for setting the coefficient c. The content of the values depends on the selected function ([1, 2, 3, 4, 5] for linear, [10, 20, 30, 40, 50] for quadratic, etc.);
4. Table with three columns: f(x, y), x, y;
5. Element for adding rows to the table from point 4.

The window should have the following usability:

1. Ability to select a function from the list of functions;
2. Ability to enter coefficients a, b and choose c;
3. Ability to enter x and y values into the table;
4. Automatic calculation by the application of the value f(x, y) according to the corresponding formulas:
    + linear: f(x, y) = ax + by^0 + c;
    + quadratic: f(x, y) = ax^2 + by^1 + c;
    + ...
    + 5th degree: f(x, y) = ax^5 + by^4 + c.
5. Ability of the program to save a set of coefficients and tabular values for each function for displaying the necessary data when the user selects another function.

Also it's necessary to fulfill the following requirements:

1. Implement the application using the MVVM pattern, use the binding mechanism;
2. When resizing a window, content should shrink/expand as well;
3. The application mustn't allow user to enter incorrect data:
    + non-numeric values in fields where must be only numbers;
    + values in the f(x, y) column (they are always calculated automatically);
    + function names from the function list.
4. In Code-behind only constructors without event handlers;
5. The formula calculation functionality is covered by Unit-tests;
6. Classes, public fields, methods, properties have summary-comments;
7. The program code must be formatted according to one of the generally accepted coding conventions;
8. Code must be posted here.

# Implementation
The result of the work is represented by the following files:

+ [View source code](https://github.com/Stix-tomsk/Test-task/blob/main/View.xaml);
+ [Model source code](https://github.com/Stix-tomsk/Test-task/blob/main/Model.cs);
+ [ViewModel source code](https://github.com/Stix-tomsk/Test-task/blob/main/ViewModel.cs);
+ [Unit tests source code](https://github.com/Stix-tomsk/Test-task/blob/main/UnitTests.cs);
+ [Odds class source code](https://github.com/Stix-tomsk/Test-task/blob/main/Odds.cs);
+ [Project source achive](https://github.com/Stix-tomsk/Test-task/blob/main/test-task.rar);

Visually the application is the following:

![g1](https://user-images.githubusercontent.com/57837079/173204739-c58ec718-0c55-49cb-b31b-78cd7c1e1034.png)

To demonstrate the adaptability of window elements, compare this screenshot with the previous one:

![g2](https://user-images.githubusercontent.com/57837079/173204785-6d6395ea-dc00-4caf-9982-6ef38dae048a.png)

Usability of application cannot be represented by screenshots, but results of unit tests definitely can:

![g3](https://user-images.githubusercontent.com/57837079/173204931-2dced430-0a04-4c49-912d-ef085038ffc9.png)

Screenshot of the application during active work:

![g4](https://user-images.githubusercontent.com/57837079/173205023-68049669-3737-457e-aeb1-8ec37434bf47.png)

## Conclusion
Independently of the result of the employer assessment, it was interesting to complete this task. These two days were marked on the calendar as productivity holidays :)
