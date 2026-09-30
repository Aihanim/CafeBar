# CafeBar ☕

A simple desktop café-bar order management application built with C# and Windows Forms.

## About the Project

CafeBar is a Windows Forms application designed to manage orders in a small café-bar.

The application allows the user to select drinks, specify quantities, add items to an order, calculate the total price, remove items, clear the order, and generate receipts.

This project was created as a practical C# application to demonstrate object-oriented programming, Windows Forms, event handling, and basic file operations.

## Features

- Select drinks from a menu
- Select drink types and sizes
- Set the quantity of each drink
- Add drinks to an order
- Remove selected items from the order
- Clear the entire order
- Automatically calculate the total order price
- Display the current order
- Generate receipts
- Save receipts as `.txt` files
- Automatically create a folder for receipts

## Technologies

- C#
- .NET
- Windows Forms
- Visual Studio
- Object-Oriented Programming
- File I/O

## Project Structure

```text
CafeBar
│
├── Coffee.cs
├── Drink.cs
├── Juice.cs
├── Tea.cs
├── Order.cs
├── Receipt.cs
├── Form1.cs
├── Form1.Designer.cs
├── Form1.resx
├── Program.cs
├── WindowsFormsApp4.csproj
├── WindowsFormsApp4.sln
└── Properties
How It Works
Select a drink from the menu
Select the drink type
Choose the quantity
Click Add to Order
The selected item appears in the order list
The application calculates the total price automatically
Items can be removed or the entire order can be cleared
Click Create Receipt to generate a text receipt
Receipt System

Receipts are automatically saved as text files in the Receipts folder.

Each receipt contains information about the café-bar, ordered items, quantities, prices, and the final total.

Example:

CAFE-BAR

Espresso    2 x 700 ₸
Cappuccino  1 x 1200 ₸

Total: 2600 ₸
User Interface

The application provides a simple and easy-to-use interface for creating and managing café-bar orders.

Main interface elements include:

Drink selection
Drink type selection
Quantity control
Price display
Order list
Total price
Add to Order button
Remove Item button
Clear Order button
Create Receipt button
Open Receipts button
Installation
Requirements
Windows
Visual Studio
.NET Framework / compatible .NET version
Running the Project
Clone the repository
Open WindowsFormsApp4.sln in Visual Studio
Build the solution
Run the application
Future Improvements

Possible improvements for future versions:

Add a database for storing drinks and orders
Add customer information
Add order history
Add discounts
Add payment methods
Improve the visual design
Add statistics and sales reports
Add user authentication
Author

Developed as a C# Windows Forms educational project.

License

This project is intended for educational and portfolio purposes.
