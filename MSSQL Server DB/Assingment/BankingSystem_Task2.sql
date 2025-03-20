use hmbank

--Write a SQL query to retrieve the name, account type and email of all customers. 
select concat(first_name,' ',last_name)as Name,account_type,email from customers
join accounts on customers.customer_id=Accounts.customer_id

--Write a SQL query to list all transaction corresponding customer. 
select concat(first_name,' ',last_name)as Name,customers.customer_id,transaction_id,transaction_type,amount,transaction_date from customers
join accounts on customers.customer_id=accounts.customer_id
join transactions on accounts.account_id=transactions.account_id

--Write a SQL query to increase the balance of a specific account by a certain amount. 
update accounts 
set balance=balance+2000
where customer_id=5;

--Write a SQL query to Combine first and last names of customers as a full_name. 
select concat(first_name,' ',last_name)as Full_name from customers

--Write a SQL query to remove accounts with a balance of zero where the account 
type is savings. 
delete from Accounts where balance=0 AND account_type='savings'

--Write a SQL query to Find customers living in a specific city. 
select concat(first_name,' ',last_name)as Full_name,address from customers
where address like '%Texas%'

--Write a SQL query to Get the account balance for a specific account. 
select balance from accounts
where account_id=3

--Write a SQL query to List all current accounts with a balance greater than $1,000. 
select account_id,balance from accounts
where balance>1000 and account_type='current'

--Write a SQL query to Retrieve all transactions for a specific account. 
select transaction_id,transaction_type,amount,transaction_date,account_id from transactions
where account_id=2

--Write a SQL query to Calculate the interest accrued on savings accounts based on a given interest rate. 
select account_id,balance,(balance*2/100) as Interest from accounts
where account_type='savings'

--Write a SQL query to Identify accounts where the balance is less than a specified overdraft limit. 
select account_id,concat(first_name,' ',last_name)as Full_name,balance from accounts
join customers on customers.customer_id=accounts.customer_id
where balance<1000

--Write a SQL query to Find customers not living in a specific city. 
select concat(first_name,' ',last_name)as Full_name,address from customers
where address not like '%Texas%'
