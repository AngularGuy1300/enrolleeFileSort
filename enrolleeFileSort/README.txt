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



Additional Questions/Answers:

1) My proudest achievement:  The birth of my daughter (and only child).
2) Most interesting thing I've read recently (that I would recommend) was a comparison of Angular vs. React
- explaining the structural differences, pros and cons of the two
https://www.cleveroad.com/blog/angular-vs-react
(Important to understand the differences and advantages of each)

3) I would describe Availity (to my grandma) as a company that provides critial data to improve the flow of information between
providers, insurance companies other people/companies that relie on accurate and complete healthcare information (through online portals).


