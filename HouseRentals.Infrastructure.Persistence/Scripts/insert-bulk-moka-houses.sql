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
	('Alameda'), ('Antônio'), ('Aurora'), ('Afonso'), ('Adelaide'),
	('Bento'), ('Bom'), ('Barão'), ('Benjamin'), ('Brasil'),
	('Carlos'), ('Campos'), ('Castro'), ('Coronel'), ('Cláudio'),
	('Dom'), ('Duque'), ('David'), ('Doutor'), ('Dias'),
	('Eduardo'), ('Estevão'), ('Elias'), ('Ernesto'), ('Estação'),
	('Frei'), ('Francisco'), ('Flávio'), ('Fernando'), ('Felício'),
	('Getúlio'), ('Gabriel'), ('Gonçalves'), ('General'), ('Guimarães'),
	('Henrique'), ('Hermínio'), ('Honório'), ('Hugo'), ('Helena'),
	('Irmãos'), ('Isabel'), ('Inácio'), ('Ivan'), ('Industrial'),
	('João'), ('José'), ('Joaquim'), ('Júlio'), ('Jaime'),
	('Luís'), ('Lúcio'), ('Lourenço'), ('Leopoldo'), ('Lagoa'),
	('Manuel'), ('Machado'), ('Marques'), ('Marcos'), ('Maria'),
	('Nilo'), ('Nicolau'), ('Nunes'), ('Natália'), ('Neves'),
	('Olavo'), ('Orlando'), ('Osvaldo'), ('Otávio'), ('Olímpio'),
	('Pedro'), ('Padre'), ('Paulo'), ('Pires'), ('Prudente'),
	('Quintino'), ('Queiroz'), ('Quitéria'), ('Quirino'), ('Querência'),
	('Rui'), ('Rodrigues'), ('Rosário'), ('Rafael'), ('Renato'),
	('Silva'), ('Santos'), ('Sebastião'), ('Sérgio'), ('Siqueira'),
	('Tiradentes'), ('Tobias'), ('Tavares'), ('Teixeira'), ('Tomás'),
	('Urbano'), ('União'), ('Ubirajara'), ('Umberto'), ('Uberaba'),
	('Vicente'), ('Virgílio'), ('Vital'), ('Viana'), ('Velho'),
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
	('Chácara'), ('Conjunto'), ('Estrada'), ('Favela'), ('Jardim'),
	('Ladeira'), ('Largo'), ('Parque'), ('Passagem'), ('Praça'),
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
		, 'Descrição ' + cast(@index as varchar)
end

select * from House
go