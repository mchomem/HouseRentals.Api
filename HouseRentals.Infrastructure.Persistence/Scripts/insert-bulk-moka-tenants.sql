use HouseRentals
go

delete from Tenant
go

dbcc checkident ('Tenant', RESEED, 0);
go

declare @tempFirstPersonNames table(id int identity(1 ,1), [name] varchar(15))
insert into @tempFirstPersonNames
values
	-- Names with A
	('Ana'), ('Alberto'), ('Amanda'), ('Adriana'), ('Alex'), ('Arthur'), ('Antônio'), ('Alice'), ('André'), ('Aline'),

	-- Names with B
	('Beatriz'), ('Bruno'), ('Benedito'), ('Bernardo'), ('Bianca'), ('Brenda'), ('Bárbara'), ('Bento'), ('Benjamin'), ('Betina'),

	-- Names with C
	('Carlos'), ('Camila'), ('Cláudia'), ('Caio'), ('Cecília'), ('Cristina'), ('Cláudio'), ('Catarina'), ('Cássio'), ('Cristiano'),

	-- Names with D
	('Daniel'), ('Débora'), ('Douglas'), ('Davi'), ('Diana'), ('Diogo'), ('Diego'), ('Denise'), ('Dalila'), ('Domingos'),

	-- Names with E
	('Eduardo'), ('Elaine'), ('Elias'), ('Estela'), ('Eliane'), ('Enzo'), ('Emanuel'), ('Elisa'), ('Érica'), ('Ester'),

	-- Names with F
	('Fernanda'), ('Fábio'), ('Felipe'), ('Francisco'), ('Fabiana'), ('Flávia'), ('Fernando'), ('Francisca'), ('Félix'), ('Flávio'),

	-- Names with G
	('Gabriel'), ('Gustavo'), ('Giovana'), ('Guilherme'), ('Gabriela'), ('Geovana'), ('Giovanni'), ('Gilberto'), ('Graça'), ('Gerson'),

	-- Names with H
	('Henrique'), ('Heloísa'), ('Helena'), ('Humberto'), ('Heitor'), ('Hugo'), ('Hamilton'), ('Hermes'), ('Helder'), ('Haroldo'),

	-- Names with I
	('Isabela'), ('Isaque'), ('Ivan'), ('Ícaro'), ('Isabel'), ('Irina'), ('Ítalo'), ('Irineu'), ('Isadora'), ('Inácio'),

	-- Names with J
	('João'), ('José'), ('Juliana'), ('Joaquim'), ('Júlia'), ('Jessica'), ('Jorge'), ('Josiane'), ('Jonas'), ('Jennifer'),

	-- Names with K
	('Karla'), ('Kauan'), ('Kátia'), ('Kleber'), ('Karin'), ('Kássio'), ('Keila'), ('Kelly'), ('Kevin'), ('Kaio'),

	-- Names with L
	('Lucas'), ('Luana'), ('Larissa'), ('Leonardo'), ('Luan'), ('Lívia'), ('Lorena'), ('Luiz'), ('Letícia'), ('Luísa'),

	-- Names with M
	('Maria'), ('Miguel'), ('Matheus'), ('Marcos'), ('Melissa'), ('Marta'), ('Maurício'), ('Milena'), ('Manoel'), ('Murilo'),

	-- Names with N
	('Nicolas'), ('Natália'), ('Nelson'), ('Nina'), ('Natanael'), ('Neide'), ('Nilton'), ('Naiara'), ('Nádia'), ('Newton'),

	-- Names with O
	('Otávio'), ('Olívia'), ('Oscar'), ('Orlando'), ('Odete'), ('Osvaldo'), ('Osmar'), ('Otília'), ('Olavo'), ('Onofre'),

	-- Names with P
	('Paulo'), ('Patrícia'), ('Pedro'), ('Priscila'), ('Paloma'), ('Pablo'), ('Paula'), ('Pamela'), ('Poliana'), ('Pedroso'),

	-- Names with Q
	('Quênia'), ('Quintino'), ('Quirino'), ('Quirina'), ('Querubim'), ('Quésia'), ('Quim'), ('Queli'), ('Quíntila'), ('Quintiliano'),

	-- Names with R
	('Rafael'), ('Ricardo'), ('Renata'), ('Rogério'), ('Raquel'), ('Roberta'), ('Rodolfo'), ('Rita'), ('Regina'), ('Ronaldo'),

	-- Names with S
	('Samuel'), ('Sandra'), ('Silvana'), ('Simone'), ('Sérgio'), ('Sebastião'), ('Sofia'), ('Salvador'), ('Sueli'), ('Sabrina'),

	-- Names with T
	('Thiago'), ('Tatiane'), ('Tatiana'), ('Tereza'), ('Tales'), ('Tiago'), ('Telma'), ('Tomás'), ('Tânia'), ('Teodoro'),

	-- Names with U
	('Ulisses'), ('Ubirajara'), ('Uriel'), ('Ursula'), ('Ubaldo'), ('Ubiraci'), ('Úrsula'), ('Urano'), ('Ueliton'), ('Umberto'),

	-- Names with V
	('Vinícius'), ('Valéria'), ('Vanessa'), ('Victor'), ('Valmir'), ('Vera'), ('Vitor'), ('Viviane'), ('Vitória'), ('Valentim'),

	-- Names with W
	('Wellington'), ('Wesley'), ('Willian'), ('Walter'), ('Wagner'), ('Wanda'), ('Wanessa'), ('Wallace'), ('Wilma'), ('Wilson'),

	-- Names with X
	('Xavier'), ('Ximenes'), ('Xuxa'), ('Xênia'), ('Xenofonte'), ('Xisto'), ('Xandro'), ('Xelina'), ('Xerxes'), ('Xênior'),

	-- Names with Y
	('Yara'), ('Yuri'), ('Yasmin'), ('Yan'), ('Yohana'), ('Yohan'), ('Yolanda'), ('Yvone'), ('Ygor'), ('Yurianna'),

	-- Names with Z
	('Zé'), ('Zélia'), ('Zenaide'), ('Zara'), ('Zoraide'), ('Zelma'), ('Zilda'), ('Zacarias'), ('Zora'), ('Zélio')

declare @tempSecondPersonNames table(id int identity(1 ,1), [name] varchar(15))
insert into @tempSecondPersonNames([name])
select [name] from @tempFirstPersonNames

declare @tempThirdPersonNames table(id int identity(1 ,1), [name] varchar(15))
insert into @tempThirdPersonNames([name])
select [name] from @tempFirstPersonNames

declare @maxRecords int = 100
declare @index int = 0

while(@maxRecords > 0)
begin
	set @maxRecords = @maxRecords - 1
	set @index = @index + 1

	declare @firstName varchar(15) = (select [name] from @tempFirstPersonNames where id = floor( (rand() * (select count(*) from @tempFirstPersonNames)) + 1))
	declare @lastName varchar(15) = (select [name] from @tempThirdPersonNames where id = floor( (rand() * (select count(*) from @tempThirdPersonNames)) + 1))

	declare @fullTenantName varchar(100) =
		@firstName
		+ ' ' + (select [name] from @tempSecondPersonNames where id = floor( (rand() * (select count(*) from @tempSecondPersonNames)) + 1))
		+ ' ' + @lastName

	declare @tenantMail varchar(100) = lower(@firstName + '.' + @lastName) + '@email.com'

	declare @year int = floor(rand() * 20) + 2000
	declare @month int = floor(rand() * 12) + 1
	declare @day int = floor(rand() * 28) + 1

	declare @birthDate datetime =
		cast(@year as varchar)
		+ '-' + cast(@month as varchar)
		+ '-' + cast(@day as varchar)


	declare @numbers int = 9
	declare @areaCode varchar(2) = ''
	declare @num varchar(9) = ''

	while(@numbers > 0)
	begin
		set @numbers = @numbers - 1
		set @num = @num + CAST(floor(RAND() * 9) as varchar)

		if(@numbers > 2)
			continue

		set @areaCode = @areaCode + CAST(floor(RAND() * 9) as varchar)
	end

	declare @phoneNumber varchar(11) = @areaCode + '' + @num

	insert into Tenant
	select
		@fullTenantName
		, @tenantMail
		, @phoneNumber
		, @birthDate
		, 0
end

select * from Tenant
