# HKSoftwareDesignExam
&lt;PG3302 23H> - [Software Design Exam 2023] 

## Description
A program that simulates an online store.

## Instructions
* A user is presented with a console based menu that they navigate by entering the number corresponding to the action they wish to take.
* A user can register as a user by choosing `Sign up` in the main menu.
* A registered user can add products to their shopping cart by choosing either `See all wares` or `Search for item` when logged in.
* When `See all wares` or `Search for item` is chosen the user is asked to enter the id corresponding to the product they want, followed by the ammount they want.
* A registered user can view their cart by choosing `View Cart` from the menu.
* A registered user can place their order by choosing `Checkout` in the menu.
* To exit the store there are two ways. If you are :
	- `Signed in` you choose `Log out` from the menu and then `Exit`.
	- `signed out` you choose `Exit` from the menu.
* To populate the database with dummy data uncomment the `StoreController storeController = new();`, `TestRunner testRunner = new();` and `testRunner.Run(storeController);` methods from Main().

## Information on the program
* The program persists users and items in a SqLite database and keeps a log of the users purchase history.
* The method responsible for handeling the checkout is multithreaded with `parallel.foreach` in order to mitigate conflicting changes made to the database.
* The creation of `shopping carts` and `items` are handled by factory methods.
* The database layer follows the `Dependency Inversion Principle` and can therefor be changed for other databases.
