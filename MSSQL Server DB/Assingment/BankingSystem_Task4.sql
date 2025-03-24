use HMbank

--Retrieve the customer(s) with the highest account balance. 
select concat(c.first_name,' ',c.last_name)as Full_name,c.customer_id,a.balance,a.account_id from customers c
join accounts a on a.customer_id=c.customer_id
where a.balance=(select max(balance) from accounts)

--Calculate the average account balance for customers who have more than one account. 
select avg(balance) from Accounts 
where customer_id in (select customer_id from Accounts
group by customer_id 
having count(customer_id)>1);

--etrieve accounts with transactions whose amounts exceed the average transaction amount.
select account_id,transaction_id,amount from Transactions
where amount>(select avg(amount) from Transactions)

--Identify customers who have no recorded transactions. 
select * from Customers
where customer_id not in(select distinct customer_id from accounts
join transactions on accounts.account_id=transactions.account_id)

--Calculate the total balance of accounts with no recorded transactions. 
select sum(balance) as total_balance from accounts 
where account_id not in(select distinct account_id from Transactions) 

--Retrieve transactions for accounts with the lowest balance. 
select * from transactions
join accounts on Transactions.account_id=Accounts.account_id
where accounts.balance=(select min(balance) from accounts)

--Identify customers who have accounts of multiple types. 
select * from customers
where customer_id in(select customer_id from accounts
group by customer_id
having count(customer_id)>1)

--Calculate the percentage of each account type out of the total number of accounts. 
select account_type,format(count(*) * 100.0 / (select count(*) from Accounts),'n2') as percentage from Accounts 
group by account_type;

--Retrieve all transactions for a customer with a given customer_id. 
select * from Transactions
where account_id in(select account_id from accounts where customer_id=1)

--Calculate the total balance for each account type, including a subquery within the SELECT clause. 
select account_type,(select sum(balance) from Accounts a where a.account_type = main.account_type) as total_balance
from Accounts main
group by account_type;

