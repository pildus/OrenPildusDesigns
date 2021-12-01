<img src="http://pildus-001-site1.gtempurl.com/images/logo_small.png"
     alt="Oren Pildus Designs"
     width="200px"
     style="float: left; margin-right: 10px;" />

# **Oren Pildus Designs**

## **Online Store Demo**

(C# &amp; WPF Project)

1. **About This Project**

This project intends to demo an online store for displaying and selling various products. It was built to demonstrate knowledge and implementation of C# and Entity Framework Programming fundamentals and principles,

2. **Built With :**

The project was Built with Entity Framework Core as the data access technology, and SQL Server as the database structure. Though not mandatory, the GUI for the demo was built with WPF graphical environment.

| **Programming** | **Data Access** | **Database** | **GUI** |
| --- | --- | --- | --- |
| C# | Entity Framework Core. | SQL Server | WPF |

The project loosely implements the **Factory** design pattern.

3. **Getting Started:**

- _ **Download the code source:** _

Download or clone the Github code from: [https://github.com/pildus/OrenPildusDesigns](https://github.com/pildus/OrenPildusDesigns)

- _ **Running the Demo:** _

Set project OPD\_GUI as startup project, Build And Run solution.

Upon Loading, the projects verify if the Database exists. If the database does not exist, the app automatically invokes a Method to create and populate the database.

The Login screen should appear to allow you to log in:

!["Login Screen"](http://pildus-001-site1.gtempurl.com/img/login.jpg)

**Predefined existing Users in the system :**

Admin user:

Email address: [admin@admin.com](mailto:admin@admin.com)

Password: Admin123!

Regular User:

Email address: [user@user.com](mailto:user@user.com)

Password: User123!

4. **Entities, Relations design and logic:**

The project implements EF TPT (Table-per-Type) inheritance model. Table-per-type inheritance uses a separate table in the database to maintain data for non-inherited properties and key properties for each type in the inheritance hierarchy.

The main model for the products section is an abstract class _ **Product** _ from which each specific product type model is inherent:

_public abstract class Product_

_{_

_[Key]_

_public int ProductId { get; set; }_

_[Required]_

_public string ProductName { get; set; }_

_[Required]_

_public double ProductPrice { get; set; }_

_[Required]_

_public ProductTypes ProductType { get; set; }_

_public EffectTypes EffectType { get; set; }_

_}_

There are currently 3 product types models (_ **Pedal, Board, Component** _), each has unique Properties:

_[Table(&quot;Pedals&quot;)]_

_public class Pedal : Product_

_{_

_public string PedalDescription { get; set; }_

_}_

_[Table(&quot;Boards&quot;)]_

_public class Board : Product_

_{_

_[Required]_

_public double BoardWidth { get; set; }_

_[Required]_

_public double BoardHeight { get; set; }_

_}_

_[Table(&quot;Components&quot;)]_

_public class Component : Product_

_{_

_[Required]_

_public int QuantityPerLot { get; set; }_

_public ComponentTypes ComponentType { get; set; }_

_}_

Furthermore, there are several more entities in the project:

**InventoryItem** _(Table Inventory)_ – Handles the actual amount of items from a certain product. Updated by explicit inventory creation/modifications, or as a result of User&#39;s oders/returns. (Returns are not implemented yet).

**Order** _(Table Orders)_ – Handles inventory traffic to/from users.

**User** _(Table Users)_ – Holds the details of each user, and the user&#39;s type. Upon signing up and registering a User, **the selected password is being encrypted using SHA256 hash function.**

**UserType** _(Table UsersTypes)_ – holds the various user&#39;s types.

!["Entities Relations"](http://pildus-001-site1.gtempurl.com/img/entitiesRelations.jpg)

5. **Usage and Logic:**

The DataControl assembly revels a Utils folder to the customer, which offer a various data retrieving / manipulation methods to be called via static classes. Following is a key list of these methods:

**Admin Only Methods:**

- Adding Products (AddProduct (Overloaded for various product types))
- Editing Products (EditProduct (Overloaded for various product types))
- Delete Product (DeleteProduct by ID)


- Adding Inventory record **
- Explicit Inventory editing (Oppose to editing via order) – allow admins to return/refund items to inventory.**
- Retrieve all orders in the system.**

**\*\*not implemented in the GUI due to lack of time.**

**General usage Methods:**

- Log in / Sign up methods.
- Retrieve Products List (Overloaded for various filters requests)
- Populating the user&#39;s shopping cart.
- Processing user&#39;s shopping cart.
- Add Order / Edit order (Confirming order to move from shopping cart to be removed from inventory).
- Retrieve list of user&#39;s confirmed orders (Overloaded for various filters requests)
- Edit User details and password

<p>

**GUI Usage – Login &amp; Sign Up :**

Upon login, a new user is given the option to sign up for the system. One must provide a valid email address and username, and a password complying with the following criteria:

- Length 8-20 characters
- At least one Upper Case character
- At least one Lower Case character
- At least one numeric character (0-9)
- At least one special symbol character (!&quot;#$%&amp;&#39;()\*+,-./:;\&lt;=\&gt;?@[\]^\_`{|}~)

Upon successful verification, the password is encrypted with SHA-256 hash functions and the User object is created.

!["Sign Up Screen"](http://pildus-001-site1.gtempurl.com/img/signup.jpg)

Upon Login, the logged in user details are reflected to the Constants.SessionUser object, from which all User&#39;s actions are performed.

**GUI Usage – Main Screen :**

!["Main Screen"](http://pildus-001-site1.gtempurl.com/img/mainScreen.jpg)

<BR>

!["Main Screen"](http://pildus-001-site1.gtempurl.com/img/mainScreen2.jpg)

**GUI Usage – Shopping Cart :**

!["Shopping Cart"](http://pildus-001-site1.gtempurl.com/img/shoppingCart.jpg)

**GUI Usage – User Page :**

!["User Screen"](http://pildus-001-site1.gtempurl.com/img/userScreen.jpg)

**GUI Usage – Admin Page :**

!["Admin Screen"](http://pildus-001-site1.gtempurl.com/img/adminScreen.jpg)
