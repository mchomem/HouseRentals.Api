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
	('Ana'), ('Alberto'), ('Amanda'), ('Adriana'), ('Alex'), ('Arthur'), ('Ant�nio'), ('Alice'), ('Andr�'), ('Aline'),

	-- Names with B
	('Beatriz'), ('Bruno'), ('Benedito'), ('Bernardo'), ('Bianca'), ('Brenda'), ('B�rbara'), ('Bento'), ('Benjamin'), ('Betina'),

	-- Names with C
	('Carlos'), ('Camila'), ('Cl�udia'), ('Caio'), ('Cec�lia'), ('Cristina'), ('Cl�udio'), ('Catarina'), ('C�ssio'), ('Cristiano'),

	-- Names with D
	('Daniel'), ('D�bora'), ('Douglas'), ('Davi'), ('Diana'), ('Diogo'), ('Diego'), ('Denise'), ('Dalila'), ('Domingos'),

	-- Names with E
	('Eduardo'), ('Elaine'), ('Elias'), ('Estela'), ('Eliane'), ('Enzo'), ('Emanuel'), ('Elisa'), ('�rica'), ('Ester'),

	-- Names with F
	('Fernanda'), ('F�bio'), ('Felipe'), ('Francisco'), ('Fabiana'), ('Fl�via'), ('Fernando'), ('Francisca'), ('F�lix'), ('Fl�vio'),

	-- Names with G
	('Gabriel'), ('Gustavo'), ('Giovana'), ('Guilherme'), ('Gabriela'), ('Geovana'), ('Giovanni'), ('Gilberto'), ('Gra�a'), ('Gerson'),

	-- Names with H
	('Henrique'), ('Helo�sa'), ('Helena'), ('Humberto'), ('Heitor'), ('Hugo'), ('Hamilton'), ('Hermes'), ('Helder'), ('Haroldo'),

	-- Names with I
	('Isabela'), ('Isaque'), ('Ivan'), ('�caro'), ('Isabel'), ('Irina'), ('�talo'), ('Irineu'), ('Isadora'), ('In�cio'),

	-- Names with J
	('Jo�o'), ('Jos�'), ('Juliana'), ('Joaquim'), ('J�lia'), ('Jessica'), ('Jorge'), ('Josiane'), ('Jonas'), ('Jennifer'),

	-- Names with K
	('Karla'), ('Kauan'), ('K�tia'), ('Kleber'), ('Karin'), ('K�ssio'), ('Keila'), ('Kelly'), ('Kevin'), ('Kaio'),

	-- Names with L
	('Lucas'), ('Luana'), ('Larissa'), ('Leonardo'), ('Luan'), ('L�via'), ('Lorena'), ('Luiz'), ('Let�cia'), ('Lu�sa'),

	-- Names with M
	('Maria'), ('Miguel'), ('Matheus'), ('Marcos'), ('Melissa'), ('Marta'), ('Maur�cio'), ('Milena'), ('Manoel'), ('Murilo'),

	-- Names with N
	('Nicolas'), ('Nat�lia'), ('Nelson'), ('Nina'), ('Natanael'), ('Neide'), ('Nilton'), ('Naiara'), ('N�dia'), ('Newton'),

	-- Names with O
	('Ot�vio'), ('Ol�via'), ('Oscar'), ('Orlando'), ('Odete'), ('Osvaldo'), ('Osmar'), ('Ot�lia'), ('Olavo'), ('Onofre'),

	-- Names with P
	('Paulo'), ('Patr�cia'), ('Pedro'), ('Priscila'), ('Paloma'), ('Pablo'), ('Paula'), ('Pamela'), ('Poliana'), ('Pedroso'),

	-- Names with Q
	('Qu�nia'), ('Quintino'), ('Quirino'), ('Quirina'), ('Querubim'), ('Qu�sia'), ('Quim'), ('Queli'), ('Qu�ntila'), ('Quintiliano'),

	-- Names with R
	('Rafael'), ('Ricardo'), ('Renata'), ('Rog�rio'), ('Raquel'), ('Roberta'), ('Rodolfo'), ('Rita'), ('Regina'), ('Ronaldo'),

	-- Names with S
	('Samuel'), ('Sandra'), ('Silvana'), ('Simone'), ('S�rgio'), ('Sebasti�o'), ('Sofia'), ('Salvador'), ('Sueli'), ('Sabrina'),

	-- Names with T
	('Thiago'), ('Tatiane'), ('Tatiana'), ('Tereza'), ('Tales'), ('Tiago'), ('Telma'), ('Tom�s'), ('T�nia'), ('Teodoro'),

	-- Names with U
	('Ulisses'), ('Ubirajara'), ('Uriel'), ('Ursula'), ('Ubaldo'), ('Ubiraci'), ('�rsula'), ('Urano'), ('Ueliton'), ('Umberto'),

	-- Names with V
	('Vin�cius'), ('Val�ria'), ('Vanessa'), ('Victor'), ('Valmir'), ('Vera'), ('Vitor'), ('Viviane'), ('Vit�ria'), ('Valentim'),

	-- Names with W
	('Wellington'), ('Wesley'), ('Willian'), ('Walter'), ('Wagner'), ('Wanda'), ('Wanessa'), ('Wallace'), ('Wilma'), ('Wilson'),

	-- Names with X
	('Xavier'), ('Ximenes'), ('Xuxa'), ('X�nia'), ('Xenofonte'), ('Xisto'), ('Xandro'), ('Xelina'), ('Xerxes'), ('X�nior'),

	-- Names with Y
	('Yara'), ('Yuri'), ('Yasmin'), ('Yan'), ('Yohana'), ('Yohan'), ('Yolanda'), ('Yvone'), ('Ygor'), ('Yurianna'),

	-- Names with Z
	('Z�'), ('Z�lia'), ('Zenaide'), ('Zara'), ('Zoraide'), ('Zelma'), ('Zilda'), ('Zacarias'), ('Zora'), ('Z�lio')

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
