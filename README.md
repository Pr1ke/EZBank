# EZBank

## Setup

Run the `Scripts\CreateEnvironment.sql` script on the **Master Database** of an MSSQL Server instance to initialize the database, then start the application.  
Specify the **address** of your MSSQL Server instance and the credentials of a valid SQL user.

---

# Feature Overview

## WinForms DataGridView and DockStyle  
## DataTables

DataTables are the data sources for the three DataGridViews (**Customer**, **Account**, **Transaction**).

## SQL Connection
![DB schema](Documentation\DBDBSchemaEnglish.png)

EZBank currently supports MSSQL and stores (almost) all data in the SQL database provided at login.

## Multiuser Operation

EZBank supports multiuser operation by utilizing the SQL Server as a user credential authority.  
This means user management is currently handled by the DBMS.

## Customer Address Management

![GUI example]Documentation\GUI.png

The Customer DataGridView allows the user to create new entries, delete old ones, and update existing ones.

## Account & Transaction Management

Buttons on the GUI allow the user to create and delete **transactions** and **customers**.

### Account
- Account IDs are unique.  
- Addresses can be linked to accounts. One account can only be associated with one customer, but one customer can have multiple accounts.

### Transactions
- Fields: Date, Amount, Purpose, IBAN, Transaction Number, and Transaction Type.  
- Available Transaction Types: Withdrawal, Deposit, Transfer, and Incoming.  
The Transaction Types table keeps track of which type is subtractive when calculating account balances.

## Display Balance

It is possible to delete old transactions without affecting the account balance.  
To keep a record of deleted transactions, the deletion only updates the field **"DeletedBy"** in the transaction table.  

Transactions marked as deleted in this way are not displayed but are still used when calculating the account balance.

The only way to tamper with account balances is by creating fake transactions.

If there is suspicion that a malicious user created fake transactions and deleted them, other users can enable the display of deleted transactions using the **"Show deleted transactions"** checkbox.

## Enter Opening Balance

When creating accounts, the user can specify a starting amount, which will create a corresponding deposit transaction when saving the account.

---

# Shortcomings and TODOs

## Error Handling

The main issue currently missing is proper error handling.  
Right now, most exceptions cause the app to exit.  
This is problematic because users are responsible for creating data that is used in SQL queries, increasing the potential for invalid data to crash the application.

## Initializer

The database must be initialized by an administrator.  
We should create an initializer class that checks the instance for the correct database and creates one if it’s missing.  
The hardcoded database name should be dynamically generated.

## UI

The UI needs to be evaluated for usability and alignment with customer needs.  
Currently, it is only a bare-bones implementation of the specifications.

## Proper Multiuser Handling

### Administration

We should implement proper user administration and permission control within the application instead of relying solely on SQL Server for authentication.

### DB Writes Inside Transactions

There are currently no semaphores implemented to lock tables or entries when a user is actively editing them.  
This could cause database inconsistencies if two users modify the same data simultaneously.  
Transactions and locks are needed to ensure safe and consistent data handling.
