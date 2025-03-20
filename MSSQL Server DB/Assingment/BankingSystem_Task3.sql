use hmbank

--Write a SQL query to Find the average account balance for all customers. 
select avg(balance) as avg_balance from accounts

--Write a SQL query to Retrieve the top 10 highest account balances.  
select top 10 balance from Accounts
order by balance desc

--Write a SQL query to Calculate Total Deposits for All Customers in specific date.
select sum(amount) as total_deposit from Transactions
where transaction_type='deposit' and convert(date,transaction_date)='2024-03-18'

--Write a SQL query to Find the Oldest and Newest Customers.
select top 1 dob,concat(first_name,' ',last_name)as Full_name from customers
order by DOB asc 
select top 1 dob,concat(first_name,' ',last_name)as Full_name from customers
order by DOB desc 

--Write a SQL query to Retrieve transaction details along with the account type.
select transaction_id,transaction_type,amount,transaction_date,account_type from Transactions
join accounts on accounts.account_id=transactions.account_id

--Write a SQL query to Get a list of customers along with their account details. 
select customers.customer_id,concat(customers.first_name,' ',customers.last_name)as Full_name,
accounts.account_id,accounts.account_type,accounts.balance from Customers
join accounts on customers.customer_id=Accounts.account_id

--Write a SQL query to Retrieve transaction details along with customer information for a specific account. 
select transactions.transaction_id,Transactions.transaction_type,Transactions.amount,Transactions.transaction_date,
Customers.customer_id,concat(customers.first_name,' ',customers.last_name)as Full_name from Transactions
join accounts on Transactions.account_id=Accounts.account_id
join customers on Customers.customer_id=Accounts.customer_id

--Write a SQL query to Identify customers who have more than one account. 
select customer_id,count(account_id) as total_accounts from accounts
group by customer_id
having count(account_id)>1

--Write a SQL query to Calculate the difference in transaction amounts between deposits and withdrawals.
select sum(case when transaction_type='deposit' then amount else 0 end) as total_deposit,
	   sum(case when transaction_type='withdrawl' then amount else 0 end) as total_withdrawl,
	   sum(case when transaction_type='deposit' then amount else 0 end)-(sum(case when transaction_type='withdrawl' then amount else 0 end)) as net_balance
	   from Transactions

--Write a SQL query to Calculate the average daily balance for each account over a specified period. 
select account_id,avg(balance) as average_daily_balance from Accounts
where account_id in(select distinct account_id from Transactions where transaction_date between '2024-03-18'and'2024-04-18')
group by account_id

--Calculate the total balance for each account type. 
select sum(case when account_type='savings' then balance else 0 end) as savings_account_total,
	   sum(case when account_type='current' then balance else 0 end) as current_account_total,
	   sum(case when account_type='zero_balance' then balance else 0 end) as zero_balance_account_total
	   from Accounts

--Identify accounts with the highest number of transactions order by descending order. 
select account_id,count(transaction_id) as total_transactions from Transactions
group by account_id
order by count(transaction_id) desc

--List customers with high aggregate account balances, along with their account types. 
select account_id,account_type,balance,c.customer_id,concat(c.first_name,' ',c.last_name)as Full_name from accounts
join customers c on accounts.customer_id=c.customer_id
where balance>10000


-- Identify and list duplicate transactions based on transaction amount, date, and account. 
select account_id,transaction_date,amount,count(*) as duplicate from Transactions
group by account_id,transaction_date,amount
having count(*)>1