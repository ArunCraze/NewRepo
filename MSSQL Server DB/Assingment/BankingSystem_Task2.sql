use hmbank

select concat(first_name,' ',last_name)as Name,account_type,email from customers
join accounts on customers.customer_id=Accounts.customer_id

select concat(first_name,' ',last_name)as Name,customers.customer_id,transaction_id,transaction_type,amount,transaction_date from customers
join accounts on customers.customer_id=accounts.customer_id
join transactions on accounts.account_id=transactions.account_id

update accounts 
set balance=balance+2000
where customer_id=5;

select concat(first_name,' ',last_name)as Full_name from customers

delete from Accounts where balance=0 AND account_type='savings'

select concat(first_name,' ',last_name)as Full_name,address from customers
where address like '%Texas%'

select balance from accounts
where account_id=3

select account_id,balance from accounts
where balance>1000 and account_type='current'

select transaction_id,transaction_type,amount,transaction_date,account_id from transactions
where account_id=2

select account_id,balance,(balance*2/100) as Interest from accounts
where account_type='savings'

select account_id,concat(first_name,' ',last_name)as Full_name,balance from accounts
join customers on customers.customer_id=accounts.customer_id
where balance<1000

select concat(first_name,' ',last_name)as Full_name,address from customers
where address not like '%Texas%'
