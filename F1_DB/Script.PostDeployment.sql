if not exists (select 1 from Driver)

begin

	insert into Driver (FirstName,LastName,Number)
	values ( 'Fernando', 'Alonso' , 14),
	('Sebastian','Vettel',4),
	('Max','Verstappen',1);
end
