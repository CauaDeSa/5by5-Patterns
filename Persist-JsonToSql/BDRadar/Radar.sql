CREATE TABLE Radar (
    id int identity(1,1),
    concessionaria varchar(50) NOT NULL,
    ano_do_pnv_snv int NOT NULL,
    tipo_de_radar varchar(30) NOT NULL,
    rodovia varchar(6) NOT NULL,
    uf varchar(2) NOT NULL,
    km_m float NOT NULL,
    municipio varchar(20) NOT NULL,
    tipo_de_pista varchar(20) NOT NULL,
    sentido varchar(20) NOT NULL,
    situacao varchar(10) NOT NULL,
    data_da_inativacao date,
    latitude float(8) NOT NULL,
    longitude float(8) NOT NULL,
    velocidade_leve int NOT NULL,
    CONSTRAINT PK_Radar PRIMARY KEY (id)
);

GO

CREATE PROC spInitializeRadar
AS
BEGIN
    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Radar' AND xtype='U')
        CREATE TABLE Radar (
        id int identity(1,1),
        concessionaria varchar(50) NOT NULL,
        ano_do_pnv_snv int NOT NULL,
        tipo_de_radar varchar(30) NOT NULL,
        rodovia varchar(6) NOT NULL,
        uf varchar(2) NOT NULL,
        km_m float NOT NULL,
        municipio varchar(20) NOT NULL,
        tipo_de_pista varchar(20) NOT NULL,
        sentido varchar(20) NOT NULL,
        situacao varchar(10) NOT NULL,
        data_da_inativacao date,
        latitude float(8) NOT NULL,
        longitude float(8) NOT NULL,
        velocidade_leve int NOT NULL,
        CONSTRAINT PK_Radar PRIMARY KEY (id)
        );
END

GO

CREATE PROC spInsertRadar
    @concessionaria varchar(50),
    @ano_do_pnv_snv int,
    @tipo_de_radar varchar(30),
    @rodovia varchar(6),
    @uf varchar(2),
    @km_m float,
    @municipio varchar(20),
    @tipo_de_pista varchar(20),
    @sentido varchar(20),
    @situacao varchar(10),
    @data_da_inativacao date,
    @latitude float,
    @longitude float,
    @velocidade_leve int
AS
BEGIN
    INSERT INTO Radar (concessionaria, ano_do_pnv_snv, tipo_de_radar, rodovia, uf, km_m, municipio, tipo_de_pista, sentido, situacao, data_da_inativacao, latitude, longitude, velocidade_leve)
    VALUES (@concessionaria, @ano_do_pnv_snv, @tipo_de_radar, @rodovia, @uf, @km_m, @municipio, @tipo_de_pista, @sentido, @situacao, @data_da_inativacao, @latitude, @longitude, @velocidade_leve)
END;