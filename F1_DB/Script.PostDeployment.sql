if not exists (select 1 from Driver)
begin
	insert into Driver (FirstName,LastName,Number,PhotoPath)
	values ( 'Fernando', 'Alonso' , 14,'127.0.0.1:6555/falonso.jpg'),
	('Sebastian','Vettel',4,'127.0.0.1:6555/svettel.jpg'),
	('Max','Verstappen',1,'127.0.0.1:6555/mverstappen.jpg');
end
