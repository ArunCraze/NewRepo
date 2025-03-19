use hmbank

select avg(balance) as avg_balance from accounts

select top 10 balance from Accounts
order by balance desc

select sum(amount) as total_deposit from Transactions
where transaction_type='deposit' and convert(date,transaction_date)='2024-03-18'

select top 1 dob,concat(first_name,' ',last_name)as Full_name from customers
order by DOB asc 
select top 1 dob,concat(first_name,' ',last_name)as Full_name from customers
order by DOB desc 

select transaction_id,transaction_type,amount,transaction_date,account_type from Transactions
join accounts on accounts.account_id=transactions.account_id

select customers.customer_id,concat(customers.first_name,' ',customers.last_name)as Full_name,
accounts.account_id,accounts.account_type,accounts.balance from Customers
join accounts on customers.customer_id=Accounts.account_id

select transactions.transaction_id,Transactions.transaction_type,Transactions.amount,Transactions.transaction_date,
Customers.customer_id,concat(customers.first_name,' ',customers.last_name)as Full_name from Transactions
join accounts on Transactions.account_id=Accounts.account_id
join customers on Customers.customer_id=Accounts.customer_id

select customer_id,count(account_id) as total_accounts from accounts
group by customer_id
having count(account_id)>1

select DIFFERENCE(amount(deposit,withdrawl)) from transactions

select * from Transactions