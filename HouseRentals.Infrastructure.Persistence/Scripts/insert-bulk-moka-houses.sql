use HouseRentals
go

delete from House
go

dbcc checkident ('House', RESEED, 0);
go

-- insert bulk Houses
declare @maxRecords int = 100
declare @index int = 0

declare @tableFirstNamesAddress table(id int identity(1, 1), [name] varchar(15))
insert into @tableFirstNamesAddress([name])
values
	('Alameda'), ('Ant�nio'), ('Aurora'), ('Afonso'), ('Adelaide'),
	('Bento'), ('Bom'), ('Bar�o'), ('Benjamin'), ('Brasil'),
	('Carlos'), ('Campos'), ('Castro'), ('Coronel'), ('Cl�udio'),
	('Dom'), ('Duque'), ('David'), ('Doutor'), ('Dias'),
	('Eduardo'), ('Estev�o'), ('Elias'), ('Ernesto'), ('Esta��o'),
	('Frei'), ('Francisco'), ('Fl�vio'), ('Fernando'), ('Fel�cio'),
	('Get�lio'), ('Gabriel'), ('Gon�alves'), ('General'), ('Guimar�es'),
	('Henrique'), ('Herm�nio'), ('Hon�rio'), ('Hugo'), ('Helena'),
	('Irm�os'), ('Isabel'), ('In�cio'), ('Ivan'), ('Industrial'),
	('Jo�o'), ('Jos�'), ('Joaquim'), ('J�lio'), ('Jaime'),
	('Lu�s'), ('L�cio'), ('Louren�o'), ('Leopoldo'), ('Lagoa'),
	('Manuel'), ('Machado'), ('Marques'), ('Marcos'), ('Maria'),
	('Nilo'), ('Nicolau'), ('Nunes'), ('Nat�lia'), ('Neves'),
	('Olavo'), ('Orlando'), ('Osvaldo'), ('Ot�vio'), ('Ol�mpio'),
	('Pedro'), ('Padre'), ('Paulo'), ('Pires'), ('Prudente'),
	('Quintino'), ('Queiroz'), ('Quit�ria'), ('Quirino'), ('Quer�ncia'),
	('Rui'), ('Rodrigues'), ('Ros�rio'), ('Rafael'), ('Renato'),
	('Silva'), ('Santos'), ('Sebasti�o'), ('S�rgio'), ('Siqueira'),
	('Tiradentes'), ('Tobias'), ('Tavares'), ('Teixeira'), ('Tom�s'),
	('Urbano'), ('Uni�o'), ('Ubirajara'), ('Umberto'), ('Uberaba'),
	('Vicente'), ('Virg�lio'), ('Vital'), ('Viana'), ('Velho'),
	('Washington'), ('Walter'), ('Wagner'), ('Wilton'), ('Wenceslau'),
	('Xavier'), ('Xavantes'), ('Xique-Xique'), ('Xingu'), ('Xisto'),
	('Ypiranga'), ('Yara'), ('Yasmin'), ('Yuri'), ('Youssef'),
	('Zacarias'), ('Zeca'), ('Zulmira'), ('Zilda'), ('Zoroastro')

declare @tableSecondNamesAddress table(id int identity(1, 1), [name] varchar(15))
insert into @tableSecondNamesAddress
select [name] from @tableFirstNamesAddress

declare @tableThirdNamesAddress table(id int identity(1, 1), [name] varchar(15))
insert into @tableThirdNamesAddress
select [name] from @tableFirstNamesAddress

declare @tableAddressType table(id int identity(1, 1), [name] varchar(15) )
insert into @tableAddressType([name])
values
	('Alameda'), ('Avenida'), ('Beco'), ('Boulevard'), ('Caminho'),
	('Ch�cara'), ('Conjunto'), ('Estrada'), ('Favela'), ('Jardim'),
	('Ladeira'), ('Largo'), ('Parque'), ('Passagem'), ('Pra�a'),
	('Quadra'), ('Rodovia'), ('Rua'), ('Setor'), ('Travessa'),
	('Vale'), ('Viela'), ('Via'), ('Vila')


while(@maxRecords > 0)
begin	
	set @maxRecords = @maxRecords - 1
	set @index = @index + 1

	declare @fullAddressName varchar(300) =
		(select [name] from @tableAddressType where id = floor( (rand() * (select count(*) from @tableAddressType)) + 1))
		+ ' ' + (select [name] from @tableFirstNamesAddress where id = floor( (rand() * (select count(*) from @tableFirstNamesAddress)) + 1))
		+ ' ' + (select [name] from @tableSecondNamesAddress where id = floor( (rand() * (select count(*) from @tableSecondNamesAddress)) + 1))
		+ ' ' + (select [name] from @tableThirdNamesAddress where id = floor( (rand() * (select count(*) from @tableThirdNamesAddress)) + 1))
		+ ', ' + cast( (floor(rand() * 10000)) as varchar)

	insert into House([Address], DailyPrice, [Status], NumberOfRooms, [Description])
	select
		@fullAddressName
		, ROUND((RAND() * (99.99 - 1.00) + 1.00), 2)
		, 'Available'
		, floor(rand() * 5) + 1
		, 'Descri��o ' + cast(@index as varchar)
end

select * from House
go