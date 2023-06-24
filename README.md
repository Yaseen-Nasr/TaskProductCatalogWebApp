# Product Management Application - Functionality Overview

This README file provides an overview of the functionality implemented in a product management application. The application allows users to manage products, categorize them, and perform various actions based on user roles. Below, each point of the specified functionality is explained separately:

## 1) Products Filteration by Current Time

- When the application loads, it retrieves and displays the products that are supposed to be shown at the current time.
- This functionality is available to all users, regardless of their role (admin or Anonymous users).
- The displayed products are dynamically filtered based on the current time, ensuring that only relevant products are shown.
- The filteration is performed automatically upon application load, without any explicit user action.

## 2) Product Information

- Each product in the application is associated with the following information:
  - Name: The name of the product.
  - Creation Date: The date when the product was created.
  - Created By User ID: The ID of the user who created the product.
  - Start Date: The date when the product becomes available.
  - Duration: The duration of the product's availability.
  - DurationType:that may be (day,hours,minutes).
  - Price: The price of the product.
  
## 3) Categorization of Products 
- Each product can be assigned to one category.
 
## 4) Managing Products

- Adding, editing, and deleting products are actions that can be performed only by users with the "Admin" role.
- Non-admin users do not have access to these management functionalities.
- Admin users can perform the following actions on products:
  - Add a new product: Create and save a new product in the application.
  - Edit an existing product: Modify the information of an existing product.
  - Delete an existing product: Remove a product from the application.

## Application Interfaces (Views)

The application provides several views that enable users to interact with the product management functionality. The following views are available:

- All Products View (Admins Only):
  - This view displays all products in the application, regardless of the current time.
  - Access to this view is restricted to users with the "Admin" role.
  - All products are shown, providing an overview of the product characteristics.

- Add/Edit/Delete Product Views (Admins Only) with require validations:
  - These views allow admin users to add new products, edit existing products, and delete products from the application.
  - Only users with the "Admin" role can access these views.

- Product Details View:
  - This view provides detailed information about a specific product.
  -admin can see all product characteristics.
  - Anonymous users can only see all product (name, category,Creation Date,price) .


- Category Filter (Client-side):
  - The application offers the ability to filter products by category.
  - This filter functionality is implemented on the client-side, allowing users to selectively display products belonging to a specific category.

## Seeding Data to the Database

The application utilizes two approaches to seed data into the database.

- Seeding Categories using DbContext :
  - The categories data is seeded into the database using the DbContext class in by overrideing (OnModelCreating).
  - This approach ensures that the categories table is populated with the required initial data.
  - It allows the application to have predefined categories for product categorization.

- Seeding Default Users and Roles :
  - in Program File as an entry point of the application, to check if the default users and roles exist.
  - by using app service to get ServiceScopeFactory instance to fetsh require servidce from RoleManager and UserManager and provide them to the Seeding methods,
  - If the default users and roles are not found.
  - This approach ensures the presence of default users and roles.

