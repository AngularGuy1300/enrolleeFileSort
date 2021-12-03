************SQL Excercises*************

a.	Write a SQL query that will produce a reverse-sorted list (alphabetically by name) of customers (first and last names) 
whose last name begins with the letter ‘S.’

select * from Customers
where LastName like 's%'
order by LastName desc, FirstName desc 


b.	Write a SQL query that will show the total value of all orders each customer has placed in the past six months. Any customer without any orders should show a $0 value.

select c.CustomerID, sum(ol.cost) as Total
from Customer c
join Orders o on c.CustomerID = o.CustomerID
join [Order Line] ol on o.OrderID = ol.OrderID
where (o.OrderDate >= DATEADD(M, -6, GETDATE())) 
group by c.CustomerID